using System.ComponentModel.DataAnnotations;

namespace ISC_WebAPIDemo_Consume.Models
{
    public class Students
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }
        public string DOB { get; set; }
    }
}
