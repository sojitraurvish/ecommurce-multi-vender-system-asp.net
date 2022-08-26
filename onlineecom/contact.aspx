<%@ Page Title="" Language="C#" MasterPageFile="~/customer.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="onlineecom.contact" %>
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
                                  <span class="breadcrumb-item active">Contact Us</span>
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
                    <div class="col-lg-7 col-md-6 col-sm-12 col-xs-12">
                        <div class="map-contacts--2">
                            <div id="googleMap"></div>
                        </div>
                    </div>
                    <div class="col-lg-5 col-md-6 col-sm-12 col-xs-12">
                        <h2 class="title__line--6">CONTACT US</h2>
                        <div class="address">
                            <div class="address__icon">
                                <i class="icon-location-pin icons"></i>
                            </div>
                            <div class="address__details">
                                <h2 class="ct__title">our address</h2>
                                <p>666 5th Ave New York, NY, United </p>
                            </div>
                        </div>
                        <div class="address">
                            <div class="address__icon">
                                <i class="icon-envelope icons"></i>
                            </div>
                            <div class="address__details">
                                <h2 class="ct__title">openning hour</h2>
                                <p>666 5th Ave New York, NY, United </p>
                            </div>
                        </div>

                        <div class="address">
                            <div class="address__icon">
                                <i class="icon-phone icons"></i>
                            </div>
                            <div class="address__details">
                                <h2 class="ct__title">Phone Number</h2>
                                <p>123-6586-587456</p>
                            </div>
                        </div>
                    </div>      
                </div>
                <div class="row">
                    <div class="contact-form-wrap mt--60">
                        <div class="col-xs-12">
                            <div class="contact-title">
                                <h2 class="title__line--6">SEND A MAIL</h2>
                            </div>
                        </div>
                        <div class="col-xs-12">
                            <form id="contact-form" action="#" method="post">
                                <div class="single-contact-form">
                                    <div class="contact-box name">
                                        <input type="text" id="name" name="name" placeholder="Your Name*">
                                        
                                    </div>
                                    <span class="field_error" id="contact_name_error"></span>
                               </div> 
                                <div class="single-contact-form">
                                    <div class="contact-box name">
                                        <input type="email" id="email" name="email" placeholder="Email*">
                                        
                                    </div>
                                    <span class="field_error" id="contact_email_error"></span>
                               </div>  
                                <div class="single-contact-form">
                                    <div class="contact-box name">
                                       <input type="mobile" id="mobile" name="mobile" placeholder="Mobile*"> 
                                        
                                    </div>
                                    <span class="field_error" id="contact_mobile_error"></span>
                               </div> 
                                    
                                <div class="single-contact-form">
                                    <div class="contact-box message">
                                        <textarea id="message" name="message" placeholder="Your Message"></textarea>
                                        <span class="field_error" id="contact_message_error"></span>
                                    </div>
                                    <span class="field_error" id="contact_message_error"></span>
                                </div>
                                <div class="contact-btn">
                                    <button type="button" id="btn_submit" onclick="send_message()" class="fv-btn">Send MESSAGE</button>
                                </div>
                            </form>
                            <div class="form-output contact_msg">
									<p class="form-messege field_error"></p>
						    </div>
                        </div>
                    </div> 
                </div>
            </div>
        </section>
        <!-- End Contact Area -->

    <script>

        function send_message()
        {
            jQuery('.field_error').html('');
            jQuery('.field_error').css('color', 'red');

            var name = jQuery("#name").val();
            var email = jQuery("#email").val();
            var mobile = jQuery("#mobile").val();
            var message = jQuery("#message").val();
            var is_error = "";

            if (name == "") {
                jQuery('#contact_name_error').html("*Please enter name");
                is_error = "yes";
            }
            if (email == "") {
                jQuery('#contact_email_error').html("*Please enter email");
                is_error = "yes";
            }
            if (mobile == "") {
                jQuery('#contact_mobile_error').html("*Please enter mobile");
                is_error = "yes";
            }
            if (message == "") {
                jQuery('#contact_message_error').html("*Please enter message");
                is_error = "yes";
            }

            if (is_error == "") {
                jQuery("#btn_submit").html("Sending MESSAGE...");
                jQuery("#btn_submit").attr('disabled', true);
                jQuery.ajax({
                    url: 'send_message.aspx',
                    type: 'post',
                    data: 'name=' + name + "&email=" + email + "&mobile=" + mobile + "&message=" + message,
                    success: function (result) {
                        console.log(result);
                        
                        if (result == "right") {
                            jQuery("#name").val("");
                            jQuery("#email").val("");
                            jQuery("#mobile").val("");
                            jQuery("#message").val("");

                            //jQuery("#name_error").html(result);
                            //jQuery("#email_error").html(result);
                            //jQuery("#mobile_error").html(result);
                            //jQuery("#message_error").html(result);

                            jQuery("#btn_submit").html("Send MESSAGE");
                            jQuery("#btn_submit").attr('disabled', false);
                            jQuery(".contact_msg p").html("Message sent successfully.");
                            //Response.redirect("index.aspx");
                        }

                        if (result == "wrong") {
                            jQuery(".contact_msg p").html("Message not sented");
                        }
                    },
                    error: function (result) {
                        alert("success:" + result);
                    }
                });
            }
        }

    </script>

       <!-- Google Map js -->
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBmGmeot5jcjdaJTvfCmQPfzeoG_pABeWo "></script>
    <script src="js/contact-map.js"></script>
    <script>
        // When the window has finished loading create our google map below
        google.maps.event.addDomListener(window, 'load', init);

        function init() {
            // Basic options for a simple Google Map
            // For more options see: https://developers.google.com/maps/documentation/javascript/reference#MapOptions
            var mapOptions = {
                // How zoomed in you want the map to start at (always required)
                zoom: 12,

                scrollwheel: false,

                // The latitude and longitude to center the map (always required)
                center: new google.maps.LatLng(23.7286, 90.3854), // New York

                // How you would like to style the map. 
                // This is where you would paste any style found on Snazzy Maps.
                 styles: 
        [ {
                "featureType": "all",
                "elementType": "labels.text.fill",
                "stylers": [
                    {
                        "saturation": 36
                    },
                    {
                        "color": "#000000"
                    },
                    {
                        "lightness": 40
                    }
                ]
            },
            {
                "featureType": "all",
                "elementType": "labels.text.stroke",
                "stylers": [
                    {
                        "visibility": "on"
                    },
                    {
                        "color": "#000000"
                    },
                    {
                        "lightness": 16
                    }
                ]
            },
            {
                "featureType": "all",
                "elementType": "labels.icon",
                "stylers": [
                    {
                        "visibility": "off"
                    }
                ]
            },
            {
                "featureType": "administrative",
                "elementType": "geometry.fill",
                "stylers": [
                    {
                        "color": "#000000"
                    },
                    {
                        "lightness": 20
                    }
                ]
            },
            {
                "featureType": "administrative",
                "elementType": "geometry.stroke",
                "stylers": [
                    {
                        "color": "#000000"
                    },
                    {
                        "lightness": 17
                    },
                    {
                        "weight": 1.2
                    }
                ]
            },
            {
                "featureType": "landscape",
                "elementType": "geometry",
                "stylers": [
                    {
                        "color": "#000000"
                    },
                    {
                        "lightness": 20
                    }
                ]
            },
            {
                "featureType": "poi",
                "elementType": "geometry",
                "stylers": [
                    {
                        "color": "#000000"
                    },
                    {
                        "lightness": 21
                    }
                ]
            },
            {
                "featureType": "road.highway",
                "elementType": "geometry.fill",
                "stylers": [
                    {
                        "color": "#000000"
                    },
                    {
                        "lightness": 17
                    }
                ]
            },
            {
                "featureType": "road.highway",
                "elementType": "geometry.stroke",
                "stylers": [
                    {
                        "color": "#000000"
                    },
                    {
                        "lightness": 29
                    },
                    {
                        "weight": 0.2
                    }
                ]
            },
            {
                "featureType": "road.arterial",
                "elementType": "geometry",
                "stylers": [
                    {
                        "color": "#000000"
                    },
                    {
                        "lightness": 18
                    }
                ]
            },
            {
                "featureType": "road.local",
                "elementType": "geometry",
                "stylers": [
                    {
                        "color": "#000000"
                    },
                    {
                        "lightness": 16
                    }
                ]
            },
            {
                "featureType": "transit",
                "elementType": "geometry",
                "stylers": [
                    {
                        "color": "#000000"
                    },
                    {
                        "lightness": 19
                    }
                ]
            },
            {
                "featureType": "water",
                "elementType": "geometry",
                "stylers": [
                    {
                        "color": "#141516"
                    },
                    {
                        "lightness": 17
                    }
                ]
            }
        ]
            };

            // Get the HTML DOM element that will contain your map 
            // We are using a div with id="map" seen below in the <body>
            var mapElement = document.getElementById('googleMap');

            // Create the Google Map using our element and options defined above
            var map = new google.maps.Map(mapElement, mapOptions);

            // Let's also add a marker while we're at it
            var marker = new google.maps.Marker({
                position: new google.maps.LatLng(23.7286, 90.3854),
                map: map,
                title: 'Ramble!',
                icon: 'images/icons/map-2.png',
                animation:google.maps.Animation.BOUNCE

            });
        }
    </script>
</asp:Content>
