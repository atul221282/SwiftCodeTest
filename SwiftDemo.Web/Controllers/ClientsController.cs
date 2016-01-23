using SwiftDemo.CoreContracts;
using SwiftDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;

namespace SwiftDemo.Web.Controllers
{
    public class ClientsController : ApiControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientsController"/> class.
        /// </summary>
        /// <param name="uow">The uow.</param>
        public ClientsController(ISwiftDemoUow uow)
        {
            sdUow = uow;
        }

        /// <summary>
        /// Gets this clients records.
        /// </summary>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get()
        {
            var list = await Task.Factory.StartNew(() =>
             sdUow.ClientRecords.GetAll().Include(x => x.ClientPhones.Select(y => y.PhoneNumber)).OrderBy(x => x.Name).ToList());

            //get client records with phone numbers where phone numbers contains basic info only
            //to avoid circular reference error
            var filteredList = list
                .Select(x => new ClientRecord
                {
                    Id = x.Id,
                    Address = x.Address,
                    Name = x.Name,
                    RowVersion = x.RowVersion,
                    ClientPhones = x.ClientPhones.Select(y => new ClientPhone
                    {
                        Id = y.Id,
                        PhoneNumber = y.PhoneNumber,
                        RowVersion = y.RowVersion
                    }).ToList()
                });

            return Ok<IEnumerable<ClientRecord>>(filteredList.ToList());
        }
    }
}
