using System;

namespace VaryBerry {
	public partial class AddQuestion : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

		}
		
		protected void QuestionUpload(object sender, EventArgs e) {
			QuestionButton.Enabled = false;

			// 질문 등록
			Models.QaAManager.AddQuestion(new Models.Question {
				Title = nTitle.Text,
				Contents = Contents.Text
			});

			Response.Redirect("/QaA.aspx");
		}
	}
}