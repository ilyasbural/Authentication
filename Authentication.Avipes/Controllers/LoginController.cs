namespace Avipes.WebApi.Controllers
{
	using System.Text;
	using System.Security.Claims;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.IdentityModel.Tokens;
	using System.IdentityModel.Tokens.Jwt;
	using System.Security.Cryptography;
	
	[ApiController]
	public class LoginController : ControllerBase
	{
		readonly IConfiguration Config;
		public LoginController(IConfiguration config)
		{
			Config = config;
		}

		[HttpPost]
		[Route("api/authentication")]
		[Produces(typeof(AuthenticationResponse))]
		public AuthenticationResponse Authentication([FromBody] BodyParameterTransfer Model)
		{
			List<Claim> Claims = new List<Claim>()
			{
				new Claim(ClaimTypes.NameIdentifier, "5464565465465466"),
				new Claim("id", "3643566786744536"),
				new Claim("email", "ilyasbural@gmail.com")
				//new Claim(ClaimTypes.NameIdentifier, "5464565465465466"),
				//new Claim(ClaimTypes.Email, "ilyasbural@gmail.com"),
				//	new Claim(ClaimTypes.GroupSid, ResponseUserDetail.ResponseDataSource.FirstOrDefault()!.Id.ToString()),
				//	new Claim(ClaimTypes.Email, Response.ResponseData.Email),
				//	new Claim(ClaimTypes.Role, "User"),
				//	new Claim(ClaimTypes.Authentication, SecurityToken.RawData),
				//	new Claim("AccessTokenExpireDate", SecurityToken.ValidTo.ToString()),
				//	new Claim("RefreshToken", Response.Authentication.RefreshToken),
				//	new Claim("RefreshTokenExpireDate", Response.Authentication.RefreshTokenExpireDate.ToString())
			};
			//List<Claim> Roles = new List<Claim>()
			//{
			//	new Claim("role", "readers"),
			//	new Claim("role", "writers"),
			//};
			//Claims.AddRange(Roles);

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

			//var claims = new List<Claim>()
			//{
			//	new Claim("sub", "eunal"),
			//	new Claim("name", "engin unal")
			//};

			//		var roleClaims = new List<Claim>()
			//{
			//	new Claim("role", "readers"),
			//	new Claim("role", "writers"),
			//};

			//claims.AddRange(roleClaims);

			//var token = new JwtSecurityToken(
			//	issuer: _config.GetSection("JwtTokenOptions")["Issuer"], 
			//	audience: _config.GetSection("JwtTokenOptions")["Audience"],
			//	claims: claims, 
			//	expires: DateTime.Now.Add(TimeSpan.FromSeconds(double.Parse(_config.GetSection("JwtTokenOptions")["Expiration"]))),
			//	signingCredentials: signingCredentials);
			//var tokenData = new JwtSecurityTokenHandler().WriteToken(token);

			return new AuthenticationResponse
			{
				JsonWebToken = value
			};
		}

		[HttpPost]
		[Route("api/read")]
		[Produces(typeof(LoginResponse))]
		public LoginResponse Login([FromBody] BodyParameterLogin Model)
		{
			JwtSecurityTokenHandler securityHandler = new JwtSecurityTokenHandler();
			JwtSecurityToken securityToken = securityHandler.ReadJwtToken(Model.JsonToken);









			//List<Claim> Claims = new List<Claim>()
			//{
			//	new Claim("id", "3643566786744536"),
			//	new Claim("email", "ilyasbural@gmail.com")
			//	//new Claim(ClaimTypes.NameIdentifier, "5464565465465466"),
			//	//new Claim(ClaimTypes.Email, "ilyasbural@gmail.com"),
			//	//	new Claim(ClaimTypes.GroupSid, ResponseUserDetail.ResponseDataSource.FirstOrDefault()!.Id.ToString()),
			//	//	new Claim(ClaimTypes.Email, Response.ResponseData.Email),
			//	//	new Claim(ClaimTypes.Role, "User"),
			//	//	new Claim(ClaimTypes.Authentication, SecurityToken.RawData),
			//	//	new Claim("AccessTokenExpireDate", SecurityToken.ValidTo.ToString()),
			//	//	new Claim("RefreshToken", Response.Authentication.RefreshToken),
			//	//	new Claim("RefreshTokenExpireDate", Response.Authentication.RefreshTokenExpireDate.ToString())
			//};
			//List<Claim> Roles = new List<Claim>()
			//{
			//	new Claim("role", "readers"),
			//	new Claim("role", "writers"),
			//};
			//Claims.AddRange(Roles);

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

			//JwtSecurityToken token = new JwtSecurityToken(
			//	issuer: Config["JwtTokenOptions:Issuer"],
			//	audience: Config["JwtTokenOptions:Audience"],
			//	claims: Claims,
			//	notBefore: DateTime.Now,
			//	expires: DateTime.Now.AddMinutes(30),
			//	signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASecretKeydfgdfgdfgdgdfgfdgfdgdfgdfgdfgfdrleojeırjeırjfıeorjeıjerdfgdflıgdflıgdlfıgdl")), SecurityAlgorithms.HmacSha256)
			//);
			//string value = new JwtSecurityTokenHandler().WriteToken(token);

			//var keyBytes = Encoding.UTF8.GetBytes(_config.GetSection("JwtTokenOptions")["SigningKey"]);
			//var symmetricKey = new SymmetricSecurityKey(keyBytes);

			//var signingCredentials = new SigningCredentials(
			//	symmetricKey,
			//	SecurityAlgorithms.HmacSha256);

			//var claims = new List<Claim>()
			//{
			//	new Claim("sub", "eunal"),
			//	new Claim("name", "engin unal")
			//};

			//		var roleClaims = new List<Claim>()
			//{
			//	new Claim("role", "readers"),
			//	new Claim("role", "writers"),
			//};

			//claims.AddRange(roleClaims);

			//var token = new JwtSecurityToken(
			//	issuer: _config.GetSection("JwtTokenOptions")["Issuer"], 
			//	audience: _config.GetSection("JwtTokenOptions")["Audience"],
			//	claims: claims, 
			//	expires: DateTime.Now.Add(TimeSpan.FromSeconds(double.Parse(_config.GetSection("JwtTokenOptions")["Expiration"]))),
			//	signingCredentials: signingCredentials);
			//var tokenData = new JwtSecurityTokenHandler().WriteToken(token);

			return new LoginResponse
			{
				
			};
		}
	}
}