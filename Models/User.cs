using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using ProjectMVC.Models;

namespace ProjectMVC.Models
{
    public class User
    {
        


        public int Id { get; set; }
        public string Name { get; set; }

        public Int64 Phone { get; set; }  

        public string Email { get; set; }

        public string CountryName { get; set; }
        public string AllBind { get; set; }

        public string StateName { get; set; }

        public string CityName { get; set; }

        public string Password { get; set; }

        public int CountryId { get; set; }

        public int StateId { get; set; }

        public int CityId { get; set; }

       public List<User> Users { get; set; }

        public List<User> Locationlist { get; set; }

    }
}