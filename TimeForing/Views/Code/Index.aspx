<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<TimeForing.Models.Code>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Oversikt arbeidskoder
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Oversikt arbeidskoder</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Prosjekt
            </th>
            <th>
                Arbeidskode
            </th>
            <th>
                Navn
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Endre", "Edit", new { id=item.CodeID }) %>
            </td>
            <td>
                <%= Html.Encode(item.ProjectID) %>
            </td>
            <td>
                <%= Html.Encode(item.CodeNumber ) %>
            </td>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Lag ny arbeidskode", "Create") %>
    </p>

</asp:Content>

