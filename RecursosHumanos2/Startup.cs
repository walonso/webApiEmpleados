using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RecursosHumanos2.Repositorio;
using RecursosHumanos2.Repositorio.Entidades;
using RecursosHumanos2.Servicios;
using RecursosHumanos2.Servicios.Interfaces;

namespace RecursosHumanos2
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //https://stackoverflow.com/questions/33566075/generic-repository-in-asp-net-core-without-having-a-separate-addscoped-line-per
            //services.AddScoped(typeof(IRepositorio<>), typeof(Memoria<>));
            services.AddSingleton<IRepositorio<Empleado>, Memoria<Empleado>>();
            services.AddScoped<IBulkService, BulkService>();
            services.AddScoped<IEmpleadoService, EmpleadoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
