using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SampleApp.Data;
using SampleApp.Data.Helpers;
using SampleApp.Models;
using System.Data;

namespace SampleApp.Controllers
{
    public class spSaleController : Controller
{
        private readonly ApplicationdbContext _context;

        public spSaleController(ApplicationdbContext context)
        {
            _context = context;
        }
            string conn = ConfigHelper.GetConnectionString("FirstConnection");


        [HttpPost]
        public IActionResult Range(DateTime? startDate, DateTime? endDate)
        {
            //input.startDate = startDate;
            //input.endDate = endDate;
            BuildQuery qb = new BuildQuery(conn);
            qb.SetInParam("@StartDate", startDate, SqlDbType.DateTime);
            qb.SetInParam("@EndDate", endDate, SqlDbType.DateTime);
            DataSet ds = qb.ExecuteDataset("spGetSalesReport", CommandType.StoredProcedure);
            //object data = new { salesReport = ds.Tables[0] };

            //using (SqlConnection sqlcon = new SqlConnection(conn))
            //{
            //    using (SqlCommand cmd = new SqlCommand("spGetSalesReport", sqlcon))
            //    {

            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@startDate", startDate);
            //        cmd.Parameters.AddWithValue("@endDate", endDate);
            //        sqlcon.Open();
            //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //        DataSet ds = new DataSet();
            //        sda.Fill(ds);
            List<SaleReport> data = new List<SaleReport>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                data.Add(new SaleReport
                {
                    Name = Convert.ToString(dr["Name"]),
                    ProductId = Convert.ToInt32(dr["ProductId"]),
                    Quantity = Convert.ToInt32(dr["Quantity"]),
                    TotalAmount = Convert.ToInt32(dr["TotalAmount"])
                });
            }


            ModelState.Clear();
            return Json(new { data });
        }   


            }



        }
 
        

    
    

    

