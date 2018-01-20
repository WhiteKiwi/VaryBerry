<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar.Master" AutoEventWireup="true" CodeBehind="Berries.aspx.cs" Inherits="VaryBerry.Guide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<nav class="navbar navbar-expand-lg navbar-dark" style="background-color: #7A8591;">
		<button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
			<span class="navbar-toggler-icon"></span>
		</button>
		<div class="collapse navbar-collapse" id="navbarText">
			<ul class="navbar-nav mr-auto">
				<li class="nav-item active">
					<a class="nav-link" href="/Berries.aspx?classification=0">행사</a>
				</li>
				<li class="nav-item active">
					<a class="nav-link" href="/Berries.aspx?classification=1">학교시설</a>
				</li>
				<li class="nav-item active">
					<a class="nav-link" href="/Berries.aspx?classification=2">기숙사</a>
				</li>
				<li class="nav-item active">
					<a class="nav-link" href="/Berries.aspx?classification=3">학습</a>
				</li>
				<li class="nav-item active">
					<a class="nav-link" href="/Berries.aspx?classification=4">활동</a>
				</li>
				<li class="nav-item active">
					<a class="nav-link" href="/Berries.aspx?classification=5">대회</a>
				</li>
				<li class="nav-item active">
					<a class="nav-link" href="/Berries.aspx?classification=6">교우관계</a>
				</li>
			</ul>
		</div>
	</nav>
</asp:Content>
