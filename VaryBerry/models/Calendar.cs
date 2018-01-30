using System;

namespace VaryBerry.Models {
	/// <summary>
	/// Calendars Model
	/// </summary>
	public class Calendar {
		public int Id { get; set; } // 일정 일련번호

		public DateTime EventDate { get; set; }	// 일정

		public string Title { get; set; }   // 일정 제목

		public int Classification { get; set; }	// 분류 번호

		public int BerryId { get; set; }	// Berry 번호
	}
}