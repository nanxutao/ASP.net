using System.Web.Mvc;

namespace MvcVBlog19301330222_2020.Areas.admin
{
    public class adminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "admin_default",
                "admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "MvcVBlog19301330222_2020.Areas.admin.Controllers" }
            );
        }
    }
}
