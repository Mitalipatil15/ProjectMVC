using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMVC.Models
{
    public class BALUser
    {

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-4MS3KTQO;Initial Catalog=MVCDb;Integrated Security=True");


        public void Register( int ID,string Name, Int64 Phone, string Email,  int CityId, string Password)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVCSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Register");
            cmd.Parameters.AddWithValue("@Id", ID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@CityId", CityId);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.ExecuteNonQuery();
            con.Close();
          }



        public DataSet GetCountry()
        {
            SqlCommand cmd = new SqlCommand("MVCSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetCountry");
            //cmd.Parameters.AddWithValue("@flag", "GetState");
            SqlDataAdapter adpt =new SqlDataAdapter();
            adpt.SelectCommand= cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }
        public DataSet GetState(int CountryId)
        {
            SqlCommand cmd = new SqlCommand("MVCSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetState");
            cmd.Parameters.AddWithValue("@CountryId", CountryId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand=cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }
        public DataSet GetCity(int StateId)
        {
            SqlCommand cmd = new SqlCommand("MVCSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetCity");
            cmd.Parameters.AddWithValue("@StateId", StateId);

            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand=cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }

        public DataSet GetData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVCSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetData");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand=cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }
        public DataSet GetFilter(int CityId)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVCSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetFilter");
            cmd.Parameters.AddWithValue("@CityId", CityId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand=cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }
        public SqlDataReader Fetch(int Id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVCSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "Fetch");
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataReader dr;
            dr=cmd.ExecuteReader();
            return dr;
            con.Close();
        }
        [HttpGet]
        public void Update(int ID, string Name, Int64 Phone, string Email, int CityId, string Password)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVCSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Update");
            cmd.Parameters.AddWithValue("@Id", ID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@CityId", CityId);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Delete(int ID)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVCSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Delete");
            cmd.Parameters.AddWithValue("@Id", ID);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataSet GetLocation()
        {
            SqlCommand cmd = new SqlCommand("MVCSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Location");
            //cmd.Parameters.AddWithValue("@flag", "GetState");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand= cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }

    }
}