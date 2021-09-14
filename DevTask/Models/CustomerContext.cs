﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DevTask.Models;

namespace DevTask.Models
{
    public class CustomerContext : DbContext
    {
         public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {

        }
        public DbSet<Customers> Customers { get; set; }
      
    }
}