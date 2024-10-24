using DynamicStore.Facades.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DynamicStoreLinkController : Controller
    {
        private readonly IDynamicLinkFacade _dynamicLinkFacade;
        public DynamicStoreLinkController(IDynamicLinkFacade dynamicLinkFacade) 
        {
            _dynamicLinkFacade = dynamicLinkFacade;
        }

        [HttpGet("retrieve-store-link")]
        public ActionResult<string> SendStoreLinkAsync()
        {
            var dynamicLinkResponse = _dynamicLinkFacade.GetStoreLinkByOperationSystem(Request.Headers);

            return Ok(dynamicLinkResponse);

        }
    }
}
