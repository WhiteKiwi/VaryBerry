<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar.Master" AutoEventWireup="true" CodeBehind="Apply.aspx.cs" Inherits="VaryBerry.Apply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<!-- Notice -->
	<div style="padding-top: 50px; margin-bottom: 150px; padding-left: 100px; padding-right: 100px; text-align: left;">
		<h3><strong>VaryBerry 지원</strong></h3>
		<hr class="hr-sky" />
		<form runat="server" style="height: 100%;">
			<div style="float: left; margin-left: 50px; margin-right: 30px;">
				<div class="float-left" style="margin-right: 20px;"><h5>학번</h5></div>
				<span class="float-left"><asp:TextBox ID="studentNumber" runat="server" /></span>
				<br />
				<br />
				<div class="float-left" style="margin-right: 20px;"><h5>디자이너/개발자/사진</h5></div>
				<span class="float-left"><asp:TextBox ID="role" runat="server" placeholder="ex: 개발자" /></span>
				<br />
				<br />
				<br />
				<h5 style="margin-bottom: 15px;">Q1. VaryBerry가 본인에게 어떤 도움이 될 것이라고 생각하시나요?</h5>
				<asp:TextBox ID="Contents1" runat="server" TextMode="MultiLine" Width="100%" Rows="10" />
				<br />
				<br />
				<br />
				<h5 style="margin-bottom: 15px;">Q2. 시험기간에 부르면 어떻게 하실 건가요?</h5>
				<asp:TextBox ID="Contents2" runat="server" TextMode="MultiLine" Width="100%" Rows="10" placeholder="ps. 그렇다고 시험기간에 모인다는 것은 아닙니다.&#10;바쁜 시기에 부르면 어떻게 대처하실지에 대한 질문입니다." />
				<br />
				<br />
				<asp:Button runat="server" CssClass="btn btn-primary float-right" OnClick="ApplyUpload" Text="등록" />
				<br />
				<br />
				<br />
			</div>
		</form>
	</div>
</asp:Content>
