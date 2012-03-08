<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Burndown
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Burndown</h2>
   <% using (Html.BeginForm())
       { %>
    <%= Html.DropDownList("Sprint", ViewData["Sprints"] as IEnumerable<SelectListItem>, new { @style = "width:200px" })%>
    <br />
    <input type="submit" value="Generer rapport" />
    <% } %>
</asp:Content>
