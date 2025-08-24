namespace Authentication.ThemeHospital.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	[Route("api/[controller]")]
	[ApiController]
	public class CreateAuthenticationController : ControllerBase
	{
		readonly IConfiguration Configuration;
		public CreateAuthenticationController(IConfiguration configuration) { Configuration = configuration; }
	}
}