using System;
using VaryBerry.Models;

namespace VaryBerry {
	public partial class QaA : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			/*
			#region 주말면학 차단
			// 주말 면학시간 차단
			DateTime now = DateTime.Now.AddHours(9);
			if (now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday) {
				// MP1
				if (now.Hour == 9)
					Response.Redirect("/Notice.aspx?id=34");
				// MP2
				else if (now.Hour == 10 && now.Minute > 30)
					Response.Redirect("/Notice.aspx?id=34");
				else if (now.Hour == 11 && now.Minute > 40)
					Response.Redirect("/Notice.aspx?id=34");
				// DP1
				else if (now.Hour == 13)
					Response.Redirect("/Notice.aspx?id=34");
				else if (now.Hour == 14 && now.Minute < 40)
					Response.Redirect("/Notice.aspx?id=34");
				// DP2
				else if (now.Hour == 15)
					Response.Redirect("/Notice.aspx?id=34");
				else if (now.Hour == 16 && now.Minute < 40)
					Response.Redirect("/Notice.aspx?id=34");
				// EP1
				else if (now.Hour == 18)
					Response.Redirect("/Notice.aspx?id=34");
				else if (now.Hour == 19 && now.Minute < 40)
					Response.Redirect("/Notice.aspx?id=34");
				// EP2
				else if (now.Hour == 20 && now.Minute > 20)
					Response.Redirect("/Notice.aspx?id=34");
				else if (now.Hour == 21)
					Response.Redirect("/Notice.aspx?id=34");
			}
			#endregion
			*/
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
			// 분류 목록 추가
			titleOrContents.Items.Add("제목");
			titleOrContents.Items.Add("내용");
		}

		protected void Searching(object sender, EventArgs e) {
			if (titleOrContents.SelectedValue == "제목")
				Response.Redirect("/QaA.aspx?titleSearch=" + SearchText.Text);
			else
				Response.Redirect("/QaA.aspx?contentsSearch=" + SearchText.Text);
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