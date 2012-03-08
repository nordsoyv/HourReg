<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<TimeForing.Models.Sprint>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
           <th>
                Name
            </th>
            <th>
                StartDate
            </th>
            <th>
                EndDate
            </th>
            <th>
                HoursInSprint
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.SprintID }) %> | <%= Html.ActionLink ("Velg tasks", "SelectTasks", new { id = item.SprintID }) %>
            </td>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.StartDate)) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.EndDate)) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:F}", item.HoursInSprint)) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

