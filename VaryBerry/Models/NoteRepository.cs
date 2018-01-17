using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace VaryBerry.Models {
	public class NoteRepository {
		private MySqlConnection conn;

		private readonly string NotesTable = "Notes";

		private readonly int NoteCount = 10;

		public NoteRepository() {
			conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
			conn.Open();
		}

		~NoteRepository() {
			conn.Close();
		}

		/// <summary>
		/// 글 업로드
		/// </summary>
		public int UploadNotice(Note n) {
			try {
				int r = 0;

				// Connect to Database
				string sql = "INSERT INTO Notes(Title, PostDate, IP, Content, Encoding, FileName, FileSize) VALUES (?, ?, ?, ?, ?, ?, ?)";
				MySqlCommand cmd = new MySqlCommand(sql, conn);
				// Add Note Info
				cmd.Parameters.Add("Title", MySqlDbType.VarChar).Value = n.Title;
				cmd.Parameters.Add("PostDate", MySqlDbType.DateTime).Value = n.PostDate;
				cmd.Parameters.Add("IP", MySqlDbType.VarChar).Value = n.IP;
				cmd.Parameters.Add("Content", MySqlDbType.VarChar).Value = n.Content;
				cmd.Parameters.Add("Encoding", MySqlDbType.VarChar).Value = n.Encoding;
				cmd.Parameters.Add("FileName", MySqlDbType.VarChar).Value = n.FileName;
				cmd.Parameters.Add("FileSize", MySqlDbType.Int32).Value = n.FileSize;

				r = cmd.ExecuteNonQuery();

				return r;
			} catch (Exception e) {
				// TODO: 예외 처리
				throw new Exception(e.Message);
			}
		}

		/// <summary>
		/// 글 삭제
		/// </summary>
		public int DeleteNote(int id, string password) {
			try {
				int r = 0;

				// Delete Note
				string sql = "DELETE FROM" + NotesTable + "WHERE Id='" + id + "' AND Password='" + password + "';";
				MySqlCommand cmd = new MySqlCommand(sql, conn);
				r = cmd.ExecuteNonQuery();

				return r;
			} catch (Exception e) {
				throw new Exception(e.Message);
			}
		}

		/// <summary>
		/// 페이지 수 반환
		/// </summary>
		public int GetPageCount() {
			// Read Notes Count
			string sql = "SELECT count(*) FROM Notes;";
			MySqlCommand cmd = new MySqlCommand(sql, conn);
			int n = Convert.ToInt32(cmd.ExecuteScalar());

			return n / 10 + 1;
		}

		/// <summary>
		/// 페이지에 해당하는 글 목록
		/// </summary>
		public List<Note> GetNotesByPage(int page) {
			// TODO: 없는 페이지 체크
			try {
				List<Note> r = new List<Note>();

				// Read Notes Count
				string sql = "SELECT count(*) FROM Notes;";
				MySqlCommand cmd = new MySqlCommand(sql, conn);
				int n = Convert.ToInt32(cmd.ExecuteScalar()) - (page * NoteCount);

				// Read Notes
				// TODO: LIMIT 뒤에 뭔가 하자가 잇다
				sql = "SELECT Id, PostDate, Title FROM" + NotesTable + "LIMIT " + (n + 1) + ", " + NoteCount + ";";
				cmd.CommandText = sql;
				var rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					r.Add(new Note {
						Id = (int)rdr["Id"],
						PostDate = (DateTime)rdr["PostDate"],
						Title = (string)rdr["Title"]
					});
				}

				return r;
			} catch (Exception e) {
				// TODO: 예외 처리
				throw new Exception(e.Message);
			}
		}

		/// <summary>
		/// 상세보기
		/// </summary>
		public Note GetNote(int id) {
			try {
				string sql = "SELECT * FROM" + NotesTable + "WHERE Id='" + id + "';";
				MySqlCommand cmd = new MySqlCommand(sql, conn);
				var rdr = cmd.ExecuteReader();
				rdr.Read();
				// TODO: 글이 없을 경우
				return new Note {
					Id = (int)rdr["Id"],
					Title = (string)rdr["Title"],
					PostDate = (DateTime)rdr["PostDate"],
					Content = (string)rdr["Content"],
					Encoding = (string)rdr["Encoding"],
					FileName = (string)rdr["FileName"],
					FileSize = (int)rdr["FileSize"]
				};
			} catch (Exception e) {
				// TODO: 예외 처리
				throw new Exception(e.Message);
			}
		}

		/// <summary>
		/// Id에 해당하는 파일명 반환
		/// </summary>
		public string GetFileNameById(int id) {
			try {
				string sql = "SELECT FileName FROM" + NotesTable + "WHERE Id='" + id + "';";
				MySqlCommand cmd = new MySqlCommand(sql, conn);
				// TODO: 파일이 없을 경우
				return (string)cmd.ExecuteScalar();
			} catch (Exception e) {
				// TODO: 예외 처리
				throw new Exception(e.Message);
			}
		}
	}
}