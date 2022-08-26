<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="manage_categories.aspx.cs" Inherits="onlineecom.admin.manage_categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <div class="content pb-0">
            <div class="animated fadeIn">
               <div class="row">
                  <div class="col-lg-12">
                     <div class="card">
                        <div class="card-header"><strong>Categories</strong><small> Form</small></div>
                         <form ID="f1" runat="server"  >
                            <div class="card-body card-block">
                               
                                   <div class="form-group">
                                       <label for="company" class=" form-control-label">Category :</label>
                                       <asp:TextBox ID="category" runat="server" placeholder="Enter Category Name" class="form-control"></asp:TextBox>
                                       <asp:Label ID="msg" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator ControlToValidate="category" ForeColor="Green" ID="RequiredFieldValidatorCategory" runat="server" ErrorMessage="*Category is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
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
