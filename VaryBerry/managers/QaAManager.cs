using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace VaryBerry.Models {
	public static class QaAManager {
		// Table Name
		const string QUESTIONTABLE = "questions";
		const string ANSWERTABLE = "answers";

		/// <summary>
		/// Add Question
		/// </summary>
		public static int AddQuestion(Question question) {
			MySqlConnection conn = null;
			try {
				// Connect to DB;
				conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
				conn.Open();

				int result = 0;

				// Connect to Database
				string sql = "INSERT INTO " + QUESTIONTABLE + "(Title, Contents, Question_At) VALUES (?, ?, ?);";
				MySqlCommand cmd = new MySqlCommand(sql, conn);

				// Add Question Info
				cmd.Parameters.Add("Title", MySqlDbType.VarChar).Value = question.Title;
				cmd.Parameters.Add("Contents", MySqlDbType.VarChar).Value = question.Contents.Replace("\r\n", "<br/>");
				cmd.Parameters.Add("Question_At", MySqlDbType.DateTime).Value = DateTime.Now;

				result = cmd.ExecuteNonQuery();

				return result;
			} catch (Exception e) {
				// TODO: 예외 처리
				throw new Exception(e.Message);
			} finally {
				conn.Close();
			}
		}

		/// <summary>
		/// Get Questions by page
		/// 목록 렌더링을 위해 제목과 글번호만 반환
		/// </summary>
		public static List<Question> GetQuestionsByPage(int page) {
			MySqlConnection conn = null;
			try {
				// Connect to DB;
				conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
				conn.Open();

				List<Question> questionList = new List<Question>();

				// Get Questions Count
				string sql = "SELECT count(*) FROM " + QUESTIONTABLE + ";";
				MySqlCommand cmd = new MySqlCommand(sql, conn);
				int questionCount = Convert.ToInt32(cmd.ExecuteScalar());

				// Get Questions
				sql = "SELECT Id, Title, Question_At FROM " + QUESTIONTABLE + " ORDER BY Id DESC LIMIT 10 OFFSET " + ((page - 1) * 10) + ";";
				cmd.CommandText = sql;

				var rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					questionList.Add(new Question {
						Id = (int)rdr["Id"],
						Title = (string)rdr["Title"],
						QuestionAt = (DateTime)rdr["Question_At"]
					});
				}

				return questionList;
			} catch (Exception e) {
				// TODO: 예외 처리
				throw new Exception(e.Message);
			} finally {
				conn.Close();
			}
		}

		/// <summary>
		/// Get Question by Id
		/// </summary>
		public static Question GetQuestionByID(int id) {
			MySqlConnection conn = null;
			try {
				// Connect to DB;
				conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
				conn.Open();

				string sql = "SELECT * FROM " + QUESTIONTABLE + " WHERE Id='" + id + "';";
				MySqlCommand cmd = new MySqlCommand(sql, conn);

				var rdr = cmd.ExecuteReader();
				rdr.Read();

				// TODO: Question이 없을 경우

				return new Question {
					Id = (int)rdr["Id"],
					Title = (string)rdr["Title"],
					Contents = (string)rdr["Contents"],
					QuestionAt = (DateTime)rdr["Question_At"]
				};
			} catch (Exception e) {
				// TODO: 예외 처리
				throw new Exception(e.Message);
			} finally {
				conn.Close();
			}
		}

		/// <summary>
		/// Add Answer
		/// </summary>
		public static int AddAnswer(Answer answer) {
			// 내용이 비어 있을 경우 종료
			if (String.IsNullOrEmpty(answer.Contents.Trim()))
				return -1;

			MySqlConnection conn = null;
			try {
				// Connect to DB;
				conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
				conn.Open();

				int result = 0;

				// Connect to Database
				string sql = "SELECT count(*) FROM " + ANSWERTABLE + " WHERE Question_Id='" + answer.QuestionId + "';";
				MySqlCommand cmd = new MySqlCommand(sql, conn);

				// 답변이 하나도 없을 경우
				int answerCount = Convert.ToInt32(cmd.ExecuteScalar());
				if (answerCount == 0) {
					// 제목 불러오기
					sql = "SELECT Title FROM questions WHERE Id='" + answer.QuestionId + "';";
					cmd.CommandText = sql;
					string title = cmd.ExecuteScalar().ToString();

					// 답변완료 추가해서 제목 저장
					sql = "UPDATE questions SET Title='<span style=\"font-size: 0.9rem; \">[답변완료]</span> " + title + "' WHERE Id='" + answer.QuestionId + "';";
					cmd.CommandText = sql;
					cmd.ExecuteNonQuery();
				}

				sql = "INSERT INTO " + ANSWERTABLE + "(Question_Id, Contents) VALUES (?, ?);";
				cmd.CommandText = sql;

				// Add Answer Info
				cmd.Parameters.Add("Question_Id", MySqlDbType.Int64).Value = answer.QuestionId;
				cmd.Parameters.Add("Contents", MySqlDbType.VarChar).Value = answer.Contents;

				result = cmd.ExecuteNonQuery();

				return result;
			} catch (Exception e) {
				// TODO: 예외 처리
				throw new Exception(e.Message);
			} finally {
				conn.Close();
			}
		}

		/// <summary>
		/// Get Answers by Id
		/// </summary>
		public static List<Answer> GetAnswersByID(int id) {

			MySqlConnection conn = null;
			try {
				// Connect to DB;
				conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
				conn.Open();

				List<Answer> answerList = new List<Answer>();

				string sql = "SELECT * FROM " + ANSWERTABLE + " WHERE Question_Id='" + id + "';";
				MySqlCommand cmd = new MySqlCommand(sql, conn);

				// TODO: Answer가 없을 경우

				var rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					answerList.Add(new Answer {
						Id = (int)rdr["Id"],
						QuestionId = (int)rdr["Question_Id"],
						Contents = (string)rdr["Contents"]
					});
				}

				return answerList;
			} catch (Exception e) {
				// TODO: 예외 처리
				throw new Exception(e.Message);
			} finally {
				conn.Close();
			}
		}

		/// <summary>
		/// Get Pages Count
		/// </summary>
		public static int GetPagesCount() {
			MySqlConnection conn = null;
			try {
				// Connect to DB;
				conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
				conn.Open();

				// Get Questions Count
				string sql = "SELECT count(*) FROM " + QUESTIONTABLE + ";";
				MySqlCommand cmd = new MySqlCommand(sql, conn);
				int questionCount = Convert.ToInt32(cmd.ExecuteScalar());

				// 공지 갯수의 1의 자리가 0일 경우
				if (questionCount % 10 != 0) {
					return questionCount / 10 + 1;
				} else {
					return questionCount / 10;
				}
			} catch (Exception e) {
				// TODO: 예외 처리
				throw new Exception(e.Message);
			} finally {
				conn.Close();
			}
		}
	}
}