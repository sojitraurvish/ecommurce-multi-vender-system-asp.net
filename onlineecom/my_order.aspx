<%@ Page Title="" Language="C#" MasterPageFile="~/customer.Master" AutoEventWireup="true" CodeBehind="my_order.aspx.cs" Inherits="onlineecom.my_order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="body__overlay"></div>
       
        <!-- Start Bradcaump area -->
       
        <div class="ht__bradcaump__area" style="background: rgba(0, 0, 0, 0) url(https://localhost:44326/images/bg/4.jpg) no-repeat scroll center center / cover ;">
            <div class="ht__bradcaump__wrap">
                <div class="container">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="bradcaump__inner">
                                <nav class="bradcaump-inner">
                                  <a class="breadcrumb-item" href="index.aspx">Home</a>
                                  <span class="brd-separetor"><i class="zmdi zmdi-chevron-right"></i></span>
                                  <span class="breadcrumb-item active">Thank you</span>
                                </nav>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Bradcaump area -->
        <!-- Start Product Grid -->
            <%--<section class="htc__product__grid bg__white ptb--100"></section>--%>
           <div class="wishlist-area ptb--100 bg__white">
            <div class="container">
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="wishlist-content">
                            <form action="#">
                                <div class="wishlist-table table-responsive">
                                    <table>
                                        <thead>
                                            <tr>
                                                
                                                <th class="product-thumbnail">Order Id</th>
                                                <th class="product-name"><span class="nobr">Order Date</span></th>
                                                <th class="product-price"><span class="nobr">Address</span></th>
                                                <th class="product-stock-stauts"><span class="nobr">Payment Type</span></th>
                                                <th class="product-stock-stauts"><span class="nobr">Payment Status</span></th>
                                                <th class="product-stock-stauts"><span class="nobr">Order Status</span></th>
                                               
                                            </tr>
                                        </thead>
                                        <tbody>
                                 <asp:Repeater ID ="my_all_orders" runat = "server" >
                                    <HeaderTemplate>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                       <%--<li class="drop"><a href='categories.aspx?id=<%# Eval("id") %>'><asp:Label ID = "booksname" Text='<%# Eval("categories") %>' runat="server"></asp:Label></a></td></li>--%>
                                            <tr>
                                                <td class="product-add-to-cart"><a href="my_order_details.aspx?id=<%# Eval("id") %>"><%# Eval("id") %></a></td>
                                                <td class="product-name"><%# Eval("created_at") %></td>
                                                <td class="product-name"><%# Eval("address") %></td>
                                                <td class="product-name"><%# Eval("payment_type") %></td>
                                                <td class="product-name"><%# Eval("payment_status") %></td>
                                                <td class="product-name"><%# Eval("name") %></td>
                                                
                                                

                                            </tr>
                                            <center><%--<asp:Label ID="single_product_not_found" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>--%></center>
                                        </tbody>
                                    </ItemTemplate>

                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:Repeater>    
                                    </table>
                                </div>  
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
