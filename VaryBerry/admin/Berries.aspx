<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar-Admin.Master" AutoEventWireup="true" CodeBehind="Berries.aspx.cs" Inherits="VaryBerryAdmin.AdminGuide" %>

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
					<a class="nav-link" href="#">디플로마</a>
				</li>
				<li class="nav-item">
					<a class="nav-link" href="#">행사</a>
				</li>
				<li class="nav-item">
					<a class="nav-link" href="#">기숙사</a>
				</li>
			</ul>
		</div>
	</nav>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
