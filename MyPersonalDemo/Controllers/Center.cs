using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPersonalDemo.Models;
using DataEntities;


using System.ComponentModel.DataAnnotations;

namespace MyPersonalDemo.Controllers
{

    [Controller]
    public class Center : Controller
    {
        private  DataBase registered_people;

        public Center(DataBase db)
        {
            registered_people = db;
        }
       
         
        [Route("/")]
        public IActionResult ProjectInfo()
        {
            return View();
        }

        [Route("/home/welcome")]
        public IActionResult HomePage()
        {

            return View();
        }

        [Route("/login")]
        public IActionResult LoginPage()
        {

            return View();
        }

        [Route("/sign-in")]
        public IActionResult SigninPage()
        {
            SignInUserDataActive usd = new SignInUserDataActive();
            usd.SetDB(registered_people);
            return View(usd);
        }

        [Route("/Result")]
        public IActionResult Result(SignInUserDataActive u)

        {

            registered_people.Users.Add(u.ToUserData());
            registered_people.SaveChanges();
            

            return View(u);
        }

        [Route("/ack")]
        public IActionResult? Acknowledge(LogInUserDataActive log)
        {
            SignInUserData su=registered_people.Users?.FirstOrDefault(user => user.Email == log.Email);
            if (su == null)
            {
                return View(new Flag() { check = Ask.UnregisteredEmail });
            }
            if (su.Password != log.Password)
            {
                return View(new Flag() { check = Ask.PasswordMisMatch });
            }
            return View(new Flag() { check = Ask.CorrectPasswordCorrectEmail });





        }
    }
}
