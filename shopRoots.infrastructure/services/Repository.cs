using shopRootsAdmin.core.interfaces;
using shopRootsAdmin.core.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                _context.Add(Model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Model;
        }

        public async Task<bool> Delete(int id)
        {
            var result  =  false;
            try
            {
                var Model = _entities.FirstOrDefault(x => x.Id == id);
                Model.Deleted = id;
                _entities.Update(Model);
                _context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }

        public async Task<IList<T>> GetAll(Func<T, bool> condition = null, bool includeDeleted = false)
        {
            var result = new List<T>();
            try
            {

                if (condition != null)
                {
                    result = _entities.Where(x=>x.Deleted==0).ToList();
                }
                else {
                    result = _entities.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public async Task<T> GetOne(Func<T, bool> condition)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Update(T Model)
        {
            try
            {
                _entities.Update(Model);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Model;
        }
    }
}
