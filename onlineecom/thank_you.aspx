<%@ Page Title="" Language="C#" MasterPageFile="~/customer.Master" AutoEventWireup="true" CodeBehind="thank_you.aspx.cs" Inherits="onlineecom.thank_you" %>
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
            <section class="htc__product__grid bg__white ptb--100"></section>
            <div class="container">
                <div class="row">
                    <div runat="server" id="single_product" class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="htc__product__rightidebar">
                            <div class="htc__grid__top">
                                <div class="htc__select__option">
                                    <center><b><h1 style="color:red;">Your order has been placed successfully.</h1></b></center>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                                   
</asp:Content>
