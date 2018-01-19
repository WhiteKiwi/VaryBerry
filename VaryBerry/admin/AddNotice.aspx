<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar-Admin.Master" AutoEventWireup="true" CodeBehind="AddNotice.aspx.cs" Inherits="VaryBerryAdmin.AddNotice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<!-- Top-Image -->
	<div class="background-image-long" style="width: 100%; height: 40%;"></div>

	<!-- Notices -->
	<div style="width: 100%; height: 70%; padding-top: 50px; margin-bottom: 150px; padding-left: 100px; padding-right: 100px; text-align: left;">
		<h3><strong>공지사항 등록</strong></h3>
		<hr class="hr-sky" />
		<br />
		<form runat="server" style="height: 100%;">
			<!-- Input Box -->
			<asp:TextBox ID="Contents" runat="server" TextMode="MultiLine" Width="100%" Height="100%" />
			<asp:Button runat="server" CssClass="btn btn-primary float-right" OnClick="NoticeUpload" Text="등록" />
		</form>
	</div>
	<footer style="width: 100%; margin-top: 1.5em; margin-bottom: 1.5em; color: #C9C9C9; text-align: center;">
		<h5>2017 Copyright © Team VaryBerry All Right Reserved.</h5>
	</footer>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
