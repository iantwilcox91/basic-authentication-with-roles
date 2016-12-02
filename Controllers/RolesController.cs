using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BasicAuthentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BasicAuthentication.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860


namespace BasicAuthentication.Controllers
{
    public class RolesController : Controller
    {
        // GET: /<controller>/
        private readonly ApplicationDbContext _db;
        public RolesController(ApplicationDbContext db)
        {
            _db = db;
        }
            public IActionResult Index()
        {
            return View();
        }
        //as of right now (12/1/16 2:11pm) there is no index view^^^^^
        // GET: /Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Roles/Create
        [HttpPost]
        public IActionResult Create(RolesViewModel model)
        {
            try
            {
                
                //context should be DB\
                var newIdentityRole = new IdentityRole() { Name = model.Name };
                _db.Roles.Add(newIdentityRole);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
