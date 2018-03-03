using MySql.Data.MySqlClient;
using System;
using System.Web.UI;

namespace VaryBerry {
	public partial class SlaveApply1 : Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

		// 지원 추가
		protected void ApplyUpload(object sender, EventArgs e) {
			if (studentNumber.Text.Trim() == "" || name.Text.Trim() == "" || Index1.Text.Trim() == "" || Index2.Text.Trim() == "" || Index3.Text.Trim() == "" || Index4.Text.Trim() == "") {
				UploadButton.Text = "모든 항목을 입력해 주세요";

				return;
			}

			// Connect to DB;
			MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
			conn.Open();

			// 등록 여부 확인
			// Connect to Database
			string sql = "SELECT Id, StudentNumber FROM slave_applys;";
			MySqlCommand cmd = new MySqlCommand(sql, conn);

			int Id = -1;
			var rdr = cmd.ExecuteReader();
			while (rdr.Read()) {
				// 이미 등록된 지원자일 경우
				if (((string)rdr["StudentNumber"]) == studentNumber.Text) {
					ApplyCheck.Text = "이미 지원되셨습니다";
					ApplyCheck.Enabled = false;
					Id = (int)rdr["Id"];

					break;
				}
			}
			rdr.Close();

			// 등록/업데이트
			if (Id == -1) {
				// 존재하지 않을 경우 추가
				sql = "INSERT INTO slave_applys(StudentNumber, Name, Index1, Index2, Index3, Index4) VALUES (?, ?, ?, ?, ?, ?);";
				cmd.CommandText = sql;

				// Add Apply Info
				cmd.Parameters.Add("StudentNumber", MySqlDbType.Int32).Value = studentNumber.Text.Trim();
				cmd.Parameters.Add("Name", MySqlDbType.VarChar).Value = name.Text.Trim();
				cmd.Parameters.Add("Index1", MySqlDbType.VarChar).Value = Index1.Text.Trim();
				cmd.Parameters.Add("Index2", MySqlDbType.VarChar).Value = Index2.Text.Trim();
				cmd.Parameters.Add("Index3", MySqlDbType.VarChar).Value = Index3.Text.Trim();
				cmd.Parameters.Add("Index4", MySqlDbType.VarChar).Value = Index4.Text.Trim();

				cmd.ExecuteNonQuery();
			} else {
				// 존재할 경우 업데이트
				sql = "UPDATE slave_applys SET StudentNumber='" + studentNumber.Text + "', Index1='" + Index1.Text.Trim() + "', Index2='" + Index2.Text.Trim() + "', Index3='" + Index3.Text.Trim() + "', Index4='" + Index4.Text.Trim() + "' WHERE Id='" + Id + "';";
				cmd.CommandText = sql;
				cmd.ExecuteNonQuery();

			}

			Response.Redirect("/SlaveApply.aspx");
		}

		// 지원 여부 확인
		protected void ApplyCheck_Click(object sender, EventArgs e) {
			// Connect to DB;
			MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
			conn.Open();

			// 등록 여부 확인
			// Connect to Database
			string sql = "SELECT StudentNumber FROM slave_applys;";
			MySqlCommand cmd = new MySqlCommand(sql, conn);

			var rdr = cmd.ExecuteReader();
			while (rdr.Read()) {
				// 이미 등록된 지원자일 경우
				if (((int)rdr["StudentNumber"]).ToString() == studentNumber.Text.Trim()) {
					ApplyCheck.Text = "이미 지원되셨습니다";
					ApplyCheck.Enabled = false;

					return;
				}
			}

			// 등록되지 않았을 경우
			ApplyCheck.Text = "지원되지 않으셨습니다";
		}
	}
}