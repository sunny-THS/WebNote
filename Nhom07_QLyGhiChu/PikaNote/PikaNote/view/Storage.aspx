<%@ Page Title="PikaNote - Storage" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Storage.aspx.cs" Inherits="PikaNote.Store" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../lib/asset/css/contentMain.css" rel="stylesheet" />
    <link href="../lib/bootstrap-icon/bootstrap-icons.css" rel="stylesheet" />

    <script defer src="../lib/asset/script/handleCard_Storage.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentWeb" runat="server">
    <div class="mt-4 mb-3 mx-auto">
      <div id="bodyContent" class="container-md row row-cols-1 row-cols-md-2 row-cols-lg-auto g-3 pe-0">
        
      </div>
    </div>
    <script src="../lib/asset/script/loadData_storage.js"></script>
</asp:Content>
