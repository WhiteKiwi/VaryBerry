using System;
using VaryBerry.Models;

namespace VaryBerry {
	public partial class Question : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			if (Request.Cookies["UserID"] == null) {
				// Cookie가 없을 경우 발급
				var rand = new Random(DateTime.Now.Millisecond);
				Response.Cookies["UserID"].Value = rand.Next().ToString() + "/" + rand.Next().ToString();
				Response.Cookies["UserID"].Expires = DateTime.Now.AddYears(5);
			} else {
				// 밴 리스트 검사 후 차단
				if (BanManager.IsBan(Request.Cookies["UserID"].Value)) {
					Response.Redirect("/");

					return;
				}
			}

			// GET Question ID
			var questionID = Request.QueryString["id"];
			ID.Value = Request.QueryString["id"];

			// questionId가 존재할 경우
			if (!String.IsNullOrEmpty(questionID)) {
				var question = QaAManager.GetQuestionByID(int.Parse(questionID));

				nTitle.Text = question.Title;
				Contents.Text = question.Contents;
				QuestionAt.Text = question.QuestionAt.ToString("yyyy-MM-dd");
			} else {
				nTitle.Text = "404 Not Found.";
				Contents.Text = "404 Not Found.";
				QuestionAt.Text = "404 Not Found.";
			}
		}

		protected void AddAnswer(object sender, EventArgs e) {
			if (Answer.Text.Split("\n".ToCharArray())[0].Contains("안녕하세요 VaryBerry")) {
				// 답변 추가
				Models.QaAManager.AddAnswer(new Models.Answer {
					QuestionId = int.Parse(ID.Value),
					Contents = Answer.Text.Replace("\r\n", "<br/>")
				});

				Response.Redirect("/Question.aspx?id=" + ID.Value);
			} else {
				AnswerButton.Text = "관리자만 답변을 달 수 있습니다.";
			}
		}
	}
}