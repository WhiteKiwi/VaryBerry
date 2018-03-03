<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar.Master" AutoEventWireup="true" CodeBehind="SlaveApply.aspx.cs" Inherits="VaryBerry.SlaveApply1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<!-- Apply -->
	<div style="padding-top: 50px; margin-bottom: 150px; padding-left: 100px; padding-right: 100px; text-align: left;">
		<h3><strong>VaryBerry 관리자 지원</strong></h3>
		<hr class="hr-sky" />
		<form runat="server" style="height: 100%;">
			<div style="float: left; margin-left: 50px; margin-right: 30px;">
				<div class="float-left" style="margin-right: 20px;"><h5>학번</h5></div>
				<span class="float-left" style="margin-right: 20px;" ><asp:TextBox ID="studentNumber" runat="server" /></span>
				<span class="float-left"><asp:Button ID="ApplyCheck" runat="server" OnClick="ApplyCheck_Click" Text="지원 여부 확인" CssClass="btn btn-primary" /></span>
				<br />
				<br />
				<br />
				<div class="float-left" style="margin-right: 20px;"><h5>이름</h5></div>
				<span class="float-left"><asp:TextBox ID="name" runat="server" /></span>
				<br />
				<br />
				<br />
				<h5 style="margin-bottom: 15px;">Q1. VaryBerry에 지원하게 된 계기가 무엇인가요?</h5>
				<asp:TextBox ID="Index1" runat="server" TextMode="MultiLine" Width="100%" Rows="10" />
				<br />
				<br />
				<br />
				<h5 style="margin-bottom: 15px;">Q2. 학교생활을 하면서 했던 활동 중 가장 의미있던 활동과 그 이유가 무엇인가요?</h5>
				<asp:TextBox ID="Index2" runat="server" TextMode="MultiLine" Width="100%" Rows="10" />
				<br />
				<br />
				<br />
				<h5 style="margin-bottom: 15px;">Q3. BlueBerry에 추가했으면 하는 기능이 있으신가요?</h5>
				<asp:TextBox ID="Index3" runat="server" TextMode="MultiLine" Width="100%" Rows="10"></asp:TextBox>
 				<br />
				<br />
				<br />
				<h5 style="margin-bottom: 15px;">Q4. 당신이 산타라면 전 세계 아이들에게 어떻게 선물을 배달할 것인가요?</h5>
				<asp:TextBox ID="Index4" runat="server" TextMode="MultiLine" Width="100%" Rows="10"></asp:TextBox>
				<br />
				<br />
				<asp:Button ID="UploadButton" runat="server" CssClass="btn btn-primary float-right" OnClick="ApplyUpload" Text="등록" />
				<br />
				<br />
				<br />
			</div>
		</form>
	</div>
</asp:Content>
