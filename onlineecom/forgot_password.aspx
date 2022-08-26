<%@ Page Title="" Language="C#" MasterPageFile="~/customer.Master" AutoEventWireup="true" CodeBehind="forgot_password.aspx.cs" Inherits="onlineecom.forgot_password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Start Bradcaump area -->
        <div class="ht__bradcaump__area" style="background: rgba(0, 0, 0, 0) url(images/bg/4.jpg) no-repeat scroll center center / cover ;">
            <div class="ht__bradcaump__wrap">
                <div class="container">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="bradcaump__inner">
                                <nav class="bradcaump-inner">
                                  <a class="breadcrumb-item" href="index.html">Home</a>
                                  <span class="brd-separetor"><i class="zmdi zmdi-chevron-right"></i></span>
                                  <span class="breadcrumb-item active">Forgot Password</span>
                                </nav>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Bradcaump area -->
        <!-- Start Contact Area -->
        <section class="htc__contact__area ptb--100 bg__white">
            <div class="container">
                <div class="row">
					<div class="col-md-6">
						<div class="contact-form-wrap mt--60">
							<div class="col-xs-12">
								<div class="contact-title">
									<h2 class="title__line--6">Forgot Password</h2>
								</div>
							</div>
							<div class="col-xs-12">
								<form id="login-form" method="post">
									<div class="single-contact-form">
										<div class="contact-box name">
											<input type="email" name="email" id="email" placeholder="Your Email*" style="width:100%" pattern="[A-Za-z0-9._%+-]{3,}@[a-zA-Z]{3,}([.]{1}[a-zA-Z]{2,}|[.]{1}[a-zA-Z]{2,}[.]{1}[a-zA-Z]{2,})" title="should be: xyz@gmail.com">
										</div>
                                        <span class="field_error" id="email_error"></span>
									</div>
									
									<div class="contact-btn">
										<button type="button" id="btn_submit" class="fv-btn" onclick="forgot_password()">Submit</button>
									</div>
								</form>
								<div class="form-output login_msg">
									<p class="form-messege field_error"></p>
								</div>
							</div>
						</div> 
                
				</div>
				
					
            </div>
        </section>
        <!-- End Contact Area -->
        
    <script>

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
            function forgot_password(){
            jQuery('#email_error').html("");
            jQuery('#email_error').css('color', 'red');

            var email = jQuery("#email").val();

            if (email == "") {
                jQuery('#email_error').html("*Please enter email id");
                is_error = 'yes';
            }
            else
            {
                    jQuery("#btn_submit").html("Please wait...");
                    jQuery("#btn_submit").attr('disabled', true);
                jQuery.ajax({
                    url: 'forgot_password_submit.aspx',
                    type: 'post',
                    data: 'email=' + email ,
                    success: function (result) {
                        console.log(result);
                        jQuery("#email").val("");
                        jQuery("#email_error").html(result);
                        jQuery("#btn_submit").html("Submit");
                        jQuery("#btn_submit").attr('disabled', false);
                        //if (result == "") {
                        //    jQuery("#email_error").html(result);
                        //}
                        //if (result == "right") {
                        //    window.location.href = 'index.aspx';
                        //    //Response.redirect("index.aspx");
                        //}
                    },
                    error: function (result) {
                        alert("Error:-" + result);
                    }
                });
            }

        }
        
    </script>
</asp:Content>
