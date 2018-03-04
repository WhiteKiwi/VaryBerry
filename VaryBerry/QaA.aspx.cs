using System;
using VaryBerry.Models;

namespace VaryBerry {
	public partial class QaA : System.Web.UI.Page {
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

			if (page < QaAManager.GetPagesCount())
				Response.Redirect("/QaA.aspx?page=" + (page + 1));
		}
	}
}