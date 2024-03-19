using Fitness_Tracker_App_00012951.Data;
using Fitness_Tracker_App_00012951.Models;
using Fitness_Tracker_App_00012951.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Fitness_Tracker_app.Repositories
{
    public class WorkoutRepository : IRepository<Workout>
    {
        private readonly GeneralDBContext _context;

        public WorkoutRepository(GeneralDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Workout>> GetAllAsync() => await _context.Workouts.ToArrayAsync();

        public async Task<Workout> GetByIDAsync(int id)
        {
            return await _context.Workouts.Include(t => t.WorkoutType).FirstOrDefaultAsync(t => t.ID == id);
        }

        public async Task AddAsync(Workout entity)
        {
            entity.WorkoutType = await _context.WorkoutTypes.FindAsync(entity.WorkoutTypeID.Value);
            /*  entity.WorkoutType = new WorkoutType {
                  ID = entity.WorkoutTypeID.Value,
                  Name = _context.WorkoutTypes.FindAsync(entity.WorkoutTypeID).ToString()
          };*/


            await _context.Workouts.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Workout entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Workouts.FindAsync(id);
            if (entity != null)
            {
                _context.Workouts.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}


