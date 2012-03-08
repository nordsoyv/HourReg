<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TimeForing.ViewModels.BurndownReportViewModel>" %>
<%@ Import Namespace ="System.Web.UI.DataVisualization.Charting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	BurndownRapport
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>BurndownRapport</h2>
Rapport for <%= Html.Encode(Model.Sprint.Name) %>
<br />
<table>
 <tr>
           <th></th>
            <% foreach (var dato in Model.Dates)
               { %>
            <th>
                <%= Html.Encode (dato.ToString("dd.MM")) %>
            </th>
            <%} %>
        </tr>
        <tr>
       <th>Timer igjen</th>
        <% for (int i = 0; i < Model.Timer.Count;i++ )
           {
               if (Model.Dates[i].DayOfWeek == DayOfWeek.Saturday || Model.Dates[i].DayOfWeek == DayOfWeek.Sunday)
               {
                    %><td style ="background-color:#F1CBC5 ;"><%
            }
               else
               {
                    %><td><%
            } %>
            <%= Html.Encode(Model.Timer[i] > 0 ? Model.Timer[i].ToString( ) : ""  )%></td>   
          <% } %>
        </tr>
</table>
<p>
<%
    
    System.Web.UI.DataVisualization.Charting.Chart chart = new Chart
                      {
                          Width = 800,
                          Height = 600,
                          RenderType = RenderType.ImageTag,
                          Palette = ChartColorPalette.BrightPastel
                      };

    Title t = new Title("Burndown for " + Model.Sprint.Name, Docking.Top);
    chart.Titles.Add(t);
    chart.ChartAreas.Add("Burndown");
    chart.ChartAreas["Burndown"].AxisY.Title = "Timer";

    chart.ChartAreas["Burndown"].AxisX.Title = "Dager i sprint : " + Model.Dates[0].ToString("dd.MM.yyyy") + " - " + Model.Dates[Model.Dates.Count - 1].ToString("dd.MM.yyyy");
    chart.ChartAreas["Burndown"].AxisX.Minimum = 0;
    chart.ChartAreas["Burndown"].AxisX.Maximum = Model.Dates.Count;
    chart.ChartAreas["Burndown"].AxisX.Interval = 1;
    
    
    

    chart.Series.Add("Ideal");
    chart.Series["Ideal"].ChartType = SeriesChartType.Line;
    chart.Series["Ideal"].BorderWidth = 2;
    
    chart.Series.Add("Burndown");
    chart.Series["Burndown"].ChartType = SeriesChartType.Spline;
    chart.Series["Burndown"].MarkerStyle = MarkerStyle.Diamond;
    chart.Series["Burndown"].MarkerSize = 15;
    chart.Series["Burndown"].BorderWidth = 4;

    //legger til ett punkt først så det matcher burndown
    chart.Series["Burndown"].Points.AddXY(0, Model.OrgTimer);
    for (int i = 0; i < Model.Timer.Count  ; i++)
    {
        double value = Model.Timer[i];
        if (value > 0)
            chart.Series["Burndown"].Points.AddXY(i+1,value );
        
    }
/*    foreach (var time in Model.Timer )
    {
        chart.Series["Burndown"].Points.AddY(time);
    } */
    chart.Series["Ideal"].Points.AddXY(0, Model.OrgTimer);
    chart.Series["Ideal"].Points.AddXY(Model.Dates.Count, 0);

    chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
    chart.BorderColor = System.Drawing.Color.FromArgb(26, 59, 105);
    chart.BorderlineDashStyle = ChartDashStyle.Solid;
    chart.BorderWidth = 2;

    chart.Legends.Add("Legend1");

    // Render chart control  
    chart.Page = this;
    HtmlTextWriter writer = new HtmlTextWriter(Page.Response.Output);
    chart.RenderControl(writer);  
  
    
     %>
</p>
 

</asp:Content>
