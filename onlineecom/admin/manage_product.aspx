<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="manage_product.aspx.cs" Inherits="onlineecom.admin.manage_product" %>
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
                                       <label for="company" class=" form-control-label">Category :</label>
                                       <asp:DropDownList ID="fcategories_id" runat="server" class="form-control" OnSelectedIndexChanged="fcategories_id_SelectedIndexChanged" AutoPostBack="True" >
                                           <asp:ListItem Text="Select Category" Value="-1"></asp:ListItem>
                                       </asp:DropDownList>
                                       <asp:Label ID="Labelfcategories_id" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator InitialValue="-1" ControlToValidate="fcategories_id" ForeColor="Green" ID="RequiredFieldValidatorfcategories_id" runat="server" ErrorMessage="*Category is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                   </div>
                                
                                   <div class="form-group">
                                       <label for="company" class=" form-control-label">Sub Category :</label>
                                       <asp:DropDownList ID="fsub_categories_id" runat="server" class="form-control" >
                                           <asp:ListItem Text="Select Sub Category" Value="-1"></asp:ListItem>
                                       </asp:DropDownList>
                                       <asp:Label ID="Labelfsub_categories_id" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator InitialValue="-1" ControlToValidate="fsub_categories_id" ForeColor="Green" ID="RequiredFieldValidatorfsub_categories_id" runat="server" ErrorMessage="*Category is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                   </div>

                                    <div class="form-group">
                                       <label for="company" class=" form-control-label">Product Name :</label>
                                       <asp:TextBox ID="fname" runat="server" placeholder="Enter Product Name" class="form-control"></asp:TextBox>
                                       <asp:Label ID="Labelfname" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator ControlToValidate="fname" ForeColor="Green" ID="RequiredFieldValidatorfname" runat="server" ErrorMessage="*Product Name required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                   </div>

                                    <div class="form-group">
                                       <label for="company" class=" form-control-label">Best Seller :</label>
                                       <asp:DropDownList ID="fbest_seller" runat="server" class="form-control" >
                                           <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                           <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                           <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                       </asp:DropDownList>
                                       <asp:Label ID="Labelfbest_seller" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator InitialValue="-1" ControlToValidate="fbest_seller" ForeColor="Green" ID="RequiredFieldValidatorfbest_seller" runat="server" ErrorMessage="*Best Seller is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                   </div>

                                    <div class="form-group">
                                       <label for="company" class=" form-control-label">Mrp :</label>
                                       <asp:TextBox ID="fmrp" runat="server" placeholder="Enter Product Mrp" class="form-control" TextMode="Number"></asp:TextBox>
                                       <asp:Label ID="Labelfmrp" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator ControlToValidate="fmrp" ForeColor="Green" ID="RequiredFieldValidatorfmrp" runat="server" ErrorMessage="*Mrp is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                   </div>

                                    <div class="form-group">
                                       <label for="company" class=" form-control-label">Price :</label>
                                       <asp:TextBox ID="fprice" runat="server" placeholder="Enter Product Price" class="form-control" TextMode="Number"></asp:TextBox>
                                       <asp:Label ID="Labelfprice" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator ControlToValidate="fprice" ForeColor="Green" ID="RequiredFieldValidatorfprice" runat="server" ErrorMessage="*Price is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                   </div>

                                    <div class="form-group">
                                       <label for="company" class=" form-control-label">Qty :</label>
                                       <asp:TextBox ID="fqty" runat="server" placeholder="Enter Qty Name" class="form-control" TextMode="Number"></asp:TextBox>
                                       <asp:Label ID="Labelfqty" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator ControlToValidate="fqty" ForeColor="Green" ID="RequiredFieldValidatorfqty" runat="server" ErrorMessage="*Qty is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                   </div>

                                    <div class="form-group">
                                       <label for="company" class=" form-control-label">Image :</label>
                                        <asp:RegularExpressionValidator ID="FileUpLoadValidator" runat="server" ErrorMessage="Upload Jpegs,pngs and Gifs only." ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.jpg|.JPG|.png|.PNG|.gif|.GIF)$" ControlToValidate="fimage" Font-Size="Medium" ForeColor="Red" Font-Bold="True"> </asp:RegularExpressionValidator> 
                                       <asp:FileUpload ID="fimage" runat="server" class="form-control"/>
                                       <asp:RequiredFieldValidator ControlToValidate="fimage" ForeColor="Green" ID="RequiredFieldValidatorfimage" runat="server" ErrorMessage="*Image is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                        
                                   </div>

                                   <div class="form-group">
                                       <label for="company" class=" form-control-label">Short Description:</label>
                                       <asp:TextBox ID="fshort_desc" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                       <asp:Label ID="Labelfshort_desc" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator ControlToValidate="fshort_desc" ForeColor="Green" ID="RequiredFieldValidatorfshort_desc" runat="server" ErrorMessage="*Short Description is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                   </div>

                                    <div class="form-group">
                                       <label for="company" class=" form-control-label">Description:</label>
                                       <asp:TextBox ID="fdescription" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                       <asp:Label ID="Labelfdescription" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                       <asp:RequiredFieldValidator ControlToValidate="fdescription" ForeColor="Green" ID="RequiredFieldValidatorfdescription" runat="server" ErrorMessage="*Description is required" Font-Size="Medium" Font-Bold="true"></asp:RequiredFieldValidator> 
                                   </div>
                                
                                    <div class="form-group">
                                       <label for="company" class=" form-control-label">Meta Title:</label>
                                       <asp:TextBox ID="fmeta_title" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                       <asp:Label ID="Labelfmeta_title" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                   </div>

                                    <div class="form-group">
                                       <label for="company" class=" form-control-label">Meta Description:</label>
                                       <asp:TextBox ID="fmeta_desc" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                       <asp:Label ID="Labelfmeta_desc" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
                                   </div>

                                    <div class="form-group">
                                       <label for="company" class=" form-control-label">Meta Keyword:</label>
                                       <asp:TextBox ID="fmeta_keyword" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                       <asp:Label ID="Labelfmeta_keyword" for="company" runat="server" style="margin-top:10px; display:none;" Font-Size="Medium" ForeColor="Red" Font-Bold="True" ></asp:Label>
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
