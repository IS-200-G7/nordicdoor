using System;
using PDSA_System.Client;

namespace PDSA_System.Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            /* 
            Services er en IServiceCollection som er en interface, med andre ord en kontrakt som spesifiserer kolleksjonen av andre kontrakter.
            Holder styr på Kontrakter systemet bruker.
            */

            //Applikasjons Tjenester
            services.Configure<JwtSettings>(Configuration.GetSection("JWTSettings"));

            /*
             AddTransient: (Definerer levetiden til tjenesten) --> Andre livstidstjenester er AddSCoped og AddSingelton.
             Transient levetids tjenester opprettes hver gang de blir forespurt.
             Fungerer bra for tjenester som er lette, statsløse og kort levetid.
             Helper.cs bruker interfasen IDisposable som vil si at tjenesten er lett og kort levetid.
             */
            services.AddTransient<DbHelper>(_ =>
                new DbHelper(Configuration["ConnectionStrings:DefaultConnectionString"]));
        }
    }
}
