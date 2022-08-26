<%@ Page Title="" Language="C#" MasterPageFile="~/customer.Master" AutoEventWireup="true" CodeBehind="payu_payment_complete.aspx.cs" Inherits="onlineecom.payu_payment_complete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div>
            Thank you for purchasing from our website<br />
            <asp:Label ID="lbl_transactionid" runat="server"></asp:Label>
        </div>
    </form>
</asp:Content>
