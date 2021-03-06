﻿<%@ Page Language="C#" MasterPageFile="~/master/Navbar.Master" AutoEventWireup="true" CodeBehind="Notice.aspx.cs" Inherits="VaryBerry.Notice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<!-- Top-Image -->
	<div class="background-image-long" style="width: 100%; height: 40%;"></div>

	<!-- Notice -->
	<div style="width: 100%; padding-top: 50px; padding-left: 100px; padding-right: 100px; text-align: left;">
		<h3><strong>공지사항</strong></h3>
		<hr class="hr-sky" />
		<form runat="server">
			<span class="float-left" style="margin-left: 17px; margin-right: 30px;">제목</span>
			<span class="float-left" style="text-align: center;">
				<asp:Label ID="nTitle" runat="server" /></span>
			<span class="float-right" style="margin-left: 30px; margin-right: 37px;">
				<asp:Label ID="NoticeAt" runat="server" /></span>
			<span class="float-right" style="text-align: center;">공지일</span>
		</form>
		<br />
		<hr class="hr-gray" />
		<div style="margin-left: 20px; margin-right: 20px;">
			<asp:Label ID="Contents" runat="server" />
		</div>
		<br />
	</div>

	<br />
	<div style="width: 100%; text-align: right;">
		<a href="/Notices.aspx" class="btn btn-primary" style="margin-right: 120px;" role="button">목록</a>
	</div>

	<br />
	<footer style="width: 100%; margin-top: 1.5em; margin-bottom: 1.5em; color: #C9C9C9; text-align: center;">
		<a href="/DevInfo.aspx" style="color: #C9C9C9;">
			<h6>2017 Copyright © Team VaryBerry All Right Reserved.</h6>
		</a>
	</footer>
</asp:Content>
