

namespace sber.Data
{
	public class DataContext : IdentityDbContext<Employee>
	{
		public DataContext(DbContextOptions<DataContext> context) : base(context)
		{

		}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Ticket> Tickets { get; set; }
	}
}
