<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Timeoversikt
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Timeoversikt</h2>
    <% using (Html.BeginForm())
       { %>
    <%= Html.DropDownList("User", ViewData["Users"] as IEnumerable<SelectListItem>, new { @style = "width:200px" })%>
    <br />
    <br />
    <%= Html.DropDownList("Week", ViewData["Weeks"] as IEnumerable <SelectListItem>, new { @style = "width:200px" })%>
    <input type="submit" value="Generer rapport" />
    <% } %>
</asp:Content>
