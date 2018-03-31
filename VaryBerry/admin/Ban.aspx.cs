using MySql.Data.MySqlClient;
using System;
using System.Web.UI;

namespace VaryBerry.admin {
	public partial class Ban : Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

		// Ban and Delete
		protected void BanAndDelete(object sender, EventArgs e) {
			// Connect to DB;
			MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
			conn.Open();

			// 아이디 불러오기
			string sql = "SELECT UserID FROM questions Where Id=" + PostID.Text.Trim() + ";";
			// Connect to Database
			MySqlCommand cmd = new MySqlCommand(sql, conn);
			string UserID = (string)cmd.ExecuteScalar();

			// 삭제
			sql = "DELETE FROM questions Where Id=" + PostID.Text.Trim() + ";";
			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();

			// 밴
			if (!Models.BanManager.IsBan(UserID)) {
				sql = "INSERT INTO ban_list(UserID) VALUES (?);";
				cmd.CommandText = sql;
				cmd.Parameters.Add("UserID", MySqlDbType.VarChar).Value = UserID;
				cmd.ExecuteNonQuery();
			}

			PostID.Text = "";
		}
	}
}