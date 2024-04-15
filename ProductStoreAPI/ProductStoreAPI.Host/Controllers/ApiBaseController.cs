using Microsoft.AspNetCore.Mvc;
using ProductStoreAPI.Host.Attributes;

namespace ProductStoreAPI.Host.Controllers
{
	[ApiController]
	[SecurityHeaders]
	[Route("api/v1/[controller]/")]
	[Produces("application/json")]
	public class ApiBaseController : ControllerBase
	{
	}
}