<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="EmployeeManagementSystemWebApplication.EmployeeManagementPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function preventDefault(event) {
            event.preventDefault();
        }
    </script>
    <style type="text/css">
        table {
            padding: 10px;
        }

        .auto-style1 {
            width: 100%;
            border-style: solid;
            border-width: 1px;
        }

        .auto-style2 {
            width: 323px;
        }

        .auto-style3 {
            width: 323px;
            height: 33px;
        }

        .auto-style4 {
            height: 33px;
        }

        .button-div {
            display: flex;
            justify-content: space-evenly;
            margin-top: 10px;
        }

        .search-div {
            border-top: 1px solid;
            display: flex;
            justify-content: space-evenly;
            margin-top: 10px;
            padding: 0 400px;
            padding-top: 10px;
        }

        .list-employee {
            display: flex;
            justify-content: center;
            flex-direction: column;
            align-items: center;
            padding: 10px;
            margin-top: 10px;
        }

        td {
            padding: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblId" runat="server" Text="ID"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtId" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButton ID="rdMale" runat="server" Text="Male" />
                        <asp:RadioButton ID="rdFemale" runat="server" Text="Female" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblDesig" runat="server" Text="Designation"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDesig" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblDepart" runat="server" Text="Department"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDepart" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblEdu" runat="server" Text="Education"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="cbGraduation" runat="server" Text="Graduation" />
                        <asp:CheckBox ID="cbPostGraduation" runat="server" Text="PostGraduation" />
                        <asp:CheckBox ID="cbPhd" runat="server" Text="Phd" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="button-div">
            <%if (!isUpdate)
                {
            %>
            <asp:Button ID="addEmployeeBtn" runat="server" Text="Add Employee" OnClick="addEmployeeBtn_Click" /><%
                                  } %>
            <%else
                {
            %>
            <asp:Button ID="updateEmployeebtn" runat="server" Text="Update Employee" OnClick="updateEmployeeBtn_Click" />
            <%
                } %>
            <asp:Button ID="clrBtn" runat="server" Text="Clear" OnClick="clrBtn_Click" />
            <asp:Button ID="listAllBtn" runat="server" Text="List All" OnClick="listAllBtn_Click" />
        </div>
        <div class="search-div">
            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
            <asp:Label ID="lblSearchBy" runat="server">Search By: </asp:Label>
            <asp:DropDownList ID="ddlSearchBy" runat="server">
            </asp:DropDownList>
            <asp:Button ID="searchBtn" runat="server" Text="Search" OnClick="searchBtn_Click" />
        </div>
        <div class="list-employee">
            <%if (isListAll)
                {
            %>
            <h1>List of All Employee</h1>
            <%
                } %>
            <% if (isSearch)
                {
            %>
            <h1>Search Employee List</h1>
            <%
                }
            %>
            <asp:GridView ID="EmployeeListGridView" runat="server" AutoGenerateColumns="false" OnRowCommand="EmployeeListGridView_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                    <asp:BoundField DataField="Department" HeaderText="Department" />
                    <asp:BoundField DataField="Designation" HeaderText="Designation" />
                    <asp:BoundField DataField="Education" HeaderText="Education" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="editBtn" runat="server" Text="Edit" CommandName="EditRow" CommandArgument='<%# Eval("ID") %>' />
                            <asp:Button ID="deleteBtn" runat="server" Text="Delete" CommandName="DeleteRow" CommandArgument='<%# Eval("ID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
