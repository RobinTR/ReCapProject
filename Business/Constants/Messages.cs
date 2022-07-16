using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car added.";
        public static string CarUpdated = "Car updated.";
        public static string CarDeleted = "Car deleted.";
        public static string CarAddedInvalid = "Car name or daily price is invalid.";
        public static string CarsListed = "Cars listed.";

        public static string BrandAdded = "Brand added.";
        public static string BrandUpdated = "Car updated.";
        public static string BrandDeleted = "Car deleted.";
        public static string BrandsListed = "Brands listed.";

        public static string ColorAdded = "Color added.";
        public static string ColorUpdated = "Color updated.";
        public static string ColorDeleted = "Color deleted.";
        public static string ColorsListed = "Brands listed.";

        public static string MaintenanceTime = "System is under maintenance.";
    }
}
