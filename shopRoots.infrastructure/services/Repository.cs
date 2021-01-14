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
        private readonly IDbContextTransaction _transaction;
        string errorMessage = string.Empty;
        public Repository(DbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
            //_transaction = _context.Database.BeginTransaction();
        }
        public async Task<T> Create(T Model)
        {
            try
            {
                //_transaction.CreateSavepoint();
                _context.Add(Model);
                _context.SaveChanges();
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
                _context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }

        public async Task<IList<T>> GetAll (Expression<Func<T, bool>> action = null, bool includeDeleted = false)
        {
            var result = new List<T>();
            try
            {

                if (action != null)
                {
                    result = _entities.Where(action).ToList();
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

        public async Task<T> GetOne(Func<T, bool> action, bool includeDeleted = false) {
            var result =  _entities.Where(action).FirstOrDefault();
            return  result; 
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
