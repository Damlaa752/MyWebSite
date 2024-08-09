﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class WriteRepository<T>(DataDbContext context) : IWriteRepository<T> where T : BaseEntity
    {
        public DbSet<T> Table => context.Set<T>();
        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.ID == int.Parse(id));
            return Remove(model);
        }

        public bool Update(T model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync() => await context.SaveChangesAsync();
    }
}
