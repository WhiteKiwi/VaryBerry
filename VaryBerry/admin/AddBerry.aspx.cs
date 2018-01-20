using System;
using System.Text;

namespace VaryBerry.admin {
	public partial class AddBerry : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			BytesCount.Text = "0 / 10000 Byte";
			BytesCount.ForeColor = System.Drawing.Color.FromName("#B2B2B2");

			// 분류 목록 추가
			ClassificationList.Items.Add("행사");
			ClassificationList.Items.Add("학교시설");
			ClassificationList.Items.Add("기숙사");
			ClassificationList.Items.Add("학습");
			ClassificationList.Items.Add("활동");
			ClassificationList.Items.Add("대회");
			ClassificationList.Items.Add("교우관계");
		}

		protected void BerryUpload(object sender, EventArgs e) {
			// Berry 추가
			Models.BerryManager.AddBerry(new Models.Berry {
				Title = nTitle.Text,
				Contents = Contents.Text,
				Classification = (Models.Classification)ClassificationList.SelectedIndex
			});
		}

		protected void CountBytes(object sender, EventArgs e) {
			BytesCount.Text = Encoding.UTF8.GetByteCount(Contents.Text) + " / 10000 Bytes";
			// TODO: Over 10,000 Bytes
		}
	}
}