using System;
using System.ComponentModel.DataAnnotations;

namespace VaryBerry.Models {
	/// <summary>
	/// 게시글 Model
	/// </summary>
	public class Note {
		[Display(Name = "번호")]
		public int Id { get; set; } // 글 일련번호

		[Display(Name = "제목")]
		[Required(ErrorMessage = "* 제목을 작성해 주세요.")]
		public string Title { get; set; }   // 글 제목

		[Display(Name = "작성일")]
		public DateTime PostDate { get; set; }  // 게시글 작성 시간

		public string IP { get; set; }  // 게시자 IP

		[Display(Name = "내용")]
		[Required(ErrorMessage = "* 내용을 작성해 주세요.")]
		public string Content { get; set; } // 글 내용
		
		[Display(Name = "인코딩")]
		public string Encoding { get; set; } = "Text";  // 인코딩 방식 ( Default = "Text" )

		public string FileName { get; set; }    // 파일 이름

		public int FileSize { get; set; } = 0;    // 파일 크기
	}
}