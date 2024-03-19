using Fitness_Tracker_App_00012951.Models;
using Microsoft.EntityFrameworkCore;

namespace Fitness_Tracker_App_00012951.Data
{
    public class GeneralDBContext:DbContext
    {
        public GeneralDBContext(DbContextOptions<GeneralDBContext> options) : base(options) { }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutType> WorkoutTypes { get; set; }
    }
}
