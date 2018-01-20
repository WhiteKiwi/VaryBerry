namespace VaryBerry.Models {
	/// <summary>
	/// Berry Proposal Model
	/// </summary>
	public class BerryProposal {
		public int Id { get; set; } // Berry Proposal 일련번호

		public string Title { get; set; }   // Proposal 제목

		public string Contents { get; set; } // Proposal 내용

		public Classification Classification { get; set; }  // Proposal 분류
	}
}