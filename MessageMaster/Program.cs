var host = Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(builder => { builder.UseStartup<Startup>(); })
    .Build();

host.Run();
