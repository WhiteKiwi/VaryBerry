using System;
using System.ComponentModel.DataAnnotations;

namespace VaryBerry.Models {
	/// <summary>
	/// Berries Model
	/// </summary>
	public class Berry {
		[Display(Name = "번호")]
		public int Id { get; set; } // Berry 일련번호

		[Display(Name = "제목")]
		[Required(ErrorMessage = "* 제목을 작성해 주세요.")]
		public string Title { get; set; }   // Berry 제목

		[Display(Name = "내용")]
		[Required(ErrorMessage = "* 내용을 작성해 주세요.")]
		public string Content { get; set; } // Berry 내용

		public Classification Classification { get; set; }	// 분류
	}
}