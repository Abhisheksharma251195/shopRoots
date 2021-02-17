using shopRootsAdmin.core.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace shopRootsAdmin.core.interfaces
{
    public interface IAddressService
    {
        public Task<AddressModel> createAddress(AddressModel addressModel);
        public Task<AddressModel> updateAddress(AddressModel addressModel);
        public Task<bool> deleteAddress(int addressId);
        public Task<AddressModel> getAddress(int addressId);
        public Task<List<AddressModel>> getAllAddress(List<int> addressIds);
    }
}
