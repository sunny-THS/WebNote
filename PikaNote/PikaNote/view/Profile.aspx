<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="PikaNote.view.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../lib/asset/script/editInfoUser.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentWeb" runat="server">
    <div class="container-md my-4 text-end" style="width:40%">
        <div class="avtProfile mb-3 text-center">
            <asp:Image ID="imgUserProfile" runat="server" Height="100" Width="100" />
            <asp:FileUpload title="Thay đổi ảnh đại diện" onchange="changeAVT(this)" CssClass="form-control" ID="imgFileUploadProFile" accept=".png, .jpg, .jpeg" Height="100" Width="100" runat="server" />
            <div class="btnPlus"></div>
        </div>
        <div class="form-floating my-2">
            <asp:TextBox ID="floatingName" CssClass="form-control mb-2" placeholder="name" runat="server" Text="Nguyen Van A"></asp:TextBox>
            <label for="floatingName">Full Name</label>
        </div>
        <div class="form-floating my-2">
            <asp:TextBox ID="floatingEmail" CssClass="form-control mb-2" placeholder="email" runat="server"></asp:TextBox>
            <label for="floatingEmail">Email</label>
        </div>
        <div class="form-floating my-2">
            <asp:TextBox ID="floatingSDT" CssClass="form-control mb-2" placeholder="tel" runat="server"></asp:TextBox>
            <label for="floatingSDT">Tel</label>
        </div>
        <asp:FileUpload ID="imgFileUploadBackground" title="Chọn hình nền" accept=".png, .jpg, .jpeg" onchange="changeBg(this)" CssClass="form-control"  runat="server" />
        <asp:Image ID="imgBG" ImageUrl="" CssClass="shadow-sm" runat="server"  Width="100%" />
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
