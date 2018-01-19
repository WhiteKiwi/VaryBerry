/// <summary>
/// 분류 enum
/// </summary>
namespace VaryBerry.Models {
	public enum Classification {
		/// <summary>
		/// 디플로마 [ 1~ ]
		/// </summary>

		// 3계열 8과정
		Curriculum = 1,

		// CNSA 디플로마
		CNSA_Diploma,

		// Dual 디플로마
		Dual_Diploma,

		// Honor 디플로마
		Honor_Diploma,
		
		// 디플로마 선택
		Worry_Diploma,


		/// <summary>
		/// 행사 [ 10~ ]
		/// </summary>
		
		// 체육대회
		Sports_Contest = 10,

		// CNSA Concert
		CNSA_Concert,

		// 학술제
		Scholar_Concert,

		// GA
		GA,

		// 동아리 설명회
		Club_Presentation,

		// 입학식
		Entrance_Ceremony,

		// 졸업식
		Graduation,

		// 수강신청
		Course_Registration,

		// 모의고사
		Mock_Test,

		// 학급 임원 선출
		Class_Election,

		// 레전드 페스티벌
		Legend_Festival,

		// 벚꽃제
		Cherry_Blossom_Festival,

		// 전체 귀가
		Homecoming,

		// 세족식
		Maundy,

		// 선후배 상견례
		SeniorAndJuniorMeeting,

		// 충남 문화유산 답사
		ChungNam_Cultural_Heritage_Exploration,

		// TODO: 이어서 작성
	}
}