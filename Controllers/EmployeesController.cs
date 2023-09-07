using Microsoft.AspNetCore.Mvc;

namespace CRUDMVC.Controllers
{
	public class EmployeesController : Controller
	{
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
	}
}
