<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="manage_coupon_master.aspx.cs" Inherits="onlineecom.manage_coupon_master" %>
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
                                       <label for="company" class=" form-control-label">Coupon Code:</label>
                                       <asp:TextBox ID="fcoupon_code" runat="server" placeholder="Enter Product Name" class="form-control"></asp:TextBox>
                                       <asp:Label ID="Labelfcoupon_code" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator ControlToValidate="fcoupon_code" ForeColor="Green" ID="RequiredFieldValidatorfcoupon_code" runat="server" ErrorMessage="*Coupon Code is equired" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                   </div>
                                
                                    <div class="form-group">
                                       <label for="company" class=" form-control-label">Coupon Value:</label>
                                       <asp:TextBox ID="fcoupon_value" runat="server" placeholder="Enter Product Name" class="form-control" TextMode="Number"></asp:TextBox>
                                       <asp:Label ID="Labelfcoupon_value" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator ControlToValidate="fcoupon_value" ForeColor="Green" ID="RequiredFieldValidatorfcoupon_value" runat="server" ErrorMessage="*Coupon Value is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                   </div>

                                    <div class="form-group">
                                       <label for="company" class=" form-control-label">Coupon Type :</label>
                                       <asp:DropDownList ID="fcoupon_type" runat="server" class="form-control" >
                                           <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                           <asp:ListItem Text="Percentage" Value="1"></asp:ListItem>
                                           <asp:ListItem Text="Rupee" Value="0"></asp:ListItem>
                                       </asp:DropDownList>
                                       <asp:Label ID="Labelfcoupon_type" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator InitialValue="-1" ControlToValidate="fcoupon_type" ForeColor="Green" ID="RequiredFieldValidatorfcoupon_type" runat="server" ErrorMessage="*Best Seller is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                   </div>

                                    <div class="form-group">
                                       <label for="company" class=" form-control-label">Cart Min Value :</label>
                                       <asp:TextBox ID="fcart_min_value" runat="server" placeholder="Enter Product Name" class="form-control" TextMode="Number"></asp:TextBox>
                                       <asp:Label ID="Labelfcart_min_value" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator ControlToValidate="fcart_min_value" ForeColor="Green" ID="RequiredFieldValidatorfcart_min_value" runat="server" ErrorMessage="*Product Name required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
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
