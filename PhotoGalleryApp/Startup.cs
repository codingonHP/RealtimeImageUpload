using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhotoGalleryApp.Startup))]
namespace PhotoGalleryApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
			app.MapSignalR();
        }
    }
}
