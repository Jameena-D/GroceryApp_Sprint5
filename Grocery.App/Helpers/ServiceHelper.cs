using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Grocery.App;

public static class ServiceHelper
{
    public static IServiceProvider Services { get; private set; } = null!;

    public static void Initialize(IServiceProvider services) => Services = services;

    public static T GetService<T>() where T : notnull =>
        Services.GetRequiredService<T>();
}

