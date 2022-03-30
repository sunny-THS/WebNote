<%@ Page Title="PikaNote - Profile" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="PikaNote.view.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../lib/asset/script/editInfoUser.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentWeb" runat="server">
    <div class="container-md my-4 text-end" style="width: 40%">
        <div class="avtProfile mb-3 text-center">
            <asp:Image ID="imgUserProfile" runat="server" Height="100" Width="100" />
            <asp:FileUpload title="Thay đổi ảnh đại diện" onchange="changeAVT(this)" CssClass="form-control" ID="imgFileUploadProFile" accept=".png, .jpg, .jpeg" Height="100" Width="100" runat="server" />
            <div class="btnPlus"></div>
        </div>
        <div class="form-floating my-2">
            <asp:TextBox ID="floatingName" CssClass="form-control" placeholder="name" runat="server" Text="Nguyen Van A"></asp:TextBox>
            <label for="floatingName">Full Name</label>
            <div class="d-grid">
                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" CssClass="text-danger text-start bg-dark" ControlToValidate="floatingName" runat="server" ErrorMessage="Hãy Nhập Tên...."></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-floating my-2">
            <asp:TextBox ID="floatingEmail" CssClass="form-control" placeholder="email" runat="server" disabled readonly></asp:TextBox>
            <label for="floatingEmail">Email</label>
            <%--<div class="d-grid">
                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2"  CssClass="text-danger text-start bg-dark" runat="server" ControlToValidate="floatingEmail" ErrorMessage="Xin mời nhập email"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display="Dynamic"  CssClass="text-danger text-start bg-dark" ControlToValidate="floatingEmail" ValidationExpression='^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$' ID="RegularExpressionValidatorEmail" runat="server" ErrorMessage="Email không hợp lợi. Mời nhập lại"></asp:RegularExpressionValidator>
            </div>--%>
        </div>
        <div class="form-floating my-2">
            <asp:TextBox ID="floatingSDT" CssClass="form-control" placeholder="tel" runat="server"></asp:TextBox>
            <label for="floatingSDT">Tel</label>
            <div class="d-grid">
                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidatorTel"  CssClass="text-danger text-start bg-dark" runat="server" ControlToValidate="floatingSDT" ErrorMessage="Xin mời nhập số điện thoại"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display="Dynamic"  CssClass="text-danger text-start bg-dark" ControlToValidate="floatingSDT" ValidationExpression="^(84|0[3|5|7|8|9])+([0-9]{8})$" ID="RegularExpressionValidatorTel" runat="server" ErrorMessage="Số điện thoại không hợp lợi. Mời nhập lại"></asp:RegularExpressionValidator>
            </div>
        </div>
        <asp:FileUpload ID="imgFileUploadBackground" title="Chọn hình nền" accept=".png, .jpg, .jpeg" onchange="changeBg(this)" CssClass="form-control" runat="server" />
        <asp:Image ID="imgBG" CssClass="shadow-sm" runat="server" Width="100%" />
        <asp:Button ID="btnSaveUserProfile" CssClass="mt-2 btn btn-primary" OnClick="btnSaveUserProfile_Click" runat="server" Text="Xác định" />
        <style>
            #ContentWeb_imgUserProfile {
                border-radius: 100%;
            }

            .avtProfile {
                position: relative;
            }

            .btnPlus::before {
                content: '+';
                text-align: center;
                font-size: x-large;
                font-weight: bold;
                color: var(--bs-light);
                position: absolute;
                bottom: 0;
                left: 50%;
                transform: translateX(-50%);
                border-bottom-left-radius: 100% 200%;
                border-bottom-right-radius: 100% 200%;
                outline: none;
                height: 35px;
                width: 100px;
                background: rgba(33, 37, 41, .5);
                display: none;
            }

            #ContentWeb_imgFileUploadProFile {
                position: absolute;
                top: 0;
                left: 50%;
                transform: translateX(-50%);
                border-radius: 50%;
                outline: none;
                opacity: 0;
                z-index: 2;
            }

                #ContentWeb_imgFileUploadProFile:hover + .btnPlus::before {
                    display: block;
                }
        </style>
    </div>
</asp:Content>
