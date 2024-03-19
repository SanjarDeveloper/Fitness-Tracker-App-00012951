using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitness_Tracker_App_00012951.Models
{
    public class Workout
    {
        [Required]
        public int ID { get; set; }
        
        [Required(ErrorMessage = "Duration is required")]
        public double? Duration { get; set; }
        
        [Required(ErrorMessage = "Burned Calories is required")]
        public double? Calories_burned{ get; set; }
        
        public int? WorkoutTypeID{ get; set; }
        
        [ForeignKey("WorkoutTypeID")]
        public WorkoutType? WorkoutType{ get; set; }


    }
}
