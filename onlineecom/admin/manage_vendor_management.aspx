<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="manage_vendor_management.aspx.cs" Inherits="onlineecom.manage_vendor_management" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content pb-0">
            <div class="animated fadeIn">
               <div class="row">
                  <div class="col-lg-12">
                     <div class="card">
                        <div class="card-header"><strong>Product</strong><small> Form</small></div>
                         <form ID="f1" runat="server"  >
                            <div class="card-body card-block">
                               
                                     <div class="form-group">
                                       <label for="company" class=" form-control-label">Username:</label>
                                       <asp:TextBox ID="fusername" runat="server" placeholder="Enter Product Name" class="form-control"></asp:TextBox>
                                       <asp:Label ID="Labelfusername" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator ControlToValidate="fusername" ForeColor="Green" ID="RequiredFieldValidatorfusername" runat="server" ErrorMessage="*Coupon Code is equired" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                   </div>
                                
                                    <div class="form-group">
                                       <label for="company" class=" form-control-label">Password:</label>
                                       <asp:TextBox ID="fpassword" runat="server" placeholder="Enter Product Name" class="form-control" ></asp:TextBox>
                                       <asp:Label ID="Labelfpassword" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator ControlToValidate="fpassword" ForeColor="Green" ID="RequiredFieldValidatorfpassword" runat="server" ErrorMessage="*Coupon Value is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                   </div>
                                
                                <div class="form-group">
                                       <label for="company" class=" form-control-label">Email:</label>
                                       <asp:TextBox ID="femail" runat="server" placeholder="Enter Product Name" class="form-control" ></asp:TextBox>
                                       <asp:Label ID="Labelfemail" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator ControlToValidate="femail" ForeColor="Green" ID="RequiredFieldValidatorfemail" runat="server" ErrorMessage="*Coupon Value is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                   </div>



                                    <div class="form-group">
                                       <label for="company" class=" form-control-label">Mobile:</label>
                                       <asp:TextBox ID="fmobile" runat="server" placeholder="Enter Product Name" class="form-control" ></asp:TextBox>
                                       <asp:Label ID="Labelfmobile" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator ControlToValidate="fmobile" ForeColor="Green" ID="RequiredFieldValidatorfmobile" runat="server" ErrorMessage="*Product Name required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                   </div>

                                   <div class="form-group">
                                     <asp:Button ID="submit" runat="server" Text="Submit" class="btn btn-lg btn-info btn-block" OnClick="submit_Click"  /> 
                                   </div>

                               </div>
                         </form>
                     </div>
                  </div>
               </div>
            </div>
    </div>

</asp:Content>
