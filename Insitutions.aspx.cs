using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CitizenScienceDB_AN
{
    public partial class Insitutions : System.Web.UI.Page
    {
        public DataTable GetData()
        { 
            DataTable dt = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connString))  //connection to DB
            {
                using (SqlCommand command = new SqlCommand("EXEC spGetAllInsititions", connection)) // will fetch a list of institutions
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt); // fills the database with sql query responses
                    }
                }
            }
            return dt;  // returns data table
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Institution.DataSource = GetData();
            Institution.DataBind();
        }
    }
}