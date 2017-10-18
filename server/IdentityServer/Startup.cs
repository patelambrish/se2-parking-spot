// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using DataAccess.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QuickstartIdentityServer.Framework;

namespace QuickstartIdentityServer
{
    public class Startup
    {
        public Startup(ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<spot2shareContext>();
            // configure identity server with in-memory stores, keys, clients and scopes
            var builder = services.AddIdentityServer();

            builder.AddTemporarySigningCredential();
            builder.AddInMemoryApiResources(Config.GetApiResources());
            builder.AddInMemoryClients(Config.GetClients());
            //builder.AddTestUsers(Config.GetUsers());

            builder.Services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            //builder.Services.AddTransient<IProfileService, ProfileService>();

            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();

            app.UseIdentityServer();
        }
    }
}