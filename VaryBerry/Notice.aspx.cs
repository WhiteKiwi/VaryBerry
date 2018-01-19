using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VaryBerry {
	public partial class Notice : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			var noticeID = Request.QueryString["id"];

			if (!String.IsNullOrEmpty(noticeID)) {
				Models.Notice notice = new Models.NoticeManager().GetNoticeByID(int.Parse(noticeID));

				Title.Text = notice.Title;
				Contents.Text = notice.Content;
				NoticeAt.Text = notice.NoticeAt.ToString("yyyy-MM-dd");
			} else {
				Title.Text = "404 Not Found.";
				Contents.Text = "404 Not Found.";
				NoticeAt.Text = "404 Not Found.";
			}
		}
	}
}