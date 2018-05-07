using MySql.Data.MySqlClient;
using System;
using System.Text;
using System.Web.UI;

namespace VaryBerry {
	public partial class Apply : Page {
		protected void Page_Load(object sender, EventArgs e) {
		}

		// 지원 
		protected void ApplyUpload(object sender, EventArgs e) {
			if (Encoding.UTF8.GetByteCount(Answer0.Text.Trim().ToCharArray()) > 2500) {
				UploadButton.Text = "1번이 너무 깁니다";

				return;
			} else if (Encoding.UTF8.GetByteCount(Answer1.Text.Trim().ToCharArray()) > 700) {
				UploadButton.Text = "2번이 너무 깁니다";

				return;
			} else if (Encoding.UTF8.GetByteCount(Answer2.Text.Trim().ToCharArray()) > 700) {
				UploadButton.Text = "3번이 너무 깁니다";

				return;
			}

			if (studentNumber.Text.Trim() == "" && Answer0.Text.Trim() == "" && Answer1.Text.Trim() == "" && Answer2.Text.Trim() == "") {
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
				if (((string)rdr["StudentNumber"]) == studentNumber.Text.Trim()) {
					Id = (int)rdr["Id"];

					break;
				}
			}
			rdr.Close();

			// 등록/업데이트
			if (Id == -1) {
				// 존재하지 않을 경우 추가
				sql = "INSERT INTO applys(StudentNumber, Answer0, Answer1, Answer2) VALUES (?, ?, ?, ?);";
				cmd.CommandText = sql;

				// Add Apply Info
				cmd.Parameters.Add("StudentNumber", MySqlDbType.VarChar).Value = studentNumber.Text.Trim();
				cmd.Parameters.Add("Answer0", MySqlDbType.VarChar).Value = Answer0.Text.Trim();
				cmd.Parameters.Add("Answer1", MySqlDbType.VarChar).Value = Answer1.Text.Trim();
				cmd.Parameters.Add("Answer2", MySqlDbType.VarChar).Value = Answer2.Text.Trim();

				cmd.ExecuteNonQuery();
			} else {
				// 존재할 경우 업데이트
				sql = "UPDATE applys SET StudentNumber='" + studentNumber.Text + "', Answer0='" + Answer0.Text.Trim() + "', Answer1='" + Answer1.Text.Trim() + "', Answer2='" + Answer2.Text.Trim() + "' WHERE Id='" + Id + "';";
				cmd.CommandText = sql;
				cmd.ExecuteNonQuery();
			}

			studentNumber.Text = "";
			Answer0.Text = "";
			Answer1.Text = "";
			Answer2.Text = "";
			UploadButton.Text = "지원되었습니다";
		}

		// 지원 여부 확인
		protected void ApplyCheck(object sender, EventArgs e) {
			// Connect to DB;
			MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
			conn.Open();

			// 등록 여부 확인
			// Connect to Database
			string sql = "SELECT StudentNumber, Answer0, Answer1, Answer2 FROM applys;";
			MySqlCommand cmd = new MySqlCommand(sql, conn);

			bool isApply = false;
			var rdr = cmd.ExecuteReader();
			while (rdr.Read()) {
				// 이미 등록된 지원자일 경우
				if (((string)rdr["StudentNumber"]) == studentNumber.Text.Trim()) {
					isApply = true;

					Answer0.Text = (string)rdr["Answer0"];
					Answer1.Text = (string)rdr["Answer1"];
					Answer2.Text = (string)rdr["Answer2"];

					break;
				}
			}
			rdr.Close();

			if(!isApply) {
				// 신규 지원 일 경우
				CheckButton.Text = "지원하지 않으셨습니다.";
			}
		}
	}
}