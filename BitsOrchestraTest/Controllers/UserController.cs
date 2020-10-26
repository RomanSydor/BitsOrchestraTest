using BitsOrchestraTest.Models;
using BitsOrchestraTest.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BitsOrchestraTest.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _repo;
        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        [Route("/User/AddToDb")]
        public IActionResult AddToDb()
        {
            _repo.AddUserToDb();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = _repo.GetUsers(x => true);
            return View(users);
        }

        [HttpGet]
        [Route("/User/Details/{id}")]
        public IActionResult Details([FromRoute]int id)
        {
            var user = _repo.GetUserByProp(x => x.Id == id);
            return View(user);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _repo.GetUserByProp(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var user = _repo.GetUserByProp(x => x.Id == id);
            _repo.DeleteUser(user);
            return RedirectToAction("Index", "User");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _repo.GetUserByProp(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,DateOfBirth,Married,Phone,Salary")]User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            var u = _repo.GetUserByProp(x => x.Id == id);
            _repo.EditUser(u, x =>
            {
                x.Name = user.Name;
                x.DateOfBirth = user.DateOfBirth;
                x.Married = user.Married;
                x.Phone = user.Phone;
                x.Salary = user.Salary;
            });
            return RedirectToAction("Details", "User", new User { Id = id });
        }
    }
}
