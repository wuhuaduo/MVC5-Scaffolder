using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Repository.Pattern.UnitOfWork;
using Repository.Pattern.Ef6;
using Repository.Pattern.DataContext;
using WebApp.Models;
using Repository.Pattern.Repositories;
using WebApp.Services;

namespace WebApp.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            //container.RegisterType<IUnitOfWorkAsync, UnitOfWork>(new HierarchicalLifetimeManager());
            //container.RegisterType<IDataContextAsync, StoreContext>(new HierarchicalLifetimeManager());

            //container.RegisterType<IRepositoryAsync<Product>, Repository<Product>>(new PerRequestLifetimeManager());
            //container.RegisterType<IProductService, ProductService>(new PerRequestLifetimeManager());
            //container.RegisterType<IRepositoryAsync<Category>, Repository<Category>>(new PerRequestLifetimeManager());
            //container.RegisterType<ICategoryService, CategoryService>(new PerRequestLifetimeManager());
            //container.RegisterType<IRepositoryAsync<Order>, Repository<Order>>(new PerRequestLifetimeManager());
            //container.RegisterType<IOrderService, OrderService>(new PerRequestLifetimeManager());

            container.RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerRequestLifetimeManager());
            container.RegisterType<IDataContextAsync, StoreContext>(new PerRequestLifetimeManager());

            container.RegisterType<IRepositoryAsync<Product>, Repository<Product>>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IRepositoryAsync<Category>, Repository<Category>>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IRepositoryAsync<Order>, Repository<Order>>();
            container.RegisterType<IOrderService, OrderService>();
            //container.RegisterType<IRepositoryAsync<Order>, Repository<Order>>();
            //container.RegisterType<IOrderService, OrderService>();
        }
    }
}
