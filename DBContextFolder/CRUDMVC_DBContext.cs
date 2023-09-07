using CRUDMVC.Models.Domain;
using Microsoft.EntityFrameworkCore;


namespace CRUDMVC.DBContextFolder

{
	public class CRUDMVC_DBContext : DbContext
	{
		public CRUDMVC_DBContext(DbContextOptions options) : base(options) // this constructor enables us pass the parameter to the base class
		{

		}
        public DbSet<Employee>  Employees { get; set; }

    }
}
