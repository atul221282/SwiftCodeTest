using System.Web.Http;
using SwiftDemo.CoreContracts;

namespace SwiftDemo.Web.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        protected ISwiftDemoUow sdUow { get; set; }
    }

}
