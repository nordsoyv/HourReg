<%@ Page Title="Rapporter" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Rapporter
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <h2>Rapporter</h2>
<%= Html.ActionLink("Timeoversikt", "TimeOversikt", "Report", new { @style = "font-size: large;" })%>
<br />
<%= Html.ActionLink ("Oppgaveoversikt", "TaskReport", "Report", new { @style = "font-size: large;" } ) %>
<br />
<%= Html.ActionLink("Burndown", "Burndown", "Report", new { @style = "font-size: large;" })%>
</asp:Content>
