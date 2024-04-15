<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list1.aspx.cs" Inherits="PROJECT.list1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" DataKeyNames="ID">
    <Columns>
        <asp:CommandField ShowEditButton="True" ButtonType="Button" EditText="Edit" UpdateText="Update" CancelText="Cancel"/>
        <asp:BoundField DataField="ID" HeaderText="ID"/>
       
        <asp:TemplateField HeaderText="Suspend">
            <ItemTemplate>
                <asp:Button ID="btnSuspend" runat="server" Text="Suspend" CommandName="Suspend" CommandArgument='<%# Eval("ID") %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

        </div>
    </form>
</body>
</html>
