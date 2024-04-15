<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Company_Master.aspx.cs" Inherits="PROJECT.Company_Master" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

                                    body {
                                font-family: Arial, sans-serif; /* Set a default font */
                                line-height: 1.6; /* Adjust line height for better readability */
                                color: #333; /* Default text color */
                                background-color: #f9f9f9; /* Background color */
                                margin: 0; /* Remove default margins */
                                padding: 0; /* Remove default padding */
                            }

                            /* Example styles for headings */
                            h1 {
                                font-size: 2.5em; /* Adjust size as needed */
                                color: #333; /* Heading color */
                                margin-top: 20px; /* Adjust spacing */
                                margin-bottom: 10px; /* Adjust spacing */
                            }

                            h2 {
                                font-size: 2em;
                                color: #333;
                                margin-top: 20px;
                                margin-bottom: 10px;
                            }

                            /* Example styles for paragraphs */
                            p {
                                font-size: 1.1em;
                                color: #666; /* Text color */
                                margin-bottom: 20px; /* Adjust spacing */
                            }

                            /* Example style for links */
                            a {
                                color: #007bff; /* Link color */
                                text-decoration: none; /* Remove underline */
                            }

                            a:hover {
                                color: #0056b3; /* Hover color */
                            }

                            /* Example style for buttons */
                            .button {
                                display: inline-block;
                                padding: 10px 20px;
                                background-color: #007bff;
                                color: #fff;
                                text-decoration: none;
                                border-radius: 5px;
                                transition: background-color 0.3s ease;
                            }

                            .button:hover {
                                background-color: #0056b3;
                            }

      
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


            function checkForm() {
                var form = document.getElementById('<%= form1.ClientID %>'); // Getting the form by ClientID
                var elements = form.elements;
                var isValid = true;

                for (var i = 0; i < elements.length; i++) {
                    var element = elements[i];

                    if ((element.tagName === 'INPUT' && element.type === 'text' && element.value.trim() === '') ||
                        (element.tagName === 'SELECT' && element.value.trim() === '')) {
                        isValid = false;
                        break;
                    }
                }

                if (isValid) {
                    alert('All textboxes and dropdowns have values.');
                } else {
                    alert('Please fill in all textboxes and dropdowns.');
                }
            }




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




            function reset() {
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

            function validateInput(input) {
                // Get the value entered by the user
                let inputValue = input.value;

                // Remove any non-digit characters using regular expression
                let sanitizedInput = inputValue.replace(/\D/g, '');

                // Update the input value with only digits
                input.value = sanitizedInput;
            }



            function resetForm() {
                // Get all textboxes
                var textboxes = document.querySelectorAll('input[type="text"]');

                // Loop through each textbox and set its value to null
                textboxes.forEach(function (textbox) {
                    textbox.value = '';
                });

                // Get all dropdowns (assuming you're using select elements for dropdowns)
                var dropdowns = document.querySelectorAll('select');

                // Loop through each dropdown and set its selected index to 0
                dropdowns.forEach(function (dropdown) {
                    dropdown.selectedIndex = 0;
                });

                // Return false to prevent postback (if using ASP.NET Web Forms)
                return false;
            }

           
        </script>

   

</head>
<body>
    <form id="form1" runat="server">
        <center><asp:Label ID="DUpdate" runat="server" Visible="false" BackColor="Red" Font-Size="Larger">DATA UPDATED SUCCESFULLY</asp:Label></center>
        <div>
             <table border="1" align="center">
        <tr>
            <td colspan="2" align="center"><h1>Company Master</h1></td>
        </tr>
        <tr>
            <td class="auto-style2"><label>Company Code</label></td>
            <td>
                <asp:TextBox ID="CompanyCode" runat="server" Height="25px" Width="195px" BackColor="White" BorderColor="Black" oninput="validateInput(this)" AutoPostBack="true" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                <asp:Label ID="Code1" runat="server" Enabled="true" Visible="false" ForeColor="Red" Font-Bold="true">*</asp:Label>
                
            </td>
        </tr>
        <tr>
           <td class="auto-style2"><label>Company Name</label></td>
<td>
    <asp:TextBox ID="CompanyName" runat="server" Height="25px" Width="195px" AutoPostBack="true" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
    <asp:Label ID="Cname" runat="server" Enabled="true" Visible="false" ForeColor="Red" Font-Bold="true">*</asp:Label>
</td>
        </tr>
        <tr>
           <td class="auto-style4">Ex.Digits / Company Prefix</td>
<td class="auto-style5">
    <asp:TextBox ID="ExDigits" runat="server" Height="25px" Width="61px" oninput="validateInput(this)"></asp:TextBox>
    
    <asp:TextBox ID="CompanyPrefix" runat="server" oninput="checkLength(this)" MaxLength="9"></asp:TextBox>
    
    
           
            
    <br />
</td>
        </tr>
        <tr>
            <td class="auto-style2"><label>Group of Company</label></td>
<td>
    <asp:DropDownList ID="GroupOfCompany" runat="server" Height="16px" Width="156px">
       
        <asp:ListItem  Value="Select Grup Of Company" Enabled="true" ></asp:ListItem>
        
    </asp:DropDownList>
</td>
        </tr>
        <tr>
          <td class="auto-style2">Loaction<label> Code</label></td>
<td>
    <asp:DropDownList ID="LocationCode" runat="server" Height="16px" Width="156px">
         <asp:ListItem  Value="Select Code" ></asp:ListItem>
          
    </asp:DropDownList>
</td>
        </tr>
        <tr>
            <td class="auto-style2">Max Request Qty</td>
<td>
    <asp:TextBox ID="mqq" runat="server" Height="25px" Width="195px"  oninput="validateInput(this)"></asp:TextBox>
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
              <asp:Button ID="Update" runat="server" Text="Save" class="btn" Visible="false" OnClick="Save_Click"/>
             <asp:Button ID="Clear" runat="server" Text="Back" class="btn" Visible="false" OnClick="Back_Click"/>
             <asp:Button ID="Cancel" runat="server" Text="Cancel" class="btn" Visible="True" OnClick="Cancel_Click"/>
            

             
             <asp:Button ID="SList" runat="server" Text="Search List" CssClass="btn" OnClick="S_Click"/>

</div>
        
    </form>
    

    
</body>
</html>
