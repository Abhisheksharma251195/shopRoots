using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace shopRootsAdmin.core.enums
{
    public enum userRoles
    {
        [EnumStringAttribute("Super Admin")]
        superAdmin = 1,
        [EnumStringAttribute("Admin")]
        Admin = 2,
        [EnumStringAttribute("DeliveryBoy")]
        Delivery = 3
    }
}
