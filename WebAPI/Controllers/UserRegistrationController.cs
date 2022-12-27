using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace webapi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public UserRegistrationController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [Route("register")]
        [HttpPost]
        public JsonResult Post(UserInfo reg)
        {
            try
            {
                string query = @"
                insert into dbo.UserInfo
                    (Fname,Lname,Email,Password,Phone)
                    values
                    (
                        '" + reg.FName + @"'
                        , '" + reg.LName + @"'
                        , '" + reg.Email + @"'
                        , '" + reg.Password + @"'
                        , '" + reg.Phone + @"'
                        
                     )";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("DbCon");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);

                        myReader.Close();
                        myCon.Close();
                    }
                }
                
                return new JsonResult("Added");

            }
            catch (Exception)
            {

                throw;
            }

           
        }



    }
}

//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using WebAPI.Models;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LoginController : ControllerBase
//    {
//        private readonly IConfiguration _configuration;
//        private readonly IWebHostEnvironment _env;

//        public LoginController(IConfiguration configuration, IWebHostEnvironment env)
//        {
//            _configuration = configuration;
//            _env = env;
//        }


//        [HttpGet]
//        public JsonResult Get()
//        {
//            string query = @"
//                select Id, ProductName, Image, Cost, Description,UserId 
//                from dbo.Products";
//            DataTable table = new DataTable();
//            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
//            SqlDataReader myReader;
//            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
//            {
//                myCon.Open();
//                using (SqlCommand myCommand = new SqlCommand(query, myCon))
//                {
//                    myReader = myCommand.ExecuteReader();
//                    table.Load(myReader);

//                    myReader.Close();
//                    myCon.Close();
//                }
//            }

//            return new JsonResult(table);
//        }

//        [route("register")]
//        [httppost]
//        public jsonresult post(userinfo reg)
//        {
//            try
//            {
//                string query = @"
//                        insert into dbo.userinfo
//                            (fname,lname,email,phone,password)
//                            values
//                            (
//                                '" + reg.fname + @"'
//                                , '" + reg.lname + @"'
//                                , '" + reg.email + @"'
//                                , '" + reg.phone + @"'
//                                , '" + reg.password + @"'
//                             )";
//                datatable table = new datatable();
//                string sqldatasource = _configuration.getconnectionstring("employeeappcon");
//                sqldatareader myreader;
//                using (sqlconnection mycon = new sqlconnection(sqldatasource))
//                {
//                    mycon.open();
//                    using (sqlcommand mycommand = new sqlcommand(query, mycon))
//                    {
//                        myreader = mycommand.executereader();
//                        table.load(myreader);

//                        myreader.close();
//                        mycon.close();
//                    }
//                }

//                return new jsonresult("register successfully");

//            }
//            catch (exception)
//            {

//                throw;
//            }
//        }

//        [Route("SaveFile")]
//        [HttpPost]
//        public JsonResult SaveFile()
//        {
//            try
//            {
//                var httpRequest = Request.Form;
//                var postedFile = httpRequest.Files[0];
//                string filename = postedFile.FileName;
//                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

//                using (var stream = new FileStream(physicalPath, FileMode.Create))
//                {
//                    postedFile.CopyTo(stream);
//                }

//                return new JsonResult(filename);
//            }
//            catch (Exception)
//            {
//                return new JsonResult("Error");
//            }
//        }


//        [HttpPut]
//        public JsonResult Put(Products product)
//        {
//            string query = @"
//                    update dbo.Products set 
//                    ProductName = '" + product.ProductName + @"'
//                    ,Image = '" + product.Image + @"'
//                    ,Cost = '" + product.Cost + @"'
//                    ,Description = '" + product.Description + @"'
//                    ,UserId = '" + product.UserId + @"'

//                    where Id = " + product.Id + @" 
//                    ";
//            DataTable table = new DataTable();
//            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
//            SqlDataReader myReader;
//            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
//            {
//                myCon.Open();
//                using (SqlCommand myCommand = new SqlCommand(query, myCon))
//                {
//                    myReader = myCommand.ExecuteReader();
//                    table.Load(myReader);

//                    myReader.Close();
//                    myCon.Close();
//                }
//            }

//            return new JsonResult("Updated Successfully");
//        }

//        [HttpDelete("{id}")]
//        public JsonResult Delete(int id)
//        {
//            string query = @"
//                    delete from dbo.Products
//                    where Id = " + id + @" 
//                    ";
//            DataTable table = new DataTable();
//            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
//            SqlDataReader myReader;
//            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
//            {
//                myCon.Open();
//                using (SqlCommand myCommand = new SqlCommand(query, myCon))
//                {
//                    myReader = myCommand.ExecuteReader();
//                    table.Load(myReader);

//                    myReader.Close();
//                    myCon.Close();
//                }
//            }

//            return new JsonResult("Deleted Successfully");
//        }


//    }
//}

