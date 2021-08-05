<%@ Page Title="PikaNote - Home" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PikaNote.tesst" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../lib/asset/css/contentMain.css" rel="stylesheet" />
    <link href="../lib/bootstrap-icon/bootstrap-icons.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentWeb" runat="server">
    <div class="mt-4 mb-3 m-auto">
        <div class="container-md row row-cols-1 row-cols-md-2 row-cols-lg-4 g-3">
            <div class="col">
                <div id="card_1" class="card shadow">
                    <div class="card-body pb-2">
                        <div class="card-title fw-bold h4" contenteditable="false" spellcheck="false" aria-multiline="true" role="textbox" dir="ltr">Card title</div>
                        <div class="card-text" contenteditable="false" spellcheck="false" aria-multiline="true" role="textbox" dir="ltr">
                            This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.
                        </div>
                        <div class="row row-cols-3 mt-0 m-auto g-3">
                            <div class="col mt-2 text-center">
                                <i role="button" onclick="" class="iconCNCard bi bi-box-arrow-down" title="Lưu trữ"></i>
                            </div>
                            <div class="col mt-2 text-center">
                                <i role="button" onclick="editCard(this)" class="iconCNCard bi bi-pencil-square" title="Chỉnh sửa"></i>
                            </div>
                            <div class="col mt-2 text-center">
                                <i role="button" onclick="" class="iconCNCard bi bi-trash" title="Xóa"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col">
                <div id="card_2" class="card shadow">
                    <div class="card-body pb-2">
                        <div class="card-title fw-bold h4" contenteditable="false" spellcheck="false" aria-multiline="true" role="textbox" dir="ltr">Card title</div>
                        <div class="card-text" contenteditable="false" spellcheck="false" aria-multiline="true" role="textbox" dir="ltr">
                            This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.
                        </div>
                        <div class="row row-cols-3 mt-0 m-auto g-3">
                            <div class="col mt-2 text-center">
                                <i role="button" onclick="" class="iconCNCard bi bi-box-arrow-down" title="Lưu trữ"></i>
                            </div>
                            <div class="col mt-2 text-center">
                                <i role="button" onclick="editCard(this)" class="iconCNCard bi bi-pencil-square" title="Chỉnh sửa"></i>
                            </div>
                            <div class="col mt-2 text-center">
                                <i role="button" onclick="" class="iconCNCard bi bi-trash" title="Xóa"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col">
                <div id="card_3" class="card shadow">
                    <div class="card-body pb-2">
                        <div class="card-title fw-bold h4" contenteditable="false" spellcheck="false" aria-multiline="true" role="textbox" dir="ltr">Card title</div>
                        <div class="card-text" contenteditable="false" spellcheck="false" aria-multiline="true" role="textbox" dir="ltr">
                            This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.
                        </div>
                        <div class="row row-cols-3 mt-0 m-auto g-3">
                            <div class="col mt-2 text-center">
                                <i role="button" onclick="" class="iconCNCard bi bi-box-arrow-down" title="Lưu trữ"></i>
                            </div>
                            <div class="col mt-2 text-center">
                                <i role="button" onclick="editCard(this)" class="iconCNCard bi bi-pencil-square" title="Chỉnh sửa"></i>
                            </div>
                            <div class="col mt-2 text-center">
                                <i role="button" onclick="" class="iconCNCard bi bi-trash" title="Xóa"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col">
                <div id="card_4" class="card shadow">
                    <div class="card-body pb-2">
                        <div class="card-title fw-bold h4" contenteditable="false" spellcheck="false" aria-multiline="true" role="textbox" dir="ltr">Card title</div>
                        <div class="card-text" contenteditable="false" spellcheck="false" aria-multiline="true" role="textbox" dir="ltr">
                            This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.
                        </div>
                        <div class="row row-cols-3 mt-0 m-auto g-3">
                            <div class="col mt-2 text-center">
                                <i role="button" onclick="" class="iconCNCard bi bi-box-arrow-down" title="Lưu trữ"></i>
                            </div>
                            <div class="col mt-2 text-center">
                                <i role="button" onclick="editCard(this)" class="iconCNCard bi bi-pencil-square" title="Chỉnh sửa"></i>
                            </div>
                            <div class="col mt-2 text-center">
                                <i role="button" onclick="" class="iconCNCard bi bi-trash" title="Xóa"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col">
                <div id="card_5" class="card shadow">
                    <div class="card-body pb-2">
                        <div class="card-title fw-bold h4" contenteditable="false" spellcheck="false" aria-multiline="true" role="textbox" dir="ltr">Card title</div>
                        <div class="card-text" contenteditable="false" spellcheck="false" aria-multiline="true" role="textbox" dir="ltr">
                            This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.
                        </div>
                        <div class="row row-cols-3 mt-0 m-auto g-3">
                            <div class="col mt-2 text-center">
                                <i role="button" onclick="" class="iconCNCard bi bi-box-arrow-down" title="Lưu trữ"></i>
                            </div>
                            <div class="col mt-2 text-center">
                                <i role="button" onclick="editCard(this)" class="iconCNCard bi bi-pencil-square" title="Chỉnh sửa"></i>
                            </div>
                            <div class="col mt-2 text-center">
                                <i role="button" onclick="" class="iconCNCard bi bi-trash" title="Xóa"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col">
                <div id="card_6" class="card shadow">
                    <div class="card-body pb-2">
                        <div class="card-title fw-bold h4" contenteditable="false" spellcheck="false" aria-multiline="true" role="textbox" dir="ltr">Card title</div>
                        <div class="card-text" contenteditable="false" spellcheck="false" aria-multiline="true" role="textbox" dir="ltr">
                            This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.
                        </div>
                        <div class="row row-cols-3 mt-0 m-auto g-3">
                            <div class="col mt-2 text-center">
                                <i role="button" onclick="" class="iconCNCard bi bi-box-arrow-down" title="Lưu trữ"></i>
                            </div>
                            <div class="col mt-2 text-center">
                                <i role="button" onclick="editCard(this)" class="iconCNCard bi bi-pencil-square" title="Chỉnh sửa"></i>
                            </div>
                            <div class="col mt-2 text-center">
                                <i role="button" onclick="" class="iconCNCard bi bi-trash" title="Xóa"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
