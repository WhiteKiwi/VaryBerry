<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar.Master" AutoEventWireup="true" CodeBehind="AddQuestion.aspx.cs" Inherits="VaryBerry.AddQuestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<!-- Question -->
	<div style="width: 100%; padding-top: 50px; margin-bottom: 150px; padding-left: 100px; padding-right: 100px; text-align: left;">
		<div>
			<h3><strong>질문 등록</strong></h3>
			<hr class="hr-sky" />

			<div style="margin-left: 50px; margin-right: 30px;">
				<!-- 안내 -->
				<div class="jumbotron jumbotron-fluid border text-center" style="padding: 30px 30px 10px 30px; border-color: #95989A !important;">
					<h4>Q&A 작성 안내</h4>
					<br />
					<div class="text-left">
						<p><strong>1. 제목에 질문하고자 하는 내용이 표현되어야 합니다.</strong><br />
							- 예를 들어 캐주얼 데이에 정복 조끼가 착용 가능한지 여부에 대해 질문해 주실 때 제목에는 "캐주얼 데이 조끼 착용 가능 여부" 처럼 작성해 주시기 바랍니다.</p>
						<p><strong>2. 질문의 의도가 교칙위반 이거나 BlueBerry의 목적에 맞지 않는 질문은 특별한 안내 없이 삭제 될 수 있습니다.</strong></p>
						<p><strong>3. 문제집과 같은 개인차가 있는 질문은 명확한 답변이 어렵습니다.</strong><br />
							- 따라서 추천보다는 선배들이 많이 사용한 문제집과 같은 객관적인 사실을 답변해드립니다.<br />
							- 어디까지나 참고사항으로 여겨주시면 좋겠습니다.</p>
						<p><strong>4. 질문하기 전 질문하고자 하는 내용이 Berries에 작성되어 있는지 확인해주시기 바랍니다.</strong><br />
							- 작성되어 있는 팁의 경우 답변의 우선순위가 낮아질 수 있습니다.</p><br />
						<p><strong>5. 20글자 이상 작성해주세요~</strong></p>
					</div>
				</div>
				<br />

				<!-- 등록 -->
				<form runat="server" style="height: 100%;">
					<div class="row">
						<div class="col-1" style="text-align: left;">
							<h4>제목</h4>
							<br />
							<br />
							<h4>내용</h4>
						</div>
						<div class="col-11">
							<asp:TextBox ID="nTitle" runat="server" Width="100%" />

							<br />
							<br />
							<br />

							<!-- Contents -->
							<asp:TextBox ID="Contents" runat="server" TextMode="MultiLine" Width="100%" Height="100%" />

							<br />
							<br />
							<asp:Button ID="QuestionButton" runat="server" CssClass="btn btn-primary float-right" OnClick="QuestionUpload" Text="등록" />
						</div>
					</div>
				</form>
			</div>
		</div>
	</div>
	<footer style="width: 100%; margin-top: 1.5em; margin-bottom: 1.5em; text-align: center;">
		<a href="/DevInfo.aspx" style="color: #C9C9C9;">
			<h6>2017 Copyright © Team VaryBerry All Right Reserved.</h6>
		</a>
	</footer>
</asp:Content>
