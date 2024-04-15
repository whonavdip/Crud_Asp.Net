using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROJECT
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDropdown2();
            BindDropdown1();
            if (!IsPostBack)
            {
                // Get the ID from query string
                if (Request.QueryString["CM_CompanyID"] != null)
                {
                    string id = Request.QueryString["CM_CompanyID"];
                    // Retrieve details for the specified ID
                    // and populate the labels or other controls
                    string CM_CompanyID = id;
                    Console.WriteLine(CM_CompanyID);
                    string connectionString = "Data Source=NAVDEEP;Initial Catalog=master;Integrated Security=True";

                    // Create SQL connection
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        // Define SQL query
                        string query = "SELECT * from company_master where CM_CompanyID=@CM_CompanyID";


                        // Create SQL command
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            // Open connection
                            con.Open();
                            cmd.Parameters.AddWithValue("@CM_CompanyID", CM_CompanyID);
                            // Execute the query
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {

                                // Check if there are rows
                                if (reader.HasRows && reader.Read())
                                {
                                    // Access columns by name or index and store in variables
                                    
                                    string cid = reader.GetString(reader.GetOrdinal("CM_CompanyID"));
                                    string codee = reader.GetString(reader.GetOrdinal("CM_CompanyCode"));
                                    string name = reader.GetString(reader.GetOrdinal("CM_CompanyName"));
                                    //string cid = reader.GetString(reader.GetOrdinal("CM_CompanyID"));
                                    string stts = reader.GetString(reader.GetOrdinal("CM_CompanyStatus"));
                                    string gid = reader.GetString(reader.GetOrdinal("CM_CompanyGrpId"));
                                    string mq = reader.GetString(reader.GetOrdinal("CM_MaxRequestQty"));
                                    string exd = reader.GetString(reader.GetOrdinal("CM_ExtensionDigit"));
                                    string cp = reader.GetString(reader.GetOrdinal("CM_CompanyPrefix"));
                                    string lcode = reader.GetString(reader.GetOrdinal("CM_LocationCode"));


                                    // Store other columns in variables as needed
                                    int code = int.Parse(codee);

                                    // Do something with the data, such as displaying it in labels or textboxes
                                    CompanyCode.Text = codee;
                                    CompanyName.Text = name;
                                    ExDigits.Text = exd;
                                    CompanyPrefix.Text = cp;
                                    GroupOfCompany.Text = gid;
                                    LocationCode.Text = lcode;
                                    mqq.Text = mq;
                                    CompanyStatus.Text = stts;


                                    mqq.Text = mq;
                                    CompanyStatus.Text = stts;
                                    //code prefix qty
                                   
                                    //Console.WriteLine("Converted number using int.Parse(): " + convertedNumber);

                                    // Display other data as needed
                                }

                            }
                        }
                    }

                }
            }
        }

        //here
        private void BindDropdown1()
        {
            // Connection string for your database
            string connectionString = "Data Source=NAVDEEP;Initial Catalog=master;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * from GOC", conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListItem item = new ListItem();
                    item.Text = reader["G_CODE"].ToString();
                    item.Value = reader["G_CODE"].ToString();
                    GroupOfCompany.Items.Add(item);

                }

                reader.Close();
            }
        }
        private void BindDropdown2()
        {
            // Connection string for your database
            string connectionString = "Data Source=NAVDEEP;Initial Catalog=master;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * from LOCATION_CODE", conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListItem item = new ListItem();
                    item.Text = reader["L_CODE"].ToString();
                    item.Value = reader["L_CODE"].ToString();
                    LocationCode.Items.Add(item);
                }

                reader.Close();
            }
        }


        protected void resetForm(object sender, EventArgs e)
        {
           
            ExDigits.Text = "";
            CompanyPrefix.Text = "";
            GroupOfCompany.Text = "Select Grup Of Company";
            LocationCode.Text = "Select Code";
            mqq.Text = "";
            CompanyStatus.Text = "Active";

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=.; Initial Catalog=Company; Integrated Security=True;"))
                {
                    String id = CompanyCode.Text;
                    string code = CompanyCode.Text;
                    string name = CompanyName.Text;
                    String exd = ExDigits.Text;
                    String cp = CompanyPrefix.Text;
                    String gid = GroupOfCompany.Text;
                    String lcode = LocationCode.Text;
                    String mq = mqq.Text;
                    String status = CompanyStatus.Text;
                    if (name == "" || code == "" || status == "" || gid == "Select Grup Of Company" || exd == "" || cp == "" || lcode == "Select Code" || mq == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fill All The Fields')", true);
                        return;
                    }
                    if (gid=="Select Grup Of Company" || lcode=="Select Code")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fill all Fields')", true);
                        return;
                    }
                    DateTime currentTimeStamp = DateTime.Now;
                    string mts = currentTimeStamp.ToString();
                    SqlConnection conn = new SqlConnection("Data Source=NAVDEEP;Initial Catalog=master;Integrated Security=True");
                    string sqlstring = "update Company_Master set CM_CompanyStatus=@status ,CM_CompanyGrpId=@gid,CM_MaxRequestQty=@mq,CM_ExtensionDigit=@exd,CM_CompanyPrefix=@cp,CM_LocationCode=@lcode,CM_ModifiedTimestamp=@mts where CM_CompanyID=@id";
                    SqlCommand cmd = new SqlCommand(sqlstring);
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@id", id);
                    //cmd.Parameters.AddWithValue("@ccode", ccode);
                    //cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@gid", gid);
                    cmd.Parameters.AddWithValue("@mq", mq);
                    cmd.Parameters.AddWithValue("@exd", exd);
                    cmd.Parameters.AddWithValue("@cp", cp);
                    cmd.Parameters.AddWithValue("@lcode", lcode);
                    //cmd.Parameters.AddWithValue("@cby", cby);
                    //cmd.Parameters.AddWithValue("@cts", cts);
                    //cmd.Parameters.AddWithValue("@mb", mb);
                    cmd.Parameters.AddWithValue("@mts", mts);
                    Console.WriteLine(sqlstring);
                    conn.Open();
                    int rowaffetcted = cmd.ExecuteNonQuery();
                    if (rowaffetcted > 0)
                    {
                        //string sttr = "Data inserted succesfully";
                        //label1.Text = sttr;

                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                        //  Response.Redirect("list.aspx");
                        CompanyCode.Text = "";
                        CompanyName.Text = "";
                        ExDigits.Text = "";
                        CompanyPrefix.Text = "";
                        GroupOfCompany.Text = "Select Grup Of Company";
                        LocationCode.Text = "Select Code";
                        mqq.Text = "";
                        CompanyStatus.Text = "";

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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('An Error Occured')", true);
            }





           
        }
    }
}                                                                                                                           