using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCatalog.Core.Contracts
{
    public interface IPhoneModel
    {
        public string Brand { get; set; } 
        
        public string Model { get; set; } 
        
    }
}
