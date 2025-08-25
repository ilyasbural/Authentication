namespace Authentication.Avipes.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using System.IdentityModel.Tokens.Jwt;

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

			UserModel User = new UserModel
			{
				Id = long.Parse(securityToken.Claims.ElementAt(0).Value), 
				Email = securityToken.Claims.ElementAt(1).Value,
				Name = securityToken.Claims.ElementAt(2).Value,
				Lastname = securityToken.Claims.ElementAt(3).Value,
				Birthdate = DateTime.Parse(securityToken.Claims.ElementAt(4).Value)
			};

			return new AuthenticationResponse
			{
				AccessToken = securityToken.RawData,
				AccessTokenExpireDate = securityToken.ValidTo,
				RefreshToken = "5464565465465466"
			};
		}
	}
}