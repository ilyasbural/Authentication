namespace Authentication.Avonyu.Controllers
{
	using System.Text;
	using System.Security.Claims;
	using System.IdentityModel.Tokens.Jwt;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.IdentityModel.Tokens;

	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		readonly IConfiguration Configuration;
		public AuthenticationController(IConfiguration configuration) { Configuration = configuration; }

		[HttpPost]
		[Route("api/login")]
		[Produces(typeof(AuthenticationResponse))]
		public AuthenticationResponse Login([FromBody] BodyParameterAuthentication Model)
		{
			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
			JwtSecurityToken securityToken = handler.ReadJwtToken(Model.JsonToken);
			return new AuthenticationResponse
			{
				AccessToken = securityToken.RawData,
				AccessTokenExpireDate = securityToken.ValidTo,
				RefreshToken = "5464565465465466"
			};
		}
	}
}