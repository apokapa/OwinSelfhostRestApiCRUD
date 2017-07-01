using System.Web.Http;
using Datastore.Abstractions;
using Datastore.EF.SQL;
using Newtonsoft.Json;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace apox.owin.webapi
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
         
            var config = new HttpConfiguration();

            //Routes
            config.MapHttpAttributeRoutes();
            // clear the supported mediatypes of the xml formatter
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            //json
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            json.SerializerSettings.NullValueHandling = NullValueHandling.Include;

            //Injection
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            //InitializeContainer(container);
            container.Register<IProductsRepository, ProductsRepository>(Lifestyle.Scoped);
            //container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            //Swagger
            SwaggerConfig.Register(config);

            app.UseWebApi(config);

        }
    }

}