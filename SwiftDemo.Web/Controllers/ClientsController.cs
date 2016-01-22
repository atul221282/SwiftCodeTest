using SwiftDemo.CoreContracts;
using SwiftDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
        public IEnumerable<ClientRecord> Get()
        {
            return sdUow.ClientRecords.GetAll();
        }
    }
}
