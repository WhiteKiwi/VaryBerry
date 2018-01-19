using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace VaryBerry.Models {
	public static class BerryManager {
		// Table Name
		private static readonly string BERRYTABLE = "Berries";

		/// <summary>
		/// Add Berry
		/// </summary>
		public static int AddBerry(Berry berry) {
			MySqlConnection conn = null;
			try {
				// Connect to DB;
				conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
				conn.Open();

				int result = 0;

				// Connect to Database
				string sql = "INSERT INTO " + BERRYTABLE + "(Title, Content, Classification) VALUES (?, ?, ?);";
				MySqlCommand cmd = new MySqlCommand(sql, conn);

				// Add Berry Info
				cmd.Parameters.Add("Title", MySqlDbType.VarChar).Value = berry.Title;
				cmd.Parameters.Add("Content", MySqlDbType.VarChar).Value = berry.Content;
				cmd.Parameters.Add("Classification", MySqlDbType.VarChar).Value = berry.Classification;

				// Query 실행
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
		/// Delete Berry
		/// </summary>
		public static int DeleteBerry(int id) {
			MySqlConnection conn = null;
			try {
				// Connect to DB;
				conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
				conn.Open();

				int result = 0;

				// Delete Berry
				string sql = "DELETE FROM " + BERRYTABLE + " WHERE Id='" + id + "';";
				MySqlCommand cmd = new MySqlCommand(sql, conn);

				// Query 실행
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
		/// Get Berries by Classification
		/// 목록 렌더링을 위해 제목과 글번호만 반환
		/// </summary>
		public static List<Berry> GetBerriesByClassification(Classification classification) {
			MySqlConnection conn = null;
			try {
				// Connect to DB;
				conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
				conn.Open();

				List<Berry> berryList = new List<Berry>();

				// Get Berries
				string sql = "SELECT Id, Title FROM " + BERRYTABLE + " WHERE Classification='" + classification + "';";
				MySqlCommand cmd = new MySqlCommand(sql, conn);
				var rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					berryList.Add(new Berry {
						Id = (int)rdr["Id"],
						Title = (string)rdr["Title"]
					});
				}

				return berryList;
			} catch (Exception e) {
				// TODO: 예외 처리
				throw new Exception(e.Message);
			} finally {
				conn.Close();
			}
		}

		/// <summary>
		/// Get Berry by Id
		/// </summary>
		public static Berry GetBerryByID(int id) {
			MySqlConnection conn = null;
			try {
				// Connect to DB;
				conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
				conn.Open();

				string sql = "SELECT * FROM " + BERRYTABLE + " WHERE Id='" + id + "';";
				MySqlCommand cmd = new MySqlCommand(sql, conn);

				var rdr = cmd.ExecuteReader();
				rdr.Read();

				// TODO: Berry가 없을 경우

				return new Berry {
					Id = (int)rdr["Id"],
					Title = (string)rdr["Title"],
					Content = (string)rdr["Content"]
				};
			} catch (Exception e) {
				// TODO: 예외 처리
				throw new Exception(e.Message);
			} finally {
				conn.Close();
			}
		}
	}
}