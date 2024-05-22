using Microsoft.Extensions.DependencyInjection;
using ProjectBLL.ManagerServices.Abstracs;
using ProjectBLL.ManagerServices.Concretes;
using ProjectDAL.Repositories.Abstracts;
using ProjectDAL.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBLL.DependencyResolves
{
    public static class RepositoryManagerServicesInjection
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IManeger<>), typeof(BaseManager<>));
            services.AddScoped<IAppUserRepositorty,AppUserRepository>();
            services.AddScoped<IAppUserManger,AppUserManger>();
            services.AddScoped<IAppUserProfileRepository, AppUserProfileRepository>();
            services.AddScoped<IAppUserProfileManager, AppUserProfileManager>();
            services.AddScoped<ICatagoryRepository,CatagoryRepository>();
            services.AddScoped<ICatagoryManager, CatagoryManager>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IOrderDetailManger, OrderDetailMannger>();
            services.AddScoped<IOrderRepository,OrderRepository>();
            services.AddScoped<IOrderManager, OrderManeger>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IProductManager,ProductManager>();   
            return services;

        }
    }
}
