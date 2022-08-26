<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="manage_banner.aspx.cs" Inherits="onlineecom.admin.manage_banner" %>
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
                                       <label for="company" class=" form-control-label">Heading 1:</label>
                                       <asp:TextBox ID="fheading1" runat="server" placeholder="Enter Category Name" class="form-control"></asp:TextBox>
                                       <asp:Label ID="Lablefheading1" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator ControlToValidate="fheading1" ForeColor="Green" ID="RequiredFieldValidatorfheading1" runat="server" ErrorMessage="*Category is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                   </div>
                                
                                <div class="form-group">
                                       <label for="company" class=" form-control-label">Heading 2:</label>
                                       <asp:TextBox ID="fheading2" runat="server" placeholder="Enter Category Name" class="form-control"></asp:TextBox>
                                       <asp:Label ID="Lablefheading2" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator ControlToValidate="fheading2" ForeColor="Green" ID="RequiredFieldValidatorfheading2" runat="server" ErrorMessage="*Category is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                   </div>
                                
                                <div class="form-group">
                                       <label for="company" class=" form-control-label">Button Text:</label>
                                       <asp:TextBox ID="fbtn_txt" runat="server" placeholder="Enter Category Name" class="form-control"></asp:TextBox>
                                       <asp:Label ID="Lablefbtn_txt" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator ControlToValidate="fbtn_txt" ForeColor="Green" ID="RequiredFieldValidatorfbtn_txt" runat="server" ErrorMessage="*Category is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                   </div>
                                
                                <div class="form-group">
                                       <label for="company" class=" form-control-label">Button Link:</label>
                                       <asp:TextBox ID="fbtn_link" runat="server" placeholder="Enter Category Name" class="form-control"></asp:TextBox>
                                       <asp:Label ID="Lablefbtn_link" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator ControlToValidate="fbtn_link" ForeColor="Green" ID="RequiredFieldValidatorfbtn_link" runat="server" ErrorMessage="*Category is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                   </div>
                                

                                    <div class="form-group">
                                       <label for="company" class=" form-control-label">Image :</label>
                                        <asp:RegularExpressionValidator ID="FileUpLoadValidator" runat="server" ErrorMessage="Upload Jpegs,pngs and Gifs only." ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.jpg|.JPG|.png|.PNG|.gif|.GIF)$" ControlToValidate="fimage" Font-Size="Medium" ForeColor="Red" Font-Bold="True"> </asp:RegularExpressionValidator> 
                                       <asp:FileUpload ID="fimage" runat="server" class="form-control"/>
                                       <asp:RequiredFieldValidator ControlToValidate="fimage" ForeColor="Green" ID="RequiredFieldValidatorfimage" runat="server" ErrorMessage="*Image is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                   </div>

                                    <div class="form-group">
                                       <label for="company" class=" form-control-label">Order No:</label>
                                       <asp:TextBox ID="forder_by" runat="server" placeholder="Enter Category Name" class="form-control" TextMode="Number"></asp:TextBox>
                                       <asp:Label ID="Labelforder_by" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator ControlToValidate="forder_by" ForeColor="Green" ID="RequiredFieldValidatorforder_by" runat="server" ErrorMessage="*Category is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
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
