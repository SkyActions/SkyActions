using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using SkyActions.Web;

namespace SkyActions {
    static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            LaunchEmbeddedWebServer();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void LaunchEmbeddedWebServer() {
            var server = WebHost.
                        CreateDefaultBuilder()
                        .UseKestrel(x => {
                            x.ListenLocalhost(5050);
                        })
                        .UseStartup<Startup>()
                        .Build();
            Task.Run(() => {
                server.Run();
            });
        }
    }
}
