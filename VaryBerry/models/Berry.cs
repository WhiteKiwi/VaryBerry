namespace VaryBerry.Models {
	/// <summary>
	/// Berries Model
	/// </summary>
	public class Berry {
		public int Id { get; set; } // Berry 일련번호

		public string Title { get; set; }   // Berry 제목

		public string Contents { get; set; } // Berry 내용

		public Classification Classification { get; set; }  // 분류

		public int Views { get; set; }  // 조회수
	}
}