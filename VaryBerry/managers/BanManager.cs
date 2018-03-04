using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaryBerry.Models {
	public static class BanManager {
		// Table Name
		const string BANTABLE = "ban_list";

		/// <summary>
		/// Ban Test
		/// </summary>
		public static bool IsBan(string userID) {
			MySqlConnection conn = null;
			try {
				// Connect to DB;
				conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
				conn.Open();

				// Connect to Database
				string sql = "SELECT * FROM " + BANTABLE + ";";
				MySqlCommand cmd = new MySqlCommand(sql, conn);

				var rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					if ((string)rdr["UserID"] == userID)
						return true;
				}

				return false;
			} catch (Exception e) {
				// TODO: 예외 처리
				throw new Exception(e.Message);
			} finally {
				conn.Close();
			}
		}
	}
}