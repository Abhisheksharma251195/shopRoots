using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using shopRootsAdmin.core.dtos;
using shopRootsAdmin.core.models;
namespace shopRoots.infrastructure.mappings.autoMapper
{
   public class autoMapper :  Profile
    {
        public autoMapper() {
            CreateMap<modelBase, dtoBase>().ReverseMap();
            CreateMap<userModel, userDto>().ReverseMap();
            CreateMap<AddressModel, AddressDto>().ReverseMap();
            CreateMap<userModel, userCreateModel>().ReverseMap();

        }
    }
}
