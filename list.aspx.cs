using Antlr.Runtime;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PROJECT
{
    public partial class list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                // Call a method to fetch data from the database
                DataTable dt = GetDataFromDatabase();


                // Bind the data to the GridView
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
        }

        private DataTable GetDataFromDatabase()
        {
            // Example: Fetch data using ADO.NET'
            // string connstring = "\"Data Source=NAVDEEP;Initial Catalog=master;Integrated Security=True\"";
            // SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection("Data Source=NAVDEEP;Initial Catalog=master;Integrated Security=True"))
            {
                string query = "SELECT * FROM [dbo].[company_master] where CM_CompanyStatus != 'Suspend'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        protected void btnViewDetails_Click(object sender, EventArgs e)
        {
            // Redirect to Details.aspx with the ID of the selected row
            Button btn = (Button)sender;
            string CM_CompanyID = btn.CommandArgument;
            string CM_CompanyCode = btn.CommandArgument;
            string CM_CompanyName = btn.CommandArgument;
            string CM_CompanyStatus = btn.CommandArgument;
            string CM_CompanyGrpId = btn.CommandArgument;
            string CM_MaxRequestQty = btn.CommandArgument;
            string CM_ExtensionDigit = btn.CommandArgument;
            string CM_CompanyPrefix = btn.CommandArgument;
            string CM_LocationCode = btn.CommandArgument;
            Response.Redirect("Company_Master.aspx?id=" + CM_CompanyID);
        }
        protected void  btnSuspend_Click(object sender,EventArgs e)
        {
            Button btn = (Button)sender;
            string CM_CompanyID = btn.CommandArgument;
            int id = int.Parse(CM_CompanyID);
            
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=.; Initial Catalog=Company; Integrated Security=True;"))
                {
                    
                   
                    SqlConnection conn = new SqlConnection("Data Source=NAVDEEP;Initial Catalog=master;Integrated Security=True");
                    string sqlstring = "UPDATE [dbo].[company_master] SET [CM_CompanyStatus] = 'Suspend' WHERE CM_CompanyID=@id";
                    SqlCommand cmd = new SqlCommand(sqlstring);
                    cmd.Connection = conn;
                    
                    cmd.Parameters.AddWithValue("@id", id);
                    Console.WriteLine(sqlstring);
                    conn.Open();
                    int rowaffetcted = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (rowaffetcted > 0)
                    {

                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Suspended Successfully')", true);

                       // myLabel.Visible= "true";
                       // Response.Write("<script>alert('Record Suspended Succesfully')</script>");

                        DSuspend.Visible = true;
                        Response.Redirect(Request.RawUrl);
                        // reload();
                        // Response.Redirect("Company_Master.aspx?CM_CompanyID=" + "Hello");

                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func()", true);
                        //Response.Redirect("Company_Master.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Inserted')", true);
                        Response.Redirect("Company_Master.aspx");
                    }
                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while executing query: " + ex.Message);
            }

        }


    }

}
