<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IndexViewModel>" %>
<%@ Import Namespace="TimeForing.ViewModels"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>
        Før timer</h2>
    <% using (Html.BeginForm())
       { %>
    <table>
        <tr>
            <th>
                Bruker
            </th>
            <th>
                Uke
            </th>
        </tr>
        <tr>
            <td>
                <%= Html.DropDownList("SelectedUser", Model.Users, new { @style = "width:200px" })%>
            </td>
            <td>
                <%= Html.DropDownList("Weeks", Model.Weeks , new { @style = "width:200px" })%>
            </td>
        </tr>
    </table>
    <input type="submit" value="Før timer" />
    <% } %>
</asp:Content>
