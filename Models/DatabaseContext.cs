using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WepApiProject.Models
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext():base("Defaultconnection")
        {


        }

        public DbSet<User> users { get; set; }

    }
}