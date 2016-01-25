using System.Web.Http;
using SwiftTest.CoreContracts;

namespace SwiftTest.Web.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        protected ISwiftDemoUow sdUow { get; set; }
    }

}
