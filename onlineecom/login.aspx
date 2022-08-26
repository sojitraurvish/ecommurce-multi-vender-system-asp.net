<%@ Page Title="" Language="C#" MasterPageFile="~/customer.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="onlineecom.login" %>
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
                                  <a class="breadcrumb-item" href="index.aspx">Home</a>
                                  <span class="brd-separetor"><i class="zmdi zmdi-chevron-right"></i></span>
                                  <span class="breadcrumb-item active">Login</span>
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
									<h2 class="title__line--6">Login</h2>
								</div>
							</div>
							<div class="col-xs-12">
								<form id="login-form" method="post">
									<div class="single-contact-form">
										<div class="contact-box name">
											<input type="email" name="login_email" id="login_email" placeholder="Your Email*" style="width:100%" pattern="[A-Za-z0-9._%+-]{3,}@[a-zA-Z]{3,}([.]{1}[a-zA-Z]{2,}|[.]{1}[a-zA-Z]{2,}[.]{1}[a-zA-Z]{2,})" title="should be: xyz@gmail.com">
										</div>
                                        <span class="field_error" id="login_email_error"></span>
									</div>
									<div class="single-contact-form">
										<div class="contact-box name">
											<input type="password" name="login_password" id="login_password" placeholder="Your Password*" style="width:100%"  maxlength="20" pattern="(?=.\d)(?=.[a-z])(?=.[A-Z])(?=.[ !#$%&'()*+,-./:;<=>?@[\]^_`{|}~]).{8,255}" title="Must contain at least one number and one uppercase one lowercase letter and spicial symbole, and at least 8 or more characters" >
										</div>
                                        <span class="field_error" id="login_password_error"></span>
									</div>
									
									<div class="contact-btn">
										<button type="button" class="fv-btn" onclick="user_login()">Login</button>
                                        <a href="forgot_password.aspx" style="margin-left:300px;font-size:15px;">Forgot Password</a>
									</div>
								</form>
								<div class="form-output login_msg">
									<p class="form-messege field_error"></p>
								</div>
							</div>
						</div> 
                
				</div>
				

					<div class="col-md-6">
						<div class="contact-form-wrap mt--60">
							<div class="col-xs-12">
								<div class="contact-title">
									<h2 class="title__line--6">Register</h2>
								</div>
							</div>
							<div class="col-xs-12">
								<form id="register-form" method="post">
									<div class="single-contact-form">
										<div class="contact-box name">
											<input type="text" name="name" id="name" placeholder="Your Name*" style="width:100%">
										</div>
                                        <span class="field_error" id="name_error"></span>
									</div>
									<div class="single-contact-form">
										<div class="contact-box name">
											<input type="email" name="email" id="email" placeholder="Your Email*" style="width:45%" pattern="[A-Za-z0-9._%+-]{3,}@[a-zA-Z]{3,}([.]{1}[a-zA-Z]{2,}|[.]{1}[a-zA-Z]{2,}[.]{1}[a-zA-Z]{2,})" title="should be: xyz@gmail.com">
										    <button type="button" class="fv-btn email_sent_otp height_60px" onclick="email_sent_otp()">Send OTP</button>
                                            <input type="number" class="email_verify_otp"  id="email_otp" placeholder="OTP*" style="width:45%" />
                                            <button type="button" class="fv-btn email_verify_otp height_60px" onclick="email_verify_otp()">Verify OTP</button>
                                            <span id="email_otp_result"></span>
                                        </div>
                                        <span class="field_error" id="email_error"></span>
									</div>
									<div class="single-contact-form">
										<div class="contact-box name">
											<input type="number" name="mobile" id="mobile" placeholder="Your Mobile*" style="width:100%" maxlength="10" pattern="[6-9]{1}-[0-9]{9} ">
                                        </div>
                                        <span class="field_error" id="mobile_error"></span>
									</div>
									<div class="single-contact-form">
										<div class="contact-box name">
											<input type="password" name="password" id="password" placeholder="Your Password*" style="width:100%"  maxlength="20" pattern="(?=.\d)(?=.[a-z])(?=.[A-Z])(?=.[ !#$%&'()*+,-./:;<=>?@[\]^_`{|}~]).{8,255}" title="Must contain at least one number and one uppercase one lowercase letter and spicial symbole, and at least 8 or more characters" >
                                        </div>
                                        <span class="field_error" id="password_error"></span>
									</div>

                                    <div class="single-contact-form">
										<div id="ReCaptchContainer"></div>
                                        <asp:Label ID="lblMessage1" runat="server"></asp:Label>
									</div>
									
									<div class="contact-btn">
										<button type="button" class="fv-btn" id="btn_register" onclick="user_register()" disabled>Register</button>
									</div>
								</form>
								<div class="form-output register_msg">
									<p class="form-messege field_error"></p>
								</div>
							</div>
						</div> 
                
				</div>
					
            </div>
        </section>
        <input type="hidden" id="is_email_verified" />
        <!-- End Contact Area -->
        <!-- End Banner Area -->
        <!-- Start Footer Area -->
        
        <!-- End Footer Style -->
    </div>
    <!-- Body main wrapper end -->

    <%--for google cepcha--%>
    <script src="https://www.google.com/recaptcha/api.js?onload=renderRecaptcha&render=explicit" async defer></script>
    <script type="text/javascript">
        var your_site_key = '6LcMIBceAAAAAFZdJMxualFYbC-vSGXjDj1pAUlk';
        var renderRecaptcha = function () {
            grecaptcha.render('ReCaptchContainer', {
                'sitekey': '6LcMIBceAAAAAFZdJMxualFYbC-vSGXjDj1pAUlk',
                'callback': reCaptchaCallback,
                theme: 'light', //light or dark
                type: 'image',// image or audio
                size: 'normal'//normal or compact
            });
        };
        var reCaptchaCallback = function (response) {
            if (response !== '') {
                document.getElementById('lblMessage1').innerHTML = "";
            }
        };
    </script>

    <script>
        function email_sent_otp() {
            jQuery("#email_error").html("");
            jQuery('.field_error').html('');
            jQuery('.field_error').css('color', 'red');

            var email = jQuery("#email").val();
            if (email == 'undefined' || email == null || email == '')
            {
                jQuery("#email_error").html("Please Enter Email ID");
            }
            else
            {
                jQuery(".email_sent_otp").html("Please wait...");
                jQuery(".email_sent_otp").attr('disabled', true);
                jQuery.ajax({
                    url: 'send_otp.aspx',
                    type: 'post',
                    data: 'email=' + email + '&type=email',
                    success: function (result) {
                        console.log(result);
                        if (result == "done") {
                            jQuery("#email").attr('disabled', true);
                            jQuery(".email_sent_otp").hide();
                            jQuery(".email_verify_otp").show();
                            
                        }
                        else {
                            jQuery(".email_sent_otp").html("Send OTP");
                            jQuery(".email_sent_otp").attr('disabled', false);
                            jQuery("#email_error").html("Please Try After Sometime");
                        }
                        //jQuery("#email").val("");
                        //jQuery("#email_error").html(result);
                        //jQuery("#btn_submit").html("Submit");
                        //jQuery("#btn_submit").attr('disabled', false);
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

        function email_verify_otp() {
            jQuery("#email_error").html("");
            jQuery('.field_error').html('');
            jQuery('.field_error').css('color', 'red');

            var email_otp = jQuery("#email_otp").val();
            if (email_otp == 'undefined' || email_otp == null || email_otp == '') {
                jQuery("#email_error").html("Please Enter OPT");
            }
            else {

                jQuery.ajax({
                    url: 'check_otp.aspx',
                    type: 'post',
                    data: 'otp=' + email_otp + '&type=email',
                    success: function (result) {
                        console.log(result);
                        if (result == "done") {
                            jQuery(".email_verify_otp").hide();
                            jQuery("#email_otp_result").html("Email Id Verified");
                            jQuery("#is_email_verified").val('1');

                            if (jQuery("#is_email_verified").val() == 1) {
                                jQuery("#btn_register").attr("disabled",false);
                            }
                        }
                        else {
                            jQuery("#email_error").html("Please Enter Valid OTP");
                        }
                        //jQuery("#email").val("");
                        //jQuery("#email_error").html(result);
                        //jQuery("#btn_submit").html("Submit");
                        //jQuery("#btn_submit").attr('disabled', false);
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
                            window.location.href = 'index.aspx';
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
