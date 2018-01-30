using System;

namespace VaryBerry {
	public partial class BerryProposals : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			if(Request.Form["DeleteProposalId"] != null) {
				Models.BerryProposalManager.DeleteBerryProposal(int.Parse(Request.Form["DeleteProposalId"]));
			}
		}
	}
}