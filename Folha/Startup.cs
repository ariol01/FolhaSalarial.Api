using FluentValidation;
using Folha.Infraestrutura;
using Folha.Interfaces;
using Folha.Models;
using Folha.Models.Validation;
using Folha.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Folha
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
            services.AddControllers();

            //services.AddTransient<IValidator<Funcionario>, FuncionarioValidator>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddTransient<FuncionarioRepositorio>();
            services.AddDbContext<DataFolhaContext>(x => x.UseInMemoryDatabase("memo"));

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddDbContext<DataFolhaContext>(op => op.UseSqlServer(Configuration.GetConnectionString("DataFolhaConnection")));

        }
        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
