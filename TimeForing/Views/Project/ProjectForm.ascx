<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<TimeForing.Models.Project>" %>

  <%= Html.ValidationSummary("Vennligst rett feilene og prøv igjen.")%>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Felter</legend>
            <p>
                <label for="ProjectID">Project nummer:</label>
                <%= Html.TextBox("ProjectID", Model.ProjectID) %>
                <%= Html.ValidationMessage("ProjectID", "*") %>
            </p>
            <p>
                <label for="Name">Navn:</label>
                <%= Html.TextBox("Name", Model.Name) %>
                <%= Html.ValidationMessage("Name", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>
