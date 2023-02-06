namespace sber.Data
{
	public class DataContext : IdentityDbContext<Employee>
	{
		public DataContext(DbContextOptions<DataContext> context) : base(context)
		{

		}
		
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Ticket> Tickets { get; set; }
		public DbSet<Bank> Banks { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			

			modelBuilder.Entity<Ticket>(entity => {
				entity.Property(e => e.EmployeeId).HasColumnName("EmployeeId");
				entity.Property(e => e.PerformerId).HasColumnName("PerformerId");

				entity.HasOne(d => d.Employee)
				   .WithMany(p => p.TicketEmployees)
				   .HasForeignKey(d => d.EmployeeId)
				   .HasConstraintName("FK_ticket_employee");

				entity.HasOne(d => d.Performer)
					.WithMany(p => p.TicketPerformers)
					.HasForeignKey(d => d.PerformerId)
					.HasConstraintName("FK_ticket_performer");

			});
			base.OnModelCreating(modelBuilder);
		}

	



	}
}
