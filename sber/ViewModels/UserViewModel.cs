using Microsoft.AspNetCore.Authentication;
using System.Globalization;

namespace sber.ViewModels
{
	public class UserViewModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Patronymic { get; set; }
		public string ProfileImageUrl { get; set; }
		public IEnumerable<string> Roles { get; set; }


	}
}
