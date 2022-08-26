<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="banner.aspx.cs" Inherits="onlineecom.admin.banner" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" type="text/css" rel="stylesheet">
    <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <div class="content pb-0">
        <div class="orders">
            <div class="row">
                <div class="col-xl-12">
                    <div class="card">
                        <div class="card-body">
                            <h4 class="box-title">Banner </h4>
                            <h4 class="box-link"><a href="manage_banner.aspx ">+Add Banner </a></h4>
                        </div>

                        <div class="card-body--">

                            <div class="table-stats order-table ov-h" style="padding: 4px 12px;">

                                <asp:Repeater ID="r1" runat="server">
                                    <HeaderTemplate>
                                        <table class="table" id="example">
                                            <thead>
                                                <tr>
                                                    <th class="serial">#</th>
                                                    <th>ID</th>
                                                    <th>Heading 1</th>
                                                    <th>Heading 2</th>
                                                    <th>Btn Text</th>
                                                    <th>Btn Link</th>
                                                    <th>Image</th>
                                                    <th>Order No</th>
                                                    <th>Status</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>

                                    <ItemTemplate>

                                        <tr>
                                            <td class="serial">
                                                <asp:Label ID="booksname" Text='<%# Container.ItemIndex + 1 %>' runat="server"></asp:Label></td>
                                            <td><%# Eval("id") %></td>
                                            <td><%# Eval("heading1") %></td>
                                            <td><%# Eval("heading2") %></td>
                                            <td><%# Eval("btn_txt") %></td>
                                            <td><%# Eval("btn_link") %></td>
                                            <td><a href="https://localhost:44326/media/banner/<%#Eval("image") %>" target="_blank"><img src="https://localhost:44326/media/banner/<%#Eval("image") %>" height="50" width="50" /></a></td>
                                            <td><%# Eval("order_by") %></td>
                                            <td>
                                                <asp:HyperLink ID="hyperLinkDeactive" runat="server" NavigateUrl='<%# string.Format("banner.aspx?type=status&opration=deactive&id={0}",Eval("id")) %>' Visible='<%# Eval("status").ToString() == "True" ? true : false %>'>
                                                    <asp:Label ID="lbldeactive" runat="server" class="badge badge-success hand_cursor" Text="Active"></asp:Label>
                                                </asp:HyperLink>&nbsp;
                                                
                                                <asp:HyperLink ID="hyperLinkActive" runat="server" NavigateUrl='<%# string.Format("banner.aspx?type=status&opration=active&id={0}",Eval("id")) %>' Visible='<%# Eval("status").ToString() != "False" ? false : true %>'>
                                                    <asp:Label ID="lblactive" runat="server" class="badge badge-primary hand_cursor" Text="Deactive"></asp:Label>
                                                </asp:HyperLink>&nbsp;
                                           
                                                <a href="manage_banner.aspx?id=<%#Eval("id") %>" id="editCategories" class="badge badge-warning hand_cursor">Edit</a>&nbsp;

                                                <a id="deleteCategories" onclick='myFunction()' href = "banner.aspx?type=delete&id=<%#Eval("id") %>" class="badge badge-danger hand_cursor">Delete</a>&nbsp;
                                                <%--<a id="deleteCategories" onclick='<%# "myFunction(" + Eval("id") + ");" %>' class="badge badge-danger hand_cursor" >Delete</a>&nbsp;--%>
                                            
                                                
                                            </td>

                                        </tr>

                                    </ItemTemplate>

                                    <FooterTemplate>
                                        </tbody>
                                </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#example').DataTable({
                "pagingType": "full_numbers"
            });
        });
    </script>
    <script>
        function myFunction() {
            let text = "Press a button to Delete Record!\nEither OK or Cancel.";
            if (confirm(text) == true) {
                /*document.getElementById("deleteCategories").href = 'categories.aspx?type=delete&id=' + id;*/
            } else {
                document.getElementById("deleteCategories").href = '';
                text = "You canceled!";
                alert(text);
            }
            /*document.getElementById("demo").innerHTML = text;*/
        }
        //function myFunction(id) {
        //    let text = "Press a button to Delete Record!\nEither OK or Cancel.";
        //    if (confirm(text) == true) {
        //        document.getElementById("deleteCategories").href = 'categories.aspx?type=delete&id=' + id;
        //    } else {
        //        text = "You canceled!";
        //        alert(text);
        //    }
        //    /*document.getElementById("demo").innerHTML = text;*/
        //}
    </script>

</asp:Content>
