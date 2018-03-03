using MySql.Data.MySqlClient;
using System;
using System.Web.UI;

namespace VaryBerry {
	public partial class Apply : Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

		// 지원 추가
		protected void ApplyUpload(object sender, EventArgs e) {
			if (studentNumber.Text.Trim() == "" || role.Text.Trim() == "" || Contents1.Text.Trim() == "" || Contents2.Text.Trim() == "") {
				UploadButton.Text = "모든 항목을 입력해 주세요";

				return;
			}

			// Connect to DB;
			MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
			conn.Open();

			// 등록 여부 확인
			// Connect to Database
			string sql = "SELECT Id, StudentNumber FROM applys;";
			MySqlCommand cmd = new MySqlCommand(sql, conn);

			int Id = -1;
			var rdr = cmd.ExecuteReader();
			while (rdr.Read()) {
				// 이미 등록된 지원자일 경우
				if (((string)rdr["StudentNumber"]).Split(" :".ToCharArray())[0] == studentNumber.Text) {
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
				sql = "INSERT INTO applys(StudentNumber, Contents1, Contents2) VALUES (?, ?, ?);";
				cmd.CommandText = sql;

				// Add Apply Info
				cmd.Parameters.Add("StudentNumber", MySqlDbType.VarChar).Value = studentNumber.Text.Trim() + " : " + role.Text.Trim();
				cmd.Parameters.Add("Contents1", MySqlDbType.VarChar).Value = Contents1.Text.Trim();
				cmd.Parameters.Add("Contents2", MySqlDbType.VarChar).Value = Contents2.Text.Trim();

				cmd.ExecuteNonQuery();
			} else {
				// 존재할 경우 업데이트
				sql = "UPDATE applys SET StudentNumber='" + studentNumber.Text + " : " + role.Text + "', Contents1='" + Contents1.Text.Trim() + "', Contents2='" + Contents2.Text.Trim() + "' WHERE Id='" + Id +"';";
				cmd.CommandText = sql;
				cmd.ExecuteNonQuery();

			}

			Response.Redirect("/Apply.aspx");
		}

		// 지원 여부 확인
		protected void ApplyCheck_Click(object sender, EventArgs e) {
			// Connect to DB;
			MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
			conn.Open();

			// 등록 여부 확인
			// Connect to Database
			string sql = "SELECT StudentNumber FROM applys;";
			MySqlCommand cmd = new MySqlCommand(sql, conn);

			var rdr = cmd.ExecuteReader();
			while (rdr.Read()) {
				// 이미 등록된 지원자일 경우
				if(((string)rdr["StudentNumber"]).Split(" :".ToCharArray())[0] == studentNumber.Text) {
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