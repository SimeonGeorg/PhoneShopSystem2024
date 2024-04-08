using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PhoneCatalog.Infrastructure.Data.Models;

namespace PhoneCatalog.Infrastructure.Data.SeedDb
{
    internal  class SeedData
    {
        public IdentityUser OwnerUser { get; set; }
        public IdentityUser GuestUser { get; set; }
        public Owner IphoneOwner { get; set; }
        public Owner SamsungOwner { get; set; }
        public Owner NokiaOwner { get; set; }
        public CategoryType SmartPhoneCategory { get; set; }
        public CategoryType MobilePhoneCategory { get; set; }
        public Comment PositiveComment { get; set; }
        public Performance IphonePerformance { get; set; }
        public Performance SamsungPerformance { get; set; }
        public Performance NokiaPerformance { get; set; }
        public Phone Iphone { get; set; }
        public Phone Samsung { get; set; }
        public Phone Nokia { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedOwner();
            SeedCategories();
            SeedComment();
            SeedPerformances();
            SeedPhones();
           
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            OwnerUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "owner@mail.com",
                NormalizedUserName = "owner@mail.com",
                Email = "owner@mail.com",
                NormalizedEmail = "owner@mail.com"
            };

            OwnerUser.PasswordHash =
                 hasher.HashPassword(OwnerUser, "owner123");

            GuestUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            GuestUser.PasswordHash =
            hasher.HashPassword(GuestUser, "guest123");
        }

        private void SeedOwner()
        {
            IphoneOwner = new Owner()
            {
                Id = 1,
                Name = "Simeon",
                PhoneNumber = "0882515555",
                Email = "Simeon@mail.com",
                UserId = OwnerUser.Id
            };

            SamsungOwner = new Owner()
            {
                Id = 2,
                Name = "Petar",
                PhoneNumber = "0882616666",
                Email = "Petar@mail.com",
                UserId = OwnerUser.Id
            };
            NokiaOwner = new Owner()
            {
                Id = 3,
                Name = "Svetlio",
                PhoneNumber = "0888777444",
                Email = "Svetlio@mail.com",
                UserId = OwnerUser.Id
            };
            
        }

        private void SeedCategories()
        {
            SmartPhoneCategory = new CategoryType()
            {
                Id = 1,
                Name = "SmartPhone"
            };
            MobilePhoneCategory = new CategoryType()
            {
                Id = 2,
                Name = "MobilePhone"
            };
        }
        private void SeedComment()
        {
            PositiveComment = new Comment()
            {
                Id = 1,
                CommentText = "This phone is very good for me. Its very fast and have a good camera for photo!",
                PhoneId = Iphone.Id,
                OwnerId = NokiaOwner.Id
            };

        }
        private void SeedPerformances()
        {
            IphonePerformance = new Performance()
            {
                Id = 1,
                Ram = "6 GB ",
                Processor = "6‑Core CPU with 2 performance and 4 efficiency Core",
                Storage = "256 GB",
                CameraPxl = "12MP Ultra Wide",
                Battery = "Lithium ion batteries 4000mAh",
                PhoneId = Iphone.Id
            };

            SamsungPerformance = new Performance()
            {
                Id = 2,
                Ram = "8 GB ",
                Processor = "8 Core 3.39GHz",
                Storage = "512 GB",
                CameraPxl = "200.0 MP + 50.0 MP + 12.0 MP + 10.0 MP",
                Battery = "Lithium ion batteries 5000mAh",
                PhoneId = Samsung.Id
            };

            SamsungPerformance = new Performance()
            {
                Id = 3,
                Ram = "512MB ",
                Processor = "1 Core",
                Storage = "16 GB",
                CameraPxl = "No Camera",
                Battery = " 1450 mAh",
                PhoneId = Nokia.Id
            };
        }

        private void SeedPhones()
        {
            Iphone = new Phone()
            {
                Id = 1,
                Brand = "Iphone",
                Model = "14",
                Price = 1500,
                ImageUrl = "https://buybest.bg/storage/public/uploads/media-manager/app-modules-shop-models-optiongroups/2252/4108/iphone-14-red-prod.png",
                OwnerId = IphoneOwner.Id,
                CategoryId = SmartPhoneCategory.Id
            };

            Samsung = new Phone()
            {
                Id = 2,
                Brand = "Samsung",
                Model = "Galaxy S24 Ultra",
                Price = 2000,
                ImageUrl = "https://s13emagst.akamaized.net/products/64817/64816457/images/res_e68a0194a894e1d6b8e13ee37aad5d58.jpg",
                OwnerId = SamsungOwner.Id,
                CategoryId = SmartPhoneCategory.Id
            };

            Nokia = new Phone()
            {
                Id = 3,
                Brand = "Nokia",
                Model = "150 2023",
                Price = 100,
                ImageUrl = "https://www.infinitygsm.ro/wp-content/uploads/2023/08/Nokia-150-2023-Black.jpg",
                OwnerId = NokiaOwner.Id,
                CategoryId = MobilePhoneCategory.Id
            };
        }

    }
}


