﻿using Microsoft.EntityFrameworkCore;
using PhoneCatalog.Core.Contracts;
using PhoneCatalog.Infrastructure.Data.Common;
using PhoneCatalog.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCatalog.Core.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IRepository repository;

        public OwnerService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<bool> IsExistByIdAsync(string userId)
        {
            return await repository.All<Owner>()
                .AnyAsync(a => a.UserId == userId);
        }
        public async Task<int?> GetOwnerIdAsync(string userId)
        {
            return (await repository.AllNoTracking<Owner>()
                .FirstOrDefaultAsync(o => o.UserId == userId))?.Id;
        }
    }
}
