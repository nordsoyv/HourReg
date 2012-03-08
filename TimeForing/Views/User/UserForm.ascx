<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<TimeForing.Models.User>" %>

 <%= Html.ValidationSummary("Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Felter</legend>
            <p>
                <label for="Name">Navn:</label>
                <%= Html.TextBox("Name",Model.Name ) %>
                <%= Html.ValidationMessage("Name", "*") %>
            </p>
            <p>
                <input type="submit" value="Lagre" />
            </p>
        </fieldset>

    <% } %>
 <div>
        <%=Html.ActionLink("Tilbake til oversikt", "Index") %>
    </div>