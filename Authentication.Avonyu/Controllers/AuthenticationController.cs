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
		readonly IConfiguration Config;
		public AuthenticationController(IConfiguration config)
		{
			Config = config;
		}

		[HttpPost]
		[Route("api/authentication")]
		[Produces(typeof(AuthResponse))]
		public AuthResponse Authentication([FromBody] BodyParameterAuthentication Model)
		{
			List<Claim> Claims = new List<Claim>()
			{
				new Claim("Id", "4563475674584678"),
				new Claim("Email", "ilyasbural@gmail.com"),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("Authentication", ""),
				//new Claim("AccessTokenExpireDate", ""),
				//new Claim("RefreshToken", ""),
				//new Claim("RefreshTokenExpireDate", "")
			};
			List<Claim> Roles = new List<Claim>()
			{
				new Claim("Role", "Reader"),
				new Claim("Role", "Writer"),
			};
			Claims.AddRange(Roles);

			//var handler = new JsonWebTokenHandler();
			//var now = DateTime.UtcNow;
			//var tokenData = handler.CreateToken(new SecurityTokenDescriptor
			//{
			//	Issuer = "AspNetJWT"
			//	//Issuer = Config["JwtTokenOptions:Issuer"],
			//	//Audience = Config["JwtTokenOptions:Audience"],
			//	//IssuedAt = now,
			//	//NotBefore = now,
			//	//Subject = new ClaimsIdentity(Claims),
			//	//Expires = now.AddMinutes(double.Parse(Config["JwtTokenOptions:Expiration"])),
			//	//SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASecretKeydfgdfgdfgdgdfgfdgfdgdfgdfgdfgfd")), SecurityAlgorithms.HmacSha256)
			//});

			JwtSecurityToken token = new JwtSecurityToken(
				issuer: Config["JwtTokenOptions:Issuer"],
				audience: Config["JwtTokenOptions:Audience"],
				claims: Claims,
				notBefore: DateTime.Now,
				expires: DateTime.Now.AddMinutes(30),
				signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASecretKeydfgdfgdfgdgdfgfdgfdgdfgdfgdfgfdrleojeırjeırjfıeorjeıjerdfgdflıgdflıgdlfıgdl")), SecurityAlgorithms.HmacSha256)
			);
			string value = new JwtSecurityTokenHandler().WriteToken(token);

			//var keyBytes = Encoding.UTF8.GetBytes(_config.GetSection("JwtTokenOptions")["SigningKey"]);
			//var symmetricKey = new SymmetricSecurityKey(keyBytes);

			//var signingCredentials = new SigningCredentials(
			//	symmetricKey,
			//	SecurityAlgorithms.HmacSha256);

			return new AuthResponse
			{
				AccessToken = value,
				AccessTokenExpireDate = token.ValidTo,
				RefreshToken = "5464565465465466",
			};
		}
	}
}