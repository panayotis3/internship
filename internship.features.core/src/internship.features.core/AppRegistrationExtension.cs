using Data;
using internship.features.core.Services;
using internship.features.core.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace internship.features.core
{
    public static class AppRegistrationExtension
    {
        public static IHostApplicationBuilder AddApllixationRegistration(this IHostApplicationBuilder builder)
        {

            // Add EF Core DbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
            return builder;
        }
    }
}
