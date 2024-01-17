using System.ComponentModel.DataAnnotations;

namespace ExoAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        public Client client { get; set; }
        public int ClientId { get; set; }
    }
}
