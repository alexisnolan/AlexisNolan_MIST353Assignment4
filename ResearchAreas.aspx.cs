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

namespace CitizenScienceDB_AN
{
    public partial class ResearchAreas : System.Web.UI.Page
    {
        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            string connstring = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();
            string idValue = Request.QueryString["ID"];


            if (!string.IsNullOrEmpty(idValue))  // if ID is provided
            {
                using (SqlConnection connection = new SqlConnection(connstring))
                {
                    connection.Open();

                    string query = "Exec spGetResearchAreasByInstutionID @ID"; // gets the areas by the provided ID
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("ID", idValue);
                        command.ExecuteNonQuery();
                        using (SqlDataAdapter da = new SqlDataAdapter(command)) { da.Fill(dt); }
                    }

                }
            }
            else  // not provided
            {
                using (SqlConnection connection = new SqlConnection(connstring))
                {
                    connection.Open();

                    string query = "ExecGetAllResearchAreas";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter d = new SqlDataAdapter(command)) { d.Fill(dt); }
                    }
                }
            }
                
                return dt; // returns the dt that is filled in if/else
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ResearchAreass.DataSource = GetData();
            ResearchAreass.DataBind();

        }
    }
}