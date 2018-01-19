using System;

namespace VaryBerry {
	public partial class AddNotice : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void NoticeUpload(object sender, EventArgs e) {
			// 공지 추가
			Models.NoticeManager.AddNotice(new Models.Notice {
				Title = nTitle.Text,
				Contents = Contents.Text
			});

			Response.Redirect("/Notices.aspx");
		}
	}
}