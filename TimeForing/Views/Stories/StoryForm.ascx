<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<TimeForing.ViewModels.StoriesViewModel>" %>

    <%= Html.ValidationSummary("Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Felter</legend>
            <p>
             <label for="Name">Name:</label>
                <%= Html.TextBox("Name", Model.Story.Name , new { @style = "width:200px" })%>
                <%= Html.ValidationMessage("Name", "*") %>
            </p>
            <p>
                <label for="Beskrivelse">Beskrivelse:</label>
                <%= Html.TextBox("Description", Model.Story.Description, new { @style = "width:200px" })%>
                <%= Html.ValidationMessage("Beskrivelse", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

   

