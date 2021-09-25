using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCProgmat.Models;
using MySql.Data.MySqlClient;
using System.Net;

namespace MVCProgmat.Controllers
{
    public class LoginDataController : Controller
    {
        public IActionResult Index()
        {
            List<LoginData> list1 = new List<LoginData>();
            string mainconn = "Server=mysql03.kacperosiadlo.beep.pl;Uid=mvcprogmat;Pwd=Admin2020!;Database=mvcprogmat;Port=3306;SslMode=none";
            MySqlConnection mysql = new MySqlConnection(mainconn);
            string query = "select * from Users";
            MySqlCommand comm = new MySqlCommand(query);
            comm.Connection = mysql;

            mysql.Open();
            MySqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                list1.Add(new LoginData
                {
                    Login = dr["Login"].ToString()
                });
            }
            mysql.Close();
            return View(list1);
        }
    }
}
