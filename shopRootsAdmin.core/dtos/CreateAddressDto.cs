﻿using System;
using System.Collections.Generic;
using System.Text;

namespace shopRootsAdmin.core.dtos
{
    public class CreateAddressDto
    {
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string addressType { get; set; }
        public int PinCode { get; set; }
    }
}
