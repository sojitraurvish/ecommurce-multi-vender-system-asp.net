<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="dashbord.aspx.cs" Inherits="onlineecom.admin.dashbord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" type="text/css" rel="stylesheet">
    <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <style>
* {
  box-sizing: border-box;
}

body {
  font-family: Arial, Helvetica, sans-serif;
}

/* Float four columns side by side */
.column {
  float: left;
  width: 25%;
  padding: 0 10px;
}

/* Remove extra left and right margins, due to padding */
.row {margin: 0 -5px;}

/* Clear floats after the columns */
.row:after {
  content: "";
  display: table;
  clear: both;
}

/* Responsive columns */
@media screen and (max-width: 600px) {
  .column {
    width: 100%;
    display: block;
    margin-bottom: 20px;
  }
}

/* Style the counter cards */
.card {
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
  padding: 16px;
  text-align: center;
  background-color: #f1f1f1;
}
</style>
    <div class="content pb-0">
        <div class="orders">
            <div class="row">
                <div class="col-xl-12">
                    <div class="card">
                        <div class="card-body">
                            <h4 class="box-title">Dashbord </h4>
                            <%--<h4 class="box-link"><a href="manage_categories.aspx ">+Add Categories </a></h4>--%>
                        </div>

                        <div class="card-body--">

                            <div class="table-stats order-table ov-h" style="padding: 4px 12px;">
                                <div class="row">
                                 <div class="column">
                                        <div class="card">
                                          <h3>Categories</h3>
                                          <p><asp:Label ID="ftotalCategories" runat="server" Text=""></asp:Label></p>
                                          
                                        </div>
                                      </div>

                                <div class="column">
                                        <div class="card">
                                          <h3>Sub Categories</h3>
                                          <p><asp:Label ID="ftotalSubCategories" runat="server" Text=""></asp:Label></p>
                                          
                                        </div>
                                      </div>
                                
                                <div class="column">
                                        <div class="card">
                                          <h3>Products</h3>
                                          <p><asp:Label ID="ftotalProducts" runat="server" Text=""></asp:Label></p>
                                          
                                        </div>
                                      </div>
                                
                                
                                      <div class="column">
                                        <div class="card">
                                          <h3>Orders</h3>
                                          <p><asp:Label ID="ftotalOrders" runat="server" Text=""></asp:Label></p>
                                          
                                        </div>
                                      </div>

                                    <div class="column">
                                        <div class="card">
                                          <h3>Sales</h3>
                                          <p><asp:Label ID="ftotalSales" runat="server" Text=""></asp:Label></p>
                                          
                                        </div>
                                      </div>
                                    
                                   

                                      <div class="column">
                                        <div class="card">
                                          <h3>Users</h3>
                                          <p> <asp:Label ID="ftotalUsers" runat="server" Text=""></asp:Label></p>
                                          
                                        </div>
                                      </div>
  
                                      <div class="column">
                                        <div class="card">
                                          <h3>Vendors</h3>
                                          <p><asp:Label ID="ftotalVendors" runat="server" Text=""></asp:Label></p>
                                          
                                        </div>
                                      </div>
  
                                      
                                    
                                    
                                    </div>

                                <div id="myPlot" style="width:100%;max-width:450px;display:inline-block;"></div>
                                    <script src="https://cdn.plot.ly/plotly-latest.min.js"></script>
                                    <script>
                                        var xArray = ["Man", "Women", "Child"];
                                        var yArray = [20, 49, 44];

                                        var data = [{
                                            x: xArray,
                                            y: yArray,
                                            type: "bar"
                                        }];

                                        var layout = { title: "Category Wise Product" };

                                        Plotly.newPlot("myPlot", data, layout);
                                    </script>   
                                    
                                    <div id="myPlot1" style="width:100%;max-width:450px;display:inline-block;"></div>

                                    <script>
                                        var xArray = ["Man", "Women", "Child"];
                                        var yArray = [20, 49, 44];

                                        var layout = { title: "Categories Wise Sales" };

                                        var data = [{ labels: xArray, values: yArray, hole: .4, type: "pie" }];

                                        Plotly.newPlot("myPlot1", data, layout);
                                    </script>

                            <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.5.0/Chart.min.js"></script>
                                    <canvas id="myChart6" style="width:100%;max-width:450px;display:inline-block;height:450px;"></canvas>

                                    <script>
                                        var xValues = [100, 200, 300, 400, 500, 600, 700, 800, 900, 1000];

                                        new Chart("myChart6", {
                                            type: "line",
                                            data: {
                                                labels: xValues,
                                                datasets: [{
                                                    data: [860, 1140, 1060, 1060, 1070, 1110, 1330, 2210, 7830, 2478],
                                                    borderColor: "red",
                                                    fill: false
                                                }, {
                                                    data: [1600, 1700, 1700, 1900, 2000, 2700, 4000, 5000, 6000, 7000],
                                                    borderColor: "green",
                                                    fill: false
                                                }, {
                                                    data: [300, 700, 2000, 5000, 6000, 4000, 2000, 1000, 200, 100],
                                                    borderColor: "blue",
                                                    fill: false
                                                }]
                                            },
                                            options: {
                                                legend: { display: false }
                                            }
                                        });
                                    </script>

                                

                                
                                  <div id="myPlot3" style="width:100%;max-width:450px;display:inline-block;"></div>

                                    <script>
                                        var xArray = [50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150];
                                        var yArray = [7, 8, 8, 9, 9, 9, 10, 11, 14, 14, 15];

                                        // Define Data
                                        var data = [{
                                            x: xArray,
                                            y: yArray,
                                            mode: "lines"
                                        }];

                                        // Define Layout
                                        var layout = {
                                            xaxis: { range: [40, 160], title: "Square Meters" },
                                            yaxis: { range: [5, 16], title: "Price in Millions" },
                                            title: "Allover Sales"
                                        };

                                        // Display using Plotly
                                        Plotly.newPlot("myPlot3", data, layout);
                                    </script>

                                
                                
                              
                                     
                                <%--<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
                                   <div id="myChart" style="width:100%;max-width:450px;display:inline-block;">
                                    </div>

                                    <script>
                                        google.charts.load('current', { 'packages': ['corechart'] });
                                        google.charts.setOnLoadCallback(drawChart);

                                        function drawChart() {
                                            var data = google.visualization.arrayToDataTable([
                                                ['Contry', 'Mhl'],
                                                ['Italy', 54.8],
                                                ['France', 48.6],
                                                ['Spain', 44.4],
                                                ['USA', 23.9],
                                                ['Argentina', 14.5]
                                            ]);

                                            var options = {
                                                title: 'World Wide Wine Production',
                                                is3D: true
                                            };

                                            var chart = new google.visualization.PieChart(document.getElementById('myChart'));
                                            chart.draw(data, options);
                                        }
                                    </script>


                                <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js"></script>


                                <canvas id="myChart5" style="width:100%;max-width:450px;display:inline-block;"></canvas>

                                <script>
                                    var xValues = ["Italy", "France", "Spain", "USA", "Argentina"];
                                    var yValues = [55, 49, 44, 24, 15];
                                    var barColors = [
                                        "#b91d47",
                                        "#00aba9",
                                        "#2b5797",
                                        "#e8c3b9",
                                        "#1e7145"
                                    ];

                                    new Chart("myChart5", {
                                        type: "doughnut",
                                        data: {
                                            labels: xValues,
                                            datasets: [{
                                                backgroundColor: barColors,
                                                data: yValues
                                            }]
                                        },
                                        options: {
                                            title: {
                                                display: true,
                                                text: "World Wide Wine Production 2018"
                                            }
                                        }
                                    });
                                </script>--%>

                            </div>
                            </div>
                        </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
