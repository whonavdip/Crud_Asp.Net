<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="PROJECT.list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function Func() {
            location.reload();
        }
    </script>
    <style>
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

    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        
        <div>
            <h1 color="red">LIST PAGE</h1>
            
            </div>
        <asp:Label runat="server" ID="DSuspend" Visible="false" BackColor="Red" Font-Size="Large">Data Suspended Successfully</asp:Label>
                <div>
                    <asp:Label ID="myLabel" runat="server" Text="Suspend success" Visible="false"></asp:Label>

                </div>
                
                <div>
                    <asp:HyperLink ID="hyperlinkRedirect" runat="server" NavigateUrl="Company_Master.aspx">
            <h1>BACK</h1>
        </asp:HyperLink>
            </div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" CellSpacing="3" Width="399px">
                <RowStyle BorderColor="#CC99FF" BorderStyle="Dotted" />
                
                <Columns>
        
        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:Button ID="btnViewDetails" runat="server" Text="Edit" CommandName="ViewDetails" CommandArgument='<%# Eval("CM_CompanyID") + "," + Eval("CM_CompanyName") + "," +  Eval("CM_ExtensionDigit") + ","+ Eval("CM_CompanyPrefix") + ","+Eval("CM_CompanyGrpId") + ","+ Eval("CM_LocationCode") + "," + Eval("CM_MaxRequestQty")+","+Eval("CM_CompanyStatus")%>' OnClick="btnViewDetails_Click" />
                <asp:Button ID="btnSuspend" runat="server" Text="Suspend" CommandName="DeleteRow" CommandArgument='<%# Eval("CM_CompanyID") %>' OnClick="btnSuspend_Click" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns> 
            </asp:GridView>
                   

        
    </form>
</body>
</html>
