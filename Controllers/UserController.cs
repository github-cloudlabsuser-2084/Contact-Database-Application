using CRUD_application_2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index()
        {
            // Implement the Index method here
            // This method is responsible for displaying the list of users.
            // It retrieves the list of users from the userlist and passes it to the Index view.
            return View(userlist);

        }
 
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Implement the details method here
            User user = userlist.FirstOrDefault(x => x.Id == id);
            return View(user);
        }
 
        // GET: User/Create
        public ActionResult Create(string name, string email)
        {
            //Implement the Create method here
            // This method is responsible for displaying the view to create a new user.
            // It returns the Create view, which contains a form to input user details.
            // If an error occurs during the process, it returns the Create view to display any validation errors.
            return View();
           
        }
 
        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            // Implement the Create method (POST) here
            // This method is responsible for handling the HTTP POST request to create a new user.
            // It receives user input from the form submission and adds the new user to the userlist.   
            // If successful, it redirects to the Index action to display the updated list of users.
            // If an error occurs during the process, it returns the Create view to display any validation errors.
            userlist.Add(user);
            return RedirectToAction("Index");  
        }
 
        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // This method is responsible for displaying the view to edit an existing user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Edit view.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            // If an error occurs during the process, it returns the Edit view to display any validation errors.
            User user = userlist.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return HttpNotFound();
            } else
            {
                return View(user);
            }
        }
 
        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
            // It receives user input from the form submission and updates the corresponding user's information in the userlist.
            // If successful, it redirects to the Index action to display the updated list of users.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            // If an error occurs during the process, it returns the Edit view to display any validation errors.
            User existingUser = userlist.FirstOrDefault(x => x.Id == id);
            if (existingUser == null)
            {
                return HttpNotFound();
            }
            else
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                return RedirectToAction("Index");
            }
        }
 
        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Implement the Delete method here
            // This method is responsible for displaying the view to delete an existing user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Delete view.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            // If an error occurs during the process, it returns the Delete view to display any validation errors.
            User user = userlist.FirstOrDefault(x => x.Id == id);
            userlist.RemoveAll(x => x.Id == id);
            return RedirectToAction("Index"); 
        }
 
        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Implement the Delete method (POST) here
            // This method is responsible for handling the HTTP POST request to delete an existing user with the specified ID.
            // It removes the user from the userlist based on the provided ID.
            // If successful, it redirects to the Index action to display the updated list of users.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            // If an error occurs during the process, it returns the Delete view to display any validation errors.
            User user = userlist.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            else
            {
                userlist.Remove(user);
                return RedirectToAction("Index");
            }
        }

        // GET: api/User/SearchByFirstName?firstName=Alice
        public ActionResult SearchByName(string name)
        {
            var users = userlist.Where(u => u.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));

            return View(users);
        }
    }
}
