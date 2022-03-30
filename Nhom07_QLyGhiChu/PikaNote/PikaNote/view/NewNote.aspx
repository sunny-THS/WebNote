<%@ Page Title="PikaNote - New Note" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="NewNote.aspx.cs" Inherits="PikaNote.view.NewNote" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentWeb" runat="server">
    <main class="mt-5 mb-3 mx-auto">
        <div class="mt-5 container-md">
            <div class="form-floating">
                <asp:TextBox ID="floatingTitleNote" CssClass="form-control mb-2" placeholder="title" runat="server"></asp:TextBox>
                <label for="floatingTitleNote">Title</label>
            </div>
            <div class="form-floating">
                <asp:TextBox ID="floatingContentNote" CssClass="form-control mb-2" TextMode="multiline" Columns="50" Rows="5" runat="server" placeholder="Content"></asp:TextBox>
                <label for="floatingContentNote">Content....</label>
            </div>
            <asp:Button ID="btnXN" OnClick="btnXN_Click" title="Xác nhận" CssClass="w-100 btn btn-lg btn-primary" runat="server" Text="Xác nhận"></asp:Button>
        </div>
    </main>
</asp:Content>
