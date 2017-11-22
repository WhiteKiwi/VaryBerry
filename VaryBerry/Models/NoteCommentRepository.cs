using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaryBerry.Models {
	public class NoteCommentRepository {
		private MySqlConnection conn;

		private readonly string CommentsTable = "NoteComments";

		public NoteCommentRepository() {
			conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[ "VaryBerry" ].ConnectionString);
			conn.Open();
		}

		~NoteCommentRepository() {
			conn.Close();
		}

		/// <summary>
		/// 게시물에 댓글 추가
		/// </summary>
		public void UploadNoteComment(NoteComment nc) {
			try {
				// Connect to Database
				string sql = "INSERT INTO" + CommentsTable + "(BoradId, Comment, IP, PostDate, Password) VALUES (?, ?, ?, ?, ?)";
				MySqlCommand cmd = new MySqlCommand(sql, conn);

				// Add NoteComment Info
				cmd.Parameters.Add("BoradId", MySqlDbType.Int32).Value = nc.BoradId;
				cmd.Parameters.Add("Content", MySqlDbType.VarChar).Value = nc.Comment;
				cmd.Parameters.Add("IP", MySqlDbType.VarChar).Value = nc.IP;
				cmd.Parameters.Add("PostDate", MySqlDbType.DateTime).Value = nc.PostDate;
				cmd.Parameters.Add("Password", MySqlDbType.VarChar).Value = nc.Password;
				cmd.ExecuteNonQuery();

				// Note.CommentCount++
				sql = "UPDATE Notes SET CommentCount=(CommentCount + 1) WHERE Id='" + nc.BoradId + "'";
				cmd.ExecuteNonQuery();
			} catch (Exception e) {
				// TODO: 예외 처리
				throw new Exception(e.Message);
			}
		}

		/// <summary>
		/// 게시물의 댓글 목록
		/// </summary>
		public List<NoteComment> GetNoteComments(int BoradId) {
			try {
				List<NoteComment> r = new List<NoteComment>();

				// Read NoteComments
				string sql = "SELECT Id, PostDate, IP, Comment FROM" + CommentsTable + "WHERE BoradId ='" + BoradId + "';";
				MySqlCommand cmd = new MySqlCommand(sql, conn);

				var rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					r.Add(new NoteComment {
						Id = (int)rdr[ "BoradId" ],
						PostDate = (DateTime)rdr[ "PostDate" ],
						IP = (string)rdr[ "IP" ],
						Comment = (string)rdr[ "Comment" ]
					});
				}

				return r;
			} catch (Exception e) {
				// TODO: 예외 처리
				throw new Exception(e.Message);
			}
		}

		/// <summary>
		/// 댓글 삭제
		/// </summary>
		public int DeleteNoteComment(int boradId, int id, string password) {
			try {
				int r = 0;

				// Delete NoteComment
				string sql = "DELETE FROM " + CommentsTable + "WHERE BoradId='" + boradId + "' AND Id='" + id + "' AND Password='" + password + "';";
				MySqlCommand cmd = new MySqlCommand(sql, conn);
				r = cmd.ExecuteNonQuery();

				return r;
			} catch (Exception e) {
				throw new Exception(e.Message);
			}
		}
	}
}