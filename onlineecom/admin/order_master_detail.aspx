<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="order_master_detail.aspx.cs" Inherits="onlineecom.admin.order_master_detail" %>
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
                            <h4 class="box-title">Order Details </h4>
                        </div>
                                 <asp:Repeater ID="address_detail" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                            <div id="address_details" style="margin-left:20px;">
                                                <strong>Address:</strong>
                                                <%# Eval("address") %> <%# Eval("city") %> (<%# Eval("pincode") %>)<br /><br />
                                                 <strong>Total Ammount:</strong>
                                                <%# Eval("total_price") %></br></br>
                                                    
                                                <div>
                                                    <strong>Order Status:</strong><%# Eval("order_status") %></div>
                                                
                                                <strong>&nbsp;</strong>
                                            </div>
                                        </ItemTemplate>

                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:Repeater>
                                            <div id="address_details">
                                                <form ID="order_status" runat="server" >
                                                    <div class="form-group" >
                                                         <asp:DropDownList style="margin-left:0px;"  ID="forder_status" runat="server" class="form-control" >
                                                               <asp:ListItem Text="Select Status" Value="-1"></asp:ListItem>
                                                         </asp:DropDownList>
                                                         <asp:Label ID="Labelforder_status" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                                         <asp:RequiredFieldValidator InitialValue="-1" ControlToValidate="forder_status" ForeColor="Green" ID="RequiredFieldValidatorforder_status" runat="server" ErrorMessage="*Category is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                                   </div>

                                                    <div class="form-group">
                                                        <asp:Button ID="submit" runat="server" Text="Submit" class="btn btn-lg btn-info btn-block" OnClick="submit_Click"  /> 
                                                    </div>
                                                </form>
                                            </div>
                                            
                                                         
                                    
                        <div class="card-body--">
                            
                            <div class="table-stats order-table ov-h" style="padding: 4px 12px;">

                                <asp:Repeater ID="product_details" runat="server">
                                    <HeaderTemplate>
                                        <table class="table" id="example">
                                            <thead>
                                                <tr>
                                                    <th class="serial">#</th>
                                                    <th>Product Name</th>
                                                    <th>Vendor Name</th>
                                                    <th>Product Image</th>
                                                    <th>Qty</th>
                                                    <th>price</th>
                                                    <th>total Price</th>
                                                    
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>

                                    <ItemTemplate>

                                        <tr>
                                            <td class="serial">
                                                <asp:Label ID="booksname" Text='<%# Container.ItemIndex + 1 %>' runat="server"></asp:Label>
                                            </td>
                                             <td class="product-name"><%# Eval("product_name") %></td>
                                             <td class="product-name"><%# Eval("username") %></td>
                                                <td><a href="https://localhost:44326/media/product/<%#Eval("image") %>" target="_blank"><img src="https://localhost:44326/media/product/<%#Eval("image") %>" height="50" width="50" /></a></td>
                                                <td class="product-name"><%# Eval("soled_qty") %></td>
                                                <td class="product-name"><%# Eval("product_price") %></td>
                                                <td class="product-name"><%# Convert.ToInt32(DataBinder.Eval(Container.DataItem, "soled_qty")) * Convert.ToInt32(DataBinder.Eval(Container.DataItem, "product_price")) %></td>
                                            <%--<td>

                                                <a id="deleteCategories" onclick='myFunction()' href = "contact_us.aspx?type=delete&id=<%#Eval("id") %>" class="badge badge-danger hand_cursor">Delete</a>&nbsp;
                                                
                                            </td>--%>

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
