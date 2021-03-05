
using System.Web.Http;


namespace ProjetoBanco.App_Start
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            AutofacWebapi.Initialize(GlobalConfiguration.Configuration);
        }
    }
}
