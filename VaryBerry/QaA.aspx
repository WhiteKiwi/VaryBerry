<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar.Master" AutoEventWireup="true" CodeBehind="QaA.aspx.cs" Inherits="VaryBerry.QaA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<!-- Top-Image -->
	<div class="background-image-long" style="width: 100%; height: 40%;"></div>

	<!-- Q&A -->
	<form runat="server">
		<div style="width: 100%; padding-top: 50px; padding-left: 100px; padding-right: 100px; text-align: left;">
			<span class="float-left">
				<h2><strong>Q&A</strong></h2>
			</span>
			<span class="float-right" style="margin-left: 10px;">
				<asp:Button runat="server" OnClick="Searching" CssClass="btn btn-primary" Text="검색" />
			</span>
			<span class="float-right" style="margin-left: 10px; width: 350px;">
				<asp:TextBox ID="SearchText" runat="server" CssClass="form-control"></asp:TextBox>
			</span>
			<span class="float-right">
				<asp:DropDownList ID="titleOrContents" runat="server" CssClass="form-control" Style="width: 80px;">
				</asp:DropDownList>
			</span>
			<br />
			<br />
			<!-- Table Head -->
			<hr class="hr-sky" />
			<div style="text-align: center; margin-top: -12px; margin-bottom: -12px;">
				<span style="float: left; margin-left: 17px;">번호</span>
				<span>제목</span>
				<span style="float: right; margin-right: 37px;">게시일</span>
			</div>
			<hr class="hr-sky" />
           <%-- <div style="width: 100%; text-align: center;">
                <img src="/assets/img/Comming-Soon.png" />
            </div>--%>
			<!-- Table Data -->
			<%
				try {
					int rPage;
					try {
						rPage = int.Parse(Request.QueryString["page"]);
					} catch (Exception e) {
						rPage = 1;
					}

					List<VaryBerry.Models.Question> questionList = null;

					if (Request.QueryString["titleSearch"] != null) {
						int pageCounts = VaryBerry.Models.QaAManager.GetPagesCountBySearching(Request.QueryString["titleSearch"], false);
						if (rPage > pageCounts)
							rPage = 1;

						questionList = VaryBerry.Models.QaAManager.GetQuestionsBySearching(rPage, Request.QueryString["titleSearch"], false);
					} else if (Request.QueryString["contentsSearch"] != null) {
						int pageCounts = VaryBerry.Models.QaAManager.GetPagesCountBySearching(Request.QueryString["contentsSearch"], true);
						if (rPage > pageCounts)
							rPage = 1;

						questionList = VaryBerry.Models.QaAManager.GetQuestionsBySearching(rPage, Request.QueryString["contentsSearch"], true);
					} else {
						int pageCounts = VaryBerry.Models.QaAManager.GetPagesCount();
						if (rPage > pageCounts)
							rPage = 1;

						questionList = VaryBerry.Models.QaAManager.GetQuestionsByPage(rPage);
					}

					foreach (var question in questionList) {
						// Write on Page
						Response.Write("<div style=\"text-align: center;\">");
						Response.Write("<span style=\"float: left; margin-left: 20px;\">" + question.Id + "</span>");
						Response.Write("<span class=\"contents-list\"><a class=\"alert-link\" href=\"/Question.aspx?id=" + question.Id + "\">" + question.Title + "</a></span>");
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
				<span>
					<strong><b>
						<asp:LinkButton runat="server" OnClick="LeftButton_Click" Text="<" ForeColor="#509BF8" />
					</b></strong>
				</span>
				<%
                    string queryText = "";
                    int page = 1;
                    int pageCount = 10;
                    if (Request.QueryString["titleSearch"] != null) {
                        pageCount = VaryBerry.Models.QaAManager.GetPagesCountBySearching(Request.QueryString["titleSearch"], false);
                        try {
                            page = int.Parse(Request.QueryString["page"]);
                        } catch (Exception e) {
                            page = 1;
                        }

                        queryText = "&titleSearch=" + Request.QueryString["titleSearch"];
                    } else if (Request.QueryString["contentsSearch"] != null) {
                        pageCount = VaryBerry.Models.QaAManager.GetPagesCountBySearching(Request.QueryString["contentsSearch"], true);
                        try {
                            page = int.Parse(Request.QueryString["page"]);
                        } catch (Exception e) {
                            page = 1;
                        }

                        queryText = "&contentsSearch=" + Request.QueryString["contentsSearch"];
                    } else {
                        pageCount = VaryBerry.Models.QaAManager.GetPagesCount();
                        try {
                            page = int.Parse(Request.QueryString["page"]);
                        } catch (Exception e) {
                            page = 1;
                        }
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
                                    Response.Write("<a" + textStyle + " href=\"/QaA.aspx?page=" + (i + ((page / 10) * 10)) + queryText + "\">" + (i + ((page / 10) * 10)) + "</a>");
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
                                    Response.Write("<a" + textStyle + " href=\"/QaA.aspx?page=" + (i + page - 10) + queryText + "\">" + (i + page - 10) + "</a>");
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
                                Response.Write("<a" + textStyle + " href=\"/QaA.aspx?page=" + (i + ((page / 10) * 10)) + queryText + "\">" + (i + ((page / 10) * 10)) + "</a>");
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
                            Response.Write("<a" + textStyle + " href=\"/QaA.aspx?page=" + i + queryText + "\">" + i + "</a>");
                            Response.Write("</span>");
                        }
                    }
				%>
				<span>
					<strong><b>
						<asp:LinkButton runat="server" OnClick="RightButton_Click" Text=">" ForeColor="#509BF8" />
					</b></strong>
				</span>
			</div>
		</div>
	</form>

	<footer style="width: 100%; margin-top: 1.5em; margin-bottom: 1.5em; text-align: center;">
		<a href="/DevInfo.aspx" style="color: #C9C9C9;">
			<h6>2017 Copyright © Team VaryBerry All Right Reserved.</h6>
		</a>
	</footer>
</asp:Content>
