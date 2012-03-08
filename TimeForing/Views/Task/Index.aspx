<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TimeForing.ViewModels.TaskIndexViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        $(function() {
            $("#treeview ul").treeview();
        });

        function Submit(value) {
            var hid = document.getElementById('command');
            hid.value = value;
            $("#taskOversiktForm").submit();
        }
        
    </script>

    <h2>
        Index</h2>
    <%= Html.ActionLink("Create New", "Create") %>
    <% using (Html.BeginForm(null, null, FormMethod.Post, new { id = "taskOversiktForm" }))
       {%>
    <%= Html.Hidden ("command","") %>
    <%= Html.CheckBox("ShowDoneTasks", Model.ShowDoneTasks, new { onclick = "Submit('update');" })%><label
        for="ShowDoneTasks">Vis oppgaver med 0 timer igjen</label>
    <%} %>
    <div id="treeview">
        <ul>
            <%
                foreach (var story in Model.Stories)
                {
            %>
            <li>
                <%=Html.Encode (story.Name ) %>
                <ul>
                    <%
                        foreach (var task in story.Tasks.OrderBy(t => t.Name))
                        {
                            if (task.TimeLeft > 0 || Model.ShowDoneTasks)
                            {
                    %>
                    <li>
                        <%= Html.ActionLink("Endre", "Edit", new { id = task.TaskID })%>&nbsp <%= Html.Encode(task.Name)%>
                    </li>
                    <%
                            }
                        } 
                    %>
                </ul>
            </li>
            <%        }
        
            %>
        </ul>
    </div>
</asp:Content>
