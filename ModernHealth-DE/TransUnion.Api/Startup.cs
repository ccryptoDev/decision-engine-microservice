using DecisionEngine.BAL.Interface;
using DecisionEngine.BAL.Service;
using DecisionEngine.DAL.Interface;
using DecisionEngine.DAL.Repository;
using DecisionEngine.Entities.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;

namespace DecisionEngine.Api
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
            //Enable CORS
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            // Add functionality to inject IOptions<T>
            services.AddOptions();

            //Register Services and Repositories
            services.AddSingleton<IConfiguration>(Configuration);

       

            services.Configure<Services.TransUnionSettings>(Configuration.GetSection("TransUnionSettings"));
            services.Configure<Services.Certificate>(Configuration.GetSection("TransUnionSettings:Certificate"));
            services.AddTransient<Services.ITransUnionService, Services.TransUnionService>();
            services.AddTransient<Services.ILoanService, Services.LoanService>();
            services.AddTransient<DataService.IDecisionEngine, DataService.DecisionEngine>();
            services.AddTransient<Handlers.TransUnionHttpClientHandler>();
            services.AddHttpClient<TunaService.ITransUnionClient, TunaService.TransUnionClient>((sp, httpclient) =>
            {
                var settings = sp.GetRequiredService<IOptions<Services.TransUnionSettings>>().Value;
                httpclient.BaseAddress = new Uri(settings.Url);

            }).ConfigurePrimaryHttpMessageHandler<Handlers.TransUnionHttpClientHandler>();

            //services.Configure<IISServerOptions>(options =>
            //{
            //    options.AllowSynchronousIO = true;
            //});
            services.AddEntityFrameworkNpgsql().AddDbContext<DecisionEngineContext>(opt =>
opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

           

            services.AddScoped<IRulesRepository, RulesRepository>();
            services.AddScoped<IRulesService, RulesService>();

            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IGradeService, GradeService>();

            services.AddScoped<IScoreRepository, ScoreRepository>();
            services.AddScoped<IScoreService, ScoreService>();

            services.AddScoped<IIncomeRepository, IncomeRepository>();
            services.AddScoped<IIncomeService, IncomeService>();

            services.AddScoped<IGradeAPRRepository, GradeAPRRepository>();
            services.AddScoped<IGradeAPRService, GradeAPRService>();

            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IOfferService, OfferService>();

            services.AddScoped<IOfferValueRepository, OfferValueRepository>();
            services.AddScoped<IOfferValueService, OfferValueService>();

            services.AddScoped<IOfferGradeRepository, OfferGradeRepository>();
            services.AddScoped<IOfferGradeService, OfferGradeService>();

            services.AddScoped<ITermRepository, TermRepository>();
            services.AddScoped<ITermService, TermService>();

            services.AddScoped<ITermGradeRepository, TermGradeRepository>();
            services.AddScoped<ITermGradeService, TermGradeService>();

            services.AddScoped<IDecisionRepository, DecisionRepository>();
            services.AddScoped<IDecisionService, DecisionService>();

            services.AddControllers();
             


            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("MyPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Decision Engine V1");
                c.DefaultModelExpandDepth(0);
                c.DefaultModelsExpandDepth(-1);
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
