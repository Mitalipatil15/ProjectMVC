using ProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;




namespace ProjectMVC.Controllers
{
    public class AdminController : Controller
    {
        public List<User> Users { get; set; }
        
        // GET: Admin
        public ActionResult Index()
        {
            Location();
           
            
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            Location();
            Show();


            return View();
        }
        [HttpPost]
        public ActionResult Register(User obj)
        {
            BALUser objB = new BALUser();
            objB.Register(obj.Id,obj.Name, obj.Phone, obj.Email, obj.CityId, obj.Password);
           // return View("Register");
           return RedirectToAction("Register");

        }

        //public void Country_Bind()
        //{
        //    BALUser objB = new BALUser();
        //    User obj = new User();
        //    DataSet ds = objB.GetCountry();
        //    List<SelectListItem>
        //    Countrylist = new List<SelectListItem>();
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        Countrylist.Add(new SelectListItem
        //        {
        //            Text=dr["CountryName"].ToString(),
        //            Value=dr["CountryId"].ToString()
        //        });
        //    }
        //    ViewBag.Country = Countrylist;
        //}
        public void Location()
        {
            BALUser objB = new BALUser();
            User obj = new User();
            DataSet ds = objB.GetLocation();
            List<SelectListItem>
            Locationlist = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Locationlist.Add(new SelectListItem
                {
                    Text=dr["Location"].ToString(),
                    Value=dr["CityId"].ToString()
                });
            }
            ViewBag.AllBind = Locationlist;
        }

        //public void State_Bind()
        //{
        //    BALUser objB = new BALUser();
        //    User objU = new User();
        //    DataSet ds = objB.GetState(objU.CountryId);

        //    List<SelectListItem>
        //    StateList = new List<SelectListItem>();
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        StateList.Add(new SelectListItem
        //        {
        //            Text=dr["StateName"].ToString(),
        //            Value=dr["StateId"].ToString()
        //        });
        //    }
        //    ViewBag.StateName = StateList;



            //       }
            public JsonResult State_Bind(int CountryId)
        {
            BALUser objB = new BALUser();
            DataSet ds = objB.GetState(CountryId);
            List<SelectListItem>
            Statelist = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Statelist.Add(new SelectListItem
                {
                    Text=dr["StateName"].ToString(),
                    Value=dr["StateId"].ToString()
                });

            }

            return Json(Statelist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult City_Bind(int StateId)
        {
            BALUser objB = new BALUser();
            DataSet ds = objB.GetCity(StateId);
            List<SelectListItem>
            Citylist = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Citylist.Add(new SelectListItem
                {
                    Text=dr["CityName"].ToString(),
                    Value=dr["CityId"].ToString()
                });

            }

            return Json(Citylist, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Show()                                                  //DataTable
        {
            Location();
            BALUser objB = new BALUser();
            DataSet ds = new DataSet();
            ds=objB.GetData();
            User objDetails = new User();
            List<User> lsUserDt1 = new List<User>();
            for (int i = 0; i<ds.Tables[0].Rows.Count; i++)
            {
                User obju = new User();
                obju.Id=Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                obju.Name=ds.Tables[0].Rows[i]["Name"].ToString();
                obju.Email=ds.Tables[0].Rows[i]["Email"].ToString();
                obju.Phone=Convert.ToInt64(ds.Tables[0].Rows[i]["Phone"].ToString());                
                obju.CountryName=ds.Tables[0].Rows[i]["CountryName"].ToString();
                obju.StateName=ds.Tables[0].Rows[i]["StateName"].ToString();
                obju.CityName=ds.Tables[0].Rows[i]["CityName"].ToString();
                obju.Password=ds.Tables[0].Rows[i]["Password"].ToString();
                lsUserDt1.Add(obju);
            }
            objDetails.Users=lsUserDt1;

            return View(objDetails);


        }
        public JsonResult GetFilter(int id)                                                  //DataTable
        {
            Location();
            BALUser objB = new BALUser();
            DataSet ds = new DataSet();
            ds=objB.GetFilter(id);
            User objDetails = new User();
            List<User> lsUserDt1 = new List<User>();
            for (int i = 0; i<ds.Tables[0].Rows.Count; i++)
            {
                User obju = new User();
                obju.Id=Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                obju.Name=ds.Tables[0].Rows[i]["Name"].ToString();
                obju.Email=ds.Tables[0].Rows[i]["Email"].ToString();
                obju.Phone=Convert.ToInt64(ds.Tables[0].Rows[i]["Phone"].ToString());
                obju.CountryName=ds.Tables[0].Rows[i]["CountryName"].ToString();
                obju.StateName=ds.Tables[0].Rows[i]["StateName"].ToString();
                obju.CityName=ds.Tables[0].Rows[i]["CityName"].ToString();
                obju.Password=ds.Tables[0].Rows[i]["Password"].ToString();
                lsUserDt1.Add(obju);
            }
            objDetails.Users=lsUserDt1;

            return Json(lsUserDt1,JsonRequestBehavior.AllowGet);


        }
        //[HttpGet]
        //public ActionResult Edit(int Id)                                                  //DataTable
        //{
        //    User objB = new User();
        //    objB.Id = Id;
        //    BALUser objC = new BALUser();
        //    SqlDataReader dr;
        //    dr=objC.Fetch(objB.Id);
        //    while (dr.Read())
        //    {
        //        objB.Id=Convert.ToInt32(dr["Id"].ToString());
        //        objB.Name=dr["Name"].ToString();
        //        objB.Email=dr["Email"].ToString();
        //        objB.Phone=Convert.ToInt64(dr["Phone"].ToString());
        //        objB.CountryName=dr["CountryName"].ToString();
        //        objB.StateName=dr["StateName"].ToString();
        //        objB.CityName=dr["CityName"].ToString();
        //        objB.Password=dr["Password"].ToString();

        //    }
        //    dr.Close();
        //    return View(objB);


        //}
        [HttpGet]
        public ActionResult Edit(int Id)                                                   // Fetch Data on click of Edit link
        {
            Location();
            User objB = new User();
            objB.Id = Id;
            BALUser objC = new BALUser();
            SqlDataReader dr;
            dr=objC.Fetch(objB.Id);
            while (dr.Read())
            {
                objB.Id=Convert.ToInt32(dr["ID"].ToString()); 
                objB.Name=dr["Name"].ToString();
                objB.Email=dr["Email"].ToString();
                objB.Phone=Convert.ToInt64(dr["Phone"].ToString());
                objB.CountryName=dr["CountryName"].ToString();
                objB.StateName=dr["StateName"].ToString();
                objB.CityName=dr["CityName"].ToString();
                objB.Password=dr["Password"].ToString();

            }
            dr.Close();
            return View(objB);
        }
        public ActionResult Update(User obj)
        {
            BALUser objB = new BALUser();
            objB.Register(obj.Id, obj.Name, obj.Phone, obj.Email, obj.CityId, obj.Password);
            // return View("Register");
            return RedirectToAction("Register");

        }
        public ActionResult Delete(User obj)
        {
            BALUser objB = new BALUser();
            objB.Delete(obj.Id);
            // return View("Register");
            return RedirectToAction("Register");
            

        }
        [HttpGet]
        public ActionResult Details(int Id)                                                   // Fetch Data on click of Edit link
        {
           // Country_Bind();
            User objB = new User();
            objB.Id = Id;
            BALUser objC = new BALUser();
            SqlDataReader dr;
            dr=objC.Fetch(objB.Id);
            while (dr.Read())
            {
                objB.Id=Convert.ToInt32(dr["ID"].ToString());
                objB.Name=dr["Name"].ToString();
                objB.Email=dr["Email"].ToString();
                objB.Phone=Convert.ToInt64(dr["Phone"].ToString());
                objB.CountryName=dr["CountryName"].ToString();
                objB.StateName=dr["StateName"].ToString();
                objB.CityName=dr["CityName"].ToString();
                objB.Password=dr["Password"].ToString();

            }
            dr.Close();
            return PartialView(objB);
        }

       

        



    }
}
    

