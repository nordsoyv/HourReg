<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TimeForing.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Endre bruker
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Endre bruker</h2>

 <% Html.RenderPartial("UserForm"); %>
  
</asp:Content>

