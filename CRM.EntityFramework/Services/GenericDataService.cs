﻿using CRM.Domain.Models;
using CRM.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly CRM_DbContextFactory _contextFactory;

        public GenericDataService(CRM_DbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Ceate(T entity)
        {
           using(CRM_DbContext context = _contextFactory.CreateDbContext())
            {
               var createEntity =  await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createEntity.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (CRM_DbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<T> Get(int id)
        {
            using (CRM_DbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id); 
                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {

            using (CRM_DbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToArrayAsync();
                return entities;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (CRM_DbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }
    }
}
