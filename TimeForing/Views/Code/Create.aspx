<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CodeFormViewModel>" %>
<%@ Import Namespace="TimeForing.ViewModels"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Lag Arbeidskode
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Lag Arbeidskode</h2>

  <% Html.RenderPartial("CodeForm"); %>
  
    <div>
        <%=Html.ActionLink("Tilbake til oversikt", "Index") %>
    </div>

</asp:Content>

