using BugStore.Application.Services;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddApplicationModule();