using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace VaryBerry.Models {
	public class BerryProposalManager {
		// Table Name
		private static readonly string BERRYPROPOSALTABLE = "berry_proposals";

		/// <summary>
		/// Add BerryProposal
		/// </summary>
		public static int AddBerryProposal(BerryProposal berryProposal) {
			MySqlConnection conn = null;
			try {
				// Connect to DB;
				conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
				conn.Open();

				int result = 0;

				// Connect to Database
				string sql = "INSERT INTO " + BERRYPROPOSALTABLE + "(Title, Contents, Classification) VALUES (?, ?, ?);";
				MySqlCommand cmd = new MySqlCommand(sql, conn);

				// Add BerryProposal Info
				cmd.Parameters.Add("Title", MySqlDbType.VarChar).Value = berryProposal.Title;
				cmd.Parameters.Add("Contents", MySqlDbType.VarChar).Value = berryProposal.Contents;
				cmd.Parameters.Add("Classification", MySqlDbType.Int64).Value = berryProposal.Classification;

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
		/// Delete BerryProposal
		/// </summary>
		public static int DeleteBerryProposal(int id) {
			MySqlConnection conn = null;
			try {
				// Connect to DB;
				conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
				conn.Open();

				int result = 0;

				// Delete BerryProposal
				string sql = "DELETE FROM " + BERRYPROPOSALTABLE + " WHERE Id='" + id + "';";
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
		/// Get BerryProposals
		/// </summary>
		public static List<BerryProposal> GetBerryProposals() {
			MySqlConnection conn = null;
			try {
				// Connect to DB;
				conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
				conn.Open();

				List<BerryProposal> berryProposalList = new List<BerryProposal>();

				// Get Berries
				string sql = "SELECT * FROM " + BERRYPROPOSALTABLE + ";";
				MySqlCommand cmd = new MySqlCommand(sql, conn);
				var rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					berryProposalList.Add(new BerryProposal {
						Id = (int)rdr["Id"],
						Title = (string)rdr["Title"],
						Contents = (string)rdr["Contents"],
						Classification = (Classification)rdr["Classification"]
					});
				}

				return berryProposalList;
			} catch (Exception e) {
				// TODO: 예외 처리
				throw new Exception(e.Message);
			} finally {
				conn.Close();
			}
		}

		/// <summary>
		/// Get BerryProposal by Id
		/// </summary>
		public static BerryProposal GetBerryProposalByID(int id) {
			MySqlConnection conn = null;
			try {
				// Connect to DB;
				conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
				conn.Open();

				string sql = "SELECT * FROM " + BERRYPROPOSALTABLE + " WHERE Id='" + id + "';";
				MySqlCommand cmd = new MySqlCommand(sql, conn);

				var rdr = cmd.ExecuteReader();
				rdr.Read();

				// TODO: BerryProposal이 없을 경우

				return new BerryProposal {
					Id = (int)rdr["Id"],
					Title = (string)rdr["Title"],
					Contents = (string)rdr["Contents"]
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