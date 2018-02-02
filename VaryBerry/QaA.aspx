<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar.Master" AutoEventWireup="true" CodeBehind="QaA.aspx.cs" Inherits="VaryBerry.QaA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<!-- Q&A -->
	<div style="width: 100%; padding-top: 50px; padding-left: 100px; padding-right: 100px; text-align: left;">
		<h3><strong>Q&A</strong></h3>
		<!-- Table Head -->
		<hr class="hr-sky" />
		<div style="text-align: center; margin-top: -12px; margin-bottom: -12px;"">
			<span style="float: left; margin-left: 17px;">번호</span>
			<span>제목</span>
			<span style="float: right; margin-right: 37px;">공지일</span>
		</div>
		<hr class="hr-sky" />
		<!-- Table Data -->
		<%
			try {
				int page;
				try {
					page = int.Parse(Request.QueryString["page"]);
				} catch (Exception e) {
					page = 1;
				}
				var questionList = VaryBerry.Models.QaAManager.GetQuestionsByPage(page);

				foreach (var question in questionList) {
					// Write on Page
					Response.Write("<div style=\"text-align: center;\">");
					Response.Write("<span style=\"float: left; margin-left: 20px;\">" + question.Id + "</span>");
					Response.Write("<span><a class=\"alert-link\" href=\"/Question.aspx?id=" + question.Id + "\">" + question.Title + "</a></span>");
					Response.Write("<span style=\"float: right; margin-right: 20px;\">" + question.QuestionAt.ToString("yyyy-MM-dd") + "</span>");
					Response.Write("</div><hr class=\"hr-gray\" />");
				}
			} catch (Exception e) {
				Response.Write(e.Message);
			}
		%>
		<div style="width: 100%; text-align: right;">
			<a href="/AddQuestion.aspx" class="btn btn-primary" role="button">질문 등록</a>
		</div>

		<!-- Page Link -->
		<div class="text-center">
			<form runat="server">
				<span>
					<asp:LinkButton runat="server" OnClick="LeftButton_Click" Text="<" ForeColor="#509BF8" />
				</span>
				<%
					int pageCount = VaryBerry.Models.QaAManager.GetPagesCount();
					int page;
					try {
						page = int.Parse(Request.QueryString["page"]);
					} catch (Exception e) {
						page = 1;
					}

					// 정상적인 페이지 요청일 경우
					if (page <= pageCount) {
						// 요청한 페이지가 마지막 장일경우
						if (pageCount / 10 == page / 10) {
							for (int i = 1; i <= pageCount % 10 && i <= 10; i++) {
								string pageStyle = "";
								string textStyle = "";
								if (i + page / 10 == page) {
									pageStyle = " class=\"this-page\"";
									textStyle = " style=\"color: white;\"";
								}

								Response.Write("<span" + pageStyle + ">");
								Response.Write("<a" + textStyle + " href=\"/QaA.aspx?page=" + (i + page / 10) + "\">" + (i + page / 10) + "</a>");
								Response.Write("</span>");
							}
						} else {
							for (int i = 1; i <= 10; i++) {
								string pageStyle = "";
								string textStyle = "";
								if (i + page / 10 == page) {
									pageStyle = " class=\"this-page\"";
									textStyle = " style=\"color: white;\"";
								}

								Response.Write("<span" + pageStyle + ">");
								Response.Write("<a" + textStyle + " href=\"/QaA.aspx?page=" + (i + page / 10) + "\">" + (i + page / 10) + "</a>");
								Response.Write("</span>");
							}
						}
					} else {
						// 첫 목록
						for (int i = 1; i <= pageCount % 10 && i <= 10; i++) {
								string pageStyle = "";
								string textStyle = "";
								if (i + page / 10 == page) {
									pageStyle = " class=\"this-page\"";
									textStyle = " style=\"color: white;\"";
								}

								Response.Write("<span" + pageStyle + ">");
							Response.Write("<a" + textStyle + " href=\"/QaA.aspx?page=" + i + "\">" + i + "</a>");
							Response.Write("</span>");
						}
					}
				%>
				<span>
					<asp:LinkButton runat="server" OnClick="RightButton_Click" Text=">" ForeColor="#509BF8" />
				</span>
			</form>
		</div>
		<footer style="width: 100%; margin-top: 1.5em; margin-bottom: 1.5em; text-align: center;">
			<a href="/DevInfo.aspx" style="color: #C9C9C9;">
				<h6>2017 Copyright © Team VaryBerry All Right Reserved.</h6>
			</a>
		</footer>
	</div>
</asp:Content>
