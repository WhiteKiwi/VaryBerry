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
					<a class="nav-link" href="/Berries.aspx?classification=2">CNSA 용어</a>
				</li>
				<li class="nav-item active">
					<a class="nav-link" href="/Berries.aspx?classification=3">생활</a>
				</li>
				<li class="nav-item active">
					<a class="nav-link" href="/Berries.aspx?classification=4">학습</a>
				</li>
				<li class="nav-item active">
					<a class="nav-link" href="/Berries.aspx?classification=5">활동</a>
				</li>
				<li class="nav-item active">
					<a class="nav-link" href="/Berries.aspx?classification=6">동아리</a>
				</li>
				<li class="nav-item active">
					<a class="nav-link" href="/Berries.aspx?classification=7">1인1기</a>
				</li>
				<li class="nav-item active">
					<a class="nav-link" href="/Berries.aspx?classification=8">단체</a>
				</li>
				<li class="nav-item active">
					<a class="nav-link" href="/Berries.aspx?classification=9">대회</a>
				</li>
			</ul>
		</div>
	</nav>

	<!-- 사이드바 제목, 크기 설정 -->
	<div class="col-3 border border-bottom-0 border-secondary text-left" style="padding: 1rem; float: left; overflow: auto;">
		<%
			VaryBerry.Models.Classification classification;
			switch (Request.QueryString["classification"]) {
				case "0":
					classification = VaryBerry.Models.Classification.Event;
					break;
				case "1":
					classification = VaryBerry.Models.Classification.Facilities;
					break;
				case "2":
					classification = VaryBerry.Models.Classification.CNSATerms;
					break;
				case "3":
					classification = VaryBerry.Models.Classification.CNSALife;
					break;
				case "4":
					classification = VaryBerry.Models.Classification.Study;
					break;
				case "5":
					classification = VaryBerry.Models.Classification.Career;
					break;
				case "6":
					classification = VaryBerry.Models.Classification.Club;
					break;
				case "7":
					classification = VaryBerry.Models.Classification.OneManOneSkill;
					break;
				case "8":
					classification = VaryBerry.Models.Classification.Group;
					break;
				case "9":
					classification = VaryBerry.Models.Classification.Contest;
					break;
				default:
					classification = VaryBerry.Models.Classification.Event;
					break;
			}
			var berryList = VaryBerry.Models.BerryManager.GetBerriesByClassification(classification);

			int i = 0;
			foreach (var berry in berryList) { %>

		<div>
			<a href="/Berries.aspx?classification=<%=Request.QueryString["classification"] != null ? Request.QueryString["classification"] : "0" %>&berry=<%= berry.Id %>" class="text-dark">
				<span style="margin-left: 10px; margin-right: 20px;"><%= ++i  %></span><span><%= berry.Title %></span>
			</a>
		</div>
		<hr style="background-color: #95989A;" />
		<% } %>
	</div>

	<!-- 본문에 대한 코드 -->
	<div class=" col-9 container" style="text-align: left; float: left; padding: 2rem; position: relative;">
		<!-- 제목 -->
		<br />
		<%
			int berryId = 1;
			if (Request.QueryString["berry"] != null) {
				berryId = int.Parse(Request.QueryString["berry"]);
			} else {
				berryId = berryList[0].Id;
			}
			var requestBerry = VaryBerry.Models.BerryManager.GetBerryByID(berryId);
		%>
		<h1 style="margin-left: 1rem;"><%= requestBerry.Title %></h1>

		<hr style="border: 1px solid #95989A; background-color: #95989A;" />
		<div style="width: 100%; padding: 2rem;">
			<%= requestBerry.Contents %>
		</div>

		<br />
		<footer style="margin-top: 1.5em; margin-bottom: 1.5em; color: #C9C9C9; position: absolute; bottom: 0px;">
			<a href="/DevInfo.aspx" style="color: #C9C9C9;">
				<h5>2017 Copyright © Team VaryBerry All Right Reserved.</h5>
			</a>
		</footer>
	</div>
</asp:Content>
