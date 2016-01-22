﻿using SwiftDemo.Core.Configurations;
using SwiftDemo.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftDemo.Core
{
    /// <summary>
    /// Represents SwiftDemoContext class
    /// </summary>
    public class SwiftDemoContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwiftDemoContext"/> class.
        /// </summary>
        public SwiftDemoContext()
            : base(nameOrConnectionString: "SwiftDemo")
        {
        }

        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            //Stop pluralizing of table name in database
            //set rules on client and phone number table
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new ClientRecordConfiguration());
            modelBuilder.Configurations.Add(new PhoneNumberConfiguration());
#if DEBUG

#endif
        }

        /// <summary>
        /// Gets or sets the client records.
        /// </summary>
        /// <value>
        /// The client records.
        /// </value>
        public DbSet<ClientRecord> ClientRecords { get; set; }
        /// <summary>
        /// Gets or sets the phone numbers.
        /// </summary>
        /// <value>
        /// The phone numbers.
        /// </value>
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    }
}
