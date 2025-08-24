namespace Authentication.Avonyu.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.IdentityModel.Tokens;
	using System.Text;
	using System.Security.Claims;
	using System.IdentityModel.Tokens.Jwt;

	[ApiController]
	public class LoginController : ControllerBase
	{
		readonly IConfiguration Config;
		public LoginController(IConfiguration config)
		{
			Config = config;
		}

		[HttpPost]
		[Route("api/login")]
		[Produces(typeof(LoginResponse))]
		public LoginResponse Login([FromBody] BodyLoginParameter Model)
		{
			JwtSecurityTokenHandler securityHandler = new JwtSecurityTokenHandler();
			JwtSecurityToken securityToken = securityHandler.ReadJwtToken(Model.JsonToken);
			return new LoginResponse
			{
				AccessToken = securityToken.RawData,
				AccessTokenExpireDate = securityToken.ValidTo,
				RefreshToken = "5464565465465466"
			};
		}
	}
}