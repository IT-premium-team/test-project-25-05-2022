Solution structure
	Api – contain service to use webhook.site (POSTs to a dummy endpoints)
	Data – DB access layer (MS SQL with code first entity framework)
	Services – data access services
	WebApp - .NET Core API application


appsettings.json
	DefaultConnection - db connection string
	IpRateLimiting - API methods throttling params


Authorization 
	via a `x-api-key` header, to check access used Token field of User entity
implementation 
	ApiKeyAttribute.cs
usage
	[ApiKey]
	public class TestController : ControllerBase


DB
	several test entities User, Post, Comment


Webhook testing
	change webHookUrl in ApiService.cs to your GUID