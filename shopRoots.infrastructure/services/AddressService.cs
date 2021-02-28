using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shopRootsAdmin.core.interfaces;
using shopRootsAdmin.core.models;

namespace shopRoots.infrastructure.services
{
    public class AddressService : IAddressService
    {
        private readonly IRepository<AddressModel> _addressService;
        public AddressService(IRepository<AddressModel> addressService) {
            _addressService = addressService;
        }
        public async Task<AddressModel> createAddress(AddressModel addressModel)
        {
            return await _addressService.Create(addressModel); 
        }

        public async Task<bool> deleteAddress(int addressId)
        {
            return await _addressService.Delete(addressId);
        }

        public  AddressModel getAddress(int addressId)
        {
            return  _addressService.GetOne(x => x.Id == addressId);
        }

        public  IList<AddressModel> getAllAddress(List<int> addressIds)
        {
            return (List<AddressModel>) _addressService.GetAll(x => addressIds.Contains((int)x.Id));
        }

        public async Task<AddressModel> updateAddress(AddressModel userModel)
        {
            return await _addressService.Update(userModel);
        }
    }
}
