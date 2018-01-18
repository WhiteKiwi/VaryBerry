using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VaryBerry.models {
	/// <summary>
	/// Notices Model
	/// </summary>
	public class Notice {
		[Display(Name = "번호")]
		public int Id { get; set; } // 글 일련번호

		[Display(Name = "제목")]
		[Required(ErrorMessage = "* 제목을 작성해 주세요.")]
		public string Title { get; set; }   // 글 제목

		[Display(Name = "내용")]
		[Required(ErrorMessage = "* 내용을 작성해 주세요.")]
		public string Content { get; set; } // 글 내용

		public DateTime NoticeAt { get; set; }  // 공지 날짜
	}
}