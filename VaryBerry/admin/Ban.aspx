<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar-Admin.master" AutoEventWireup="true" CodeBehind="Ban.aspx.cs" Inherits="VaryBerry.admin.Ban" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
		<!-- Ban -->
	<div style="width: 100%; height: 70%; padding-top: 50px; margin-bottom: 150px; padding-left: 100px; padding-right: 100px; text-align: left;">
		<h3><strong>Ban</strong></h3>
		<hr class="hr-sky" />
		<form runat="server" style="height: 100%;">
			<div style="float: left; margin-left: 50px; margin-right: 30px;">
				<h4></h4>
			</div>
			<div style="float: left; width: 70%; width: calc(100% - 300px); height: 70%;">
				<asp:TextBox ID="PostID" runat="server" Width="100%" />
				<br />
				<br />
				<asp:Button runat="server" CssClass="btn btn-primary float-right" OnClick="BanAndDelete" Text="등록" />
			</div>
		</form>
	</div>
</asp:Content>
