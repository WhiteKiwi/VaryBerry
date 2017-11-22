namespace VaryBerry.Models {
	/// <summary>
	/// 글 내용의 인코딩 처리 방식
	/// </summary>
	public enum ContentEncodingType {
		/// <summary>
		/// 입력한 내용 그대로 표시 ( HTML 태그를 실행하지 않음 )
		/// </summary>
		Text,
		/// <summary>
		/// HTML로 실행
		/// </summary>
		HTML,
		/// <summary>
		/// HTML로 실행 + \r\n 적용
		/// </summary>
		Mixed
	}
}