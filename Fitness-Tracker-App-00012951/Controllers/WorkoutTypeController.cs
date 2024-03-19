using Fitness_Tracker_App_00012951.Models;
using Fitness_Tracker_App_00012951.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Fitness_Tracker_app.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WorkoutTypeController:ControllerBase
    {
        private readonly IRepository<WorkoutType> _repository;
        public WorkoutTypeController(IRepository<WorkoutType> repository)
        {
            _repository = repository;
        }







        // GET: api/<WorkoutTypeController>
        [HttpGet]
        public async Task<IEnumerable<WorkoutType>> Get()
        {
            return await _repository.GetAllAsync();
        }








        // GET api/<WorkoutTypeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var resultedWorkoutType = await _repository.GetByIDAsync(id);
            if (resultedWorkoutType == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(resultedWorkoutType);
            }
        }







        // POST api/<WorkoutTypeController>
        [HttpPost]
        public async Task<IActionResult> Create(WorkoutType workoutTypes)
        {
            await _repository.AddAsync(workoutTypes);
            return CreatedAtAction(nameof(GetByID), new { id = workoutTypes.ID }, workoutTypes);
        }







        // PUT api/<WorkoutTypeController>/5
        [HttpPut]
        public async Task<IActionResult> Update(WorkoutType workoutTypes)
        {
            //if(id!=items.ID) return BadRequest();
            await _repository.UpdateAsync(workoutTypes);
            return NoContent();
        }






        // DELETE api/<WorkoutTypeController>/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
