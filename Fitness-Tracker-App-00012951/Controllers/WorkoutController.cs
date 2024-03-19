using Fitness_Tracker_App_00012951.Data;
using Fitness_Tracker_App_00012951.Models;
using Fitness_Tracker_App_00012951.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Fitness_Tracker_App_00012951.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WorkoutController:ControllerBase
    {
        private readonly IRepository<Workout> _workoutsRepository;
        public WorkoutController(IRepository<Workout> toDoItemsRepository)
        {
            _workoutsRepository = toDoItemsRepository;
        }










        [HttpGet]
        public async Task<IEnumerable<Workout>> GetAll() => await _workoutsRepository.GetAllAsync();














        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Workout), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByID(int id)
        {
            var resultedWorkouts = await _workoutsRepository.GetByIDAsync(id);
            return resultedWorkouts == null ? NotFound() : Ok(resultedWorkouts);
        }
















        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Workout workouts)
        {
            await _workoutsRepository.AddAsync(workouts);
            return Ok(workouts);
            //return CreatedAtAction(nameof(GetByID), new { id = items.ID }, items);
        }













        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Workout workouts)
        {
            //if(id!=items.ID) return BadRequest();
            await _workoutsRepository.UpdateAsync(workouts);
            return NoContent();
        }












        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _workoutsRepository.DeleteAsync(id);
            return NoContent();


        }
    }
}
