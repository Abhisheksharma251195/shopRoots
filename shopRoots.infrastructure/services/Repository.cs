using shopRootsAdmin.core.interfaces;
using shopRootsAdmin.core.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace shopRoots.infrastructure.services
{
    public class Repository<T> : IRepository<T> where T : modelBase
    {

        private readonly DbContext _context;
        private DbSet<T> _entities;
        string errorMessage = string.Empty;
        public Repository(DbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public async Task<T> Create(T Model)
        {
            try
            {
                var currentDateTime = DateTime.Now;
                Model.UpdatedOn = currentDateTime;
                Model.CreatedOn = currentDateTime;
                await _context.AddAsync(Model);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Model;
        }

        public async Task<bool> Delete(int id , bool hardDelete =  false)
        {
            var result  =  false;
            try
            {
                var Model = _entities.FirstOrDefault(x => x.Id == id);
              
                if (hardDelete) {
                    _entities.Remove(Model);
                }
                else
                {
                    Model.Deleted = id;
                    _entities.Update(Model);
                }
               await _context.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }

        public IList<T> GetAll(Func<T, bool> action = null, bool includeDeleted = false)
        {
            var result = new List<T>();
            try
            {

                if (action != null)
                {
                    result = _entities.Where(action).Where(x => (x.Deleted == (includeDeleted == true ? x.Id : 0)) || x.Deleted == 0).ToList();
                }
                else
                {
                    result = _entities.Where(x => (x.Deleted == (includeDeleted == true ? x.Id : 0)) || x.Deleted == 0).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public T GetOne(Func<T, bool> action, bool includeDeleted = false)
        {
            var result = _entities.Where(action).Where(x => (x.Deleted == (includeDeleted == true ? x.Id : 0)) || x.Deleted == 0).FirstOrDefault();
            return result;
        }
         
        public async Task<T> Update(T Model)
        {
            try
            {
                 Model.UpdatedOn = DateTime.Now;
                _entities.Update(Model);
                await  _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Model;
        }
    }
}
