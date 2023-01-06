using System.Security.Claims;

namespace sber
{
	public static class ClaimsPrincipalExtensions
	{
		public static string GetUserId(this ClaimsPrincipal user)
		{
			return user.FindFirst(ClaimTypes.NameIdentifier).Value;
		}
	}
}
