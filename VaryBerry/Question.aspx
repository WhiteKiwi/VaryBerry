<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar.Master" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="VaryBerry.Question" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<!-- Notice -->
	<form runat="server">
		<div style="width: 100%; padding-top: 50px; padding-left: 100px; padding-right: 100px; text-align: left;">
			<h3><strong>Q&A</strong></h3>
			<hr class="hr-sky" />
			<span class="float-left" style="margin-left: 17px; margin-right: 30px;">제목</span>
			<span class="float-left" style="text-align: center;">
				<asp:Label ID="nTitle" runat="server" /></span>
			<span class="float-right" style="margin-left: 30px; margin-right: 37px;">
				<asp:Label ID="QuestionAt" runat="server" /></span>
			<span class="float-right" style="text-align: center;">공지일</span>
			<br />
			<hr class="hr-gray" />
			<div style="margin-left: 20px; margin-right: 20px;">
				<asp:Label ID="Contents" runat="server" />
			</div>
			<hr />
		</div>

		<br />
		<div style="width: 100%; text-align: right;">
			<a href="/QaA.aspx" class="btn btn-primary" style="margin-right: 120px;" role="button">목록</a>
		</div>
		<br />

		<div style="height: 100px; padding-left: 100px; padding-right: 100px;">
			<asp:TextBox ID="Answer" runat="server" TextMode="MultiLine" Height="100%" Width="90%" CssClass="float-left" />
			<asp:Button runat="server" CssClass="btn btn-primary" OnClick="AddAnswer" Width="9%" Height="100%" Text="등록" />
		</div>
		<asp:HiddenField ID="ID" runat="server" Value="1" />
	</form>

	<%
		try {
			int id;
			try {
				id = int.Parse(Request.QueryString["id"]);
			} catch (Exception e) {
				id = 1;
			}

			var answerList = VaryBerry.Models.QaAManager.GetAnswersByID(id);

			foreach (var answer in answerList) {
				// Write on Page
				Response.Write("<br /><div class=\"border\" style=\"padding: 20px;margin-left: 100px; margin-right: 100px;\">");
				Response.Write(answer.Contents);
				Response.Write("</div>");
			}
		} catch (Exception e) {
			Response.Write(e.Message);
		}
	%>

	<br />
	<footer style="width: 100%; margin-top: 1.5em; margin-bottom: 1.5em; color: #C9C9C9; text-align: center;">
		<a href="/DevInfo.aspx" style="color: #C9C9C9;">
			<h6>2017 Copyright © Team VaryBerry All Right Reserved.</h6>
		</a>
	</footer>
</asp:Content>
