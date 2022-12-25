using System.Net;

namespace sber.Data
{
	public class Seed
	{
		public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
		{
			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
				// Roles 
				var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

				if (!await roleManager.RoleExistsAsync(EmployeeRoles.Admin))
					await roleManager.CreateAsync(new IdentityRole(EmployeeRoles.Admin));

				if (!await roleManager.RoleExistsAsync(EmployeeRoles.Engineer))
					await roleManager.CreateAsync(new IdentityRole(EmployeeRoles.Engineer));

				if (!await roleManager.RoleExistsAsync(EmployeeRoles.Client))
					await roleManager.CreateAsync(new IdentityRole(EmployeeRoles.Client));

				//Users
				var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<Employee>>();

				string adminEmail = "vipmen5555@gmail.com";

				var admin = await userManager.FindByEmailAsync(adminEmail);

				if (admin == null)
				{
					var newAdmin = new Employee()
					{
						UserName = "admin",
						Surname = "Ятченко",
						Name = "Андрей",
						Patronymic = "Сергеевич",
						Email = adminEmail,
						EmailConfirmed = true,				

					};
					await userManager.CreateAsync(newAdmin, "Coding@1234?");
					await userManager.AddToRoleAsync(newAdmin, EmployeeRoles.Admin);
				}

				string EngineerEmail = "Engineer@gmail.com";
				var Engineer = await userManager.FindByEmailAsync(EngineerEmail);

				if (Engineer == null)
				{
					var newEngineer = new Employee()
					{
						UserName = "Engineer",
						Surname = "Малянов",
						Name = "Егор",
						Patronymic = "Вячеславович",
						Email = EngineerEmail,
						EmailConfirmed = true,
					};
					await userManager.CreateAsync(newEngineer, "Coding@1234?");
					await userManager.AddToRoleAsync(newEngineer, EmployeeRoles.Engineer);
				}

				string ClientEmail = "Client@gmail.com";
				var Client = await userManager.FindByEmailAsync(ClientEmail);

				if (Client == null)
				{
					var newClient = new Employee()
					{
						UserName = "Client",
						Surname = "Иванов",
						Name = "Иван",
						Patronymic = "Иванович",
						Email = ClientEmail,
						EmailConfirmed = true,
					};
					await userManager.CreateAsync(newClient, "Coding@1234?");
					await userManager.AddToRoleAsync(newClient, EmployeeRoles.Client);
				}
			}
		}
	}
}
