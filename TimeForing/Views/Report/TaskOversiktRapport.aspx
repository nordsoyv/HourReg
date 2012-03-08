<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TimeForing.ViewModels.TaskOversiktViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	TaskOversiktRapport
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>TaskOversiktRapport</h2>
 Rapport for
    <%=Html.Encode (Model.User.Name ) %>, uke <%=Html.Encode (Model.Week   ) %>
    <br />
    <br />
    <table>
        <tr>
            <th>
            </th>
            <% foreach (var dato in Model.Dates)
               { %>
            <th>
                <%= Html.Encode (dato.ToString("dd.MM")) %>
            </th>
            <%} %>
        </tr>
        <%for (int i = 0; i < Model.Tasks.Count; i++)
          { %>
        <tr>
            <th>
                <%= Html.Encode(Model.Tasks[i].Name   )%>
            </th>
            <% foreach (var dato in Model.Dates)
               {
                   String d = dato.ToString("ddMMyyyy");
                   var timeInfo = Model.Timer[d];
                    if (dato.DayOfWeek == DayOfWeek .Saturday  || dato.DayOfWeek == DayOfWeek.Sunday )
                   {
                    %><td style ="background-color:#F1CBC5 ;"><%
                   }
                   else
                   {
                    %><td><%
                   }
            %>
                <%= Html.Encode ( timeInfo.ContainsKey ( Model.Tasks[i].TaskID  ) ? timeInfo[Model.Tasks[i].TaskID  ].ToString (): "0"   ) %>
            </td>
            <%        
               
               
                } %>
        </tr>
        <%} %>
    </table>
</asp:Content>
