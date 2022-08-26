<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="onlineecom.admin.login" %>

<!doctype html>
<html class="no-js" lang="">
   <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
   <head>
      <meta charset="utf-8">
      <meta http-equiv="X-UA-Compatible" content="IE=edge">
      <title>Login Page</title>
      <meta name="viewport" content="width=device-width, initial-scale=1">
      <link rel="stylesheet" href="assets/css/normalize.css">
      <link rel="stylesheet" href="assets/css/bootstrap.min.css">
      <link rel="stylesheet" href="assets/css/font-awesome.min.css">
      <link rel="stylesheet" href="assets/css/themify-icons.css">
      <link rel="stylesheet" href="assets/css/pe-icon-7-filled.css">
      <link rel="stylesheet" href="assets/css/flag-icon.min.css">
      <link rel="stylesheet" href="assets/css/cs-skin-elastic.css">
      <link rel="stylesheet" href="assets/css/style.css">
      <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,600,700,800' rel='stylesheet' type='text/css'>
   
      <!--mine-->
       <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
   </head>
   <body class="bg-dark">
      <div class="sufee-login d-flex align-content-center flex-wrap">
         <div class="container">
            <div class="login-content">
               <div class="login-form mt-150">
                  <form ID="f1" runat="server">
                     <div class="form-group">
                        <label>Username:</label>
                        <asp:TextBox ID="username" runat="server" class="form-control" placeholder="Username"></asp:TextBox>

                     </div>
                     <div class="form-group">
                        <label>Password</label>
                         <asp:TextBox ID="password" runat="server" class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                      </div>
                      <asp:Button ID="submit" runat="server" Text="Sign in" class="btn btn-success btn-flat m-b-30 m-t-30" OnClick="submit_Click" /> 
                     
                      <div class="alert alert-danger field_error" ID="ferror" runat="server" style="margin-top:10px; display:none;" >
                          <strong>You have entered invalid username or password</strong>
                      </div>
                      <div class="alert alert-danger field_error" ID="fall_error" runat="server" style="margin-top:10px; display:none;" >
                          <asp:Label ID="Labelfall_error" runat="server" Text="Label"></asp:Label>
                      </div>
                      <asp:Label ID="error2" runat="server"></asp:Label>
					</form>
               </div>
            </div>
         </div>
      </div>
      <script src="assets/js/vendor/jquery-2.1.4.min.js" type="text/javascript"></script>
      <script src="assets/js/popper.min.js" type="text/javascript"></script>
      <script src="assets/js/plugins.js" type="text/javascript"></script>
      <script src="assets/js/main.js" type="text/javascript"></script>
   </body>
</html>
