<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TaskFormViewModel>" %>
<%@ Import Namespace="TimeForing.ViewModels"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Endre task
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Endre task</h2>
    
    <%  using (Html.BeginForm(null, null, FormMethod.Post, new { id = "taskRegForm" }))
        {
 
%>
    <% Html.RenderPartial("TaskForm"); %>
           <button name="save" onclick="JavaScript:Submit('save');" >Lagre</button>
        </fieldset>

    <% } %> 
   
     <div>
        <%=Html.ActionLink("Tilbake til oversikt", "Index") %>
    </div>
</asp:Content>
