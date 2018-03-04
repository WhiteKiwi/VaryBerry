using System;

namespace VaryBerry.Models {
	/// <summary>
	/// Question Model
	/// </summary>
	public class Question {
		public int Id { get; set; } // 질문 일련번호

		public string Title { get; set; }   // 질문 제목

		public string Contents { get; set; } // 질문 내용

		public DateTime QuestionAt { get; set; }  // 질문 날짜

		public string UserID { get; set; }	// 등록자 ID
	}
}