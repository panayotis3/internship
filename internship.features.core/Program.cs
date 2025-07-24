using Data;
using Microsoft.EntityFrameworkCore;
using internship.features.core.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register your services here
builder.Services.AddScoped<ITournamentService, TournamentService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<ITeamMemberService, TeamMemberService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IRefereeService, RefereeService>();
builder.Services.AddScoped<IStadiumService, StadiumService>();
builder.Services.AddScoped<IJunctionTournamentService, JunctionTournamentService>();
builder.Services.AddScoped<IStandingService, StandingService>();
builder.Services.AddScoped<IFictureService, FictureService>();
builder.Services.AddScoped<IGoalService, GoalService>();
builder.Services.AddScoped<ICardService, CardService>();


// Add EF Core DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
