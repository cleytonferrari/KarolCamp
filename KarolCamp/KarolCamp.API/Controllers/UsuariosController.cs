using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KarolCamp.Aplicacao;
using KarolCamp.Dominio;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;

namespace KarolCamp.API.Controllers
{
    [RoutePrefix("api/Usuarios")]
    public class UsuariosController : ApiController
    {
        public UserManager<Usuario> UserManager { get; private set; }
        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }
        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        public UsuariosController()
            : this(Startup.UserManagerFactory(), Startup.OAuthOptions.AccessTokenFormat)
        {
        }
        public UsuariosController(UserManager<Usuario> userManager, ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
        }

        public async Task<IHttpActionResult> Post(Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await UserManager.CreateAsync(usuario, usuario.PasswordHash);
            var errorResult = GetErrorResult(result);

            return errorResult ?? Ok();
        }

        [Authorize]
        [Route("MudarSenha")]
        public async Task<IHttpActionResult> MudarSenha(SenhaModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.SenhaVelha,
                model.SenhaNova);
            var errorResult = GetErrorResult(result);

            return errorResult ?? Ok();
        }

        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null) return InternalServerError();

            if (result.Succeeded) return null;

            if (result.Errors != null)
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error);

            if (ModelState.IsValid) return BadRequest();

            return BadRequest(ModelState);
        }
    }

    public class SenhaModel
    {

        public string SenhaVelha { get; set; }
        public string SenhaNova { get; set; }
    }
}