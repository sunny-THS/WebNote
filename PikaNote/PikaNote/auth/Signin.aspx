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
</asp:Content>
