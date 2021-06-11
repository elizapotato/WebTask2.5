using System.ComponentModel.DataAnnotations;

namespace Web._931803.Chegodaeva.Lab5._1.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Specialization is required")]
        public string Specialization { get; set; }
    }
}