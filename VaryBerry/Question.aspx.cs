using System;

namespace VaryBerry {
	public partial class Question : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			var questionID = Request.QueryString["id"];
			ID.Value = Request.QueryString["id"];

			// questionId가 존재할 경우
			if (!String.IsNullOrEmpty(questionID)) {
				var question = Models.QaAManager.GetQuestionByID(int.Parse(questionID));

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
			// 답변 추가
			Models.QaAManager.AddAnswer(new Models.Answer {
				QuestionId = int.Parse(ID.Value),
				Contents = Answer.Text.Replace("\r\n", "<br/>")
			});

			Response.Redirect("/Question.aspx?id=" + ID.Value);
		}
	}
}