<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Innstillinger
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Innstillinger</h2>
    <ul>
        <li>
            <%= Html.ActionLink("Prosjekter", "Index", "Project")%></li>
        <li>
            <%= Html.ActionLink("Arbeidskoder", "Index", "Code")%></li>
        <li>
            <%= Html.ActionLink("Brukere", "Index", "User")%></li>
        <li>
            <%= Html.ActionLink ("Stories","Index","Stories") %>
        </li>
    </ul>
</asp:Content>
