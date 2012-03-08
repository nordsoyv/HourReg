<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TimeForing.ViewModels.TimeRegViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Registerer timer
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        function Submit( value) {
            var hid = document.getElementById('command');        
            hid.value = value;
            $("#timeRegForm").submit();
        }

        function AnimateMessage() {
            var m = $('#message');
            if (m.value != "")
                m.animate({ fontSize: '1.5em' }, 400);
        }

        $(document).ready(function() {
            AnimateMessage();
        });
    
    </script>

    <h2>
       Registrer timer for uke nr
        <%= Html.Encode(Model.Week ) %></h2>
    <%= Html.ValidationSummary("Vennligst rett feilene og prøv igjen.")%>
    <% using (Html.BeginForm(null, null, FormMethod.Post, new { id = "timeRegForm" }))
       {
           int i = 0;   %>
    <%= Html.Hidden ("command","") %>
    <%= Html.DropDownList("Date", Model.Dates, new { onchange = "Submit('update');" })%>
    <%= Html.CheckBox("ShowDoneTasks",Model.ShowDoneTasks, new { onclick = "Submit('update');" }) %><label for="ShowDoneTasks">Vis oppgaver med 0 timer igjen</label>
    <table>
        <tr>
            <th>
                Story
            </th>
            <th>
                Kode
            </th>
            <th>
                Navn
            </th>
            <th>
                Org estimat
            </th>
            <th>
                Timer brukt i dag
            </th>
            <th>
                Timer igjen
            </th>
        </tr>
        <%
            foreach (var item in Model.Tasks)
            {
        %>
        <tr>
            <td>
                <%= Html.Encode( item.Story.Name ) %>
            </td>
            <td>
                <%= Html.Encode (item.Code.Name)%>
            </td>
            <td>
                <%= Html.Encode(item.Name)%>
            </td>
            <td>
                <%= Html.Encode(item.OrgEstimate)%>
            </td>
            <td>
                <%= Html.TextBox("TimerBrukt", Model.HourSpent[i])%>
            </td>
            <td>
                <%= Html.TextBox("TimerIgjen", item.TimeLeft )%>
                <%= Html.Hidden("TaskId",item.TaskID ) %>
            </td>
        </tr>
        <%
            i++;
            }
        %>
    </table>
    <table style="border: none 45px #ffffff;">
        <tr>
            <td style="border: none 45px #ffffff;">
                <button name="button" value="save" onclick = "JavaScript:Submit('save');">
                    Lagre</button>
            </td>
            <td style="border: none 45px #ffffff;">
                <div id="message" style="color: #F11B15;">
                    <%= Html.Encode(Model.Message ) %></div>
            </td>
        </tr>
    </table>
    <% }%>
</asp:Content>
