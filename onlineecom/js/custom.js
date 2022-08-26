function myredirect(url) {
    window.location.href = url;
}

function manage_cart(product_id,type,is_buy_now) {

    var qty = jQuery("#qty").val();

    if (type == "update") {

        qty = jQuery("#" + product_id + "qty").val();
    }

    if (qty == 'undefined' || qty == null || qty == "")
    {
        qty = 1;
    }
    

    //alert(product_id + type + qty);

    jQuery.ajax({
        url:'manage_cart.aspx',
        type:'post',
        data:'product_id=' + product_id + '&qty=' + qty + '&type=' + type,
        success: function (result) {
            console.log(result);
            if (type == "remove" || type == "update") {
                window.location.href = window.location.href;
            }
            if (result =="qty_zero") {
                alert("Qty Must Be Grater Than Zero!'");
            }
            if (result == "not_avaliable") {
                alert("Qty Not Avaliable!");
            }
            else {
                jQuery(".htc__qua").html(result);
                if (is_buy_now == 'yes') {
                    window.location.href = 'checkout.aspx';
                }
            }
            
            //if (result == "right") {

            //    jQuery("#btn_submit").html("Send MESSAGE");
            //    jQuery("#btn_submit").attr('disabled', false);
            //    jQuery(".contact_msg p").html("Message sent successfully.");
            //    //Response.redirect("index.aspx");
            //}

            //if (result == "wrong") {
            //    jQuery(".contact_msg p").html("Message not sented");
            //}
        },
        error: function (result) {
            alert("Error:" + result);
        }
    });

}

function manage_wishlist(product_id, type) {
    

    jQuery.ajax({
        url: 'manage_wishlist.aspx',
        type: 'post',
        data: 'product_id=' + product_id + '&type=' + type,
        success: function (result) {
            console.log(result);
            if (type == "remove") {
                window.location.href = window.location.href;
            }
            jQuery(".htc__wishlist").html(result);
            //if (result == "right") {

            //    jQuery("#btn_submit").html("Send MESSAGE");
            //    jQuery("#btn_submit").attr('disabled', false);
            //    jQuery(".contact_msg p").html("Message sent successfully.");
            //    //Response.redirect("index.aspx");
            //}

            //if (result == "wrong") {
            //    jQuery(".contact_msg p").html("Message not sented");
            //}
        },
        error: function (result) {
            alert("Error:" + result);
        }
    });
}


function sort_product_dropdown(categories_id) {
    var sort_product_id = jQuery("#sort_product_id").val();
    window.location.href = "https://localhost:44326/categories.aspx?id=" + categories_id + "&sort=" + sort_product_id + "";
    
}


////$(document).ready(function () {

////    $("#email").change(function () {
////        var inputvalues = $(this).val();
////        var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
////        if (!regex.test(inputvalues)) {
////            alert("invalid email id");
////            return regex.test(inputvalues);
////        }
////    });    

////});
//function user_login() {
//    jQuery('.field_error').html('');
//    jQuery('.field_error').css('color', 'red');

//    var email = jQuery("#login_email").val();
//    var password = jQuery("#login_password").val();
//    var is_error = "";

//    if (email == "") {
//        jQuery('#login_email_error').html("*Please enter email");
//        is_error = 'yes';
//    }
//    if (password == "") {
//        jQuery('#login_password_error').html("*Please enter password");
//        is_error = 'yes';
//    }

//    if (is_error == "") {
//        jQuery.ajax({
//            url: 'login_submit.aspx',
//            type: 'post',
//            data: 'email=' + email + '&password=' + password,
//            success: function (result) {
//                console.log(result);
//                if (result == "wrong") {
//                    jQuery(".login_msg p").html("Please enter valid login details");
//                }
//                if (result == "right") {
//                    window.location.href = 'index.aspx';
//                    //Response.redirect("index.aspx");
//                }
//            },
//            error: function (result) {
//                alert("Error:-" + result);
//            }
//        });
//    }

//}
//function user_register() {
//    jQuery('.field_error').html('');
//    jQuery('.field_error').css('color', 'red');

//    var name = jQuery("#name").val();
//    var email = jQuery("#email").val();
//    var mobile = jQuery("#mobile").val();
//    var password = jQuery("#password").val();
//    var is_error = "";

//    if (name == "") {
//        jQuery('#name_error').html("*Please enter name");
//        is_error = 'yes';
//    }
//    if (email == "") {
//        jQuery('#email_error').html("*Please enter email");
//        is_error = 'yes';
//    }
//    if (mobile == "") {
//        jQuery('#mobile_error').html("*Please enter mobile");
//        is_error = 'yes';
//    }
//    if (password == "") {
//        jQuery('#password_error').html("*Please enter password");
//        is_error = 'yes';
//    }

//    if (is_error == "") {
//        jQuery.ajax({
//            url: 'register_submit.aspx',
//            type: 'post',
//            data: 'name=' + name + '&email=' + email + '&mobile=' + mobile + '&password=' + password,
//            success: function (result) {
//                console.log(result);
//                if (result == "present") {
//                    jQuery("#email_error").html("Email id already present");
//                }
//                if (result == "insert") {
//                    jQuery(".register_msg p").css('color', 'red');
//                    jQuery(".register_msg p").html("Thank you for Registration");
//                }
//            },
//            error: function (result) {
//                alert("Error:-" + result);
//            }
//        });
//    }

//}

//function email_sent_otp() {
//    jQuery("#email_error").html("");
//    jQuery('.field_error').html('');
//    jQuery('.field_error').css('color', 'red');

//    var email = jQuery("#email").val();
//    if (email == 'undefined' || email == null || email == '') {
//        jQuery("#email_error").html("Please Enter Email ID");
//    }
//    else {
//        jQuery(".email_sent_otp").html("Please wait...");
//        jQuery(".email_sent_otp").attr('disabled', true);
//        jQuery.ajax({
//            url: 'send_otp.aspx',
//            type: 'post',
//            data: 'email=' + email + '&type=email',
//            success: function (result) {
//                console.log(result);
//                if (result == "done") {
//                    jQuery("#email").attr('disabled', true);
//                    jQuery(".email_sent_otp").hide();
//                    jQuery(".email_verify_otp").show();

//                }
//                else {
//                    jQuery(".email_sent_otp").html("Send OTP");
//                    jQuery(".email_sent_otp").attr('disabled', false);
//                    jQuery("#email_error").html("Please Try After Sometime");
//                }
//                //jQuery("#email").val("");
//                //jQuery("#email_error").html(result);
//                //jQuery("#btn_submit").html("Submit");
//                //jQuery("#btn_submit").attr('disabled', false);
//                //if (result == "") {
//                //    jQuery("#email_error").html(result);
//                //}
//                //if (result == "right") {
//                //    window.location.href = 'index.aspx';
//                //    //Response.redirect("index.aspx");
//                //}
//            },
//            error: function (result) {
//                alert("Error:-" + result);
//            }
//        });


//    }
//}

//function email_verify_otp() {
//    jQuery("#email_error").html("");
//    jQuery('.field_error').html('');
//    jQuery('.field_error').css('color', 'red');

//    var email_otp = jQuery("#email_otp").val();
//    if (email_otp == 'undefined' || email_otp == null || email_otp == '') {
//        jQuery("#email_error").html("Please Enter OPT");
//    }
//    else {

//        jQuery.ajax({
//            url: 'check_otp.aspx',
//            type: 'post',
//            data: 'otp=' + email_otp + '&type=email',
//            success: function (result) {
//                console.log(result);
//                if (result == "done") {
//                    jQuery(".email_verify_otp").hide();
//                    jQuery("#email_otp_result").html("Email Id Verified");
//                    jQuery("#is_email_verified").val('1');

//                    if (jQuery("#is_email_verified").val() == 1) {
//                        jQuery("#btn_register").attr("disabled", false);
//                    }
//                }
//                else {
//                    jQuery("#email_error").html("Please Enter Valid OTP");
//                }
//                //jQuery("#email").val("");
//                //jQuery("#email_error").html(result);
//                //jQuery("#btn_submit").html("Submit");
//                //jQuery("#btn_submit").attr('disabled', false);
//                //if (result == "") {
//                //    jQuery("#email_error").html(result);
//                //}
//                //if (result == "right") {
//                //    window.location.href = 'index.aspx';
//                //    //Response.redirect("index.aspx");
//                //}

//            },
//            error: function (result) {
//                alert("Error:-" + result);
//            }
//        });

//    }
//}


           
        //function forgot_password() {
        //    jQuery('#email_error').html("");
        //    jQuery('#email_error').css('color', 'red');

        //    var email = jQuery("#email").val();

        //    if (email == "") {
        //        jQuery('#email_error').html("*Please enter email id");
        //        is_error = 'yes';
        //    }
        //    else {
        //        jQuery("#btn_submit").html("Please wait...");
        //        jQuery("#btn_submit").attr('disabled', true);
        //        jQuery.ajax({
        //            url: 'forgot_password_submit.aspx',
        //            type: 'post',
        //            data: 'email=' + email,
        //            success: function (result) {
        //                console.log(result);
        //                jQuery("#email").val("");
        //                jQuery("#email_error").html(result);
        //                jQuery("#btn_submit").html("Submit");
        //                jQuery("#btn_submit").attr('disabled', false);
        //                //if (result == "") {
        //                //    jQuery("#email_error").html(result);
        //                //}
        //                //if (result == "right") {
        //                //    window.location.href = 'index.aspx';
        //                //    //Response.redirect("index.aspx");
        //                //}
        //            },
        //            error: function (result) {
        //                alert("Error:-" + result);
        //            }
        //        });
        //    }

        //}
        


