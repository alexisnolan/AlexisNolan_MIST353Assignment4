using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace CitizenScienceDB_AN
{
    public partial class ProjectDetails : System.Web.UI.Page
    {
        public DataTable GetData() 
        {
            DataTable dt = new DataTable();

            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();
            string idValue = Request.QueryString["ID"];

            if (!string.IsNullOrEmpty(idValue) )
            {
                using(SqlConnection connection = new SqlConnection(connString)) 
                {
                    connection.Open();

                    string query = "Exec spGetAllProjectDetails @ID"; // gets details from ID
                    using (SqlCommand command = new SqlCommand(query, connection)) 
                    {
                        command.Parameters.AddWithValue("ID", idValue);
                        command.ExecuteNonQuery();
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            da.Fill(dt);
                        }
                    }
                
                }

            }
            return dt;
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            ProjectDetailss.DataSource = GetData();
            ProjectDetailss.DataBind();
        }
    }
}