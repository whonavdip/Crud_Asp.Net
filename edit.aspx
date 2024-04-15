<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="PROJECT.edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
      
       .btn {
    margin: 10px; /* This sets the margin for all sides */
    padding: 8px 16px; /* Optional: Padding inside the button */
    background-color: #007bff;
    color: #ffffff;
    border: none;
    border-radius: 4px;
    cursor: pointer;
  }
       .lables {
           align-items:center
       }
      
        
    </style>

   
        <script type="text/javascript">




            function confirmRedirect() {
                // Show a confirmation dialog
                var confirmed = confirm("Are you sure you want to navigate to another page?");
                if (confirmed) {
                    // If user clicked OK, redirect to other page
                    window.location.href = "list.aspx";
                }
                // If user clicked Cancel, stay on the current page
                return false;
            }




            function Func() {
                location.reload();
            }
            window.onload = function () {
                var dropdown1 = document.getElementById("GroupOfCompany");
                var dropdown2 = document.getElementById("LocationCode");

                // Disable the default option in dropdown1
                var defaultOption1 = dropdown1.options[0];
                defaultOption1.disabled = true;
                defaultOption1.text = defaultOption1.text + " (Selected)";

                // Disable the default option in dropdown2
                var defaultOption2 = dropdown2.options[0];
                defaultOption2.disabled = true;
                defaultOption2.text = defaultOption2.text + " (Selected)";

                // Handle dropdown1 change event
                dropdown1.onchange = function () {
                    if (dropdown1.selectedIndex === 0) {
                        dropdown1.selectedIndex = -1;
                    }
                };

                // Handle dropdown2 change event
                dropdown2.onchange = function () {
                    if (dropdown2.selectedIndex === 0) {
                        dropdown2.selectedIndex = -1;
                    }
                };
            };
        </script>

   

</head>
<body>
    <form id="form1" runat="server">
        <center><h1>EDIT PAGE</h1></center>
        <div>
             <table border="1" align="center">
        <tr>
            <td colspan="2" align="center"><h1>Company Master</h1></td>
        </tr>
        <tr>
            <td class="auto-style2"><label>Company Code</label></td>
            <td>
                <asp:TextBox ID="CompanyCode" runat="server" Height="25px" Width="195px" BackColor="White" BorderColor="Black" readonly="true"></asp:TextBox>
     
            </td>
        </tr>
        <tr>
           <td class="auto-style2"><label>Company Name</label></td>
<td>
    <asp:TextBox ID="CompanyName" runat="server" Height="25px" Width="195px" readonly="true"></asp:TextBox>

</td>
        </tr>
        <tr>
           <td class="auto-style4">Ex.Digits / Company Prefix</td>
<td class="auto-style5">
    <asp:TextBox ID="ExDigits" runat="server" Height="25px" Width="61px" ></asp:TextBox>

    <asp:TextBox ID="CompanyPrefix" runat="server" oninput="checkLength(this)" MaxLength="9"></asp:TextBox>

    
           
            
    <br />
</td>
        </tr>
        <tr>
            <td class="auto-style2"><label>Group of Company</label></td>
<td>
    <asp:DropDownList ID="GroupOfCompany" runat="server" Height="16px" Width="156px">
       
        <asp:ListItem Value="Select Grup Of Company" Enabled="true" ></asp:ListItem>
        
    </asp:DropDownList>
</td>
        </tr>
        <tr>
          <td class="auto-style2">Loaction<label> Code</label></td>
<td>
    <asp:DropDownList ID="LocationCode" runat="server" Height="16px" Width="156px">
         <asp:ListItem Value="Select Code" ></asp:ListItem>
          
    </asp:DropDownList>
</td>
        </tr>
        <tr>
            <td class="auto-style2">Max Request Qty</td>
<td>
    <asp:TextBox ID="mqq" runat="server" Height="25px" Width="195px" ></asp:TextBox>
</td>
        
        <tr>
            <td class="auto-style2"><label>Company Status</label></td>
<td>
    <asp:DropDownList ID="CompanyStatus" runat="server" >
        <asp:ListItem Value="Active"></asp:ListItem>
        <asp:ListItem Value="Inactive"></asp:ListItem>
    </asp:DropDownList>
     
</td>
        
    </table>
        </div>
         <div align="center">
             <asp:Button ID="Save" runat="server" Text="Save" class="btn" OnClick="Save_Click"/>
             <asp:Button ID="Cancel" runat="server" Text="Cancel" class="btn" OnClick="resetForm"/>
             <asp:Button ID="List" runat="server" Text="List" class="btn" OnClientClick="return confirmRedirect();"/>
</div>
        
    </form>
    
</body>
</html>

