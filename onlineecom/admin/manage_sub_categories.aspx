<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="manage_sub_categories.aspx.cs" Inherits="onlineecom.admin.manage_sub_categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="content pb-0">
            <div class="animated fadeIn">
               <div class="row">
                  <div class="col-lg-12">
                     <div class="card">
                        <div class="card-header"><strong>Sub Categories</strong><small> Form</small></div>
                         <form ID="f1" runat="server"  >
                            <div class="card-body card-block">
                               
                                   <div class="form-group">
                                       <label for="company" class=" form-control-label">Category :</label>
                                       <asp:DropDownList ID="fcategories_id" runat="server" class="form-control" >
                                           <asp:ListItem Text="Select Category" Value="-1"></asp:ListItem>
                                       </asp:DropDownList>
                                       <asp:Label ID="Labelfcategories_id" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator InitialValue="-1" ControlToValidate="fcategories_id" ForeColor="Green" ID="RequiredFieldValidatorfcategories_id" runat="server" ErrorMessage="*Category is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                   </div>

                                   <div class="form-group">
                                       <label for="company" class=" form-control-label">Sub Category :</label>
                                       <asp:TextBox ID="fsub_categories" runat="server" placeholder="Enter Sub Category Name" class="form-control"></asp:TextBox>
                                       <asp:Label ID="Labelfsub_categories" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator ControlToValidate="fsub_categories" ForeColor="Green" ID="RequiredFieldValidatorfsub_categories" runat="server" ErrorMessage="*Sub Category is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                   </div>

                                   <asp:Button ID="submit" runat="server" Text="Submit" class="btn btn-lg btn-info btn-block" OnClick="submit_Click" /> 
                            </div>
                         </form>
                     </div>
                  </div>
               </div>
            </div>
    </div>
</asp:Content>
