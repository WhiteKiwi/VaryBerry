using System;
using System.IO;

/* Created at 2017-12-03
 * Created by 띵배
 */

namespace VaryLibrary {
	public class BoardLibrary {
		#region 각 글의 Step별 들여쓰기 처리
		/// <summary>
		/// 각 글의 Step별 들여쓰기 처리
		/// </summary>
		/// <param name="objStep">1, 2, 3</param>
		/// <returns>Re 이미지를 포함한 Step만큼 들여쓰기</returns>
		public static string FuncStep(object objStep) {
			int intStep = Convert.ToInt32(objStep);
			string strTemp = String.Empty;
			if (intStep == 0) {
				strTemp = String.Empty;
			}
			else {
				for (int i = 0; i < intStep; i++) {
					strTemp = String.Format(
						"<img src=\"{0}\" height=\"{1}\" width=\"{2}\">", "/images/dnn/blank.gif", "0", (intStep * 15));
				}
				strTemp += "<img src=\"/images/dnn/re.gif\">";
			}
			return strTemp;
		}
		#endregion

		#region 댓글 개수를 표현하는 메서드
		/// <summary>
		/// 댓글 개수를 표현하는 메서드
		/// </summary>
		/// <param name="objCommentCount">댓글 수</param>
		/// <returns>댓글 이미지와 함께 숫자 표시</returns>
		public static string ShowCommentCount(object objCommentCount) {
			string strTemp = "";
			try {
				if (Convert.ToInt32(objCommentCount) > 0) {
					strTemp = "<img src =\"/image/dnn/commentcount.gif\" />";
					strTemp += "(" + objCommentCount.ToString() + ")";
				}
			}
			catch (Exception) {
				strTemp = "";
			}
			return strTemp;
		}
		#endregion

		#region 24시간 내에 올라온 글 new 이미지 표시하기
		/// <summary>
		/// 24시간 내에 올라온 글 new 이미지 표시하기
		/// </summary>
		public static string FuncNew(object strDate) {
			if (strDate != null) {
				if (!String.IsNullOrEmpty(strDate.ToString())) {
					DateTime originDate = Convert.ToDateTime(strDate);

					TimeSpan objTs = DateTime.Now - originDate;
					string newImage = "";
					if (objTs.TotalMinutes < 1440) {
						newImage = "img src=\"/images/dnn/new.gif\">";
					}
					return newImage;
				}
			}
			return "";
		}
		#endregion

		#region 넘겨온 날짜 형식이 오늘 날짜면 시간 표시
		/// <summary>
		/// 넘겨온 날짜 형식이 오늘 날짜면 시간 표시
		/// 그렇지 않으면 날짜 표시
		/// </summary>
		public static string FuncShowTime(object date) {
			if (date != null) {
				if (!String.IsNullOrEmpty(date.ToString())) {
					string strPostDate = Convert.ToDateTime(date).ToString("yyyy-MM-dd");
					if (strPostDate == DateTime.Now.ToString("yyyy-MM-dd")) {
						return Convert.ToDateTime(date).ToString("hh:mm:ss");
					}
					else {
						return strPostDate;
					}
				}
			}
			return "-";
		}
		#endregion

		#region ConvertToFileSize() 함수
		/// <summary>
		/// 파일 크기를 계산해서 알맞은 단위로 변환해줌
		/// </summary>
		public static string ConvertToFileSize(int intByte) {
			int intFileSize = Convert.ToInt32(intByte);
			string strResult = "";
			if (intFileSize >= 1048576) {
				strResult = string.Format("{0:F} MB", (intByte / 1048576));
			}
			else {
				if (intFileSize > 1024) {
					strResult = string.Format("{0} KB", (intByte / 1024));
				}
				else {
					strResult = intByte + " Byte(s)";
				}
			}
			return strResult;
		}
		#endregion

		#region IsPhoto() 함수
		/// <summary>
		/// 파일 확장자를 검사해서 파일이 이미지 파일인지 검사
		/// </summary>
		/// <param name="strFileNameTemp">확장자를 포함한 파일(Test.png)</param>
		/// <returns>이미지 확장자이면 true, 그렇지 않으면 false</returns>
		public static bool IsPhoto(string strFileNameTemp) {
			string ext = Path.GetExtension(strFileNameTemp).Replace(".", "").ToLower();
			bool blnResult = false;
			if (ext == "gif" || ext == "jpg" || ext == "jpeg" || ext == "png") {
				blnResult = true;
			}
			else {
				blnResult = false;
			}
			return blnResult;
		}
		#endregion

		#region 파일 다운로드 기능
		/// <summary>
		/// 파일 다운로드 기능
		/// 주의 : 각 필드에 NULL 값이 들어가면 에러 발생
		/// </summary>
		public static string FuncFileDownSingle(int id, string strFileName, string strFileSize) {
			if (strFileName.Length > 0) {
				return "<a herf=\"/DotNetNote/BoardDown.aspx?Id="
					+ id.ToString() + "\">" + DownloadType(strFileName, strFileName + "("
					+ ConvertToFileSize(Convert.ToInt32(strFileSize)) + ")")
					+ "</a>";
			}
			else {
				return "-";
			}
		}
		#endregion

		#region DownloadType() 함수
		/// <summary>
		/// 다운로드할 파일의 확장자를 통해 아이콘 결정
		/// </summary>
		/// <param name="strFileName">파일 이름</param>
		/// <param name="altString">alt 메세지로 넣을 문자열</param>
		public static string DownloadType(string strFileName, string altString) {
			string strFileExt = Path.GetExtension(strFileName).Replace(".", "").ToLower();
			string r = "";
			switch (strFileExt) {
				case "bmp":
					r = "<img src='/images/ext/ext_bmp.gif' border='0' alt='" + altString + "'>";
					break;
				case "css":
					r = "<img src='/images/ext/ext_css.gif' border='0' alt='" + altString + "'>";
					break;
				case "gif":
					r = "<img src='/images/ext/ext_gif.gif' border='0' alt='" + altString + "'>";
					break;
				case "htm":
					r = "<img src='/images/ext/ext_htm.gif' border='0' alt='" + altString + "'>";
					break;
				case "html":
					r = "<img src='/images/ext/ext_html.gif' border='0' alt='" + altString + "'>";
					break;
				case "jpg":
					r = "<img src='/images/ext/ext_jpg.gif' border='0' alt='" + altString + "'>";
					break;
				case "jpeg":
					r = "<img src='/images/ext/ext_jpeg.gif' border='0' alt='" + altString + "'>";
					break;
				case "js":
					r = "<img src='/images/ext/ext_js.gif' border='0' alt='" + altString + "'>";
					break;
				case "":
					r = "<img src='/images/ext/ext_none.gif' border='0' alt='" + altString + "'>";
					break;
				case "png":
					r = "<img src='/images/ext/ext_png.gif' border='0' alt='" + altString + "'>";
					break;
				case "sql":
					r = "<img src='/images/ext/ext_sql.gif' border='0' alt='" + altString + "'>";
					break;
				case "txt":
					r = "<img src='/images/ext/ext_txt.gif' border='0' alt='" + altString + "'>";
					break;
				case "zip":
					r = "<img src='/images/ext/ext_zip.gif' border='0' alt='" + altString + "'>";
					break;
				default:
					r = "<img src='/images/ext/ext_unknown.gif' border='0' alt='" + altString + "'>";
					break;
			}
			return r;
		}
		#endregion
	}
}


