using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace STGchannelMVC
{
    [System.Web.Script.Services.ScriptService]
    public class Get_next_tranid : System.Web.Services.WebService
    {
      
        [WebMethod]
        public int Q_get_next_tranid(int foretagkod, int tranid)
        {
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Test_jvspkkEntities"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "q_get_next_tranid";
                    cmd.Parameters.AddWithValue("@foretagkod", foretagkod);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return tranid;
                }

            }
        }

        [WebMethod]
        public ChangePO AddPO(ChangePO cpo, int foretagkod, int tranid)
        {
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Test_jvspkkEntities"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "q_get_next_tranid";
                    cmd.Parameters.AddWithValue("@foretagkod", foretagkod);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return cpo;
                }

            }
        }

    }
    public class ChangePO
    {
        public int tranid { get; set; }
        public int foretagkod { get; set; }

    }
}
