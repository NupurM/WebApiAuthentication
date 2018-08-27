using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;
using EmployeeDataAccess;

namespace EmployeeService.Controllers
{
    [EnableCors("*","*","*")]
    public class EmployeesController : ApiController
    {
        [BasicAuthentication]
        public HttpResponseMessage Get()
        {
            string username = Thread.CurrentPrincipal.Identity.Name;
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                switch (username.ToLower())
                {
                    case "male":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.Where(e => e.Gender == "male").ToList());
                    case "female":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.Where(e => e.Gender == "female").ToList());
                    default:
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
        }
    }
}