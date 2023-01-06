using System.ComponentModel.DataAnnotations;

namespace sber.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Ticket> Ticket { get; set; }    
    }
}
