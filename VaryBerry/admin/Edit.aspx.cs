using System;
using VaryBerry.Models;

namespace VaryBerry.admin {
	public partial class Edit : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
		}

		protected void GetBerry(object sender, EventArgs e) {
			var berry = BerryManager.GetBerryByID(int.Parse(BerryNum.Text));

			Contents.Text = berry.Contents;
		}

		protected void EditBerry(object sender, EventArgs e) {
			BerryManager.EditBerry(int.Parse(BerryNum.Text), Contents.Text);

			Response.Redirect("/admin/Edit.aspx");
		}
	}
}