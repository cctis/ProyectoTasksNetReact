using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace TaskManagementApp.Controllers.Auth
{
    public class SimpleBearerTokenHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private const string _token = "mi_token_secreto"; 

        [Obsolete]
        public SimpleBearerTokenHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // Obtener el header Authorization
            if (!Request.Headers.ContainsKey("Authorization"))
                return Task.FromResult(AuthenticateResult.Fail("Missing Authorization Header"));

            var authorizationHeader = Request.Headers["Authorization"].ToString();

            if (!authorizationHeader.StartsWith("Bearer "))
                return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));

            var token = authorizationHeader.Substring("Bearer ".Length).Trim();

            // Validar el token
            if (token != _token)
                return Task.FromResult(AuthenticateResult.Fail("Invalid Token"));

            // Crear las claims del usuario autenticado
            var claims = new[] { new Claim(ClaimTypes.Name, "User") };
            var identity = new ClaimsIdentity(claims, "Bearer");
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
