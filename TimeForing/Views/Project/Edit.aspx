<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TimeForing.Models.Project>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Rediger prosjekt
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Rediger prosjekt</h2>

   <% Html.RenderPartial("ProjectForm"); %>
    <div>
        <%=Html.ActionLink("Tilbake til oversikt", "Index") %>
    </div>

</asp:Content>

