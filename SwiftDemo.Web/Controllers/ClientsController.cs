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
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ClientRecord>> Get()
        {
            //var clientRecord = new ClientRecord { Name = "John", Address = "218 Kingfisher Street, Somewhere, Melbourne" };
            //clientRecord.PhoneNumbers = new List<PhoneNumber>();
            //clientRecord.PhoneNumbers.Add(new PhoneNumber { Number = "0400497250" });
            //sdUow.ClientRecords.Add(clientRecord);
            //sdUow.Commit();

            //var atul = sdUow.ClientRecords.GetById(1);
            //atul.PhoneNumbers.Add(new PhoneNumber { Number = "0430499210" });
            //sdUow.Commit();

            var list = await Task.Factory.StartNew(() =>
             sdUow.ClientRecords.GetAll().Include(x => x.PhoneNumbers).OrderBy(x => x.Name).ToList());
            return list;
        }
    }
}
