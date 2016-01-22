using SwiftDemo.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftDemo.Core.Configurations
{
    /// <summary>
    /// Business rule class for phone number
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{SwiftDemo.Model.PhoneNumber}" />
    public class PhoneNumberConfiguration : EntityTypeConfiguration<PhoneNumber>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberConfiguration"/> class.
        /// </summary>
        public PhoneNumberConfiguration()
        {
            //Set rules for Number property
            Property(x => x.Number).IsRequired().HasMaxLength(15);

            HasRequired(t => t.ClientRecordBelongTo).WithMany(t=>t.PhoneNumbers).HasForeignKey(t => t.ClientRecordId);
        }
    }
}
