using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VaryBerry {
	public partial class AddQuestion : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

		}
		
		protected void QuestionUpload(object sender, EventArgs e) {
			// 질문 등록
			Models.QaAManager.AddQuestion(new Models.Question {
				Title = nTitle.Text,
				Contents = Contents.Text
			});

			Response.Redirect("/QaA.aspx");
		}
	}
}