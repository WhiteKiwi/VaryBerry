using System;
using VaryBerry.Models;

namespace VaryBerry {
	public partial class Question : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			#region 주말면학 차단
			// 주말 면학시간 차단
			DateTime now = DateTime.Now.AddHours(9);
			if (now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday) {
				// MP1
				if (now.Hour == 9)
					Response.Redirect("/Notice.aspx?id=34");
				// MP2
				else if (now.Hour == 10 && now.Minute > 30)
					Response.Redirect("/Notice.aspx?id=34");
				else if (now.Hour == 11 && now.Minute > 40)
					Response.Redirect("/Notice.aspx?id=34");
				// DP1
				else if (now.Hour == 13)
					Response.Redirect("/Notice.aspx?id=34");
				else if (now.Hour == 14 && now.Minute < 40)
					Response.Redirect("/Notice.aspx?id=34");
				// DP2
				else if (now.Hour == 15)
					Response.Redirect("/Notice.aspx?id=34");
				else if (now.Hour == 16 && now.Minute < 40)
					Response.Redirect("/Notice.aspx?id=34");
				// EP1
				else if (now.Hour == 18)
					Response.Redirect("/Notice.aspx?id=34");
				else if (now.Hour == 19 && now.Minute < 40)
					Response.Redirect("/Notice.aspx?id=34");
				// EP2
				else if (now.Hour == 20 && now.Minute > 20)
					Response.Redirect("/Notice.aspx?id=34");
				else if (now.Hour == 21)
					Response.Redirect("/Notice.aspx?id=34");
			}
			#endregion

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
			if (Answer.Text.Split("\n".ToCharArray())[0].Contains("안녕하세요 VaryBerry1234")) {
				// 답변 추가
				QaAManager.AddAnswer(new Answer {
					QuestionId = int.Parse(ID.Value),
					Contents = Answer.Text.Replace("\r\n", "<br/>").Replace("안녕하세요 VaryBerry1234", "안녕하세요 VaryBerry"),
				});

				Response.Redirect("/Question.aspx?id=" + ID.Value);
			} else {
				AnswerButton.Text = "관리자만 답변을 달 수 있습니다.";
			}
		}
	}
}