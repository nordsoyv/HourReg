<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SelectTasksViewModel>" %>

<%@ Import Namespace="TimeForing.ViewModels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Velg oppgaver
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Velg oppgaver i sprint</h2>
    <%= Html.Encode (Model.Sprint.Name ) %>
    <% using (Html.BeginForm())
       {%>
    <table>
        <tr>
            <th>
                Story
            </th>
            <th>
                Name
            </th>
            <th>
                Beskrivelse
            </th>
            <th>
                Assigned
            </th>
            <th>
                Antall timer
            </th>
            <th>
                Sprint
            </th>
        </tr>
        <% for (int i = 0; i < Model.Tasks.Count; i++)
           { %>
        <tr>
            <td>
                <%= Html.Encode( Model.Tasks[i].Story.Name ) %>
            </td>
            <td>
                <%= Html.Encode(Model.Tasks[i].Name )%>
            </td>
            <td>
                <%= Html.Encode (Model.Tasks[i].Description ) %>
            </td>
            <td>
                <%= Html.DropDownList ("UserID", Model.AllUsers[i]) %>
            </td>
            <td>
                <%= Html.Encode(Model.Tasks[i].TimeLeft)%>
            </td>
            <td>
                <%= Html.DropDownList("SprintID", Model.AllSprints[i])%>
            </td>
        </tr>
        <%       } %>
    </table>
    <input type="submit" value="Save" />
    <%         }%>
</asp:Content>
