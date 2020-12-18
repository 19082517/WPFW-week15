using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WPFW_week15.Models;

namespace WPFW_week15.Data
{
    public class WPFW_week15Context : DbContext
    {
        public WPFW_week15Context (DbContextOptions<WPFW_week15Context> options)
            : base(options)
        {
        }

        public DbSet<WPFW_week15.Models.Student> Student { get; set; }
    }
}
