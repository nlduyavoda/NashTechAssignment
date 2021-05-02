using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace NashTechAssignment.backend_test
{
    public class SqliteInMemoryFixture : IDisposable
    {
        private IServiceScope _serviceScope;
        private SqliteConnection _connection;
        public virtual IServiceProvider ServiceProvider
        {
            get
            {
                if (_serviceScope == null)
                {
                    _serviceScope = ConfigureServices(new ServiceCollection())
                        .BuildServiceProvider()
                        .CreateScope();
                }

                return _serviceScope.ServiceProvider;
            }
        }
        public virtual DbContext Context
           => ServiceProvider.GetRequiredService<DbContext>();
        public virtual void CreateDatabase()
        {
            Dispose();
            _connection = new SqliteConnection("Data Source=:memory:");
            _connection.Open();
            Context.Database.EnsureCreated();
        }
        public virtual void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
            _serviceScope?.Dispose();
            _serviceScope = null;
        }
        public virtual IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbContext>(b =>
                b.UseSqlite(_connection));

            return services;
        }
        
    }
}