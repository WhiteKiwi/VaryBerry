<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar.Master" AutoEventWireup="true" CodeBehind="AddQuestion.aspx.cs" Inherits="VaryBerry.AddQuestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<!-- Question -->
	<div style="width: 100%; height: 70%; padding-top: 50px; margin-bottom: 150px; padding-left: 100px; padding-right: 100px; text-align: left;">
		<h3><strong>질문 등록</strong></h3>
		<hr class="hr-sky" />
		<form runat="server" style="height: 100%;">
			<div style="float: left; margin-left: 50px; margin-right: 30px;">
				<h4>제목</h4>
				<br />
				<br />
				<h4>내용</h4>
			</div>
			<div style="float: left; width: 70%; width: calc(100% - 300px); height: 70%;">
				<!-- Title -->
				<asp:TextBox ID="nTitle" runat="server" Width="100%" />

				<br />
				<br />
				<br />

				<!-- Contents -->
				<asp:TextBox ID="Contents" runat="server" TextMode="MultiLine" Width="100%" Height="100%"/>

				<br />
				<asp:Button runat="server" CssClass="btn btn-primary float-right" OnClick="QuestionUpload" Text="등록" />
			</div>
		</form>
	</div>
</asp:Content>
