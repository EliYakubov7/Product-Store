using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace ProductStoreAPI.Host.Attributes
{
	public sealed class SecurityHeadersAttribute : ActionFilterAttribute
	{
		public override void OnResultExecuting(ResultExecutingContext context)
		{
			var headers = context.HttpContext.Request.Headers;

			const string contentTypeOptions = "nosniff";

			if (!headers.ContainsKey("X-Content-Type-Options"))
			{
				headers.Append("X-Content-Type-Options", contentTypeOptions);
			}

			const string frameOptions = "SAMEORIGIN";

			if (!headers.ContainsKey("X-Frame-Options"))
			{
				headers.Append("X-Frame-Options", frameOptions);
			}

			const string contentSecurityPolicy =
				"default-src 'self'; object-src 'none'; img-src 'self' data:; frame-ancestors 'none'; sandbox allow-forms allow-same-origin allow-scripts allow-popups; base-uri 'self';";

			if (!headers.ContainsKey("Content-Security-Policy"))
			{
				headers.Append("Content-Security-Policy", contentSecurityPolicy);
			}
			if (!headers.ContainsKey("X-Content-Security-Policy"))
			{
				headers.Append("X-Content-Security-Policy", contentSecurityPolicy);
			}

			const string referrerPolicy = "no-referrer";

			if (!headers.ContainsKey("Referrer-Policy"))
			{
				headers.Append("Referrer-Policy", referrerPolicy);
			}

			const string transportSecurity = "max-age=31536000; includeSubDomains";

			if (!headers.ContainsKey("Strict-Transport-Security"))
			{
				headers.Append("Strict-Transport-Security", transportSecurity);
			}

			const string permissionsPolicy = "*";

			if (!headers.ContainsKey("Permissions-Policy"))
			{
				headers.Append("Permissions-Policy", permissionsPolicy);
			}
		}
	}
}