<%@ Page Title="" Language="C#" MasterPageFile="~/customer.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="onlineecom.product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <span runat="server" id="single_product">
        
     <asp:Repeater ID = "product_repeter" runat = "server" >
         
                           
        <ItemTemplate>
                       <%--<li class="drop"><a href='categories.aspx?id=<%# Eval("id") %>'><asp:Label ID = "booksname" Text='<%# Eval("categories") %>' runat="server"></asp:Label></a></td></li>--%>
                        <!-- Start Bradcaump area -->
        <div class="ht__bradcaump__area" style="background: rgba(0, 0, 0, 0) url(images/bg/4.jpg) no-repeat scroll center center / cover ;">
            <div class="ht__bradcaump__wrap">
                <div class="container">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="bradcaump__inner">
                                <nav class="bradcaump-inner">
                                  <a class="breadcrumb-item" href="index.aspx">Home</a>
                                  <span class="brd-separetor"><i class="zmdi zmdi-chevron-right"></i></span>
                                  <a class="breadcrumb-item" href="categories.aspx?id=<%#Eval("cid") %>"><%#Eval("categories") %></a>
                                  <span class="brd-separetor"><i class="zmdi zmdi-chevron-right"></i></span>
                                  <span class="breadcrumb-item active"><%#Eval("name") %></span>
                                </nav>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Bradcaump area -->
        
    
        <!-- Start Product Details Area -->
        <section class="htc__product__details bg__white ptb--100">
            <!-- Start Product Details Top -->
            <div class="htc__product__details__top">
                <div class="container">
                    <div class="row">
                        <div class="col-md-5 col-lg-5 col-sm-12 col-xs-12">
                            <div class="htc__product__details__tab__content">
                                <!-- Start Product Big Images -->
                                <div class="product__big__images">
                                    <div class="portfolio-full-image tab-content">
                                        <div role="tabpanel" class="tab-pane fade in active" id="img-tab-1">
                                            <img src="https://localhost:44326/media/product/<%#Eval("image") %>" alt="full-image"/>
                                        </div>
                                    </div>
                                </div>
                                <!-- End Product Big Images -->
                                
                            </div>
                        </div>
                        <div class="col-md-7 col-lg-7 col-sm-12 col-xs-12 smt-40 xmt-40">
                            <div class="ht__product__dtl">
                                <h2><%#Eval("name") %></h2>
                                <ul  class="pro__prize">
                                   <li class="old__prize" style="text-decoration: line-through;"> &#8377;<%#Eval("mrp") %></li>
                                    <input type="hidden" id="product_id" value="<%#Eval("id") %>">
                                    <li>&#8377;<%#Eval("price") %></li>
                                </ul>
                                <p class="pro__info"><%#Eval("short_desc") %></p>
                                <div class="ht__pro__desc">
                                    <div class="sin__desc">
                                      
                                           
                                        </ItemTemplate>
                                   </asp:Repeater>
                                        <p><span>Availability: </span></p> <b> <asp:Label ID="favailability" runat="server" Text="" ></asp:Label> </b>
                                    </div><br>

                                    <asp:Repeater ID = "product_repeter2" runat = "server" >
                                     <ItemTemplate>
                                        <div class="sin__desc" style="<%# availability_of_product() == null ? "display:none;" : "" %>">
                                        <p><span>Qty:</span> 
                                            <select id="qty" >
                                                <option>1</option>
                                                <option>2</option>
                                                <option>3</option>
                                                <option>4</option>
                                                <option>5</option>
                                                <option>6</option>
                                                <option>7</option>
                                                <option>8</option>
                                                <option>9</option>
                                                <option>10</option>

                                            </select>
                                        </p>

                                    </div>
                                   
                                    
                                    </div>
                                
                                         <div class="sin__desc align--left">
                                        <p><span>Categories:</span>
                                           
                                        </p>
                                        <ul class="pro__cat__list">
                                            <li><a href="categories.aspx?id=<%#Eval("cid") %>"><%#Eval("categories") %></a></li>
                                        </ul>
                                        </div></br>

                                <a style="<%# availability_of_product() == null ? "display:none;" : "" %>" class="fr__btn" href="#" onclick="<%# Session["USER_LOGIN"] == null ? "myredirect('login.aspx');" : "manage_cart(" +Eval("id") + ",'add');" %>" style="margin-top:20px;">+Add to cart</a>
                                <a style="<%# availability_of_product() == null ? "display:none;" : "" %>" class="fr__btn buy_now" href="#" onclick="<%# Session["USER_LOGIN"] == null ? "myredirect('login.aspx');" : "manage_cart(" +Eval("id") + ",'add','yes');" %>" style="margin-top:20px;">+Buy Now</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- End Product Details Top -->
        </section>
        <!-- End Product Details Area -->
    <!-- Start Product Description -->
        <section class="htc__produc__decription bg__white">
            <div class="container">
                <div class="row">
                    <div class="col-xs-12">
                        <!-- Start List And Grid View -->
                        <ul class="pro__details__tab" role="tablist">
                            <li role="presentation" class="description active"><a href="#description" role="tab" data-toggle="tab"><b>Description:</b></a></li>
                            <p class="pro__info"><%#Eval("description") %></p>
                            </ItemTemplate>
                            </asp:Repeater> 
                        </ul>
                        <!-- End List And Grid View -->
                    </div>
                </div>
                
            </div>
        <div class="container">
                <div class="row">
                    <div class="col-xs-12">
                        <!-- Start List And Grid View -->
                        <ul style='<%= Session["USER_LOGIN"] == "yes" ? "" : "display:none;" %>' class="pro__details__tab" role="tablist" >
                            <li role="presentation" class="description active"><a href="#description" role="tab" data-toggle="tab"><b>Review:</b></a></li>
                            <div class="form-group" style="width:100%;text-align:center;" >
                                <form id="contact-form" action="#" method="post">  
                                <span>Ratting:</span> 
                                            <select id="ratting" style="width:93%;text-align:center;min-height:40px;margin-top:14px">
                                                <option value="5">Fantastic</option>
                                                <option value="4">Very Good</option>
                                                <option value="3">Good</option>
                                                <option value="2">Bad</option>
                                                <option value="1">Worst</option>
                                                
                                            
                                            </select>
                                       
                                    <div class="single-contact-form" >
                                        <div class="contact-box message">
                                            <span>Review:</span>  
                                             <input type="text" id="review" name="review" placeholder="Enter Review*" style="width:93%;text-align:center;min-height:40px;margin-top:14px"> 
                                            
                                        </div>
                                        <span class="field_error" id="review_error"></span>
                                    </div>
                                    <div class="single-contact-form" >
                                            <div class="contact-box message">
                                                <div class="contact-btn">
                                                    <button type="button" id="btn_submit" onclick="send_message()" class="fv-btn" style="margin-left:80%;text-align:center;min-height:40px;margin-top:14px">Submit Review</button>
                                                </div>
                                             </div>
                                        
                                    </div>
                                       
                                            <div class="form-output contact_msg">
									            <p class="form-messege field_error"></p>
						                    </div>
                                    </form>
                            </div>
                           
                        </ul>
                        <!-- End List And Grid View -->
                    </div>
                </div>
                
            </div>
        <div class="container">
                <div class="row">
                    <div class="col-xs-12">
                        <!-- Start List And Grid View -->
                        <ul class="pro__details__tab" role="tablist" >
                            <%--<li role="presentation" class="description active"><a href="#description" role="tab" data-toggle="tab"><b>Product Review:</b></a></li>--%>
                            <div class="form-group" >
                                  
                                
                                            
                                       
                                    <div class="single-contact-form" style="width:100%;"></br>
                                        <span style="margin-left:20px;"><b>Reviews :</b></span>
                                    <asp:Repeater ID = "review_repeater" runat = "server" >
                                     <ItemTemplate>
                                        <div class="contact-box message" ></br>
                                            <div style="margin-left:26px">
                                            <span style="margin-left:22px;"><b><%# Eval("ratting_name") %></b></span> <span style="color:#c43b68"><b>( <%# Eval("username") %>: )</b></span>  </br>
                                             <span style="margin-left:22px;"><b><%# Eval("date") %></b></span> </br>
                                             <div style="margin-left:22px;margin-right:59px;"><%# Eval("review") %></div> </br>
                                            <span class="field_error" id="contact_message_error"></span>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                   </asp:Repeater> 
                                       
                            </div>
                           
                        </ul>
                        <!-- End List And Grid View -->
                    </div>
                </div>
                
            </div>
        </section>
        <!-- End Product Description -->              
        
    </span>
    <center><asp:Label ID="single_product_not_found" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label></center>
    
    <!-- Start Product Grid -->
        <section class="htc__product__grid bg__white ptb--100">
            <div class="container">
                <div class="row">
                    <div runat="server" id="Div1" class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="htc__product__rightidebar">
                            <%--<div class="htc__grid__top">
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
                                
                                   
                            </div>--%>
                            <!-- Start Product View -->
                            <div class="row">
                                <div class="shop__grid__view__wrap">
                                    <div role="tabpanel" id="grid-view" class="single-grid-view tab-pane fade in active clearfix">
                                        <!-- Start Single Category -->
                                        <div class="row">
                    <div class="col-xs-12">
                        <div class="section__title--2 text-center">
                            <h2 class="title__line">SIMILAR PRODUCTS</h2>
                            <p>Our Best Similar Products</p>
                        </div>
                    </div>
                </div>
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
                                                        <li><a style="padding-top:15px;" href="javascript:void(0)" onclick="<%# Session["USER_LOGIN"] == null ? "myredirect('login.aspx');" : "manage_wishlist(" +Eval("id") + ",'add');" %>"><i class="icon-heart icons"></i></a></li>

                                                        <li><a style="padding-top:15px; href="javascript:void(0)" onclick="<%# Session["USER_LOGIN"] == null ? "myredirect('login.aspx');" : "manage_cart(" +Eval("id") + ",'add');" %>" ><i class="icon-handbag icons"></i></a></li>

                                                        
                                                    </ul>
                                                </div>

                                                <div class="fr__product__inner">
                                                    <h4><a href="product-details.html"><asp:Label ID = "booksname" Text='<%# Eval("name") %>' runat="server"></asp:Label>t</a></h4>
                                                    <ul class="fr__pro__prize">
                                                        <li class="old__prize"><asp:Label ID = "Label1" Text='<%# Eval("mrp") %>' runat="server"></asp:Label></li>
                                                        <li><asp:Label ID = "Label2" Text='<%# Eval("price") %>' runat="server"></asp:Label></li>
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
                    <center><asp:Label ID="Label3" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label></center>
                </div>
            </div>
        </section>
        <!-- End Product Grid -->
    
    <script>

        function send_message() {
            jQuery('.field_error').html('');
            jQuery('.field_error').css('color', 'red');

            var product_id = jQuery("#product_id").val();
            var review = jQuery("#review").val();
            var ratting = jQuery("#ratting").val();
            var is_error = "";

            //alert(product_id + " " + review + " " + ratting);

            if (review == "") {
                jQuery('#review_error').html("*Please enter review");
                is_error = "yes";
            }

            if (is_error == "") {
                jQuery("#btn_submit").html("Sending REVIEW...");
                jQuery("#btn_submit").attr('disabled', true);
                jQuery.ajax({
                    url: 'send_review.aspx',
                    type: 'post',
                    data: 'product_id=' + product_id + "&review=" + review + "&ratting=" + ratting,
                    success: function (result) {
                        console.log(result);

                        if (result == "right") {
                            jQuery("#review").val("");
                            

                            jQuery("#btn_submit").html("Submit Review");
                            jQuery("#btn_submit").attr('disabled', false);
                            jQuery(".contact_msg p").html("Review Submited successfully.");
                            window.location.href = window.location.href;
                            //Response.redirect("index.aspx");
                        }

                        if (result == "wrong") {
                            jQuery(".contact_msg p").html("Review Not Submited");
                        }
                    },
                    error: function (result) {
                        alert("success:" + result);
                    }
                });
            }

        }
        //    jQuery('.field_error').html('');
        //    jQuery('.field_error').css('color', 'red');

        //    var name = jQuery("#name").val();
        //    var email = jQuery("#email").val();
        //    var mobile = jQuery("#mobile").val();
        //    var message = jQuery("#message").val();
        //    var is_error = "";

        //    if (name == "") {
        //        jQuery('#contact_name_error').html("*Please enter name");
        //        is_error = "yes";
        //    }
        //    if (email == "") {
        //        jQuery('#contact_email_error').html("*Please enter email");
        //        is_error = "yes";
        //    }
        //    if (mobile == "") {
        //        jQuery('#contact_mobile_error').html("*Please enter mobile");
        //        is_error = "yes";
        //    }
        //    if (message == "") {
        //        jQuery('#contact_message_error').html("*Please enter message");
        //        is_error = "yes";
        //    }

        //    if (is_error == "") {
        //        jQuery("#btn_submit").html("Sending MESSAGE...");
        //        jQuery("#btn_submit").attr('disabled', true);
        //        jQuery.ajax({
        //            url: 'send_message.aspx',
        //            type: 'post',
        //            data: 'name=' + name + "&email=" + email + "&mobile=" + mobile + "&message=" + message,
        //            success: function (result) {
        //                console.log(result);

        //                if (result == "right") {
        //                    jQuery("#name").val("");
        //                    jQuery("#email").val("");
        //                    jQuery("#mobile").val("");
        //                    jQuery("#message").val("");

        //                    jQuery("#name_error").html(result);
        //                    jQuery("#email_error").html(result);
        //                    jQuery("#mobile_error").html(result);
        //                    jQuery("#message_error").html(result);

        //                    jQuery("#btn_submit").html("Send MESSAGE");
        //                    jQuery("#btn_submit").attr('disabled', false);
        //                    jQuery(".contact_msg p").html("Message sent successfully.");
        //                    //Response.redirect("index.aspx");
        //                }

        //                if (result == "wrong") {
        //                    jQuery(".contact_msg p").html("Message not sented");
        //                }
        //            },
        //            error: function (result) {
        //                alert("success:" + result);
        //            }
        //        });
        //    }
        //}

    </script>
    <script>
        
        //function manage_cart(product_id,type) {

            
        //    var qty = jQuery("#qty").val();
        //    alert(product_id + type + qty);
           
        //        jQuery.ajax({
        //            url: 'manage_cart.aspx',
        //            type: 'post',
        //            data: 'product_id=' + product_id + '&qty=' + qty + '&type='+type,
        //            success: function (result) {
        //                console.log(result);
        //                jQuery(".htc__qua").html(result);
        //                //if (result == "right") {

        //                //    jQuery("#btn_submit").html("Send MESSAGE");
        //                //    jQuery("#btn_submit").attr('disabled', false);
        //                //    jQuery(".contact_msg p").html("Message sent successfully.");
        //                //    //Response.redirect("index.aspx");
        //                //}

        //                //if (result == "wrong") {
        //                //    jQuery(".contact_msg p").html("Message not sented");
        //                //}
        //            },
        //            error: function (result) {
        //                alert("success:" + result);
        //            }
        //       });
            
        //}
    </script>
</asp:Content>
