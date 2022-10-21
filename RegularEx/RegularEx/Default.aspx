<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RegularEx._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

            <asp:Button ID="Button1" runat="server" Text="Button" />

            <div class="form-col-12">

                <asp:TextBox ID="ebultenInputEmail" placeholder="E-mail" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Email alanı boş bırakılamaz." ValidationGroup="Contact" ControlToValidate="ebultenInputEmail" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ValidationGroup="Contact" ID="rglEmail" ErrorMessage="Geçerli bir email adresi giriniz." ControlToValidate="ebultenInputEmail" ValidationExpression="\w+([-+.’]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

            </div>

             <div class="form-col-6">
                <asp:TextBox ID="inputTelNumber" runat="server" placeholder="Telefon Numarası" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rvTelNumber" runat="server" ErrorMessage="Telefon Numarası alanı boş geçilemez." ControlToValidate="inputTelNumber" ForeColor="Red" ValidationGroup="Contact"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ValidationGroup="Contact" ID="rglTelNumber" ErrorMessage="Geçerli bir telefon numarası giriniz." ControlToValidate="inputTelNumber" ValidationExpression="^(([\+]90?)|([0]))([ ]?)((\([0-9]{3}\))|([0-9]{3}))([ ]?)([0-9]{3})(\s*[\-]?)([0-9]{2})(\s*[\-]?)([0-9]{2})"></asp:RegularExpressionValidator>
      
            </div>

               <div class="form-col-6">
                <asp:TextBox ID="inputDateOfBirth" runat="server" placeholder="dd.MM.yyyy" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rvDateOfBirth" runat="server" ErrorMessage="Doğum Tarihi alanı boş geçilemez." ControlToValidate="inputDateOfBirth" ForeColor="Red" ValidationGroup="Contact"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ValidationGroup="Contact" ID="rglDateOfBirth" ErrorMessage="Geçerli bir doğum tarihi bilgisi giriniz." ControlToValidate="inputDateOfBirth" ValidationExpression="^(((0[1-9])|([12][0-9])|(3[01]))\.((0[0-9])|(1[012]))\.((20[012]\d|19\d\d)|(1\d|2[0123])))">

                </asp:RegularExpressionValidator>

            </div>

        </div>
        
    </div>

</asp:Content>
