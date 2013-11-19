using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using KarolCamp.Dominio;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;

namespace KarolCamp.API.Controllers
{
    [System.Web.Http.RoutePrefix("api/Usuarios")]
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

        [System.Web.Http.Authorize]
        [System.Web.Http.Route("MudarSenha")]
        public async Task<IHttpActionResult> MudarSenha(SenhaModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.SenhaVelha,
                model.SenhaNova);
            var errorResult = GetErrorResult(result);

            return errorResult ?? Ok();
        }

        [System.Web.Http.Authorize]
        [System.Web.Http.Route("AdicionarPermissao")]
        public async Task<IHttpActionResult> AdicionarPermissao(string permissao)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await UserManager.AddToRoleAsync(User.Identity.GetUserId(), permissao);
            var errorResult = GetErrorResult(result);

            return errorResult ?? Ok();
        }

        [System.Web.Http.Authorize]
        [System.Web.Http.Route("RemovePermissao")]
        public async Task<IHttpActionResult> RemovePermissao(string permissao)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await UserManager.RemoveFromRoleAsync(User.Identity.GetUserId(), permissao);
            var errorResult = GetErrorResult(result);

            return errorResult ?? Ok();
        }

        [System.Web.Http.Authorize]
        [System.Web.Http.Route("Info")]
        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> Info()
        {
            if (!User.Identity.IsAuthenticated) return BadRequest("Usuário não autenticado");

            var usuario = UserManager.FindById(User.Identity.GetUserId());
            if (usuario == null) return BadRequest();

            var retorno = new
            {
                id = User.Identity.GetUserId(),
                nome = usuario.UserName,
                telefone = usuario.Telefone,
                permissoes = usuario.Roles.ToArray()
            };

            return Ok(retorno);
        }

        [System.Web.Http.Route("Logout")]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
        }

        [System.Web.Http.Route("Token")]
        public async Task<IHttpActionResult> Token(LoginModel login)
        {
            var baseUrl = string.Format((HttpContext.Current.Request.Url.Port != 80) ? "{0}://{1}:{2}" : "{0}://{1}",
                HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Host, HttpContext.Current.Request.Url.Port);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var content = new FormUrlEncodedContent(new[] {
                 new KeyValuePair<string, string>("grant_type", "password"),
                 new KeyValuePair<string, string>("username", login.Login),
                 new KeyValuePair<string, string>("password", login.Senha)
             });
                var result = client.PostAsync("/token", content).Result;
                var resultContent = result.Content.ReadAsStringAsync().Result;

                return Ok(JsonConvert.DeserializeObject(resultContent));
            }
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

    public class LoginModel
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
