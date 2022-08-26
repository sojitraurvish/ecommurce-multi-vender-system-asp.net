<%@ Page Title="" Language="C#" MasterPageFile="~/customer.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="onlineecom.checkout" %>
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
                                  <span class="breadcrumb-item active">checkout</span>
                                </nav>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Bradcaump area -->
        <!-- cart-main-area start -->
        <div class="checkout-wrap ptb--100">
            <div class="container">
                <div class="row">
                    <div class="col-md-8">
                        <div class="checkout__inner">
                            <div class="accordion-list">
                                <div class="accordion">
                                    
                                    <div runat="server" id="checkout_method_lable" class="accordion__title">
                                        Checkout Method
                                    </div>
                                    <div runat="server" class="accordion__body">
                                        <div runat="server" id="checkout_method_form" class="accordion__body__form">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="checkout-method__login">
                                                        
                                                        <form id="login-form" method="post">
                                                            <h5 class="checkout-method__title">Login</h5>
                                                            <div class="single-input">
                                                                <input type="email" name="login_email" id="login_email" placeholder="Your Email*" style="width:100%" pattern="[A-Za-z0-9._%+-]{3,}@[a-zA-Z]{3,}([.]{1}[a-zA-Z]{2,}|[.]{1}[a-zA-Z]{2,}[.]{1}[a-zA-Z]{2,})" title="should be: xyz@gmail.com">
                                                                <span class="field_error" id="login_email_error"></span>
                                                            </div>
                                                                
                                                            <div class="single-input">
                                                                <input type="password" name="login_password" id="login_password" placeholder="Your Password*" style="width:100%"  maxlength="20" pattern="(?=.\d)(?=.[a-z])(?=.[A-Z])(?=.[ !#$%&'()*+,-./:;<=>?@[\]^_`{|}~]).{8,255}" title="Must contain at least one number and one uppercase one lowercase letter and spicial symbole, and at least 8 or more characters" >
                                                                <span class="field_error" id="login_password_error"></span>
                                                            </div>
                                                                
                                                            <p class="require">* Required fields</p>
                                                            <div >
                                                                <button type="button" class="fv-btn" onclick="user_login()">Login</button>
                                                                <a href="forgot_password.aspx" style="margin-left:125px;font-size:15px; height: 50px;">Forgot Password</a>
                                                                
                                                            </div>
                                                            
                                                        </form>
                                                            <div class="form-output login_msg">
									                            <p class="form-messege field_error"></p>
								                            </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="checkout-method__login">
                                                        <form action="#">
                                                            <h5 class="checkout-method__title">Register</h5>
                                                            <div class="single-input">
                                                                <label for="user-email">Name</label>
                                                                <input type="email" id="user-email">
                                                            </div>
															<div class="single-input">
                                                                <label for="user-email">Email Address</label>
                                                                <input type="email" id="user-email">
                                                            </div>
															
                                                            <div class="single-input">
                                                                <label for="user-pass">Password</label>
                                                                <input type="password" id="user-pass">
                                                            </div>
                                                            <div class="dark-btn">
                                                                <a href="#">Register</a>
                                                            </div>
                                                        </form>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <form method="post" runat="server">
                                        <div runat="server" id="address_information" class="accordion__hide">
                                            Address Information
                                        </div>
                                    
                                        <div class="accordion__body">
                                                <div class="bilinfo">
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <div class="single-input">
                                                                    
                                                                    <asp:TextBox ID="faddress" runat="server" placeholder="Street Address" class="form-control"></asp:TextBox>
                                                                    <asp:Label ID="Labelfaddress" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                                                    <asp:RequiredFieldValidator ControlToValidate="faddress" ForeColor="Green" ID="RequiredFieldValidatorfaddress" runat="server" ErrorMessage="*Address is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                                                </div>
                                                            </div>
                                                    
                                                            <div class="col-md-6">
                                                                <div class="single-input">
                                                                    
                                                                    <asp:TextBox ID="fcity" runat="server" placeholder="City/State" class="form-control"></asp:TextBox>
                                                                    <asp:Label ID="Labelfcity" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                                                    <asp:RequiredFieldValidator ControlToValidate="fcity" ForeColor="Green" ID="RequiredFieldValidatorfcity" runat="server" ErrorMessage="*City/State is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="single-input">
                                                                    
                                                                    <asp:TextBox ID="fpincode" runat="server" placeholder="Post code/ zip" class="form-control"></asp:TextBox>
                                                                    <asp:Label ID="Labelfpincode" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                                                    <asp:RequiredFieldValidator ControlToValidate="fpincode" ForeColor="Green" ID="RequiredFieldValidatorfpincode" runat="server" ErrorMessage="*Post code/ zip is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 

                                                                </div>
                                                            </div>
                                                        </div>
                                                </div>
                                        </div>
                                        <!---payment-->
                                        <div runat="server" id="payment_information" class="accordion__hide">
                                            payment information
                                        </div>
                                        <div class="accordion__body">
                                            <div class="paymentinfo">
                                                <div class="single-method" style="margin-left:20px;">
                                                    <%--COD: <input type="radio" name="payment_type" value="COD" />&nbsp;&nbsp;
                                                    PayU: <input type="radio" name="payment_type" value="payu" />--%>
                                                    <asp:RadioButtonList ID="fpayment_type" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Height="21px" Width="156px">
                                                        <asp:ListItem Text="COD" Value="cod"></asp:ListItem>
                                                        <asp:ListItem Text="PayU" Value="payu"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <asp:Label ID="Labelfpayment_type" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                                    <asp:RequiredFieldValidator ControlToValidate="fpayment_type" ForeColor="Green" ID="RequiredFieldValidatorfpayment_type" runat="server" ErrorMessage="*Payment Type is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                                </div>
                                                <div class="single-method">
                                               
                                                </div>
                                            </div>
                                        </div>
                                     
                                        <asp:Button ID="submit" runat="server" Text="Submit" class="btn btn-lg btn-info btn-block fv-btn" OnClick="submit_Click" />
                                   </form>
                            </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="order-details">
                            <h5 class="order-details__title">Your Order</h5>
                            <div class="order-details__item">
                             <asp:Repeater ID = "checkout_product_repeter" runat = "server" >
                                    <HeaderTemplate>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                               <%--<li class="drop"><a href='categories.aspx?id=<%# Eval("id") %>'><asp:Label ID = "booksname" Text='<%# Eval("categories") %>' runat="server"></asp:Label></a></td></li>--%>
                                        <div class="single-item">
                                            <div class="single-item__thumb">
                                                <img src="https://localhost:44326/media/product/<%#Eval("image") %>" alt="product img" />
                                            </div>
                                            <div class="single-item__content">
                                                <a href="#"><%# Eval("name") %></a>
                                                <span class="price">&#8377;<%# Convert.ToInt32(DataBinder.Eval(Container.DataItem, "qty")) * Convert.ToInt32(DataBinder.Eval(Container.DataItem, "price")) %></span></div>
                                            <div class="single-item__remove">
                                                <a href="javascript:void(0)" onclick="<%# "manage_cart(" +Eval("product_id") + ",'remove');" %>"><i class="icon-trash icons"></i></a>
                                            </div>
                                        </div>
                                    </ItemTemplate>

                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                            
                            <asp:Repeater ID = "checkout_product_total_price_repeter" runat = "server" >
                                    <HeaderTemplate>
                                    </HeaderTemplate>

                                    <ItemTemplate>

                            <div class="ordre-details__total" id="coupon_box">
                                <h5>Coupon Value</h5>
                                <span id="coupon_price" class="price"></span>
                            </div>

                            <div class="ordre-details__total">
                                <h5>Order total</h5>
                                <span id="order_total_price" class="price">&#8377;<%# Eval("cart_total") %></span></div>
                            
                            
                                        
                            <div class="ordre-details__total bilinfo">
                                <input type="textbox" id="coupon_str" class="coupon_style mr5">
                                <input type="button" name="submit" value="APPLY COUPON" class="btn btn-lg btn-info btn-block fv-btn coupon_style" onclick="set_coupon()"/>
                            </div>
                            <div id="coupon_result"></div>
                            </ItemTemplate>

                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <script>

        function set_coupon() {
            var coupon_str = jQuery('#coupon_str').val();
            if (coupon_str != '') {
                jQuery.ajax({
                    url: 'set_coupon.aspx',
                    type: 'post',
                    data: 'coupon_str=' + coupon_str,
                    success: function (success) {
                        //alert("success:" + success);
                        const myArray = success.split("_");
                        if (success == 'not_found' || myArray[0] == 'less-total') {
                            jQuery("#coupon_box").hide();
                            if (success == 'not_found') {
                                alert('Coupon Code Not Found');
                            }
                            if (myArray[0] == 'less-total') {
                                alert('Cart Total Value Must Be Grater than ' + myArray[1])
                            }
                            //jQuery("#order_total_price").html(myArray[0]);
                        }
                        else {
                            jQuery("#coupon_box").show();
                            jQuery("#coupon_price").html("&#8377;"+myArray[1]);
                            jQuery("#order_total_price").html("&#8377;"+myArray[0]);
                        }
                        
                    },
                    error: function (error) {
                        alert("error:"+error);
                    }
                });
            }
        }

            //$(document).ready(function () {

            //    $("#email").change(function () {
            //        var inputvalues = $(this).val();
            //        var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            //        if (!regex.test(inputvalues)) {
            //            alert("invalid email id");
            //            return regex.test(inputvalues);
            //        }
            //    });    
    
            //});
            function user_login(){
            jQuery('.field_error').html('');
            jQuery('.field_error').css('color', 'red');

            var email = jQuery("#login_email").val();
            var password = jQuery("#login_password").val();
            var is_error = "";

            if (email == "") {
                jQuery('#login_email_error').html("*Please enter email");
                is_error = 'yes';
            }
            if (password == "") {
                jQuery('#login_password_error').html("*Please enter password");
                is_error = 'yes';
            }

            if (is_error == "") {
                jQuery.ajax({
                    url: 'login_submit.aspx',
                    type: 'post',
                    data: 'email=' + email + '&password=' + password,
                    success: function (result) {
                        console.log(result);
                        if (result == "wrong") {
                            jQuery(".login_msg p").html("Please enter valid login details");
                        }
                        if (result == "right") {
                            window.location.href = window.location.href;
                            //Response.redirect("index.aspx");
                        }
                    },
                    error: function (result) {
                        alert("Error:-" + result);
                    }
                });
            }

        }
        function user_register() {
            jQuery('.field_error').html('');
            jQuery('.field_error').css('color', 'red');

            var name = jQuery("#name").val();
            var email = jQuery("#email").val();
            var mobile = jQuery("#mobile").val();
            var password = jQuery("#password").val();
            var is_error = "";

            if (name == "") {
                jQuery('#name_error').html("*Please enter name");
                is_error = 'yes';
            }
            if (email == "") {
                jQuery('#email_error').html("*Please enter email");
                is_error = 'yes';
            }
            if (mobile == "") {
                jQuery('#mobile_error').html("*Please enter mobile");
                is_error = 'yes';
            }
            if (password == "") {
                jQuery('#password_error').html("*Please enter password");
                is_error = 'yes';
            }

            if (is_error == "")
            {
                jQuery.ajax({
                    url: 'register_submit.aspx',
                    type: 'post',
                    data: 'name=' + name + '&email=' + email + '&mobile=' + mobile + '&password=' + password,
                    success: function (result) {
                        console.log(result);
                        if (result == "present") {
                            jQuery("#email_error").html("Email id already present");
                        }
                        if (result == "insert") {
                            jQuery(".register_msg p").css('color', 'red');
                            jQuery(".register_msg p").html("Thank you for Registration");
                        }
                    },
                    error: function (result) {
                        alert("Error:-"+result);
                    }
                });
            }

        }
    </script>
    
</asp:Content>
