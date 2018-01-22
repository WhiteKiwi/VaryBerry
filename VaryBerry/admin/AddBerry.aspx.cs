using System;
using System.Text;

namespace VaryBerry {
	public partial class AddBerry : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			BytesCount.Text = "0 / 10000 Byte";
			BytesCount.ForeColor = System.Drawing.Color.FromName("#B2B2B2");

			// 분류 목록 추가
			ClassificationList.Items.Add("행사");
			ClassificationList.Items.Add("학교시설");
			ClassificationList.Items.Add("CNSA 용어");
			ClassificationList.Items.Add("생활");
			ClassificationList.Items.Add("학습");
			ClassificationList.Items.Add("활동");
			ClassificationList.Items.Add("동아리");
			ClassificationList.Items.Add("1인1기");
			ClassificationList.Items.Add("단체");
			ClassificationList.Items.Add("대회");
		}

		protected void BerryUpload(object sender, EventArgs e) {
			Models.Classification classification;

			switch (ClassificationList.SelectedValue) {
				case "행사":
					classification = Models.Classification.Event;
					break;
				case "학교시설":
					classification = Models.Classification.Facilities;
					break;
				case "CNSA 용어":
					classification = Models.Classification.CNSATerms;
					break;
				case "생활":
					classification = Models.Classification.CNSALife;
					break;
				case "학습":
					classification = Models.Classification.Study;
					break;
				case "활동":
					classification = Models.Classification.Career;
					break;
				case "동아리":
					classification = Models.Classification.Club;
					break;
				case "1인1기":
					classification = Models.Classification.OneManOneSkill;
					break;
				case "단체":
					classification = Models.Classification.Group;
					break;
				case "대회":
					classification = Models.Classification.Contest;
					break;
				default:
					classification = Models.Classification.Event;
					break;
			}

			// Berry 추가
			Models.BerryManager.AddBerry(new Models.Berry {
				Title = nTitle.Text,
				Contents = Contents.Text,
				Classification = classification
			});

			Response.Redirect("/admin/AddBerry.aspx");
		}

		protected void CountBytes(object sender, EventArgs e) {
			BytesCount.Text = Encoding.UTF8.GetByteCount(Contents.Text) + " / 10000 Bytes";
			// TODO: Over 10,000 Bytes
		}
	}
}