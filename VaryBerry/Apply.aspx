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
					<asp:TextBox ID="studentNumber" runat="server" /></span>
				<br />
				<br />
				<br />

				<h5 style="float: left; margin-bottom: 15px;">
					<asp:Label runat="server" ID="Question"></asp:Label> (최대 5000 Bytes)</h5>
				<asp:TextBox ID="Answer" runat="server" TextMode="MultiLine" Width="100%" Rows="20" />
				<br />
				<p>서류 질문은 총 4개로 9일에 걸쳐 평가가 진행됩니다. <br /> 2일마다 질문이 바뀌므로 한 질문에 답변하셨더라도 다음에 이어질 새로운 질문에 또 답변하셔야 합니다. <br /> 이점 유의해주시고 공지사항을 읽지 않으셨다면 불이익을 받지 않기 위해서 꼭 필독하시기 바랍니다!</p>
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
