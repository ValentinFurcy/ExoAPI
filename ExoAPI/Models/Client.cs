using System.ComponentModel.DataAnnotations;

namespace ExoAPI.Models
{
    public class Client
    {
        [Required]
        public int Id {  get; set; }
        public string Name { get; set; }    
        public int Age {  get; set; }
    }
}
