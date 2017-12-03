using System.IO;

/* Created at 2017-12-03
 * Created by 띵배
 */

/// <summary>
/// Vul.dll: VaryBerry Utility Library
/// </summary>
namespace VaryLibrary {
	/// <summary>
	/// 파일 처리 관련 기본 유틸리티
	/// </summary>
	public class FileUtility {
		#region 중복된 파일 뒤에 번호를 붙이는 메서드 : GetFileNameWithNumbering
		/// <summary>
		/// GetFilePath : 파일명 뒤에 번호를 붙이는 메서드
		/// </summary>
		/// <param name="dir">경로(c:\MyFiles)</param>
		/// <param name="name">Text.txt</param>
		/// <returns>Test(1).txt</returns>
		public static string GetFileNameWithNumbering(string dir, string name) {
			//순수파일명 : Test
			string strName = Path.GetFileNameWithoutExtension(name);
			//확장자 : .txt
			string strExt = Path.GetExtension(name);
			bool blnExist = true;
			int i = 0;
			while (blnExist) {
				//Path.Combine(경로, 파일명) = 경로 + 파일명
				if (File.Exists(Path.Combine(dir, name))) {
					name = strName + "(" + ++i + ")" + strExt; //Test(3).txt
				}
				else {
					blnExist = false;
				}
			}
			return name;
		}
		#endregion
	}
}
