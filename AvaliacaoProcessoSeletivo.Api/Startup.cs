using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AvaliacaoProcessoSeletivo.Api.Domain;
using AvaliacaoProcessoSeletivo.Api.Infra.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AvaliacaoProcessoSeletivo.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });




            //string path = Directory.GetCurrentDirectory();
            services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddDbContext<Contexto>(options =>
                //options.UseSqlServer(Configuration.GetConnectionString("AvaliacaoProcessoSeletivo")//.Replace("[DataDirectory]", path))
                options.UseSqlite("Data Source=Avaliacao.db")
                
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //pra funcionar o  cors via atributo o 
            //comando UseCors tem que ser dado depois 
            //de use routing e antes de use authorization, 
            //e deve ir sem o argumento da policy, 
            //porque a policy vc vai colocar no 
            //atributo em cima do controller ou da action

            //app.UseCors("CorsPolicy");
            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
