using Ls.Repository;
using Ls.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Ls.WebServer
{
    public static class Injection
    {
        public static void RegiterTypes(this IServiceCollection services)
        {
            RegiterRepository(services);
            RegiterService(services);
            // 添加跨域支持
            services.AddCors(options =>
            {
                options.AddPolicy("any", builder =>
                {
                    builder.AllowAnyOrigin() //允许任何来源的主机访问
                                             //builder.WithOrigins("http://localhost:8080") ////允许http://localhost:8080的主机访问
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();//指定处理cookie

                });
            });
        }

        public static void RegiterRepository(IServiceCollection services)
        {
            foreach (var item in GetClassesByAssembly("Ls.Repository"))
            {
                foreach (var typeArray in item.Value)
                {
                    if (typeArray.IsGenericType) continue;
                    services.AddScoped(typeArray, item.Key);
                }
            }
        }

        public static void RegiterService(IServiceCollection services)
        {
            foreach (var item in GetClassesByAssembly("Ls.Service"))
            {
                foreach (var typeArray in item.Value)
                {
                    services.AddScoped(typeArray, item.Key);
                }
            }

        }

        public static Dictionary<Type, Type[]> GetClassesByAssembly(string assemblyName)
        {
            if (!string.IsNullOrEmpty(assemblyName))
            {
                Assembly assembly = Assembly.Load(assemblyName);
                List<Type> ts = assembly.GetTypes().ToList();

                var result = new Dictionary<Type, Type[]>();
                foreach (var item in ts.Where(s => !s.IsInterface))
                {
                    var interfaceType = item.GetInterfaces();
                    result.Add(item, interfaceType);
                }
                return result;
            }
            return new Dictionary<Type, Type[]>();
        }
    }
}
