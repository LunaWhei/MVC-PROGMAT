using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_PROGMAT.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace MVC_PROGMAT.Controllers
{
    public class LoginController : Controller
    {
        MySqlConnection cn;
        MySqlDataAdapter da;
        DataSet ds;

        void DbConnect(string Login)
        {
            cn = new MySqlConnection("server=mysql03.kacperosiadlo.beep.pl;uid=mvcprogmat;pwd=Admin2020!;database=mvcprogmat");
            
            da = new MySqlDataAdapter("SELECT * FROM `Users` WHERE `Login` = '"+Login+"'", cn);
            ds = new DataSet();
            da.Fill(ds, "logins");
            ViewData["string"] = ds.Tables["logins"];
        }



        [HttpGet]
        public IActionResult Login()
        {
            DbConnect("Admin");
            return View();
            
        }

        [HttpPost]
        public IActionResult VerifyUser(LoginModel user)
        {
            DbConnect(user.Login);
            return View();
        }
    }
}
