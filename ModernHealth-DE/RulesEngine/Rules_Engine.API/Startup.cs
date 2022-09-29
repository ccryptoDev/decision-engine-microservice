using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Rules_Engine.BAL.Interface;
using Rules_Engine.BAL.Service;
using Rules_Engine.DAL.Interface;
using Rules_Engine.DAL.Repository;
using Rules_Engine.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Rules_Engine.API.Controllers.GradeAPRController;
using static Rules_Engine.API.Controllers.GradeController;

namespace Rules_Engine.API
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            //  services.AddControllers();
            services.AddControllers(o =>
            {
                o.Conventions.Add(new ActionHidingConvention());
               // o.Conventions.Add(new ActionGradeAPRHidingConvention());
                //o.Conventions.Add(new ControllerHidingAppConvention());
            });
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddEntityFrameworkNpgsql().AddDbContext<RulesEngineContext>(opt =>
opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IRulesRepository, RulesRepository>();
            services.AddScoped<IRulesService, RulesService>();

            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IGradeService, GradeService>();

            services.AddScoped<IScoreRepository, ScoreRepository>();
            services.AddScoped<IScoreService,ScoreService>();

            services.AddScoped<IIncomeRepository, IncomeRepository>();
            services.AddScoped<IIncomeService, IncomeService>();

            services.AddScoped<IGradeAPRRepository, GradeAPRRepository>();
            services.AddScoped<IGradeAPRService, GradeAPRService>();

            services.AddScoped<IOfferLoanRepository, OfferLoanRepository>();
            services.AddScoped<IOfferLoanService, OfferLoanService>();

            services.AddScoped<IOfferedTermRepository, OfferedTermRepository>();
            services.AddScoped<IOfferedTermService, OfferedTermService>();

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Title = "v1",
                    Description = "My Web - API",
                    Version = "V1.0.0"
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("MyPolicy");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

          /*  app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });*/
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Rules-Engine");
                c.DefaultModelExpandDepth(0);
               c.DefaultModelsExpandDepth(-1);
            });
            app.UseMvc();
        }
    }
}
