using STGchannelMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace STGchannelMVC.Controllers
{
    [System.Web.Script.Services.ScriptService]
    [Authorize(Roles = "Admin, SuperAdmin, Logistiikka-asiakas")]
    public class LogistiikkaController : Controller
    {
        private Test_jvspkkEntities db = new Test_jvspkkEntities();

        // GET: Logistiikka
        public ActionResult Index()
        {
            return View(db.q_import_bp);
        }
        public ActionResult AddPO()
        {
            return View(db.q_import_bp);
        }
        public JsonResult InsertPB(List<q_import_bp> insertbps)
        {
            {
                //Loop and insert records.
                foreach (q_import_bp importbp in insertbps)
                {
                    db.q_import_bp.Add(importbp);
                }
                int insertedRecords = db.SaveChanges();
                return Json(insertedRecords);
            }
        }

        // 
        //public class Get_next_tranid : System.Web.Services.WebService
        public class Get_next_tranid
        {

        }
        
        //public ChangePO AddPOnum(ChangePO cpo, int foretagkod, int tranid)
        public string AddPOnum(int foretagkod)
        {
            
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "q_get_next_tranid";
            cmd.Parameters.AddWithValue("@foretagkod", foretagkod);
            cmd.Parameters.Add("@tranid", SqlDbType.BigInt);
            cmd.Parameters["@tranid"].Direction = ParameterDirection.Output;
            conn.Open();

            cmd.ExecuteNonQuery();
           
           int @tranid = Convert.ToInt32(cmd.Parameters["@tranid"].Value);
            conn.Close();
            return @tranid.ToString();
        }

        public class ChangePO
        {
            public int tranid { get; set; }
            public int foretagkod { get; set; }

        }
    }

}