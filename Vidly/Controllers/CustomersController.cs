using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    [Authorize(Roles = RoleName.CanManageMovies)]
    public class CustomersController : Controller
    {
        // GET: Customers
        private ApplicationDbContext _context;

        public CustomersController() // Constructor
        {
            _context = new ApplicationDbContext(); // context initialization in constructor
        }

        protected override void Dispose(bool disposing) // overriding Dispose unmenaged resurses
        {
            _context.Dispose();    
        }
        
        public ActionResult Index()
        {
                return View();
        }
        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            
            var viewModel = new CustumerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customerFromDataBase = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerFromDataBase == null)
                return HttpNotFound();
            
            var viewModel = new CustumerFormViewModel
            {
                Customer = customerFromDataBase,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustumerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                    // Or Mapper.Map(customer,customerInDb);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}