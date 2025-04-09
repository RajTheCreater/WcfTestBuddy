using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class HomeController : Controller
    {
        [HttpGet("Index")]
        [Produces("application/json")]
        public async Task<ActionResult> Index(int id)
        {
            ChannelFactory<IService1> factory = new ChannelFactory<IService1>(new BasicHttpBinding(), new EndpointAddress("http://localhost:8089/Service1.svc"));
            IService1 proxy = factory.CreateChannel();

            var result = proxy.GetDataAsync(id).Result;
            var res = (result == null ? string.Empty : result);
            return Ok(res);
        }
        [HttpGet("Details")]
        [Produces("application/json")]
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}
