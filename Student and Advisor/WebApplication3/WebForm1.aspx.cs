using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //string confString = WebConfigurationManager.ConnectionStrings["StudentCon"].ConnectionString;
        //public void LoadGridview()
        //{
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["confString"].ConnectionString);
        //    SqlCommand cmd = new SqlCommand("Select tblStudent.Name, tblAdbisor.Name from tblStudent join tblAdvisor where tblStudent.StudentId == tblAdvisor.AdvisorId");
        //    using(con)
        //    {
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        //        {
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);   
        //            GridView1.DataSource= da;
        //            GridView1.DataBind();
        //        }
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            String databaseDetails = "Data Source=.;Initial Catalog=StudentsDB;Integrated Security=True";
            SqlConnection connection = new SqlConnection(databaseDetails);
            
            string query = " select tblStudent.Name, tblAdvisor.Name from tblStudent left join tblAdvisor on tblStudent.AdvisiorId = tblAdvisor.AdvisorId order by tblStudent.Name ;";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader readData =    command.ExecuteReader();
            GridView1.DataSource = readData;
            GridView1.DataBind();
            connection.Close();

        }
    }
}