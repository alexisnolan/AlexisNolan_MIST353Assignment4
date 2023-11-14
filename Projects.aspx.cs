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
    public partial class Projects : System.Web.UI.Page
    {
        public DataTable GetData()
        {
            DataTable dt = new DataTable();

            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();
            string idValue = Request.QueryString["ID"]; 

            if (!string.IsNullOrEmpty(idValue) )
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();

                    string query = "EXEC spGetAllProjectsByResearchID @ID"; // query that uses ID 

                    using(SqlCommand command = new SqlCommand(query, connection)) 
                    {
                        command.Parameters.AddWithValue("ID", idValue);
                        command.ExecuteNonQuery();
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        { da.Fill(dt); }
                    }
                }

            }
            return dt;
        }




        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string idValue = Request.QueryString.Get("ID");
                if (string.IsNullOrEmpty(idValue) )   // redirects to page when not provided
                {
                    Response.Redirect("ResearchAreas.aspx"); // redircts to researchareas.apex

                }
                else // shows projects page if provided
                {
                    Projectss.DataSource = GetData();
                    Projectss.DataBind();
                }
            }
        }
    }
}