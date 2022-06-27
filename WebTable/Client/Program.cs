using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebTable.Client;
using WebTable.Client.Services;
using WebTable.Shared.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ITableService<TableColumn>, TableColumnService>();
builder.Services.AddScoped<ITableService<TableRow>, TableRowService>();
builder.Services.AddScoped<ITableService<TableItem>, TableItemService>();
builder.Services.AddScoped<ITableService<TableColumnType>, TableColumnTypeService>();

await builder.Build().RunAsync();
