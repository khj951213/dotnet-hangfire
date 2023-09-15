// See https://aka.ms/new-console-template for more information
using dotnet_hangfire_example;
using Hangfire;
using Hangfire.Common;
using Hangfire.MySql.Core;
var connectionString = "";
GlobalConfiguration.Configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseStorage(new MySqlStorage(connectionString, new MySqlStorageOptions()
    {
        TransactionIsolationLevel = System.Data.IsolationLevel.ReadCommitted, // transaction isolation level. Default is read committed
        QueuePollInterval = TimeSpan.FromSeconds(15), // job queue polling interval. Default is 15 seconds
        JobExpirationCheckInterval = TimeSpan.FromSeconds(15), // job expiration check inteval. Default 1 hour
        CountersAggregateInterval = TimeSpan.FromMinutes(5), // interval to aggrgate counter. Default is 5 minutes.
        PrepareSchemaIfNecessary = true, // if set to true, it creates database tables. Default is true
        DashboardJobListLimit = 50000, // dashboard job list limit. Default is 50000
        TransactionTimeout = TimeSpan.FromMinutes(1), // transaction timeout. Default is 1 minute.
        TablePrefix = "Hangfire"
    }));


int num = 0;
using (var server = new BackgroundJobServer())
{
    var manager = new RecurringJobManager();
    manager.AddOrUpdate("test", () => Console.WriteLine("Recurring"), "*/1 * * * * *");
    while (true)
    {

    }
}


void PrintHello()
{
    num += 1;
}