using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaryBerry.Models {
	public class NoticeManager {
		private MySqlConnection conn;

		private readonly string NOTICETABLE = "Notices";

		public NoticeManager() {
			conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
			conn.Open();
		}

		~NoticeManager() {
			conn.Close();
		}

		/// <summary>
		/// Add Notice
		/// </summary>
		public int AddNotice(Notice n) {
			try {
				int result = 0;

				// Connect to Database
				string sql = "INSERT INTO " + NOTICETABLE + "(Title, Content, Notice_At) VALUES (?, ?, ?);";
				MySqlCommand cmd = new MySqlCommand(sql, conn);

				// Add Notice Info
				cmd.Parameters.Add("Title", MySqlDbType.VarChar).Value = n.Title;
				cmd.Parameters.Add("Content", MySqlDbType.VarChar).Value = n.Content;
				cmd.Parameters.Add("Notice_At", MySqlDbType.VarChar).Value = n.NoticeAt;

				result = cmd.ExecuteNonQuery();

				return result;
			} catch (Exception e) {
				// TODO: 예외 처리
				throw new Exception(e.Message);
			}
		}

		/// <summary>
		/// Delete Notice
		/// </summary>
		public int DeleteNotice(int id) {
			try {
				int result = 0;

				// Delete Notice
				string sql = "DELETE FROM " + NOTICETABLE + " WHERE Id='" + id + "';";
				MySqlCommand cmd = new MySqlCommand(sql, conn);
				result = cmd.ExecuteNonQuery();

				return result;
			} catch (Exception e) {
				// TODO: 예외 처리
				throw new Exception(e.Message);
			}
		}

		/// <summary>
		/// Get Notices by page
		/// 목록 렌더링을 위해 제목과 글번호만 반환
		/// </summary>
		public List<Notice> GetNoticeByPage(int page) {
			try {
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
			}
		}

		/// <summary>
		/// Get Notice by Id
		/// </summary>
		public Notice GetNoticeByID(int id) {
			try {
				string sql = "SELECT * FROM " + NOTICETABLE + " WHERE Id='" + id + "';";
				MySqlCommand cmd = new MySqlCommand(sql, conn);

				var rdr = cmd.ExecuteReader();
				rdr.Read();
				// TODO: Notice가 없을 경우
				return new Notice {
					Id = (int)rdr["Id"],
					Title = (string)rdr["Title"],
					Content = (string)rdr["Content"],
					NoticeAt = (DateTime)rdr["Notice_At"]
				};
			} catch (Exception e) {
				// TODO: 예외 처리
				throw new Exception(e.Message);
			}
		}

		/// <summary>
		/// Get Pages Count
		/// </summary>
		public int GetPagesCount() {
			try {
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
			}
		}
	}
}