<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar.Master" AutoEventWireup="true" CodeBehind="Notices.aspx.cs" Inherits="VaryBerry.Notices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<!-- Top-Image -->
	<div class="background-image-long" style="width: 100%; height: 40%;"></div>

	<!-- Notices -->
	<div style="width: 100%; padding-top: 50px; padding-left: 100px; padding-right: 100px; text-align: left;">
		<h3><strong>공지사항</strong></h3>
		<!-- Table Head -->
		<hr class="hr-sky" />
		<div style="text-align: center; margin-top: -12px; margin-bottom: -12px;">
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
				var noticeList = VaryBerry.Models.NoticeManager.GetNoticeByPage(page);

				foreach (var notice in noticeList) {
					// Write on Page
					Response.Write("<div style=\"text-align: center;\">");
					Response.Write("<span style=\"float: left; margin-left: 20px;\">" + notice.Id + "</span>");
					Response.Write("<span class=\"contents-list\"><a class=\"alert-link\" href=\"/Notice.aspx?id=" + notice.Id + "\">" + notice.Title + "</a></span>");
					Response.Write("<span style=\"float: right; margin-right: 20px;\">" + notice.NoticeAt.ToString("yyyy-MM-dd") + "</span>");
					Response.Write("</div><hr class=\"hr-gray\" />");
				}
			} catch (Exception e) {
				Response.Write(e.Message);
			}
		%>

		<!-- Page Link -->
		<div class="text-center">
			<form runat="server">
				<span>
					<strong><b>
						<asp:LinkButton runat="server" OnClick="LeftButton_Click" Text="<" ForeColor="#509BF8" />
					</b></strong>
				</span>
				<%
					int pageCount = VaryBerry.Models.NoticeManager.GetPagesCount();
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
							if (page % 10 != 0) {
								for (int i = 1; i <= pageCount % 10; i++) {
									string pageStyle = "";
									string textStyle = "";
									if (i + ((page / 10) * 10) == page) {
										pageStyle = " class=\"this-page\"";
										textStyle = " style=\"color: white;\"";
									}

									Response.Write("<span" + pageStyle + " style=\"padding: 3px 9px; margin: 3px;\">");
									Response.Write("<a" + textStyle + " href=\"/Notices.aspx?page=" + (i + ((page / 10) * 10)) + "\">" + (i + ((page / 10) * 10)) + "</a>");
									Response.Write("</span>");
								}
							} else {
								// 마지막 페이지의 일의 자릿 수가 0일 경우
								for (int i = 1; i <= 10; i++) {
									string pageStyle = "";
									string textStyle = "";
									if (i + page - 10 == page) {
										pageStyle = " class=\"this-page\"";
										textStyle = " style=\"color: white;\"";
									}

									Response.Write("<span" + pageStyle + " style=\"padding: 3px 9px; margin: 3px;\">");
									Response.Write("<a" + textStyle + " href=\"/Notices.aspx?page=" + (i + page - 10) + "\">" + (i + page - 10) + "</a>");
									Response.Write("</span>");
								}
							}
						} else {
							for (int i = 1; i <= 10; i++) {
								string pageStyle = "";
								string textStyle = "";
								if (i + ((page / 10) * 10) == page) {
									pageStyle = " class=\"this-page\"";
									textStyle = " style=\"color: white;\"";
								}

								Response.Write("<span" + pageStyle + " style=\"padding: 3px 9px; margin: 3px;\">");
								Response.Write("<a" + textStyle + " href=\"/Notices.aspx?page=" + (i + ((page / 10) * 10)) + "\">" + (i + ((page / 10) * 10)) + "</a>");
								Response.Write("</span>");
							}
						}
					} else {
						// 첫 목록
						for (int i = 1; i <= 10; i++) {
							string pageStyle = "";
							string textStyle = "";
							if (i == 1) {
								pageStyle = " class=\"this-page\"";
								textStyle = " style=\"color: white;\"";
							}

							Response.Write("<span" + pageStyle + " style=\"padding: 3px 9px; margin: 3px;\">");
							Response.Write("<a" + textStyle + " href=\"/Notices.aspx?page=" + i + "\">" + i + "</a>");
							Response.Write("</span>");
						}
					}
				%>
				<span>
					<strong><b>
						<asp:LinkButton runat="server" OnClick="RightButton_Click" Text=">" ForeColor="#509BF8" />
					</b></strong>
				</span>
			</form>
		</div>
	</div>

	<footer style="width: 100%; margin-top: 1.5em; margin-bottom: 1.5em; text-align: center;">
		<a href="/DevInfo.aspx" style="color: #C9C9C9;">
			<h6>2017 Copyright © Team VaryBerry All Right Reserved.</h6>
		</a>
	</footer>
</asp:Content>
