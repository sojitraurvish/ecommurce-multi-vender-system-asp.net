<%@ Page Title="" Language="C#" MasterPageFile="~/customer.Master" AutoEventWireup="true" CodeBehind="wishlist.aspx.cs" Inherits="onlineecom.wishlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ht__bradcaump__area" style="background: rgba(0, 0, 0, 0) url(images/bg/4.jpg) no-repeat scroll center center / cover ;">
            <div class="ht__bradcaump__wrap">
                <div class="container">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="bradcaump__inner">
                                <nav class="bradcaump-inner">
                                  <a class="breadcrumb-item" href="index.html">Home</a>
                                  <span class="brd-separetor"><i class="zmdi zmdi-chevron-right"></i></span>
                                  <span class="breadcrumb-item active">shopping cart</span>
                                </nav>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Bradcaump area -->
        <!-- cart-main-area start -->
        <div class="cart-main-area ptb--100 bg__white">
            <div class="container">
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <form action="#">               
                            <div class="table-content table-responsive">

                               
                                <table>
                                    <thead>
                                        <tr>
                                            <th class="product-thumbnail">products</th>
                                            <th class="product-name">name of products</th>
                                            <th class="product-remove">Remove</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                   <asp:Repeater ID = "cart_product_repeter" runat = "server" >
                                    <HeaderTemplate>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                       <%--<li class="drop"><a href='categories.aspx?id=<%# Eval("id") %>'><asp:Label ID = "booksname" Text='<%# Eval("categories") %>' runat="server"></asp:Label></a></td></li>--%>
                                        <tr>
                                            <td class="product-thumbnail"><a href="product.aspx?id=<%#Eval("product_id") %>"><img src="https://localhost:44326/media/product/<%#Eval("image") %>" alt="product img" height="50%" width="50%"/></a></td>
                                            <td class="product-name"><a href="#"><%# Eval("name") %></a>
                                                <ul  class="pro__prize">
                                                    <li class="old__prize" style="text-decoration: line-through;"> &#8377;<%# Eval("mrp") %></li>
                                                    <li> &#8377;<%# Eval("price") %></li>
                                                </ul>
                                            </td>
                                            
                                            <td class="product-remove"><a href="javascript:void(0)" onclick="<%# "manage_wishlist(" +Eval("product_id") + ",'remove');" %>"><i class="icon-trash icons"></i></a></td>
                                        </tr>
                                        
                                    
                                
                                    </ItemTemplate>

                                    <FooterTemplate>
                                        
                                    </FooterTemplate>
                                </asp:Repeater>
                             </tbody>
                            </table>
                            </div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <div class="buttons-cart--inner">
                                        <div class="buttons-cart">
                                            <a href="index.aspx">Continue Shopping</a>
                                        </div>
                                        <div class="buttons-cart checkout--btn">
                                            
                                            <a href="checkout.aspx">checkout</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </form> 
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
