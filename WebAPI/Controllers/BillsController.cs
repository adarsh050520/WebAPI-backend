using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public BillsController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                
                select Id, UserId,TransactionId,
                            TransactionMode,
                        BillCost,
                        BillDate,BillStatus,BillingAddress 
                from dbo.Bills";

            //(select ProductName from dbo.Products where id=ProductId)
            //select FName from dbo.UserInfo where dbo.UserInfo=dbo.Orders.UserId
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

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Bills order)
        {
            string rDate = order.BillDate.ToString("yyyy/MM/dd");
            string query =
                
                @"
                    insert into dbo.Bills 
                    (UserId,TransactionId,TransactionMode,BillCost,BillDate,BillStatus,BillingAddress)
                    values 
                    (
                    '" + order.UserId + @"'
                    ,'" + order.TransactionId + @"'
                    ,'" + order.TransactionMode + @"'
                    ,'" + order.BillCost+ @"'                                
                    ,'" + rDate + @"'   
                    ,'" + order.BillStatus + @"'
                    ,'" + order.BillingAddress + @"'
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

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Bills order)
        {
            string query = @"
                    update dbo.Bills set 
                    UserId = '" + order.UserId + @"'
                    ,TransactionId = '" + order.TransactionId + @"'
                    ,TransactionMode = '" + order.TransactionMode + @"'
                    ,BillCost = '" + order.BillCost + @"'
                    ,BillDate = '" + order.BillDate + @"'
                    ,BillStatus = '" + order.BillStatus + @"'
                    ,BillingAddress = '" + order.BillingAddress + @"'

                    where Id = " + order.Id + @" 
                    ";
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

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {

                string query = @"
                    delete from dbo.Bills
                    where Id = " + id + @" 
                    ";
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

                return new JsonResult("Order Deleted Successfully");
            }
            catch (Exception )
            {

                throw ;
            }
        }

    }
}
