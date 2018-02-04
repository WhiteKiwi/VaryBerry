<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar.Master" AutoEventWireup="true" CodeBehind="BerryPropose.aspx.cs" Inherits="VaryBerry.BerryPropose" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<nav class="navbar navbar-expand-lg navbar-dark" style="background-color: #7A8591;">
		<button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
			<span class="navbar-toggler-icon"></span>
		</button>
		<div class="collapse navbar-collapse" id="navbarText">
			<ul class="navbar-nav mr-auto">
				<li class="nav-item active" style="margin-left: 10px; margin-right: 10px;">
					<a class="nav-link" href="/Berries.aspx?classification=0"><strong>행사</strong></a>
				</li>
				<li class="nav-item active" style="margin-left: 10px; margin-right: 10px;">
					<a class="nav-link" href="/Berries.aspx?classification=1"><strong>학교시설</strong></a>
				</li>
				<li class="nav-item active" style="margin-left: 10px; margin-right: 10px;">
					<a class="nav-link" href="/Berries.aspx?classification=2"><strong>CNSA 용어</strong></a>
				</li>
				<li class="nav-item active" style="margin-left: 10px; margin-right: 10px;">
					<a class="nav-link" href="/Berries.aspx?classification=3"><strong>생활</strong></a>
				</li>
				<li class="nav-item active" style="margin-left: 10px; margin-right: 10px;">
					<a class="nav-link" href="/Berries.aspx?classification=4"><strong>학습</strong></a>
				</li>
				<li class="nav-item active" style="margin-left: 10px; margin-right: 10px;">
					<a class="nav-link" href="/Berries.aspx?classification=5"><strong>동아리</strong></a>
				</li>
				<li class="nav-item active" style="margin-left: 10px; margin-right: 10px;">
					<a class="nav-link" href="/Berries.aspx?classification=6"><strong>단체</strong></a>
				</li>
				<li class="nav-item active" style="margin-left: 10px; margin-right: 10px;">
					<a class="nav-link" href="/Berries.aspx?classification=7"><strong>대회</strong></a>
				</li>
			</ul>
		</div>
	</nav>

	<!-- Propose -->
	<div style="width: 100%; height: 100%; padding-top: 50px; margin-bottom: 150px; padding-left: 100px; padding-right: 100px; text-align: left;">
		<h3><strong>Berry 제안</strong></h3>
		<hr class="hr-sky" />
		<form runat="server" style="height: 100%;">
			<div style="float: left; margin-left: 50px; margin-right: 30px;">
				<h4>분류 선택</h4>
				<br />
				<br />
				<h4>제목</h4>
				<br />
				<br />
				<h4>내용</h4>
			</div>
			<div style="float: left; width: 70%; width: calc(100% - 300px); height: 70%;">
				<asp:DropDownList runat="server" ID="ClassificationList" CssClass="custom-select">
				</asp:DropDownList>

				<br />
				<br />
				<br />

				<!-- Title -->
				<asp:TextBox ID="nTitle" runat="server" Width="100%" />

				<br />
				<br />
				<br />

				<!-- Contents -->
				<asp:ScriptManager ID="BytesCountScriptManager" runat="server"></asp:ScriptManager>
				<asp:UpdatePanel runat="server" ID="BytesPanel" UpdateMode="Always" style="height: 100%;">
					<ContentTemplate>
						<fieldset style="height: 100%;">
							<asp:TextBox ID="Contents" runat="server" TextMode="MultiLine" Width="100%" Height="100%" OnTextChanged="CountBytes" AutoPostBack="true" />
							<asp:Label runat="server" ID="BytesCount" CssClass="float-left" AutoPostBack="true" />
						</fieldset>
					</ContentTemplate>
				</asp:UpdatePanel>
				<br />
				<asp:Button runat="server" CssClass="btn btn-primary float-right" OnClick="BerryProposalUpload" Text="등록" />
			</div>
		</form>
	</div>
	<br />
	<footer style="width: 100%; margin-top: 1.5em; margin-bottom: 1.5em; color: #C9C9C9; text-align: center;">
		<a href="/DevInfo.aspx" style="color: #C9C9C9;">
			<h6>2017 Copyright © Team VaryBerry All Right Reserved.</h6>
		</a>
	</footer>
</asp:Content>
