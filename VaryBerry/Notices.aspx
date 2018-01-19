<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar.Master" AutoEventWireup="true" CodeBehind="Notices.aspx.cs" Inherits="VaryBerry.Notices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<!-- Top-Image -->
	<div class="background-image-long" style="width: 100%; height: 40%;"></div>

	<!-- Notices -->
	<div style="width: 100%; padding-top: 50px; padding-left: 100px; padding-right: 100px; text-align: left;">
		<h3><strong>공지사항</strong></h3>
		<!-- <tr> -->
		<hr class="hr-sky" />
		<div style="text-align: center;">
			<span style="float: left; margin-left: 17px;">번호</span>
			<span>제목</span>
			<span style="float: right; margin-right: 37px;">공지일</span>
		</div>
		<hr class="hr-sky" />
		<!-- <td> -->
		<%
			try {
				// Connect Database
				string connectionString = ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString;
				using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString)) {
					conn.Open();

					int page;
					try {
						page = int.Parse(Request.QueryString["page"]);
					} catch(Exception e) {
						page = 1;
					}
					var noticeList = VaryBerry.Models.NoticeManager.GetNoticeByPage(page);

					foreach (var notice in noticeList) {
						// Write on Page
						Response.Write("<div style=\"text-align: center;\">");
						Response.Write("<span style=\"float: left; margin-left: 20px;\">" + notice.Id + "</span>");
						Response.Write("<span><a class=\"alert-link\" href=\"/Notice.aspx?id=" + notice.Id + "\">" + notice.Title + "</a></span>");
						Response.Write("<span style=\"float: right; margin-right: 20px;\">" + notice.NoticeAt.ToString("yyyy-MM-dd") + "</span>");
						Response.Write("</div><hr class=\"hr-gray\" />");
					}
				}
			} catch (Exception e) {
				Response.Write(e.Message);
			}
		%>
		<!-- Page Link -->
		<div class="text-center">
			<form runat="server">
				<span>
					<asp:ImageButton runat="server" ImageUrl="/assets/images/left-pointer.png" OnClick="LeftButton_Click" />
				</span>
				<%
					int pageCount = VaryBerry.Models.NoticeManager.GetPagesCount();
					int page;
					try {
						page = int.Parse(Request.QueryString["page"]);
					} catch(Exception e) {
						page = 1;
					}

					// 정상적인 페이지 요청일 경우
					if (page <= pageCount) {
						// 요청한 페이지가 마지막 장일경우
						if (pageCount / 10 == page / 10) {
							for (int i = 1; i <= pageCount % 10 && i <= 10; i++) {
								Response.Write("<span>");
								Response.Write("<a href=\"/Notices.aspx?page=" + (i + page / 10) + "\">" + (i + page / 10) + "</a>");
								Response.Write("</span>");
							}
						} else {
							for (int i = 1; i <= 10; i++) {
								Response.Write("<span>");
								Response.Write("<a href=\"/Notices.aspx?page=" + (i + page / 10) + "\">" + (i + page / 10) + "</a>");
								Response.Write("</span>");
							}
						}
					} else {
						// 첫 목록
						for (int i = 1; i <= pageCount % 10 && i <= 10; i++) {
							Response.Write("<span>");
							Response.Write("<a href=\"/Notices.aspx?page=" + i + "\">" + i + "</a>");
							Response.Write("</span>");
						}
					}
				%>
				<span>
					<asp:ImageButton runat="server" ImageUrl="/assets/images/right-pointer.png" OnClick="RightButton_Click" />
				</span>
			</form>
		</div>
		<footer style="width: 100%; margin-top: 1.5em; margin-bottom: 1.5em; color: #C9C9C9; text-align: center;">
			<h5>2017 Copyright © Team VaryBerry All Right Reserved.</h5>
		</footer>
	</div>
</asp:Content>
