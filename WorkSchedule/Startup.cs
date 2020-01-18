using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using DataAccess.Repositories.Implementations;
using DataAccess.Repositories.Interfaces;
using Service.Services.Implementations;
using Service.Services.Interfaces;
using DataAccess.Context;
using Microsoft.OpenApi.Models;
using Service.Authentication;
using System.Collections.Generic;
using DataAccess.Entities;

namespace WorkSchedule
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<TokenManagement>(Configuration.GetSection("tokenManagement"));
            //var token = Configuration.GetSection("tokenManagement").Get<TokenManagement>();
            //var secret = Encoding.ASCII.GetBytes(token.Secret);

            services.AddMvc();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddDbContext<WorkScheduleContext>();
            //services.AddAuthorization();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("WorkScheduleV1", new OpenApiInfo { Title = "WorkSchedule", Version = "v1" });
                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Description = "JWT authorization",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.ApiKey
                //});
                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {new OpenApiSecurityScheme{Reference = new OpenApiReference
                //    {
                //        Id = "Bearer",
                //        Type = ReferenceType.SecurityScheme
                //    }}, new List<string>()}
                //});
            });

            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = Configuration["Jwt:Issuer"],
            //        ValidAudience = Configuration["Jwt:Issuer"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            //    };
            //});

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonService, PersonService>();

            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IPositionService, PositionService>();

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<IShiftService, ShiftService>();
            services.AddScoped<IShiftRepository, ShiftRepository>();

            services.AddScoped<IShiftTypeService, ShiftTypeService>();
            services.AddScoped<IShiftTypeRepository, ShiftTypeRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            //services.AddScoped<IAuthenticationService, AuthenticationService>();
            //services.AddTransient<TokenManagerMiddleware>();
            services.AddHttpContextAccessor();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/WorkScheduleV1/swagger.json", "WorkSchedule v1");
            });

            //app.UseMiddleware<TokenManagerMiddleware>();
            //app.UseAuthentication();
        }
    }
}
