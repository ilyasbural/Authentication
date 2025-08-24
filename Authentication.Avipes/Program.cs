using Microsoft.OpenApi.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(x =>
{
	x.SwaggerDoc("v1", new() { Title = "Avipes API", Version = "v1" });
	x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Description = "JWT Authorization header using the Bearer scheme."
	});
	x.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
				}
			},
			Array.Empty<string>()
		}
	});
});

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//	.AddJwtBearer(options =>
//	{
//		options.TokenValidationParameters = new TokenValidationParameters
//		{
//			ValidateIssuer = true,
//			ValidateAudience = true,
//			ValidateIssuerSigningKey = true,
//			ValidIssuer = JwtSettings.ValidIssuer,
//			ValidAudience = JwtSettings.ValidAudience,
//			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.SigningCredentials))
//		};
//	});

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
//{
//	x.LoginPath = "/login/index"; //login path verdik. Return Url yapacap?m?z dizin
//	x.AccessDeniedPath = "/login/accessdenied"; // Eri?im reddedildi sayfas? belirleyin.
//});

//builder.Services.ConfigureApplicationCookie(opts => // birden fazla y nlerdirme hatas  ald m bunun ile   z ld 
//{
//	opts.Cookie.HttpOnly = true;
//	opts.ExpireTimeSpan = TimeSpan.FromMinutes(100);
//	opts.AccessDeniedPath = new PathString("/login/accessdenied/");  //yetkisi olmayan sayfalarda gidece i path 
//	opts.LoginPath = "/login/index/";
//	opts.SlidingExpiration = true;
//});

//builder.Services.AddAuthentication(options =>
//{
//	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//		.AddJwtBearer("Bearer", options =>
//		{
//			options.SaveToken = true;
//			options.RequireHttpsMetadata = false;
//			options.TokenValidationParameters = new TokenValidationParameters()
//			{
//				ValidIssuer = "http://localhost",
//				ValidAudience = "http://localhost",
//				ClockSkew = TimeSpan.Zero,
//				ValidateIssuerSigningKey = true,
//				ValidateLifetime = true,
//				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"))
//			};
//		});

//builder.Services.AddAuthentication(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme);
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, option =>
//{
//	option.LoginPath = "/login/index";
//	option.LogoutPath = "/home/index";
//	option.AccessDeniedPath = "/home/index";
//	option.Cookie.SameSite = SameSiteMode.Strict;
//	option.Cookie.HttpOnly = true;
//	option.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
//	//option.SlidingExpiration = true;
//	//option.ExpireTimeSpan = TimeSpan.FromMinutes(5);
//	option.Cookie.Name = "NetCoreMvc.Auth";
//});
//builder.Services.AddAuthentication(x => { x.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme; x.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme; x.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme; }).AddCookie();

//builder.Services.AddAuthentication(options =>
//{
//	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer("Bearer", options =>
//{
//	options.SaveToken = true;
//	options.RequireHttpsMetadata = false;
//	options.TokenValidationParameters = new TokenValidationParameters()
//	{
//		ValidIssuer = "http://localhost",
//		ValidAudience = "http://localhost",
//		ClockSkew = TimeSpan.Zero,
//		ValidateIssuerSigningKey = true,
//		ValidateLifetime = true,
//		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"))
//	};
//	options.Events = new JwtBearerEvents
//	{
//		OnMessageReceived = context =>
//		{
//			context.Token = context.Request.Cookies["fdgdf"];
//			return Task.CompletedTask;
//		},
//	};
//}).AddCookie("Cookies");


//builder.Services.AddAuthentication(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
//{
//option.RequireHttpsMetadata = false;
//option.TokenValidationParameters = new TokenValidationParameters()
//{
//	ValidIssuer = "http://localhost",
//	ValidAudience = "http://localhost",
//	ClockSkew = TimeSpan.Zero,
//	ValidateIssuerSigningKey = true,
//	ValidateLifetime = true,
//	IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"))
//};
//}).AddCookie(option =>
//{
//	option.Cookie.Name = "NetCoreMvc.Auth";
//	option.LoginPath = "/login/index";
//	option.AccessDeniedPath = "/login/index";
//	option.SlidingExpiration = true;
//	option.ExpireTimeSpan = TimeSpan.FromMinutes(5);
//});

/*builder.Services.AddDistributedMemoryCache()*/

//builder.Services.AddSession(option =>
//{
//	option.IdleTimeout = TimeSpan.FromMinutes(30);
//	option.Cookie.HttpOnly = true;
//	option.ExpireTimeSpan = TimeSpan.FromMinutes(5);
//	option.LoginPath = "/Identity/Account/Login";
//	option.AccessDeniedPath = "/Identity/Account/AccessDenied";
//	option.SlidingExpiration = true;
//});

//builder.Services.ConfigureApplicationCookie(options =>
//{
//	options.Cookie.HttpOnly = true;
//	options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
//	options.LoginPath = "/Identity/Account/Login";
//	options.AccessDeniedPath = "/Identity/Account/AccessDenied";
//	options.SlidingExpiration = true;
//});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors();
app.Run();