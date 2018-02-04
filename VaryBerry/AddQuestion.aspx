<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar.Master" AutoEventWireup="true" CodeBehind="AddQuestion.aspx.cs" Inherits="VaryBerry.AddQuestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
    <!-- Question -->
    <div style="width: 100%; height: 70%; padding-top: 50px; margin-bottom: 150px; padding-left: 100px; padding-right: 100px; text-align: left;">
        <div>
            <h3><strong>질문 등록</strong></h3>
            <hr class="hr-sky" />
            <form runat="server" style="height: 100%;">
                <div class="row">
                    <div class="col-1" style="text-align:left;">
                        <h4>제목</h4>
                        <br />
                        <br />
                        <h4>내용</h4>
                    </div>
                    <div class="col-11">
                        <asp:TextBox ID="nTitle" runat="server" Width="100%" />

                        <br />
                        <br />
                        <br />

                        <!-- Contents -->
                        <asp:TextBox ID="Contents" runat="server" TextMode="MultiLine" Width="100%" Height="100%" />

                        <br />
                        <asp:Button runat="server" CssClass="btn btn-primary float-right" OnClick="QuestionUpload" Text="등록" />
                    </div>
                </div>
            </form>
        </div>
    </div>
    <footer style="width: 100%; margin-top: 1.5em; margin-bottom: 1.5em; text-align: center;">
        <a href="/DevInfo.aspx" style="color: #C9C9C9;">
            <h6>2017 Copyright © Team VaryBerry All Right Reserved.</h6>
        </a>
    </footer>
</asp:Content>
