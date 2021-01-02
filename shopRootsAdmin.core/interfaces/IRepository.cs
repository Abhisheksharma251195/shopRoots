using shopRootsAdmin.core.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace shopRootsAdmin.core.interfaces
{
    public interface IRepository <T> where T : modelBase
    {
        public Task<IList<T>> GetAll(Func<T, bool> condition = null , bool includeDeleted =  false);
        public Task<T> GetOne(Func<T, bool> condition);
        public Task<T> Update(T Model);
        public Task<T> Create(T Model);
        public Task<bool> Delete(int id);
    }
}
