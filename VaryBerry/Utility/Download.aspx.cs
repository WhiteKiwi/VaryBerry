using System;
using VaryBerry.Models;

namespace VaryBerry.Utility {
	public partial class Download : System.Web.UI.Page {
		private string fileName = "";
		private string dir = "";

		private NoteRepository _repository;

		public Download() {
			_repository = new NoteRepository();
			dir = Server.MapPath("./Files/");
		}

		protected void Page_Load(object sender, EventArgs e) {
			// Get FileName
			fileName = _repository.GetFileNameById(int.Parse(Request[ "Id" ]));

			// fileName에 해당하는 File이 없을 경우
			if (fileName == "") {
				Response.Clear();
				Response.End();
			} else {
				Response.Clear();
				Response.ContentType = "application/octet-stream";
				Response.AddHeader("Content-Disposition", "attachment;filename=" + Server.UrlPathEncode((fileName.Length > 50) ? fileName.Substring(fileName.Length - 50, 50) : fileName));
				Response.WriteFile(dir + fileName);
				Response.End();
			}
		}
	}
}