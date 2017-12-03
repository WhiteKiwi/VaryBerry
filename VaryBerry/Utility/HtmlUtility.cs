using System;

/* Created at 2017-12-03
 * Created by 띵배
 */

namespace VaryLibrary {
	public class HtmlUtility {
		#region Encode() 함수
		/// <summary>
		/// Html을 실행하지 않고 소스 그대로 표현해서 바로 웹 페이지에 보여줌
		/// </summary>
		/// <param name="strContent">Html 태그가 포함된 문자열</param>
		/// <returns>태그가 인코드되어 소스 그대로 표현할 문자열</returns>
		public static string Encode(string strContent) {
			string strTemp = "";
			if (String.IsNullOrEmpty(strContent)) {
				strTemp = "";
			}
			else {
				strTemp = strContent;
				strTemp = strTemp
					.Replace("&", "&amp")
					.Replace(">", "&gt")
					.Replace("<", "&lt")
					.Replace("\r\n", "<br />")
					.Replace("\"", "&#34");
			}
			return strTemp;
		}
		#endregion

		#region EncodeWithTagAndSpace() 함수
		/// <summary>
		/// Html을 실행하지 않고 소스 그대로 표현해서 바로 웹 페이지에 보여줌
		/// 추가적으로 탭과 공백도 Html 코드(&nbsp;)로 처리해서 출력
		/// </summary>
		/// <param name="strContent"></param>
		/// <returns></returns>
		public static string EncodeWithTagAndSpace(string strContent) {
			return Encode(strContent)
				.Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;")
				.Replace(" " + " ", "&nbsp;&nbsp;");
		}
		#endregion
	}
}
