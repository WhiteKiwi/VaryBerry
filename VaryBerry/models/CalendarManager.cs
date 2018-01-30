using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace VaryBerry.Models {
	public static class CalendarManager {
		// Table Name
		const string CALENDARTABLE = "calendars";

		/// <summary>
		/// Add Calendar
		/// </summary>
		public static int AddCalendar(Calendar calendar) {
			MySqlConnection conn = null;
			try {
				// Connect to DB;
				conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
				conn.Open();

				int result = 0;

				// Connect to Database
				string sql = "INSERT INTO " + CALENDARTABLE + "(Event_Date, Title, Berry_Id) VALUES (?, ?, ?);";
				MySqlCommand cmd = new MySqlCommand(sql, conn);

				// Add Calendar Info
				cmd.Parameters.Add("Event_Date", MySqlDbType.Date).Value = calendar.EventDate;
				cmd.Parameters.Add("Title", MySqlDbType.VarChar).Value = calendar.Title;
				cmd.Parameters.Add("Berry_Id", MySqlDbType.VarChar).Value = calendar.BerryId;

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
		/// Get Calendars
		/// </summary>
		public static List<Calendar> GetCalendars() {
			MySqlConnection conn = null;
			try {
				// Connect to DB;
				conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
				conn.Open();

				List<Calendar> calendarList = new List<Calendar>();

				// Get Calendars Count
				string sql = "SELECT * FROM " + CALENDARTABLE + " ORDER BY Event_Date;";
				MySqlCommand cmd = new MySqlCommand(sql, conn);

				var rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					calendarList.Add(new Calendar {
						Id = (int)rdr["Id"],
						EventDate = (DateTime)rdr["Event_Date"],
						Title = (string)rdr["Title"],
						BerryId = (int)rdr["Berry_Id"]
					});
				}

				return calendarList;
			} catch (Exception e) {
				// TODO: 예외 처리
				throw new Exception(e.Message);
			} finally {
				conn.Close();
			}
		}
	}
}