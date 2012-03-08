<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<TimeForing.Models.Project>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Prosjekter
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Prosjekter</h2>

    <table>
        <tr>
            <th>Prosjekt nummer</th>
            <th>
                Navn
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink(item.ProjectID.ToString ()  , "Edit", new { id=item.ProjectID }) %> 
            </td>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Opprett nytt prosjekt", "Create") %>
    </p>

</asp:Content>

