<%@ Page Title="" Language="C#" MasterPageFile="~/customer.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="onlineecom.profile" %>
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
									    <h2 class="title__line--6">Profile</h2>
								    </div>
							    </div>
							    <div class="col-xs-12">
								    <form id="form1" runat="server" method="post">
									    <div class="single-contact-form">
										    <div class="contact-box name">
                                                <asp:TextBox ID="fname" runat="server" class="form-control" placeholder="Your Name*" style="width:100%"></asp:TextBox>
											    
										    </div>
											<asp:Label ID="Labelfname" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                                <asp:RequiredFieldValidator ControlToValidate="fname" ForeColor="Green" ID="RequiredFieldValidatorfname" runat="server" ErrorMessage="*Name is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                            <span class="field_error" id="name_error"></span>
									    </div>
									
									    <div class="contact-btn">
                                            <asp:Button ID="submit" runat="server" Text="Submit" class="fv-btn" OnClick="submit_Click"  /> 
										
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
									    <h2 class="title__line--6">Change Password</h2>
								    </div>
							    </div>
							    <div class="col-xs-12">
								    <form id="frmpassword"  method="post">
									    <div class="single-contact-form">
										    <div class="contact-box name">
												<input type="password" name="current_password" id="current_password" placeholder="Current Password*" style="width:100%" />
										    </div>
                                            <span class="field_error" id="current_password_error"></span>
									    </div>
										<div class="single-contact-form">
										    <div class="contact-box name">
												<input type="password" name="new_password" id="new_password" placeholder="New Password*" style="width:100%" />
										    </div>
                                            <span class="field_error" id="new_password_error"></span>
									    </div>
										<div class="single-contact-form">
										    <div class="contact-box name">
												<input type="password" name="confirm_new_password" id="confirm_new_password" placeholder="Conform New Password*" style="width:100%" />
										    </div>
                                            <span class="field_error" id="confirm_new_password_error"></span>
									    </div>
									
									    <div class="contact-btn">
											<button type="button" class="fv-btn" onclick="update_password()" id="btn_update_password">Update</button>
									    </div>
								    </form>
								    <div class="form-output login_msg">
									    <p class="form-messege field_error"></p>
								    </div>
							    </div>
				        </div> 
                
				    </div>
				</div>
             </div>         
        </section>
    <script>
        function update_password() {
            jQuery('.field_error').html("");
            jQuery('.field_error').css('color', 'red');

            var current_password = jQuery("#current_password").val();
            var new_password = jQuery("#new_password").val();
            var confirm_new_password = jQuery("#confirm_new_password").val();
            var is_error = "";

            if (current_password == "") {
                jQuery('#current_password_error').html("*Please Enter Old Password");
                is_error = 'yes';
            }
            if (new_password == "") {
                jQuery('#new_password_error').html("*Please Enter New Password");
                is_error = 'yes';
            }
            if (confirm_new_password == "") {
                jQuery('#confirm_new_password_error').html("*Please Enter New Confirm Password");
                is_error = 'yes';
            }
           
            if (new_password != "" && confirm_new_password != "" && new_password != confirm_new_password) {
                jQuery('#confirm_new_password_error').html("*Please Enter Same Password");
                is_error = 'yes';
            }

            

            if (is_error=="") {
                jQuery("#btn_update_password").html("Please wait...");
                jQuery("#btn_update_password").attr('disabled', true);
                jQuery.ajax({
                    url: 'update_password.aspx',
                    type: 'post',
                    data: 'current_password=' + current_password + "&new_password=" + new_password,
                    success: function (result) {
                        console.log(result);
                        jQuery("#email").val("");
                        jQuery("#current_password_error").html(result);
                        jQuery("#btn_update_password").html("Submit");
                        jQuery("#btn_update_password").attr('disabled', false);
                        jQuery("#frmpassword")[0].reset();
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


