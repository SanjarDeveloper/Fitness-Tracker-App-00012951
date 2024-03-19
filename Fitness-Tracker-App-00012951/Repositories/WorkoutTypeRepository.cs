using Fitness_Tracker_App_00012951.Data;
using Fitness_Tracker_App_00012951.Models;
using Fitness_Tracker_App_00012951.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fitness_Tracker_app.Repositories
{
    public class WorkoutTypeRepository:IRepository<WorkoutType>
    {
        private readonly GeneralDBContext _context;

        public WorkoutTypeRepository(GeneralDBContext context)
        {
            _context = context;
        }

        // Add or create new entity
        public async Task AddAsync(WorkoutType workoutTypes)
        {
            await _context.WorkoutTypes.AddAsync(workoutTypes);
            await _context.SaveChangesAsync();
        }

        // Delete an entity
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.WorkoutTypes.FindAsync(id);
            if (entity != null)
            {
                _context.WorkoutTypes.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        // Retrieve all entity from the database
        public async Task<IEnumerable<WorkoutType>> GetAllAsync() => await _context.WorkoutTypes.ToArrayAsync();

        // Retrieve an entity from database using only an id
        public async Task<WorkoutType> GetByIDAsync(int id) => await _context.WorkoutTypes.FindAsync(id);

        // Update the entity
        public async Task UpdateAsync(WorkoutType workoutTypes)
        {
            _context.Entry(workoutTypes).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
