using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VaryBerry.Models {
	/// <summary>
	/// 댓글 Model
	/// </summary>
	public class NoteComment {
		public int Id { get; set; }	// 댓글 일련번호

		public int BoradId { get; set; }	// 게시글 일련번호

		public string IP { get; set; }	// 댓글 게시자 IP

		public DateTime PostDate { get; set; }	// 댓글 게시 날짜

		[Required(ErrorMessage = "댓글을 입력하세요")]
		public string Comment { get; set; }	// 댓글 내용

		[Required(ErrorMessage = "암호를 입력하세요")]
		public string Password { get; set; }	// 댓글 수정/삭제 시 필요한 Password
	}
}