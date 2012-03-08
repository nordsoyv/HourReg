<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TimeForing.ViewModels.StoriesViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Rediger Story
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Rediger Story</h2>

     <% Html.RenderPartial("StoryForm"); %>
    <div>
        <%=Html.ActionLink("Til oversikt", "Index") %>
    </div>
</asp:Content>

