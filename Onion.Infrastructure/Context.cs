using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using OnionDemo.Core.Model;

namespace Onion.Infrastructure
{
    public class Context : DbContext
    {
        public Context() : base()
        {
            //Quick and dirty test database...

            System.Data.Entity.Database.DefaultConnectionFactory = new SqlCeConnectionFactory(
                "System.Data.SqlServerCe.4.0",
                @"c:\temp\",
                @"Data Source=C:\temp\Oniondemo.sdf");
            //System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<DynamicGridExampleContext>());
            System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseAlways<Context>());
        }

        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<DynamicGridExample.Models.DynamicGridExampleContext>());

        public DbSet<Album> Albums { get; set; }
    }
}
