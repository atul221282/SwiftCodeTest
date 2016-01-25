﻿using SwiftTest.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftTest.Core.Configurations
{
    /// <summary>
    /// Business rules for Client record class
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{SwiftTest.Model.ClientRecord}" />
    public class ClientRecordConfiguration : EntityTypeConfiguration<ClientRecord>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientRecordConfiguration"/> class.
        /// </summary>
        public ClientRecordConfiguration()
        {
            //Property(x => x.Name).IsRequired().HasMaxLength(150);
            //Property(x => x.Name).IsRequired().HasMaxLength(1000);
        }
        
    }
}
