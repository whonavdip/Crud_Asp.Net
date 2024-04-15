using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


//using System.Windows.Forms;

namespace PROJECT
{
    public partial class Company_Master : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string id = Request.QueryString["id"];
                string gid = Request.QueryString["gid"];
                string stts = Request.QueryString["stts"];
                string code = Request.QueryString["code"];
                Console.WriteLine(id);
                Console.WriteLine(gid);
                Console.WriteLine(stts);
                Console.WriteLine(code);
                BindDropdown1();
                BindDropdown2();
                if (id != null)
                {
                    string[] id1 = id.Split(',');
                    string cid = id1[0];
                    string name = id1[1];
                    string exd = id1[2];
                    string cp = id1[3];
                    string gidd = id1[4];
                    string lcode = id1[5];
                    string max = id1[6];
                    string status = id1[7];
                    SelectCity(gid);
                    SelectCity1(lcode);
                    CompanyCode.Text = cid;
                    CompanyName.Text = name;
                    ExDigits.Text = exd;
                    CompanyPrefix.Text = cp;
                    GroupOfCompany.Text = gid;
                    LocationCode.Text = lcode;
                    mqq.Text = max;
                    CompanyStatus.Text = stts;
                    CompanyCode.ReadOnly = true;
                    CompanyName.ReadOnly = true;
                    GroupOfCompany.Text = gidd;
                    Clear.Visible = true;
                    Cancel.Visible = false;
                    Save.Visible = false;
                    Update.Visible = true;
                }
            }
            

        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            CompanyName.Text = "";
            CompanyCode.Text = "";
            ExDigits.Text = "";
            CompanyPrefix.Text = "";
            GroupOfCompany.Text = "Select Grup Of Company";
            LocationCode.Text = "Select Code";
            mqq.Text = "";
            CompanyStatus.Text ="Active";
            DUpdate.Visible = false;
            
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=.; Initial Catalog=Company; Integrated Security=True;"))
                {
                    String id = CompanyCode.Text;
                    String name = CompanyName.Text;
                    String ccode = CompanyCode.Text;
                    String status = CompanyStatus.Text;
                    String gid = GroupOfCompany.Text;
                    String mq = mqq.Text;
                    String cp = CompanyPrefix.Text;
                    String exd = ExDigits.Text;
                    String lcode = LocationCode.Text;
                    DateTime currentTimeStamp = DateTime.Now;
                    string mts = currentTimeStamp.ToString();
                    if (gid == "Select Grup Of Company" || exd == "" || cp == "" || lcode == "Select Code" || mq == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fill All The Fields')", true);
                        return;
                    }
                    SqlConnection conn = new SqlConnection("Data Source=NAVDEEP;Initial Catalog=master;Integrated Security=True");
                    string sqlstring = "UPDATE company_master SET CM_CompanyStatus = @status ,CM_CompanyGrpId = @gid ,CM_MaxRequestQty = @mq ,CM_ExtensionDigit = @exd ,CM_CompanyPrefix = @cp ,CM_LocationCode = @lcode ,CM_ModifiedTimestamp = @mts WHERE CM_CompanyID = @id";
                    SqlCommand cmd = new SqlCommand(sqlstring);
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@gid", gid);
                    cmd.Parameters.AddWithValue("@mq", mq);
                    cmd.Parameters.AddWithValue("@exd", exd);
                    cmd.Parameters.AddWithValue("@cp", cp);
                    cmd.Parameters.AddWithValue("@lcode", lcode);
                    cmd.Parameters.AddWithValue("@mts", mts);
                    Console.WriteLine(sqlstring);
                    conn.Open();
                    int rowaffetcted = cmd.ExecuteNonQuery();
                    if (rowaffetcted > 0)
                    {
                        //string sttr = "Data inserted succesfully";
                        //label1.Text = sttr;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
                        Response.Redirect("list.aspx");
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Already Exist')", true);
            }
        }
       protected void Back_Click(object sender, EventArgs e)
       {
            Response.Redirect("list.aspx");
       }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            // If textbox is not empty, show the label
            if (!string.IsNullOrWhiteSpace(CompanyCode.Text))
            {
                Code1.Visible = false;
            }
            else
            {
                Code1.Visible = true;
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            // If textbox is not empty, show the label
            if (!string.IsNullOrWhiteSpace(CompanyName.Text))
            {
                Cname.Visible = false;
            }
            else
            {
                Cname.Visible = true;
            }
        }
        protected void Save_Click(object sender, EventArgs e)
       {
            if(CompanyCode.ReadOnly==true)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection("Data Source=.; Initial Catalog=Company; Integrated Security=True;"))
                    {
                        String id = CompanyCode.Text;
                        String name = CompanyName.Text;
                        String ccode = CompanyCode.Text;
                        String status = CompanyStatus.Text;
                        String gid = GroupOfCompany.Text;
                        String mq = mqq.Text;
                        String cp = CompanyPrefix.Text;
                        String exd = ExDigits.Text;
                        String lcode = LocationCode.Text;
                        DateTime currentTimeStamp = DateTime.Now;
                        string mts = currentTimeStamp.ToString();
                        if (gid == "Select Grup Of Company" || exd == "" || cp == "" || lcode == "Select Code" || mq == "")
                        {
                            Code1.Visible = true;
                            Cname.Visible = true;
                            return;
                        }
                        SqlConnection conn = new SqlConnection("Data Source=NAVDEEP;Initial Catalog=master;Integrated Security=True");
                        string sqlstring = "UPDATE company_master SET CM_CompanyStatus = @status ,CM_CompanyGrpId = @gid ,CM_MaxRequestQty = @mq ,CM_ExtensionDigit = @exd ,CM_CompanyPrefix = @cp ,CM_LocationCode = @lcode ,CM_ModifiedTimestamp = @mts WHERE CM_CompanyID = @id";
                        SqlCommand cmd = new SqlCommand(sqlstring);
                        cmd.Connection = conn;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@gid", gid);
                        cmd.Parameters.AddWithValue("@mq", mq);
                        cmd.Parameters.AddWithValue("@exd", exd);
                        cmd.Parameters.AddWithValue("@cp", cp);
                        cmd.Parameters.AddWithValue("@lcode", lcode);
                        cmd.Parameters.AddWithValue("@mts", mts);
                        Console.WriteLine(sqlstring);
                        conn.Open();
                        int rowaffetcted = cmd.ExecuteNonQuery();
                        if (rowaffetcted > 0)
                        {
                            //string sttr = "Data inserted succesfully";
                            //label1.Text = sttr;
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
                            Console.WriteLine("<script>alert('Record Updated Succcessfully');</script>");
                            CompanyCode.ReadOnly = false;
                            CompanyName.ReadOnly = false;
                            Code1.Visible=false;
                            Cname.Visible=false;
                            CompanyName.Text = "";
                            CompanyCode.Text = "";
                            ExDigits.Text = "";
                            CompanyPrefix.Text = "";
                            GroupOfCompany.Text = "Select Grup Of Company";
                            LocationCode.Text = "Select Code";
                            mqq.Text = "";
                            CompanyStatus.Text = "Active";
                            DUpdate.Visible = true;
                            Clear.Visible = false;  
                            Cancel.Visible = true;

                            //Console.WriteLine("<script");
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
                    Console.WriteLine(ex);
                }
            }
            else
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection("Data Source=.; Initial Catalog=Company; Integrated Security=True;"))
                    {
                        //@id, @ccode, @name , @status, @gid, @mq, @cp, @exd, @lcode, @cby, @cts, @mb, @mts
                        String id = CompanyCode.Text;
                        String name = CompanyName.Text;
                        String ccode = CompanyCode.Text;
                        String status = CompanyStatus.Text;
                        String gid = GroupOfCompany.Text;
                        String mq = mqq.Text;
                        String cp = CompanyPrefix.Text;
                        String exd = ExDigits.Text;
                        String lcode = LocationCode.Text;
                        String cby = "Admin";
                        String mb = "User";
                        String mts = "";
                        if(ccode == "")
                        {
                            Code1.Visible = true;
                            return;
                        }
                        if(name == "")
                        {
                            Cname.Visible = true;
                            return;
                        }
                        if(gid == "Select Grup Of Company")
                        {
                            gid = "";
                        }
                        if(lcode=="Select Code")
                        {
                            lcode = "";
                        }
                        DateTime currentTimeStamp = DateTime.Now;
                        string cts = currentTimeStamp.ToString();
                        
                        SqlConnection conn = new SqlConnection("Data Source=NAVDEEP;Initial Catalog=master;Integrated Security=True");
                        string sqlstring = "INSERT INTO dbo.company_master(CM_CompanyID,CM_CompanyCode,CM_CompanyName,CM_CompanyStatus,CM_CompanyGrpId,CM_MaxRequestQty,CM_ExtensionDigit,CM_CompanyPrefix,CM_LocationCode,CM_CreatedBy,CM_CreatedTimestamp,CM_ModifiedBy,CM_ModifiedTimestamp) VALUES (@id,@ccode,@name,@status,@gid,@mq,@exd,@cp,@lcode,@cby,@cts,@mb,@mts)";
                        SqlCommand cmd = new SqlCommand(sqlstring);
                        cmd.Connection = conn;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@ccode", ccode);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@gid", gid);
                        cmd.Parameters.AddWithValue("@mq", mq);
                        cmd.Parameters.AddWithValue("@exd", exd);
                        cmd.Parameters.AddWithValue("@cp", cp);
                        cmd.Parameters.AddWithValue("@lcode", lcode);
                        cmd.Parameters.AddWithValue("@cby", cby);
                        cmd.Parameters.AddWithValue("@cts", cts);
                        cmd.Parameters.AddWithValue("@mb", mb);
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
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Already Exist')", true);
                }
            }
            
       }
       
        protected void S_Click(object sender, EventArgs e)
        {
            Response.Redirect("S_List.aspx");
        }
       private void BindDropdown1()
       {
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
       protected void clearform(object sender, EventArgs e)
       {
            Response.Redirect(Request.RawUrl);
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
       private void SelectCity(string cityName)
       {
            foreach (ListItem item in GroupOfCompany.Items)
            {
                if (item.Text.Equals(cityName, StringComparison.OrdinalIgnoreCase))
                {
                    item.Selected = true;
                    break;
                }
            }
       }
       private void SelectCity1(string code)
       {
            foreach (ListItem item in LocationCode.Items)
            {
                if (item.Text.Equals(code, StringComparison.OrdinalIgnoreCase))
                {
                    item.Selected = true;
                    break;
                }
            }
       }

    }
}