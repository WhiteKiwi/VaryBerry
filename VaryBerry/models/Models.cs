using System;
/// <summary>
/// 분류 enum
/// </summary>
namespace VaryBerry.Models {
	public enum Classification {
		// 행사
		Event,

		// 학교시설
		Facilities,

		// CNSA 용어
		CNSATerms,

		// 생활
		CNSALife,

		// 학습
		Study,

		// 동아리
		Club,
		
		// 단체
		Group,

		// 대회
		Contest
	}

	/// <summary>
	/// Berries Model
	/// </summary>
	public class Berry {
		public int Id { get; set; } // Berry 일련번호

		public string Title { get; set; }   // Berry 제목

		public string Contents { get; set; } // Berry 내용

		public Classification Classification { get; set; }  // 분류
	}

	/// <summary>
	/// Berry Proposal Model
	/// </summary>
	public class BerryProposal {
		public int Id { get; set; } // Berry Proposal 일련번호

		public string Title { get; set; }   // Proposal 제목

		public string Contents { get; set; } // Proposal 내용

		public Classification Classification { get; set; }  // Proposal 분류
	}

	/// <summary>
	/// Notices Model
	/// </summary>
	public class Notice {
		public int Id { get; set; } // 글 일련번호

		public string Title { get; set; }   // 글 제목

		public string Contents { get; set; } // 글 내용

		public DateTime NoticeAt { get; set; }  // 공지 날짜
	}

	/// <summary>
	/// Calendars Model
	/// </summary>
	public class Calendar {
		public int Id { get; set; } // 일정 일련번호

		public DateTime EventDate { get; set; } // 일정

		public string Title { get; set; }   // 일정 제목

		public int Classification { get; set; } // 분류 번호

		public int BerryId { get; set; }    // Berry 번호
	}

	/// <summary>
	/// Question Model
	/// </summary>
	public class Question {
		public int Id { get; set; } // 질문 일련번호

		public string Title { get; set; }   // 질문 제목

		public string Contents { get; set; } // 질문 내용

		public DateTime QuestionAt { get; set; }  // 질문 날짜
	}

	/// <summary>
	/// Answer Model
	/// </summary>
	public class Answer {
		public int Id { get; set; } // 답변 일련번호

		public int QuestionId { get; set; }   // 답변의 질문 일련번호

		public string Contents { get; set; } // 답변 내용
	}
}