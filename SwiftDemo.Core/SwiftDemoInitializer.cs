using SwiftDemo.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftDemo.Core
{
    /// <summary>
    /// Initialise databse on initialisation
    /// </summary>
    public class SwiftDemoInitializer : DropCreateDatabaseAlways<SwiftDemoContext>
    {
        protected override void Seed(SwiftDemoContext context)
        {
            InitialiseClientRecord(context);
        }

        /// <summary>
        /// Initialises the client records.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void InitialiseClientRecord(SwiftDemoContext context)
        {
            new List<ClientRecord> {
                new ClientRecord {Name="Atul",Address="18 Brunel Drive, Modbury Heihts, Adelaide",
                    PhoneNumbers= new List<PhoneNumber> { new PhoneNumber {Number="0430499210" }, new PhoneNumber { Number = "0430111890" } } ,
                }, new ClientRecord {
                    Name="John",Address="282 Kingfisher street, Somehwre, Melbourne",
                    PhoneNumbers= new List<PhoneNumber> { new PhoneNumber {Number="0410429267"}, new PhoneNumber { Number = "0440111692" } } ,
                }
            }.ForEach(b => context.ClientRecords.Add(b));

            base.Seed(context);
        }
    }
}
