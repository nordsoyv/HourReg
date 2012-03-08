<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<TimeForing.Models.Story>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>Navn</th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id = item.StoryID  }) %> |
                <%= Html.ActionLink("Legg til Tasks", "AddTasks", new { id = item.StoryID })%> |
            </td>
            <td><%= Html.Encode (item.Name ) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Opprett ny story", "Create") %>
    </p>

</asp:Content>

