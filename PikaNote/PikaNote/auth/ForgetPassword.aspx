<%@ Page Title="Forgot Password" Language="C#" MasterPageFile="~/masterPageSignin.Master" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="PikaNote.auth.ForgetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentWeb" runat="server">
    <main class="text-center form-signin mt-4" style="max-width: 450px">
        <div class="container-md">
            <img class="mb-4" src="../image/pikachu-icon.png" alt="" width="72" height="72">
            <h1 class="mb-3 fw-normal">Forget your password!</h1>

            <div class="row g-2">
                <div class="input-group col">
                    <span class="input-group-text mb-2" style="height: calc(3.5rem + 2px); line-height: 1.25;" id="basic-addon1">@</span>
                    <div class="mb-2 form-floating">
                        <asp:TextBox ID="floatingEmailXN" CssClass="form-control" runat="server" disabled readonly></asp:TextBox>
                        <label for="floatingEmailXN">Email</label>
                    </div>
                </div>
                <div class="form-floating col-4">
                    <asp:TextBox ID="floatingMXNForgorPw" CssClass="form-control mb-0" runat="server" placeholder="Code"></asp:TextBox>
                    <label for="floatingMXNForgorPw">Code</label>
                    <div class="mb-2 d-grid">
                        <asp:RequiredFieldValidator Display="Dynamic" ID="ValidatefloatingMXNForgorPw" CssClass="text-danger text-start bg-dark" ControlToValidate="floatingMXNForgorPw" runat="server" ErrorMessage="Hãy điền mã..."></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="form-floating">
                <asp:TextBox ID="floatingPasswordNew" TextMode="Password" CssClass="form-control mb-0" runat="server" placeholder="New Password"></asp:TextBox>
                <label for="floatingPasswordNew">New Password</label>
                <div class="mb-2 d-grid">
                    <asp:RequiredFieldValidator Display="Dynamic" ID="ValidatefloatingPasswordNew" CssClass="text-danger text-start bg-dark" ControlToValidate="floatingPasswordNew" runat="server" ErrorMessage="Hãy nhập mật khẩu"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-floating">
                <asp:TextBox ID="floatingRePasswordNew" TextMode="Password" CssClass="form-control mb-0" runat="server" placeholder="Re New Password"></asp:TextBox>
                <label for="floatingRePasswordNew">Re Password</label>
                <div class="mb-2 d-grid">
                    <asp:RequiredFieldValidator Display="Dynamic" ID="ValidatefloatingRePasswordNew" CssClass="text-danger text-start bg-dark" ControlToValidate="floatingRePasswordNew" runat="server" ErrorMessage="Hãy điền lại mật khẩu"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidatefloatingRePasswordNew" CssClass="text-danger text-start bg-dark" runat="server" ErrorMessage="Mật khẩu không giống. Vui lòng kiểm tra" Display="Dynamic" ControlToValidate="floatingRePasswordNew" ControlToCompare="floatingPasswordNew"></asp:CompareValidator>
                </div>
            </div>
            <asp:Button ID="btnXn" runat="server" CssClass="w-100 btn btn-lg btn-primary" title="Xác nhận đổi mật khẩu" Text="Xác nhận" OnClick="btnXn_Click"></asp:Button>
        </div>
    </main>
</asp:Content>
