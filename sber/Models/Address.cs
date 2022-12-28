using System.ComponentModel.DataAnnotations;

namespace sber.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public ICollection<Ticket> Ticket { get; set; }    
    }
}
