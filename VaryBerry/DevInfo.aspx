<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar.Master" AutoEventWireup="true" CodeBehind="DevInfo.aspx.cs" Inherits="VaryBerry.DevInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<div>
		<img src="/assets/img/VaryBerry.png" style="width: 300px; height: 300px;" alt="VaryBerry Logo" />
		<br />

		<h1 style="font-weight: bold">ABOUT US</h1>
		<br />
		<br />
		<br />

		<table style="width: 100%; height: 100%; text-align: center">
			<thead>
				<tr>
					<th style="width: 20%; color: red">Director</th>
					<th style="width: 20%; color: mediumpurple">Designer</th>
					<th style="width: 20%; color: blue">Developer</th>
					<th style="width: 20%; color: blue">Developer</th>
					<th style="width: 20%; color: burlywood">Photographer</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<th style="width: 20%;">4기 장지훈</th>
					<th style="width: 20%;">3기 김도연</th>
					<th style="width: 20%;">4기 김재훈</th>
					<th style="width: 20%;">3기 가동식</th>
					<th style="width: 20%;">3기 전민규</th>
				</tr>
			</tbody>
		</table>
		<br />
		<br />
		<br />

		<table style="width: 100%; height: 100%; text-align: center">
			<thead>
				<tr>
					<th style="width: 20%; color: gray">Guide Director</th>
					<th style="width: 20%; color: gray">Guide Codirector</th>
					<th style="width: 20%; color: gray">Guide Codirector</th>
					<th style="width: 20%; color: gray">Guide Codirector</th>
					<th style="width: 20%; color: gray">Guide Codirector</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<th style="width: 20%;">3기 김영훈</th>
					<th style="width: 20%;">4기 강범석</th>
					<th style="width: 20%;">4기 이주원</th>
					<th style="width: 20%;">4기 공민선</th>
					<th style="width: 20%;">4기 임채림</th>
				</tr>
			</tbody>
			<tfoot>
			</tfoot>
		</table>
		<br />
		<br />
		<br />

		<table style="width: 100%; height: 100%">
			<tr style="height: 60px;">
				<th style="width: 20%; color: hotpink">로고 아이디어 제공</th>
				<th style="width: 20%; color: hotpink">페이지 제작 지원</th>
				<th style="width: 20%; color: hotpink">개발 조언</th>
				<th style="width: 20%; color: hotpink">웹페이지 이름 아이디어 제공</th>
				<th style="width: 20%; color: hotpink">단체 작성 도움</th>
			</tr>
			<tr style="height: 60px">
				<th style="width: 20%;">3기 조현준</th>
				<th style="width: 20%;">입학홍보부 김지민 선생님</th>
				<th style="width: 20%;">1기 조성욱, 2기 박민재</th>
				<th style="width: 20%;">3기 박준서</th>
				<th style="width: 20%;">4기 석기범</th>
			</tr>
		</table>
	</div>
	<br />
	<br />
	<br />
	<footer style="width: 100%; margin-top: 1.5em; margin-bottom: 1.5em; color: #C9C9C9; text-align: center;">
		<a href="/DevInfo.aspx" style="color: #C9C9C9;">
			<h6>2017 Copyright © Team VaryBerry All Right Reserved.</h6>
		</a>
	</footer>
</asp:Content>
