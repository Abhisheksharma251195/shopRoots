﻿using shopRootsAdmin.core.dtos;
using shopRootsAdmin.core.models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace shopRootsAdmin.core.interfaces
{
    public interface IRepository <T> where T : modelBase
    {
        public IList<T> GetAll(Func<T, bool> action = null, bool includeDeleted = false);
        public T GetOne(Func<T, bool> action, bool includeDeleted = false);
        public Task<T> Update(T Model);
        public Task<T> Create(T Model);
        public Task<bool> Delete(int id, bool hardDelete = false);
        //public Task<object> SqlQuery(string Query);
    }
}
