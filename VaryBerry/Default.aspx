<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VaryBerry.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<!-- Background -->
	<div class="background-image">
		<!-- Main Contents -->
		<div class="text-vertical-center" style="color: white;">
			<h1>CNSA Guide for 5th Fresh Students</h1>
			<h3>From CNSA IT Slaves</h3>
			<br />
			<!-- Berries Page Button -->
			<a href="~/Berries.aspx" runat="server" class="btn btn-outline-light" style="border: 3px solid #f8f9fa;" role="button">View details »</a>
		</div>
	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
