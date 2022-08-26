<%@ Page Title="" Language="C#" MasterPageFile="~/customer.Master" AutoEventWireup="true" CodeBehind="payu_payment_fail.aspx.cs" Inherits="onlineecom.payu_payment_fail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div>
            <h1><b>Transaction In Process ,Please do not reload</b></h1><br />
            <asp:Label ID="lbl_transactionid" runat="server"></asp:Label>
        </div>
    </form>
</asp:Content>
