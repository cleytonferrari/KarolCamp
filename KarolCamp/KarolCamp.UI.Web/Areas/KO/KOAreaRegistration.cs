using System.Web.Mvc;

namespace KarolCamp.UI.Web.Areas.KO
{
    public class KOAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "KO";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "KO_default",
                "KO/{controller}/{action}/{id}",
                new { action = "Index", controller="Home", id = UrlParameter.Optional }
            );
        }
    }
}
