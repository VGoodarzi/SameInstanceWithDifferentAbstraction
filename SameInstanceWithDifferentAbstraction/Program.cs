using Microsoft.Extensions.DependencyInjection;
using SameInstanceWithDifferentAbstraction;

Console.WriteLine("++++++++ Scenario 1 ++++++++");
ProcessScenario1();

Console.WriteLine();
Console.WriteLine();

Console.WriteLine("++++++++ Scenario 2 ++++++++");
ProcessScenario2();

void ProcessScenario1()
{
    var services = new ServiceCollection();

    services.AddSingleton<IDataWriter, DataProvider>();
    services.AddSingleton<IDataReader, DataProvider>();

    Test(services);
}

void ProcessScenario2()
{
    var services = new ServiceCollection();

    services.AddSingleton<DataProvider>();
    services.AddSingleton<IDataWriter>(sp => sp.GetRequiredService<DataProvider>());
    services.AddSingleton<IDataReader>(sp => sp.GetRequiredService<DataProvider>());

    Test(services);
}

void Test(ServiceCollection services)
{
    var sp = services.BuildServiceProvider();

    var writer = sp.GetRequiredService<IDataWriter>();
    var reader = sp.GetRequiredService<IDataReader>();

    var entry = new DataModel(1, "This is Data");
    writer.Add(entry);

    var data = reader.Get(1);

    Console.WriteLine(entry.Equals(data)
        ? "The fetched data is the same with entry object."
        : "The fetched data is not the same.");
}
