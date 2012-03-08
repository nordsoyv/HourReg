<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TimeForing.Models.Sprint>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Opprett sprint
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Opprett sprint</h2>

    <% Html.RenderPartial("SprintForm"); %>
</asp:Content>

