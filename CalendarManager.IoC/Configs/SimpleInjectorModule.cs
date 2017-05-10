using System.Data;
using CalendarManager.DataAccess.Listeners;
using CalendarManager.DataAccess.Queries;
using CalendarManager.DataAccess.Repositories;
using CalendarManager.EntityFramework.DataBase;
using CalendarManager.EntityFramework.Queries;
using CalendarManager.EntityFramework.Repositories;
using CalendarManager.Infrastructure.Files;
using CalendarManager.Services.Implements;
using CalendarManager.Services.Interfaces;
using CalendarManager.Services.Validators.Implements;
using CalendarManager.Services.Validators.Interfaces;
using SimpleInjector;

namespace CalendarManager.IoC.Configs
{
    public static class SimpleInjectorModule
    {
        private static Container _container;

        public static void SetContainer(Container container)
        {
            _container = container;
        }

        public static Container GetContainer()
        {
            return _container;
        }

        public static void VerifyContainer()
        {
            _container.Verify();
        }

        public static void Load()
        {
            _container.RegisterWebApiRequest<IDataBaseSqlServerEntityFramework, DataBaseSqlServerEntityFramework>();
            _container.RegisterInitializer<DataBaseSqlServerEntityFramework>(handler =>
            {
                handler.AuditEventListener = _container.GetInstance<IAuditEventListener>();
                handler.DbContext = new CalendarManagerContext();
                handler.DbContextTransaction = handler.DbContext.Database.BeginTransaction(IsolationLevel.Snapshot);
            });

            _container.Register<IAuditEventListener, AuditEventListener>();
            _container.Register<IFileResolver, FileResolver>();
            _container.Register<IFileValidator, FileValidator>();
            _container.Register<IStorageProvider, StorageProvider>();
            
            _container.Register<IUserRepository, UserRepository>();
            _container.Register<IUserQuery, UserQuery>();
            _container.Register<IUserValidator, UserValidator>();
            _container.Register<IUserService, UserService>();

            _container.Register<ILocationRepository, LocationRepository>();
            _container.Register<ILocationQuery, LocationQuery>();
            _container.Register<ILocationValidator, LocationValidator>();
            _container.Register<ILocationService, LocationService>();
        }
    }
}