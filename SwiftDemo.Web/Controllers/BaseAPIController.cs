using SwiftDemo.CoreContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SwiftDemo.Web.Controllers
{
    /// <summary>
    /// Base API controller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public abstract class BaseAPIController : ApiController
    {
        /// <summary>
        /// Gets or sets the uow.
        /// </summary>
        /// <value>
        /// The uow.
        /// </value>
        protected ISwiftDemoUow UOW { get; set; }
    }
}
