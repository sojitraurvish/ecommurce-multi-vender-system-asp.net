<%@ Page Title="" Language="C#" MasterPageFile="~/customer.Master" AutoEventWireup="true" CodeBehind="my_order_details.aspx.cs" Inherits="onlineecom.my_order_details" %>
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
                                    <tr>
                                                <div class="buttons-cart checkout--btn">
                                            
                                            <a style="width:100%;text-align:center;" onclick="window.print()" >Downlode PDF</a>
                                        </div>
                                                </tr></br>
                                    <table>
                                        <thead>
                                            
                                            <tr>
                                                
                                                <th class="product-thumbnail">Product Name</th>
                                                <th class="product-thumbnail">Product Image</th>
                                                <th class="product-name"><span class="nobr">Qty</span></th>
                                                <th class="product-price"><span class="nobr">Price</span></th>
                                                <th class="product-price"><span class="nobr">Total Price</span></th>
                                                
                                                
                                               
                                            </tr>
                                        </thead>
                                        <tbody>
                                 <asp:Repeater ID ="my_all_orders" runat = "server" >
                                    <HeaderTemplate>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                       <%--<li class="drop"><a href='categories.aspx?id=<%# Eval("id") %>'><asp:Label ID = "booksname" Text='<%# Eval("categories") %>' runat="server"></asp:Label></a></td></li>--%>
                                            <tr>
                                                <td class="product-name"><%# Eval("name") %></td>
                                                <td class="product-name"><img src="https://localhost:44326/media/product/<%#Eval("image") %>" alt="product img" /></td>
                                                <td class="product-name"><%# Eval("myqty") %></td>
                                                <td class="product-name">&#8377;<%# Eval("price") %></td>
                                                <td class="product-name">&#8377;<%# Convert.ToInt32(DataBinder.Eval(Container.DataItem, "myqty")) * Convert.ToInt32(DataBinder.Eval(Container.DataItem, "price")) %>.00</td>
                                                
                                                

                                            </tr>

                                            <center><%--<asp:Label ID="single_product_not_found" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>--%></center>
                                        </tbody>
                                    </ItemTemplate>

                                    <FooterTemplate>
                                             
                                    </FooterTemplate>
                                </asp:Repeater>   
                                    <asp:Repeater ID ="my_all_orders_total_price" runat="server" >
                                    <ItemTemplate>
        
                                            <tr style='<%# coupon_value().ToString() == "True" ? "" : "display:none;" %>'>
                                                <th colspan="4" class="product-price"><span class="nobr">Coupon Value</span></th>
                                                <td class="product-name">&#8377;<%# Eval("coupon_value") %>.00</td>
                                            </tr>
                                            <tr>
                                                <th colspan="4" class="product-price"><span class="nobr">Total Price</span></th>
                                                <td class="product-name">&#8377;<%# Eval("total_price") %></td>
                                            </tr>
                                    </ItemTemplate>
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
