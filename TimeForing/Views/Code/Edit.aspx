<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CodeFormViewModel>" %>
<%@ Import Namespace="TimeForing.ViewModels"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Rediger arbeidskode
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Rediger arbeidskode</h2>
        
        <% Html.RenderPartial("CodeForm"); %>
  
    <div>
        <%=Html.ActionLink("Tilbake til oversikt", "Index") %>
    </div>

</asp:Content>

