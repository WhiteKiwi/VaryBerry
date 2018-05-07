<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar.Master" AutoEventWireup="true" CodeBehind="Apply.aspx.cs" Inherits="VaryBerry.Apply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<!-- Apply -->
	<div style="padding-top: 50px; margin-bottom: 150px; padding-left: 100px; padding-right: 100px; text-align: left;">
		<h3><strong>VaryBerry 지원</strong></h3>
		<hr class="hr-sky" />
		<form runat="server" style="height: 100%; text-align: center;">
			<div style="margin-left: 50px; margin-right: 30px;">
				<div class="float-left" style="margin-right: 20px;">
					<h5>학번</h5>
				</div>
				<span class="float-left" style="margin-right: 20px;">
					<asp:TextBox ID="studentNumber" runat="server" />
				</span>
				<span class="float-left" style="margin-right: 20px;">
					<asp:Button ID="CheckButton" runat="server" CssClass="btn btn-primary float-right" OnClick="ApplyCheck" Text="지원서 불러오기" />
				</span>
				<br />
				<br />
				<br />
				<h5 style="float: left; margin-bottom: 15px;"> Q1. 교내 대회들 중 하나를 조사하여 Berry를 작성해보세요. (최대 1200자)</h5>
				<asp:TextBox ID="Answer0" runat="server" TextMode="MultiLine" Width="100%" Rows="20" />
				<br />
				<h5 style="float: left; margin-bottom: 15px;"> Q2. VaryBerry에 지원하게 된 계기가 무엇입니까? (최대 300자)</h5>
				<asp:TextBox ID="Answer1" runat="server" TextMode="MultiLine" Width="100%" Rows="20" />
				<br />
				<h5 style="float: left; margin-bottom: 15px;"> Q3. 본인이 VaryBerry 팀원으로 적합한 이유가 무엇인가요? (최대 300자)</h5>
				<asp:TextBox ID="Answer2" runat="server" TextMode="MultiLine" Width="100%" Rows="20" />
				<br />
				<br />
				<p>공지사항을 읽지 않으셨다면 불이익을 받지 않기 위해서 꼭 필독하시기 바랍니다! <br /> 튕김 현상이 일어날 수 있습니다. 복사해놓은 후 제출해주세요!</p>
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
