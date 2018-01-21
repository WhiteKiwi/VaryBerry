<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar.Master" AutoEventWireup="true" CodeBehind="DevInfo.aspx.cs" Inherits="VaryBerry.DevInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<div>
		<img src="/assets/images/VaryBerry.png" style="width: 300px; height: 300px;" alt="VaryBerry Logo">
		<br />

		<h1 style="font-weight: bold">ABOUT US</h1>
		<br />
		<table style="width: 100%; height: 100%; align: center">
			<thead>
				<tr height="60px">
					<th style="width: 20%">Leader</th>
					<th style="width: 20%">Design</th>
					<th style="width: 20%">Program</th>
					<th style="width: 20%">Program</th>
					<th style="width: 20%">Program</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<th style="width: 20%">4기 장지훈</th>
					<th style="width: 20%">3기 김도연</th>
					<th style="width: 20%">누군가가 있겠지</th>
					<th style="width: 20%">누군가가 있겠지</th>
					<th style="width: 20%">누군가가 있겠지</th>
				</tr>
			</tbody>
			<tfoot>
			</tfoot>
		</table>
		<h1>
			<br />
			<br />
		</h1>
		<table style="width: 100%; height: 100%">
			<thead>
				<th colspan="4">도움을 주신 분들</th>
			</thead>
			<tbody>
				<tr style="height: 60px;">
					<th style="width: 25%">3기 조현준</th>
					<th style="width: 25%">입학홍보부 김지민 선생님</th>
					<th style="width: 25%">입학홍보부 김지민 선생님</th>
					<th style="width: 25%">조현준</th>
				</tr>
				<tr style="height: 60px">
					<th style="width: 25%">조현준</th>
					<th style="width: 25%">입학홍보부 김지민 선생님</th>
					<th style="width: 25%">입학홍보우 김지민 선생님</th>
					<th style="width: 25%">조현준</th>
				</tr>
			</tbody>
			<tfoot>
			</tfoot>
		</table>
	</div>
</asp:Content>
