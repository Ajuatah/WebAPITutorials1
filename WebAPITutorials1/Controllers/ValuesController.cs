using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace WebAPITutorials1.Controllers
{
    public class ValuesController : ApiController
    {
        SqlConnection con = new SqlConnection(@"server=DESKTOP-64OPCUB\SQLEXPRESS; database=TestCustomer; Integrated Security =true;");    
        // GET api/values
        public string  Get()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Customer",con); 
            DataTable dt = new DataTable(); 
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
            {
                return "No Data found";
            }
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Customer WHERE id  ='"+id+"'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
            {
                return "No Data found";
            }
            // return "value";
        }

        // POST api/values
        public string Post([FromBody] string value)
        {
            //return value + " added successfully "
            SqlCommand cmd = new SqlCommand("Insert into Customer(Name) VALUES('"+value+"')", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if(i == 1)
            {
                return "Record inserted with value as " + value; 

            }
            else
            {
                return "Try Again. No data inserted";
            }
;        }

        // PUT api/values/5
        public  string  Put(int id, [FromBody] string value)
        {
            //return " Reclord updated successfully" +id;
            SqlCommand cmd = new SqlCommand("UPDATE Customer SET Name='"+value+"' WHERE ID ='"+id+"'",con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return "Record updated with the value as  "+value+ "and id as"+id;
            }
            else
            {
                return "Try again. No data inserted";
            }
        }

        // DELETE api/values/5
        public string  Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Customer WHERE ID ='"+id+"'",con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return "Record deleted with the id as  " + id;
            }
            else
            {
                return "Try again. No data deleted ";
            }
            //delete at postman expect only ID
            //return "Record  deleted successfuly with ID" + id;
        }
    }
}
