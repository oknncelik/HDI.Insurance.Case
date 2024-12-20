﻿using HDI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Data.Contexts
{
    public sealed class HDIContext : DbContext
    {
        public HDIContext()
        {
            //İki uygulama connect olduğundan connection stringi burda tanımladım normalde webconfig yada appconfig dosyasından gelmeli !...
            Database.Connection.ConnectionString = @"Server=localhost,1433; database=HDICASESAMPLE; User ID=sa; password=19Mayis1919!;";
        }

        public DbSet<Partner> Partner { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<Work> Work { get; set; }
    }
}
