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
    /// Business rule class for phone number
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{SwiftTest.Model.ClientPhone}" />
    public class ClientPhoneConfiguration : EntityTypeConfiguration<ClientPhone>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientPhoneConfiguration"/> class.
        /// </summary>
        public ClientPhoneConfiguration()
        {
            //Set rules for Number property
        }
    }
}
