<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CodeFormViewModel>" %>
<%@ Import Namespace="TimeForing.ViewModels"%>

  <%= Html.ValidationSummary("Vennligst rett feilene og prøv igjen.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Felter</legend>
            <p>
                <label for="ProjectID">Prosjekt:</label>
                <%= Html.DropDownList("ProjectID", Model.ProjectCodes)%>
                <%= Html.ValidationMessage("ProjectID", "*") %>
            </p>
            <p>
                <label for="CodeNumber">Arbeidskode:</label>
                <%= Html.TextBox("CodeNumber", Model.Code.CodeNumber) %>
                <%= Html.ValidationMessage("CodeNumber", "*") %>
            </p>
            <p>
                <label for="Name">Navn:</label>
                <%= Html.TextBox("Name", Model.Code.Name) %>
                <%= Html.ValidationMessage("Name", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>
