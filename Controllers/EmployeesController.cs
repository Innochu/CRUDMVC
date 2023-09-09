using CRUDMVC.DBContextFolder;
using CRUDMVC.Models;
using CRUDMVC.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CRUDMVC.Controllers
{
	public class EmployeesController : Controller
	{
        private readonly CRUDMVC_DBContext _cRUDMVCDBContext;    //we will use this private teadonly field to talk to our data base

        public EmployeesController(CRUDMVC_DBContext cRUDMVCDBContext)     // we created a constructor and inject the injected service here in the controller constructor
        {
            _cRUDMVCDBContext = cRUDMVCDBContext;
        }

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var employees = await _cRUDMVCDBContext.Employees.ToListAsync();
			return View(employees);
		}

        [HttpGet]
		public IActionResult Add()            //where did IActionResult come from?
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Add(AddNewEmployee addEmployeeRequest)
		{
            // Create a new Employee object
            var employee = new Employee()
			{
				Id = Guid.NewGuid(),
					Name = addEmployeeRequest.Name,
					Email = addEmployeeRequest.Email,
					Salary = addEmployeeRequest.Salary,
					DateOfBirth = addEmployeeRequest.DateOfBirth,
					Department = addEmployeeRequest.Department,

                // Here, you would typically add the 'employee' object to a database or data store.
                // You can use Entity Framework, ADO.NET, or any other data access technology.

                // Assuming you have added the employee successfully, you can return a response.
                // You might also want to handle any errors that occur during the addition process.



            };

			await _cRUDMVCDBContext.Employees.AddAsync(employee); // _cRUDMVCDBContext is the injection of the DBContext and now it it interacting with our employee table now
			await _cRUDMVCDBContext.SaveChangesAsync();
			//usually after this line of code that saves our user input in the database,
			//there would be a follow up line of code that would direct the user to the home page after successfully login in,
			//here we will direct it back to the add method  so we  can keep adding


			return RedirectToAction("Add");

    //The RedirectToAction method in ASP.NET MVC is used to redirect a user to a different 
				//action within the same controller or to a different controller.
				//In your case, you want to redirect to the "Add" action.Here's how you can use it:
        }
        }
}
