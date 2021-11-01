using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VolvoCrudApi.Models;
using VolvoCrudApi.Repositories;
using VolvoCrudApi.Requests;

namespace VolvoCrudApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Aqui registramos a classe responsável por disparar a validação
            //Esta forma de implementação simplificar o desenvolvimento
            //Pois elimina a necessidade de chamar  ModelState.IsValid em cada método das Controllers
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidateModelStateAttribute));
            });


            services.AddControllers()
            .AddFluentValidation(fv =>
            {
                fv.ImplicitlyValidateChildProperties = true;
                fv.ImplicitlyValidateRootCollectionElements = true;
                fv.RegisterValidatorsFromAssemblyContaining<Startup>();
            });

            //Aqui estamos registrando o contexto como serviço
            //Tambem definimos a connexão e o tipo de banco de dados
            services.AddDbContext<VolvoContext>(
                option => option.UseSqlServer(Configuration.GetConnectionString("VolvoDB"))
            );

            //Aqui registramos o Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VolvoCrudApi", Version = "v1" });
            });

            //Aqui estamos registrando os repositórios como serviço
            services.AddScoped<ICaminhaoRepository, CaminhaoRepository>();
            services.AddScoped<IModeloRepository, ModeloRepository>();

            //Aqui estamos registrando os validators como serviço
            services.AddScoped<IValidator<CaminhaoInsertRequest>, CaminhaoInsertRequestValidator>();
            services.AddScoped<IValidator<CaminhaoInsertRequest>, CaminhaoInsertRequestValidator>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Cria o Banco de Dados automaticamente
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<VolvoContext>();
                context.Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VolvoCrudApi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
