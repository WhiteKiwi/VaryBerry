using System;

namespace VaryBerry {
	public partial class QaA : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void LeftButton_Click(object sender, EventArgs e) {
			int page;
			try {
				page = int.Parse(Request.QueryString["page"]);
			} catch (Exception ex) {
				page = 1;
			}

			if (page > 1)
				Response.Redirect("/QaA.aspx?page=" + (page - 1));
		}

		protected void RightButton_Click(object sender, EventArgs e) {
			int page;
			try {
				page = int.Parse(Request.QueryString["page"]);
			} catch (Exception ex) {
				page = 1;
			}

			if (page < Models.QaAManager.GetPagesCount())
				Response.Redirect("/QaA.aspx?page=" + (page + 1));
		}
	}
}