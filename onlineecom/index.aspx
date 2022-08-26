<%@ Page Title="" Language="C#" MasterPageFile="~/customer.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="onlineecom.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="body__overlay"></div>
        
        <!-- Start Slider Area -->
        <div class="slider__container slider--one bg__cat--3">
            <div class="slide__container slider__activation__wrap owl-carousel">
                <!-- Start Single Slide -->
                <asp:Repeater ID = "banner" runat = "server" >
         
                           
                        <ItemTemplate>
                <div style="background-image:url(images/slider/bg/1.png);" class="single__slide animation__style01 slider__fixed--height">
                    
                                <div class="container">
                                    <div class="row align-items__center">
                                        <div class="col-md-7 col-sm-7 col-xs-12 col-lg-6">
                                            <div class="slide">
                                                <div class="slider__inner">
                                                    <h2><%# Eval("heading1") %></h2>
                                                    <h1><%# Eval("heading2") %></h1>
                                                    <div class="cr__btn">
                                                        <a href="<%# Eval("btn_link") %>"><%# Eval("btn_txt") %></a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-sm-5 col-xs-12 col-md-5">
                                            <div class="slide__thumb">
                                                <a href="https://localhost:44326/media/banner/<%#Eval("image") %>" target="_blank"><img src="https://localhost:44326/media/banner/<%#Eval("image") %>"/></a>
                                               
                                            </div>
                                        </div>
                                    </div>
                                </div>
                          
                </div>
                <!-- End Single Slide -->
              </ItemTemplate>
                     </asp:Repeater> 
               
            </div>
        </div>
        <!-- Start Slider Area -->
        <!-- Start Category Area -->
        <section class="htc__category__area ptb--100">
            <div class="container">
                <div class="row">
                    <div class="col-xs-12">
                        <div class="section__title--2 text-center">
                            <h2 class="title__line">New Arrivals</h2>
                            <p>Our Newest Arrival Products On Sale</p>
                        </div>
                    </div>
                </div>
                <div class="htc__product__container">
                    <div class="row">
                        <div class="product__list clearfix mt--30">
                            <!-- Start Single Category -->
                            <asp:Repeater ID = "new_arrivals_repeter" runat = "server" >
                                    <HeaderTemplate>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                       <%--<li class="drop"><a href='categories.aspx?id=<%# Eval("id") %>'><asp:Label ID = "booksname" Text='<%# Eval("categories") %>' runat="server"></asp:Label></a></td></li>--%>
                                       <div class="col-md-4 col-lg-3 col-sm-4 col-xs-12">
                                            <div class="category">
                                                <div class="ht__cat__thumb">
                                                    <a href="product.aspx?id=<%#Eval("pid") %>">
                                                        <img src="https://localhost:44326/media/product/<%#Eval("image") %>" alt="product images" style="max-width: 100%;">
                                                    </a>
                                                </div>

                                                <div class="fr__hover__info">
                                                    <ul class="product__action">
                                                        <li><a href="javascript:void(0)" onclick="<%# Session["USER_LOGIN"] == null ? "myredirect('login.aspx');" : "manage_wishlist(" +Eval("id") + ",'add');" %>"><i class="icon-heart icons"></i></a></li>

                                                        <li><a href="javascript:void(0)" onclick="<%# Session["USER_LOGIN"] == null ? "myredirect('login.aspx');" : "manage_cart(" +Eval("id") + ",'add');" %>" ><i class="icon-handbag icons"></i></a></li>

                                                        
                                                    </ul>
                                                </div>

                                                <div class="fr__product__inner">
                                                    <h4><a href="product-details.html"><asp:Label ID = "booksname" Text='<%# Eval("name") %>' runat="server"></asp:Label></a></h4>
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
            </div>
        </section>
        <!-- End Category Area -->
        <!-- Start Product Area -->
        <section class="ftr__product__area ptb--100">
            <div class="container">
                <div class="row">
                    <div class="col-xs-12">
                        <div class="section__title--2 text-center">
                            <h2 class="title__line">Best Seller</h2>
                            <p>Our Best Products On Sale</p>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="product__list clearfix mt--30">
                            <!-- Start Single Category -->
                            <asp:Repeater ID = "best_seller_repeter" runat = "server" >
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
                                                        <li><a href="javascript:void(0)" onclick="<%# Session["USER_LOGIN"] == null ? "myredirect('login.aspx');" : "manage_wishlist(" +Eval("id") + ",'add');" %>"><i class="icon-heart icons"></i></a></li>

                                                        <li><a href="javascript:void(0)" onclick="<%# Session["USER_LOGIN"] == null ? "myredirect('login.aspx');" : "manage_cart(" +Eval("id") + ",'add');" %>" ><i class="icon-handbag icons"></i></a></li>

                                                        
                                                    </ul>
                                                </div>

                                                <div class="fr__product__inner">
                                                    <h4><a href="product-details.html"><asp:Label ID = "booksname" Text='<%# Eval("name") %>' runat="server"></asp:Label></a></h4>
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
        </section>
        <!-- End Product Area -->
</asp:Content>
