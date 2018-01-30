using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace VaryBerry.Models {
	public static class NoticeManager {
		// Table Name
		const string NOTICETABLE = "notices";
		
		/// <summary>
		/// Add Notice
		/// </summary>
		public static int AddNotice(Notice notice) {
			MySqlConnection conn = null;
			try {
				// Connect to DB;
				conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
				conn.Open();

				int result = 0;

				// Connect to Database
				string sql = "INSERT INTO " + NOTICETABLE + "(Title, Contents, Notice_At) VALUES (?, ?, ?);";
				MySqlCommand cmd = new MySqlCommand(sql, conn);

				// Add Notice Info
				cmd.Parameters.Add("Title", MySqlDbType.VarChar).Value = notice.Title;
				cmd.Parameters.Add("Contents", MySqlDbType.VarChar).Value = notice.Contents.Replace("\r\n", "<br/>");
				cmd.Parameters.Add("Notice_At", MySqlDbType.DateTime).Value = DateTime.Now;
				
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
		/// Delete Notice
		/// </summary>
		public static int DeleteNotice(int id) {
			MySqlConnection conn = null;
			try {
				// Connect to DB;
				conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
				conn.Open();

				int result = 0;

				// Delete Notice
				string sql = "DELETE FROM " + NOTICETABLE + " WHERE Id='" + id + "';";
				MySqlCommand cmd = new MySqlCommand(sql, conn);
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
		/// Get Notices by page
		/// 목록 렌더링을 위해 제목과 글번호만 반환
		/// </summary>
		public static List<Notice> GetNoticeByPage(int page) {
			MySqlConnection conn = null;
			try {
				// Connect to DB;
				conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
				conn.Open();

				List<Notice> noticeList = new List<Notice>();

				// Get Notices Count
				string sql = "SELECT count(*) FROM " + NOTICETABLE + ";";
				MySqlCommand cmd = new MySqlCommand(sql, conn);
				int noticeCount = Convert.ToInt32(cmd.ExecuteScalar());

				// Get Notices
				sql = "SELECT Id, Title, Notice_At FROM " + NOTICETABLE + " ORDER BY Id DESC LIMIT 10 OFFSET " + ((page - 1) * 10) + ";";
				cmd.CommandText = sql;

				var rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					noticeList.Add(new Notice {
						Id = (int)rdr["Id"],
						Title = (string)rdr["Title"],
						NoticeAt = (DateTime)rdr["Notice_At"]
					});
				}

				return noticeList;
			} catch (Exception e) {
				// TODO: 예외 처리
				throw new Exception(e.Message);
			} finally {
				conn.Close();
			}
		}

		/// <summary>
		/// Get Notice by Id
		/// </summary>
		public static Notice GetNoticeByID(int id) {
			MySqlConnection conn = null;
			try {
				// Connect to DB;
				conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
				conn.Open();

				string sql = "SELECT * FROM " + NOTICETABLE + " WHERE Id='" + id + "';";
				MySqlCommand cmd = new MySqlCommand(sql, conn);

				var rdr = cmd.ExecuteReader();
				rdr.Read();

				// TODO: Notice가 없을 경우

				return new Notice {
					Id = (int)rdr["Id"],
					Title = (string)rdr["Title"],
					Contents = (string)rdr["Contents"],
					NoticeAt = (DateTime)rdr["Notice_At"]
				};
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

				// Get Notices Count
				string sql = "SELECT count(*) FROM " + NOTICETABLE + ";";
				MySqlCommand cmd = new MySqlCommand(sql, conn);
				int noticeCount = Convert.ToInt32(cmd.ExecuteScalar());
				
				// 공지 갯수의 1의 자리가 0일 경우
				if (noticeCount % 10 != 0) {
					return noticeCount / 10 + 1;
				} else {
					return noticeCount / 10;
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