<%@ Page Title="PikaNote - Signin" Language="C#" MasterPageFile="~/masterPageSignin.Master" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="PikaNote.auth.Signup1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../lib/crypto-js/crypto-js.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentWeb" runat="server">
    <main class="text-center form-signin mt-4">
        <div class="container-md">
            <img class="mb-4" src="../image/pikachu-icon.png" alt="" width="72" height="72">
            <h1 class="mb-3 fw-normal">Please sign in</h1>

            <div class="form-floating">
                <asp:TextBox ID="floatingInputSignin" CssClass="form-control mb-2" placeholder="username" runat="server"></asp:TextBox>
                <label for="floatingInputSignin">Username</label>
            </div>
            <div class="form-floating">
                <asp:TextBox ID="floatingPasswordSignin" CssClass="form-control mb-2" TextMode="Password" runat="server" placeholder="Password"></asp:TextBox>
                <label for="floatingPasswordSignin">Password</label>
            </div>
            <div class="mb-2 text-end">
                <asp:HyperLink ID="HyperLink1" NavigateUrl="#forgotPassword" runat="server" data-bs-toggle="modal" data-bs-target="#modalForgotPW" title="Forgot your password?" style="text-decoration:none;">Forgot your password?</asp:HyperLink>
            </div>
            <asp:Button ID="btnSignin" title="Sign in" CssClass="w-100 btn btn-lg btn-primary" runat="server" OnClick="btnSignin_Click" Text="Sign in"></asp:Button>
            <div class="text-center m-1">
                <span class="text-muted">
                    <i class="bi bi-dash-lg"></i>
                    or
                    <i class="bi bi-dash-lg"></i>
                </span>
            </div>
            <asp:HyperLink ID="btnSignup" CssClass="w-100 btn btn-lg btn-primary" data-bs-toggle="modal" data-bs-target="#modalSignup" title="Sign up" runat="server" NavigateUrl="#signup">Sign up</asp:HyperLink>
        </div>
    </main>
    <div class="modal fade" id="modalForgotPW" tabindex="-1" aria-labelledby="modalSignup" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h3 class="modal-title fw-bold">Hãy nhập username của bạn</h3>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" title="Close" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="mb-2 form-floating">
                        <asp:TextBox ID="floatingUsernameForgotPW" CssClass="form-control mb-2" placeholder="username" runat="server">ex: username</asp:TextBox>
                        <label for="floatingUsernameForgotPW">Username</label>
                        <div class="d-grid">
                            <asp:RequiredFieldValidator Display="Dynamic" ID="ValidateUsernameForgotPW" CssClass="text-danger text-start" runat="server" ControlToValidate="floatingUsernameForgotPW" ErrorMessage="* Xin mời nhập username"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <hr />
                    <asp:Button ID="btnForgotPW" CssClass="w-100 btn btn-lg btn-primary" title="Xác nhận" runat="server" OnClick="btnForgotPW_Click" Text="Xác nhận" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var modalForgotPW = document.getElementById('modalForgotPW');
        $('#modalForgotPW').on('hide.bs.modal', (event) => {
            $('form').trigger("reset");
            $('#ContentWeb_ValidateUsernameForgotPW').css('display', 'none')
        })
    </script>
</asp:Content>
