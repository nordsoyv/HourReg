<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<TimeForing.Models.Sprint>" %>
<%= Html.ValidationSummary("Vennligst rett feilene og prøv igjen.")%>
<% using (Html.BeginForm())
   {%>
<fieldset>
    <legend>Felter</legend>
    <p>
        <label for="Name">
            Navn:</label>
        <%= Html.TextBox("Name", Model.Name) %>
        <%= Html.ValidationMessage("Name", "*") %>
    </p>
    <p>
        <label for="StartDate">
            Start dato:</label>
        <%= Html.TextBox("StartDate", String.Format("{0:g}", Model.StartDate)) %>
        <%= Html.ValidationMessage("StartDate", "*") %>
    </p>
    <p>
        <label for="EndDate">
            Slutt dato:</label>
        <%= Html.TextBox("EndDate", String.Format("{0:g}", Model.EndDate)) %>
        <%= Html.ValidationMessage("EndDate", "*") %>
    </p>
    <p>
        <label for="HoursInSprint">
            Timer i sprint:</label>
        <%= Html.TextBox("HoursInSprint", String.Format("{0:F}", Model.HoursInSprint)) %>
        <%= Html.ValidationMessage("HoursInSprint", "*") %>
    </p>
    <p>
    <%= Html.CheckBox( "Archived",Model.Archived ) %><label for="Archived">Arkiver sprint</label>
        <%= Html.ValidationMessage("Archived", "*")%>
        
    </p>
    <p>
        <input type="submit" value="Save" />
    </p>
</fieldset>
<% } %>
<div>
    <%=Html.ActionLink("Tilbake til oversikt", "Index") %>
</div>
