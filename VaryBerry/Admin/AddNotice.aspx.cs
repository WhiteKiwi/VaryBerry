using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VaryBerry.Admin {
	public partial class AddNotice : System.Web.UI.Page {
		private string dir;
		private string fileName;
		private int fileSize;

		protected void Page_Load(object sender, EventArgs e) {

		}
		protected void SaveButton_Click(object sender, EventArgs e) {

		}

		private void UploadProcess() {
			dir = Server.MapPath("./Files/");
			fileName = "";
			fileSize = 0;
			if (txtFileName.PostedFile != null) {
				if (txtFileName.PostedFile.FileName.Trim().Length > 0 && txtFileName.PostedFile.ContentLength > 0) {
					//fileName = Dul//TODO: Make Dul.dll
				}
			}
		}

		protected void CancelButton_Click(object sender, EventArgs e) {

		}

		protected void FileUploadButton_Click(object sender, EventArgs e) {
			FilePanel.Visible = !FilePanel.Visible;
		}
	}
}