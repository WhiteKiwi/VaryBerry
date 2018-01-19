using System;
using System.Web.UI;

namespace VaryBerryAdmin {
	public partial class AdminNotices : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void LeftButton_Click(object sender, ImageClickEventArgs e) {
			if (Request.QueryString["page"] != "1" && Request.QueryString["page"] != null)
				Response.Redirect("/Notices.aspx?page=" + (int.Parse(Request.QueryString["page"]) - 1));
		}

		protected void RightButton_Click(object sender, ImageClickEventArgs e) {
			VaryBerry.Models.NoticeManager nm = new VaryBerry.Models.NoticeManager();
			if (Request.QueryString["page"] != nm.GetPagesCount().ToString())
				Response.Redirect("/Notices.aspx?page=" + (int.Parse(Request.QueryString["page"]) + 1));
		}
	}
}