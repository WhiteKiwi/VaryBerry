<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar-Admin.master" AutoEventWireup="true" CodeBehind="BerryProposals.aspx.cs" Inherits="VaryBerry.BerryProposals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
	<!-- Carousel css -->
	<link href="/assets/css/carousel.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<!-- Proposals -->
	<div id="BerryProposalsCarousel" class="carousel slide" data-ride="carousel" style="background-color: #C9C9C9;">
		<!-- carousel 하단 바 -->
		<ol class="carousel-indicators">
			<li data-target="#BerryProposalsCarousel" data-slide-to="0" class="active"></li>
			<%
				int count = VaryBerry.Models.BerryProposalManager.GetBerryProposals().Count;
				for (int i = 1; i < count; i++) {
			%>
			<li data-target="#BerryProposalsCarousel" data-slide-to="<%= i %>" class=""></li>
			<% } %>
		</ol>
		<!-- carousel 내용 -->
		<div class="carousel-inner">
			<% 
				var proposalList = VaryBerry.Models.BerryProposalManager.GetBerryProposals();
				bool first = true;
				foreach (var proposal in proposalList) {
			%>
			<div class="carousel-item <%
				if (first) {
					Response.Write("active");
					first = false;
				}%>">
				<div class="container">
					<div class="carousel-caption text-center" style="color: black;">
						<!-- 분류 - 제목 -->
						<h1><% 
								switch (proposal.Classification) {
									case VaryBerry.Models.Classification.Event:
										Response.Write(proposal.Title + " - 행사");
										break;
									case VaryBerry.Models.Classification.Facilities:
										Response.Write(proposal.Title + " - 시설");
										break;
									case VaryBerry.Models.Classification.CNSATerms:
										Response.Write(proposal.Title + " - CNSA 용어");
										break;
									case VaryBerry.Models.Classification.CNSALife:
										Response.Write(proposal.Title + " - 생활");
										break;
									case VaryBerry.Models.Classification.Study:
										Response.Write(proposal.Title + " - 학습");
										break;
									case VaryBerry.Models.Classification.Club:
										Response.Write(proposal.Title + " - 동아리");
										break;
									case VaryBerry.Models.Classification.Group:
										Response.Write(proposal.Title + " - 단체");
										break;
									case VaryBerry.Models.Classification.Contest:
										Response.Write(proposal.Title + " - 대회");
										break;
									default:
										Response.Write(proposal.Title);
										break;
								}
								%></h1>
						<br />

						<!-- 내용 -->
						<p><% Response.Write(proposal.Contents); %></p>
						<br />
						<br />
						<br />
						<br />

						<form method="POST">
							<input type="hidden" name="DeleteProposalId" value="<%= proposal.Id %>" />
							<!-- Buttons -->
							<input class="btn btn-outline-primary" type="submit" value="해결" />
							<input class="btn btn-outline-danger" type="submit" value="지연" />
						</form>
					</div>
				</div>
			</div>
			<% } %>
		</div>
		<a class="carousel-control-prev" href="#BerryProposalsCarousel" role="button" data-slide="prev">
			<span class="carousel-control-prev-icon" aria-hidden="true"></span>
			<span class="sr-only">Previous</span>
		</a>
		<a class="carousel-control-next" href="#BerryProposalsCarousel" role="button" data-slide="next">
			<span class="carousel-control-next-icon" aria-hidden="true"></span>
			<span class="sr-only">Next</span>
		</a>
	</div>
</asp:Content>
