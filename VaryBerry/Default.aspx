<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VaryBerry.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<div class="background-image" style="width: 100%; height: 100%;">
		<div class="text-vertical-center text-white" style="background-color: rgba(0, 0, 0, 0.12);">
			<h1>Blueberry is delicious.</h1>
			<br />
			<br />
			<br />
			<!-- Berries Page Button -->
			<a href="~/Berries.aspx" runat="server" class="btn btn-outline-light" style="border: 3px solid #f8f9fa;" role="button">View details »</a>
		</div>
	</div>

	<footer class="fixed-bottom text-vertical-center text-white" style="width: 100%; margin-bottom: 0.5em;">
		<a href="/DevInfo.aspx" style="color: #C9C9C9;"><h5>2017 Copyright © Team VaryBerry All Right Reserved.</h5></a>
	</footer>
</asp:Content>
