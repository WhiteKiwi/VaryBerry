using System;
using System.Text;

namespace VaryBerry {
	public partial class AddNotice : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			BytesCount.Text = "0 / 10000 Byte";
			BytesCount.ForeColor = System.Drawing.Color.FromName("#B2B2B2");
		}

		protected void NoticeUpload(object sender, EventArgs e) {
			// 공지 추가
			Models.NoticeManager.AddNotice(new Models.Notice {
				Title = nTitle.Text,
				Contents = Contents.Text
			});

			Response.Redirect("/Notices.aspx");
		}

		protected void CountBytes(object sender, EventArgs e) {
			BytesCount.Text = Encoding.UTF8.GetByteCount(Contents.Text) + " / 10000 Byte";
			// TODO: Over 10,000 Bytes
		}
	}
}