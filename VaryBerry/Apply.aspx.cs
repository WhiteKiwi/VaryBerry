using MySql.Data.MySqlClient;
using System;
using System.Web.UI;

namespace VaryBerry {
	public partial class Apply : Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

		// 지원 추가
		protected void ApplyUpload(object sender, EventArgs e) {
			// Connect to DB;
			MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
			conn.Open();

			// Connect to Database
			string sql = "INSERT INTO applys(StudentNumber, Contents1, Contents2) VALUES (?, ?, ?);";
			MySqlCommand cmd = new MySqlCommand(sql, conn);

			// Add Apply Info
			cmd.Parameters.Add("StudentNumber", MySqlDbType.Int32).Value = studentNumber.Text;
			cmd.Parameters.Add("Contents1", MySqlDbType.VarChar).Value = Contents1.Text.Trim();
			cmd.Parameters.Add("Contents2", MySqlDbType.VarChar).Value = Contents2.Text.Trim();

			cmd.ExecuteNonQuery();

			Response.Redirect("/Apply.aspx");
		}
	}
}