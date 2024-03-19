using System.ComponentModel.DataAnnotations;

namespace Fitness_Tracker_App_00012951.Models
{
    public class WorkoutType
    {
        public int ID { get; set; }
        private string _name ;
        [Required(ErrorMessage = "Name is required")]
        public string Name 
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty.");
                }
                _name = value;
            } 
        }
    }
}
