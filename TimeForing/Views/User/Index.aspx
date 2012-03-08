<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<TimeForing.Models.User>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Oversikt brukere
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Oversikt brukere</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Navn
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Endre", "Edit", new { id=item.UserID }) %>
            </td>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Opprett ny bruker", "Create") %>
    </p>

</asp:Content>

