<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<TaskFormViewModel>" %>
<%@ Import Namespace="TimeForing.ViewModels"%>
 <script type="text/javascript">
        function Submit( value) {
            var hid = document.getElementById('command');        
            hid.value = value;
            $("#taskRegForm").submit();
        }
        </script>
        
  <%= Html.ValidationSummary("Vennligst rett feilene og prøv igjen.")%>

        
        <%= Html.Hidden( "command","") %>
        <fieldset>
            <legend>Felter</legend>
            <p>
                <label for="Name">Navn:</label>
                <%= Html.TextBox("Name", Model.Task.Name   , new { @style = "width:200px" })%>
                <%= Html.ValidationMessage("Name", "*") %>
            </p>
            <p>
                <label for="Beskrivelse">Beskrivelse:</label>
                <%= Html.TextBox("Description", Model.Task.Description, new { @style = "width:200px" })%>
                <%= Html.ValidationMessage("Beskrivelse", "*") %>
            </p>
            <p>
                <label for="Story">Story:</label>
                <%= Html.DropDownList ("StoryID", Model.Story , new  { @style = "width:200px" })%>
                <%= Html.ValidationMessage("Story", "*")%>
            </p>
            <p>
                <label for="OrgEstimate">Estimat:</label>
                <%= Html.TextBox("OrgEstimate", Model.Task.OrgEstimate, new { @style = "width:200px" })%>
                <%= Html.ValidationMessage("OrgEstimate", "*")%>
            </p>
            <p>
                <label for="TimeLeft">Tid igjen:</label>
                <%= Html.TextBox("TimeLeft", Model.Task.TimeLeft, new { @style = "width:200px" })%>
                <%= Html.ValidationMessage("TimeLeft", "*") %>
            </p>
            <p>
                <label for="User">Bruker:</label>
                <%= Html.DropDownList("UserID", Model.User, new { @style = "width:200px" })%>
                <%= Html.ValidationMessage("User", "*") %>
            </p>
            <p>
                <label for="Code">Timekode</label>
                <%= Html.DropDownList("CodeID", Model.Code, new { @style = "width:200px" })%>
                <%= Html.ValidationMessage("Code", "*") %>
            </p>
            <p>
                <label for="Sprint">Sprint</label>
                <%= Html.DropDownList("SprintID",Model.Sprint ,new{@style="width:200px"}) %>
                <%= Html.ValidationMessage("Sprint", "*") %>
            </p>