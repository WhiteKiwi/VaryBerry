<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VaryBerry.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<div id="BerryProposalsCarousel" class="carousel slide" data-ride="carousel" style="background-color: #C9C9C9; height: 600px;">
		<!-- carousel 하단 바 -->
		<ol class="carousel-indicators">
			<li data-target="#BerryProposalsCarousel" data-slide-to="0" class="active"></li>
			<li data-target="#BerryProposalsCarousel" data-slide-to="1" class=""></li>
		</ol>
		<!-- carousel 내용 -->
		<div class="carousel-inner" style="height: 100%;">
			<div class="carousel-item carousel-item-next carousel-item-left" style="height: 100%;">
				<div class="carousel-caption text-center" style="height: 100%; right: 0; left: 0;">
					<img src="/assets/images/선후배상견례 3.jpg" style="height: auto; max-width: 100%;" />
				</div>
			</div>

			<div class="carousel-item active carousel-item-left" style="height: 100%;">
				<div class="carousel-caption text-center" style="height: 100%; right: 0; left: 0;">
					<img src="/assets/images/선후배상견례 2.jpg" style="height: auto; max-width: 100%;" />
				</div>
			</div>

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

	<!-- Contents -->
	<div style="width: 100%;">
		<div style="width: 50%; float: left; padding: 50px; text-align: left;">
			<h1 style="color: #2865B0;">About BlueBerry</h1>
			<hr class="hr-sky" />
			<!-- 페이지 설명 -->
			<div style="padding: 5px;">
				<p>&nbsp;신입생에게 충남삼성고등학교란 낯설고 익숙하지 않은 장소입니다.
				중학교와 다른 점이 너무나도 많은 본교에서 신입생 홀로 빠르게 적응하기란 쉽지 않습니다. 
				BlueBerry는 넥타이 매는 법을 몰랐던 선배들의 미숙했던 시절을 떠올리며, 신입생들의 빠른 학교 적응을 바라며 만들었습니다.
				먼저 CNSA를 경험한 선배들의 진심어린 조언을 BlueBerry에 담아 앞으로 여러분들이 좀 더 편한 학교생활을 즐길 수 있도록 노력하겠습니다.</p>
				<p>&nbsp;"BlueBerry"는 2017년 학사일정을 기준으로 작성되었습니다.
				지속적으로 관리해 나갈 예정이지만 2018년도 학사일정과 차이가 있을 수 있음을 알려드립니다.
				신입생들의 학교 적응에 VaryBerry가 많은 도움이 되었으면 좋겠습니다.
			</div>
		</div>
		<div style="width: 50%; float: right; padding: 50px; text-align: left; margin-bottom: 100px;">
			<h1 style="color: #2865B0;">Notices</h1>
			<hr class="hr-sky" />
			<!-- Notices -->
			<%
				var noticesList = VaryBerry.Models.NoticeManager.GetNoticeByPage(1);

				foreach (var notice in noticesList) { %>
			<div style="padding-left: 10px; padding-right: 10px;">
				<span class="float-left"><a href="/Notice.aspx?id=<%= notice.Id %>"><%= notice.Title %></a></span>
				<span class="float-right"><%= notice.NoticeAt %></span>
			</div>
			<br />
			<% } %>
		</div>

		<br />
		<footer class="fixed-bottom text-vertical-center text-white" style="width: 100%; margin-bottom: 0.5em;">
			<a href="/DevInfo.aspx" style="color: #C9C9C9;">
				<h6>2017 Copyright © Team VaryBerry All Right Reserved.</h6>
			</a>
		</footer>
</asp:Content>
