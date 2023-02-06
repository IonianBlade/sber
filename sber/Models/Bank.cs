namespace sber.Models
{
	public class Bank
	{
		public int Id { get; set; }
		public string City { get; set; }
		public string Street { get; set; }
		public string House { get; set; }
		public string Index { get; set; }
		public string PhoneNumber { get; set; }
		public ICollection<Ticket> Tickets { get; set; }
		

	}
}
