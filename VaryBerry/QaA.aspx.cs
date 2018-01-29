using System;

namespace VaryBerry {
	public partial class QaA : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void LeftButton_Click(object sender, EventArgs e) {
			// TODO: page < 1
			if (Request.QueryString["page"] != "1" && Request.QueryString["page"] != null)
				Response.Redirect("/QaA.aspx?page=" + (int.Parse(Request.QueryString["page"]) - 1));
		}

		protected void RightButton_Click(object sender, EventArgs e) {
			// TODO: max < page
			if (Request.QueryString["page"] != Models.NoticeManager.GetPagesCount().ToString())
				Response.Redirect("/QaA.aspx?page=" + (int.Parse(Request.QueryString["page"]) + 1));
		}
	}
}