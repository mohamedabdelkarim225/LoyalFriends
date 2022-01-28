using System;
using System.ComponentModel;
using System.Reflection;

namespace Inno.Utility
{
    public enum LookupCategories
    {
        Governorate=1,
        Offer,
        ServiceProvider,
        ServiceQuota,
        CustomerStatus,
        RouterType,
        RouterDeliveryMethod,
        CustomerType,
        UserRole,
        AccountType
    }
    public enum Roles
    {
        Employee=25,
        Supervisor,
        Admin
    }

    public enum CustomerTypes
    {
        Adsl=22,
        Fixedline,
        AdslFixedline
    }
}