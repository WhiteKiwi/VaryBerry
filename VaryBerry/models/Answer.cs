namespace VaryBerry.Models {
	/// <summary>
	/// Answer Model
	/// </summary>
	public class Answer {
		public int Id { get; set; } // 답변 일련번호

		public int QuestionId { get; set; }   // 답변의 질문 일련번호

		public string Contents { get; set; } // 답변 내용
	}
}