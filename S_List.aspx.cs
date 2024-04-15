using Antlr.Runtime.Misc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace PROJECT
{
    public partial class S_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
               
            }
            else
            {
                DataTable dt = GetDataFromDatabase();
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        
            private DataTable GetDataFromDatabase()
            {
                    DataTable dt = new DataTable();
                    using (SqlConnection conn = new SqlConnection("Data Source=NAVDEEP;Initial Catalog=master;Integrated Security=True"))
                    {
                        string query = "SELECT * FROM company_master where CM_CompanyStatus != 'Suspend' ORDER BY CM_CreatedTimestamp DESC;";
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

        protected void BACK_Click(object sender, EventArgs e)
        {
            Response.Redirect("Company_Master.aspx");
        }
        protected void btnSuspend_Click(object sender, EventArgs e)
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

                       // DSuspend.Visible = true;
                        Response.Redirect(Request.RawUrl);
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

        protected void SEARCH_Click(object sender, EventArgs e)
        {
            Label1.Visible = false;
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=.; Initial Catalog=master; Integrated Security=True;"))
                {
                    String txt1= TextBox1.Text;
                    String txt2= TextBox2.Text;
                    String dd1 = dropdown1.Text;
                    String dd2 = dropdown2.Text;
                    if (txt1 == "" && txt2 == "")
                    {
                        Response.Redirect("S_List.aspx");
                    }
                    else if (dd1 == "Select" && dd2 == "Select")
                    {
                        Response.Redirect("S_List.aspx");
                    }
                    else if (dd1 != "Select" && dd2 != "Select" && txt1 != "" && txt2 != "")
                    {

                        string searchvalue1 = txt1 + "%";
                        string searchvalue2 = txt2 + "%";
                        string QueryString = "select * from company_master where " + dd1 + " LIKE '" + searchvalue1 + "' and " + dd2 + " like '" + searchvalue2 + "' ; and CM_CompanyStatus != 'Suspend'";
                        SqlCommand cmd = new SqlCommand(QueryString);
                        cmd.Connection = conn;
                        conn.Open();
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        DataTable dt1 = new DataTable();
                        Console.WriteLine(cmd);
                        Console.WriteLine(da1);
                        da1.Fill(dt1);
                        int rr = dt1.Rows.Count;
                        if (rr > 0)
                        {
                            GridView2.DataSource = dt1;
                            GridView2.DataBind();
                            GridView1.Visible = false;
                            GridView2.Visible = true;
                        }
                        else
                        {
                            Label1.Text = "No Records Found";
                            GridView2 .Visible = false;
                            Label1.Visible = true;
                            GridView1.Visible = false;
                        }
                    }
                    else if (dd2 != "select" && txt2 != "")
                    {
                        string searchvalue2 = txt2 + "%";
                        string QueryString = "select * from company_master where " + dd2 + " LIKE '" + searchvalue2 + "' and CM_CompanyStatus != 'Suspend';";
                        SqlCommand cmd = new SqlCommand(QueryString);
                        cmd.Connection = conn;
                        conn.Open();
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        DataTable dt1 = new DataTable();
                        Console.WriteLine(cmd);
                        Console.WriteLine(da1);
                        da1.Fill(dt1);
                        int rr = dt1.Rows.Count;
                        if (rr > 0)
                        {
                            GridView2.DataSource = dt1;
                            GridView2.DataBind();
                            GridView1.Visible = false;
                            GridView2.Visible = true;
                        }
                        else
                        {
                            Label1.Text = "No Records Found";
                            GridView2.Visible = false;
                            Label1.Visible = true;
                            GridView1.Visible = false;
                        }
                    }
                    else if (dd1 != "select" && txt1 != "")
                    {
                        string searchvalue = txt1 + "%";
                        string QueryString = "select * from company_master where " + dd1 + " LIKE '" + searchvalue + "' and CM_CompanyStatus != 'Suspend';";
                        SqlCommand cmd = new SqlCommand(QueryString);
                        cmd.Connection = conn;
                        conn.Open();
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        DataTable dt1 = new DataTable();
                        Console.WriteLine(cmd);
                        Console.WriteLine(da1);
                        da1.Fill(dt1);
                        int rr = dt1.Rows.Count;
                        if(rr>0)
                        {
                            GridView2.DataSource = dt1;
                            GridView2.DataBind();
                            GridView1.Visible = false;
                            GridView2.Visible = true;
                        }
                        else
                        {
                            Label1.Text = "No Records Found";
                            GridView2.Visible = false;
                            Label1.Visible = true;
                            GridView1.Visible= false;
                        }
                    }
                    else if (dd2 != "select" && txt1 != "")
                    {
                        string searchvalue1 = txt1 + "%";
                        string QueryString = "select * from company_master where " + dd2 + " LIKE '" + searchvalue1 + "' and CM_CompanyStatus != 'Suspend';";
                        SqlCommand cmd = new SqlCommand(QueryString);
                        cmd.Connection = conn;
                        conn.Open();
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        DataTable dt1 = new DataTable();
                        Console.WriteLine(cmd);
                        Console.WriteLine(da1);
                        da1.Fill(dt1);
                        int rr = dt1.Rows.Count;
                        if (rr > 0)
                        {
                            GridView2.DataSource = dt1;
                            GridView2.DataBind();
                            GridView1.Visible = false;
                            GridView2.Visible = true;
                        }
                        else
                        {
                            Label1.Text = "No Records Found";
                            GridView2.Visible = false;
                            Label1.Visible = true;
                            GridView1.Visible = false;
                        }
                    }
                    else if (dd1 != "select" && txt2 != "")
                    {
                        string searchvalue2 = txt2 + "%";
                        string QueryString = "select * from company_master where " + dd1 + " LIKE '" + searchvalue2 + "' and CM_CompanyStatus != 'Suspend';";
                        SqlCommand cmd = new SqlCommand(QueryString);
                        cmd.Connection = conn;
                        conn.Open();
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        DataTable dt1 = new DataTable();
                        Console.WriteLine(cmd);
                        Console.WriteLine(da1);
                        da1.Fill(dt1);
                        int rr = dt1.Rows.Count;
                        if (rr > 0)
                        {
                            GridView2.DataSource = dt1;
                            GridView2.DataBind();
                            GridView1.Visible = false;
                            GridView2.Visible = true;
                        }
                        else
                        {
                            Label1.Text = "No Records Found";
                            GridView2.Visible = false;
                            Label1.Visible = true;
                            GridView1.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}