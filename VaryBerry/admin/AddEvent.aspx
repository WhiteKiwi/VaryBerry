<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar-Admin.master" AutoEventWireup="true" CodeBehind="AddEvent.aspx.cs" Inherits="VaryBerry.AddEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<!-- Calendar -->
	<div style="width: 100%; height: 70%; padding-top: 50px; margin-bottom: 150px; padding-left: 100px; padding-right: 100px; text-align: left;">
		<h3><strong>일정 등록</strong></h3>
		<hr class="hr-sky" />
		<form runat="server" style="height: 100%;">
			<div style="float: left; margin-left: 50px; margin-right: 30px;">
				<h4>일정</h4>
				<br />
				<br />
				<h4>제목</h4>
				<br />
				<br />
				<h4>분류, Berry 번호</h4>
			</div>
			<div style="float: left; width: 70%; width: calc(100% - 300px); height: 70%;">
				<!-- Calendar -->
				<asp:TextBox ID="EventDate" runat="server" Width="100%" />
				<br />
				<br />
				<br />

				<!-- Title -->
				<asp:TextBox ID="nTitle" runat="server" Width="100%" />
				<br />
				<br />
				<br />

				<!-- Contents -->
				<asp:TextBox ID="Classification" runat="server"  Width="20%" placeholder="분류번호" />
				<asp:TextBox ID="BerryId" runat="server"  Width="20%" placeholder="BerryID" />
				<br />
				<asp:Button runat="server" CssClass="btn btn-primary float-right" OnClick="EventUpload" Text="등록" />
			</div>
		</form>
	</div>
	<br />
</asp:Content>
