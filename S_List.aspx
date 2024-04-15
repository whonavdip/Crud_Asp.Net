<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="S_List.aspx.cs" Inherits="PROJECT.S_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
            .dropdown_div{
                margin:10px;
            }
            .div_1 {
              /* 100% of viewport width */
              display: flex;
            }
             .container {
                display: flex;
                flex-direction: column;
                align-items: center;
                justify-content: center;
                height: 100px;
                width: 100vw; /* Width of viewport */
            }

            .content {
                display: flex;
            }
    </style>
      <script>
         
          function updateDropdown(value, dropdownId) {
              var dropdown = document.getElementById(dropdownId);
              for (var i = 0; i < dropdown.options.length; i++) {
                  if (dropdown.options[i].value === value) {
                      dropdown.options[i].disabled = true;
                      if (dropdown.options[i].value == "Select") {
                          dropdown.options[i].disabled = true;
                      }
                  } else {
                      dropdown.options[i].disabled = false;
                      if (dropdown.options[i].value == "Select") {
                          dropdown.options[i].disabled = true;
                      }
                  }
              }
          }
      </script>
</head>
<body>
    <form id="form1" runat="server">
        <center><h1>Search Page</h1></center>

        <div class="container">
    <div class="content">
                <asp:Button class="dropdown_div" ID="BACK" runat="server" Text="BACK" BackColor="#82D8F4" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" Font-Bold="True" Font-Names="Arial Black" Font-Size="Large" ForeColor="Blue" OnClick="BACK_Click"  />
        <asp:DropDownList class="dropdown_div" ID="dropdown1" runat="server" onchange="updateDropdown(this.value, 'dropdown2')" Font-Bold="True" Font-Italic="False" Font-Names="Arial Black" Font-Size="Larger" Font-Strikeout="False" ForeColor="Black">
            <asp:ListItem Selected="True" Disabled="True" Value="Select"></asp:ListItem>
            <asp:ListItem Value="CM_CompanyGrpId"></asp:ListItem>
            <asp:ListItem Value="CM_LocationCode"></asp:ListItem>
            <asp:ListItem Value="CM_CompanyName"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox class="dropdown_div"  ID="TextBox1" placeholder="Search Here" runat="server" BackColor="Black" BorderColor="Black" BorderStyle="Dotted" BorderWidth="3px" Font-Bold="False" Font-Names="Agency FB" Font-Size="Larger" ForeColor="White"></asp:TextBox>
        <asp:DropDownList class="dropdown_div" ID="dropdown2" runat="server" onchange="updateDropdown(this.value, 'dropdown1')" Font-Bold="True" Font-Names="Arial Black" Font-Size="Larger" ForeColor="Black" >
            <asp:ListItem Selected="True" Disabled="True" Value="Select"></asp:ListItem>
            <asp:ListItem Value="CM_CompanyGrpId"></asp:ListItem>
            <asp:ListItem Value="CM_LocationCode"></asp:ListItem>
            <asp:ListItem Value="CM_CompanyName"></asp:ListItem>   
        </asp:DropDownList>
        <asp:TextBox class="dropdown_div" ID="TextBox2" placeholder="Search Here" runat="server" BackColor="Black" BorderColor="Black" BorderStyle="Dotted" BorderWidth="3px" Font-Bold="False" Font-Size="Larger" ForeColor="White" Font-Names="Agency FB"></asp:TextBox>
        <asp:Button class="dropdown_div" ID="SEARCH" runat="server" Text="SEARCH" BackColor="#82D8F4" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" Font-Bold="True" Font-Names="Arial Black" Font-Size="Large" ForeColor="Blue" OnClick="SEARCH_Click"  />
 
                
 
    </div>
</div>
        <div>

        </div>
        <center><div class="div_1">  
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="false" BackColor="Red"></asp:Label>
    </div></center>
        <div></div>
            
        <center>
            <asp:GridView ID="GridView1" runat="server" Width="100px">
               <Columns>
        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:Button ID="Button1" runat="server" Text="Edit" CommandName="Edit_Click" CommandArgument='<%# Eval("CM_CompanyID") + "," + Eval("CM_CompanyName") + "," +  Eval("CM_ExtensionDigit") + ","+ Eval("CM_CompanyPrefix") + ","+Eval("CM_CompanyGrpId") + ","+ Eval("CM_LocationCode") + "," + Eval("CM_MaxRequestQty")+","+Eval("CM_CompanyStatus")%>' OnClick="btnViewDetails_Click" />
                <asp:Button ID="Button2" runat="server" Text="Suspend" CommandName="DeleteRow" CommandArgument='<%# Eval("CM_CompanyID") %>' OnClick="btnSuspend_Click"/>
            </ItemTemplate>
        </asp:TemplateField>
        
    </Columns>
            </asp:GridView>
            <asp:GridView ID="GridView2" runat="server" Width="100px">
               <Columns>
        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:Button ID="Button3" runat="server" Text="Edit" CommandName="Edit_Click" CommandArgument='<%# Eval("CM_CompanyID") + "," + Eval("CM_CompanyName") + "," +  Eval("CM_ExtensionDigit") + ","+ Eval("CM_CompanyPrefix") + ","+Eval("CM_CompanyGrpId") + ","+ Eval("CM_LocationCode") + "," + Eval("CM_MaxRequestQty")+","+Eval("CM_CompanyStatus")%>' OnClick="btnViewDetails_Click" />
                <asp:Button ID="Button4" runat="server" Text="Suspend" CommandName="DeleteRow" CommandArgument='<%# Eval("CM_CompanyID") %>' OnClick="btnSuspend_Click"/>
            </ItemTemplate>
        </asp:TemplateField>
        
    </Columns>
            </asp:GridView>
        </center>
        
    </form>
</body>
</html>
