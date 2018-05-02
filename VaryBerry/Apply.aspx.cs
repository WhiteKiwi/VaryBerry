using MySql.Data.MySqlClient;
using System;
using System.Text;
using System.Web.UI;

namespace VaryBerry {
	public partial class Apply : Page {
		protected void Page_Load(object sender, EventArgs e) {
			string[] questions = {  "Q 3~4일차. 교내 대회들 중 하나를 조사하여 Berry를 작성해보세요.",
												"Q 5~6일차. 교내 행사(입학식, 벚꽃제 등)들 중 하나를 Berry를 작성해보세요.",
												"Q 7~8일차. C, N, S, A, 레이크뷰, 인재관 중 하나를 선택해서 Berry를 작성해보세요.",
												"Q 9일차. 본인이 VaryBerry 팀원으로 적합한 이유가 무엇인가요?" };

			DateTime now = DateTime.Now.AddHours(9);
			if (now.Day == 3 || now.Day == 4) {
				Question.Text = questions[0];
			} else if (now.Day == 5 || now.Day == 6) {
				Question.Text = questions[1];
			} else if (now.Day == 7 || now.Day == 8) {
				Question.Text = questions[2];
			} else if (now.Day == 9) {
				Question.Text = questions[3];
			}
		}

		// 지원 추가
		protected void ApplyUpload(object sender, EventArgs e) {
			if (Encoding.UTF8.GetByteCount(Answer.Text.Trim().ToCharArray()) > 5000) {
				UploadButton.Text = "너무 깁니다";

				return;
			}

			if (studentNumber.Text.Trim() == "" && Answer.Text.Trim() == "") {
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

			string index = "";
			string[] questions = {  "교내 대회들 중 하나를 조사하여 Berry를 작성해보세요.",
												"교내 행사(입학식, 벚꽃제 등)들 중 하나를 Berry를 작성해보세요.",
												"C, N, S, A, 레이크뷰, 인재관 중 하나를 선택해서 Berry를 작성해보세요.",
												"본인이 VaryBerry 팀원으로 적합한 이유가 무엇인가요?" };
			if (Question.Text == questions[0]) {
				index = "0";
			} else if (Question.Text == questions[1]) {
				index = "1";
			} else if (Question.Text == questions[2]) {
				index = "2";
			} else if (Question.Text == questions[3]) {
				index = "3";
			}

			// 등록/업데이트
			if (Id == -1) {
				// 존재하지 않을 경우 추가
				sql = "INSERT INTO applys(StudentNumber, Answer" + index + ") VALUES (?, ?);";
				cmd.CommandText = sql;

				// Add Apply Info
				cmd.Parameters.Add("StudentNumber", MySqlDbType.VarChar).Value = studentNumber.Text.Trim();
				cmd.Parameters.Add("Answer" + index, MySqlDbType.VarChar).Value = Answer.Text.Trim();

				cmd.ExecuteNonQuery();
			} else {
				// 존재할 경우 업데이트
				sql = "UPDATE applys SET StudentNumber='" + studentNumber.Text + "', Answer" + index + "='" + Answer.Text.Trim() + "' WHERE Id='" + Id + "';";
				cmd.CommandText = sql;
				cmd.ExecuteNonQuery();
			}

			Response.Redirect("/Apply.aspx");
		}
	}
}