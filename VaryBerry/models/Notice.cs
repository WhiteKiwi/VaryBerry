using System;
using System.ComponentModel.DataAnnotations;

namespace VaryBerry.Models {
	/// <summary>
	/// Notices Model
	/// </summary>
	public class Notice {
		public int Id { get; set; } // 글 일련번호

		public string Title { get; set; }   // 글 제목

		public string Contents { get; set; } // 글 내용

		public DateTime NoticeAt { get; set; }  // 공지 날짜
	}
}