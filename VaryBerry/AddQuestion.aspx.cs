using System;
using VaryBerry.Models;

namespace VaryBerry {
	public partial class AddQuestion : System.Web.UI.Page {
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
		}
		
		protected void QuestionUpload(object sender, EventArgs e) {
			QuestionButton.Enabled = false;

			// 질문 등록
			QaAManager.AddQuestion(new Models.Question {
				Title = nTitle.Text,
				Contents = Contents.Text,
				UserID = Request.Cookies["UserID"].Value
			});

			Response.Redirect("/QaA.aspx");
		}
	}
}