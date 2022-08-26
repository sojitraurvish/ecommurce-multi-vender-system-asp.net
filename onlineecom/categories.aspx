<%@ Page Title="" Language="C#" MasterPageFile="~/customer.Master" AutoEventWireup="true" CodeBehind="categories.aspx.cs" Inherits="onlineecom.categories" %>
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
                                  <a class="breadcrumb-item" href="index.html">Home</a>
                                  <span class="brd-separetor"><i class="zmdi zmdi-chevron-right"></i></span>
                                  <span class="breadcrumb-item active">Products</span>
                                </nav>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Bradcaump area -->
        <!-- Start Product Grid -->
        <section class="htc__product__grid bg__white ptb--100">
            <div class="container">
                <div class="row">
                    <div runat="server" id="single_product" class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="htc__product__rightidebar">
                            <div class="htc__grid__top">
                                <div class="htc__select__option">
                                    <asp:Repeater ID = "sort_product_dropdown" runat = "server" >
                                    <HeaderTemplate>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                    <select class="ht__select" onchange="<%# "sort_product_dropdown(" +Eval("categories_id") + ")" %>" id="sort_product_id">
                                        <option value="">Default softing</option>
                                        <option value="price_low" <%=Price_low_selected%> >Sort by price low to high</option>
                                        <option value="price_high" <%=Price_high_selected%> >Sort by price high to low</option>
                                        <option value="new" <%=New_selected%> >Sort by new first</option>
                                        <option value="old" <%=Old_selected%> >Sort by old first</option>
                                    </select>
                                     </ItemTemplate>

                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:Repeater>
                                </div>
                                
                                   
                            </div>
                            <!-- Start Product View -->
                            <div class="row">
                                <div class="shop__grid__view__wrap">
                                    <div role="tabpanel" id="grid-view" class="single-grid-view tab-pane fade in active clearfix">
                                        <!-- Start Single Category -->
                            <asp:Repeater ID = "categories_repeter" runat = "server" >
                                    <HeaderTemplate>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                       <%--<li class="drop"><a href='categories.aspx?id=<%# Eval("id") %>'><asp:Label ID = "booksname" Text='<%# Eval("categories") %>' runat="server"></asp:Label></a></td></li>--%>
                                       <div class="col-md-4 col-lg-3 col-sm-4 col-xs-12">
                                            <div class="category">
                                                <div class="ht__cat__thumb">
                                                    <a href="product.aspx?id=<%#Eval("id") %>">
                                                        <img src="https://localhost:44326/media/product/<%#Eval("image") %>" alt="product images" style="max-width: 100%;">
                                                    </a>
                                                </div>

                                                <div class="fr__hover__info">
                                                    <ul class="product__action">
                                                        <li><a style="padding-top:2px;" href="javascript:void(0)" onclick="<%# Session["USER_LOGIN"] == null ? "myredirect('login.aspx');" : "manage_wishlist(" +Eval("id") + ",'add');" %>"><i class="icon-heart icons"></i></a></li>

                                                        <li><a style="padding-top:2px; href="javascript:void(0)" onclick="<%# Session["USER_LOGIN"] == null ? "myredirect('login.aspx');" : "manage_cart(" +Eval("id") + ",'add');" %>" ><i class="icon-handbag icons"></i></a></li>

                                                        
                                                    </ul>
                                                </div>

                                                <div class="fr__product__inner">
                                                    <h4><a href="product-details.html"><asp:Label ID = "booksname" Text='<%# Eval("name") %>' runat="server"></asp:Label>t</a></h4>
                                                    <ul class="fr__pro__prize">
                                                        <li class="old__prize" style="text-decoration: line-through;">&#8377;<asp:Label ID = "Label1" Text='<%# Eval("mrp") %>' runat="server"></asp:Label></li>
                                                        <li>&#8377;<asp:Label ID = "Label2" Text='<%# Eval("price") %>' runat="server"></asp:Label></li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>

                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:Repeater>
                            
                            <!-- End Single Category -->
                                       
                                    </div>

                                </div>
                                
                            </div>
                            <!-- End Product View -->
                        </div>
                        
                    </div>
                    <center><asp:Label ID="single_product_not_found" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label></center>
                </div>
            </div>
        </section>
        <!-- End Product Grid -->

        <!-- End Banner Area -->
</asp:Content>
