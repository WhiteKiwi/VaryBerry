<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VaryBerry.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<div id="BerryProposalsCarousel" class="carousel slide" data-ride="carousel" style="background-color: #C9C9C9; height: 50%;">
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
			<pre>asdasda
sdasda
sdasd
asdasc
			</pre>
		</div>
		<div style="width: 50%; float: right; padding: 50px; text-align: left">
			<h1 style="color: #2865B0;">Notice</h1>
			<hr class="hr-sky" />
			<pre>asdasda
sdasda
sdasd
asdasc
			</pre>
		</div>
	</div>

	<footer class="fixed-bottom text-vertical-center text-white" style="width: 100%; margin-bottom: 0.5em;">
		<a href="/DevInfo.aspx" style="color: #C9C9C9;">
			<h6>2017 Copyright © Team VaryBerry All Right Reserved.</h6>
		</a>
	</footer>
</asp:Content>
