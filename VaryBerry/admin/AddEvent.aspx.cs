using System;
using System.Globalization;

namespace VaryBerry {
	public partial class AddEvent : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void EventUpload(object sender, EventArgs e) {
			// 일정추가
			Models.CalendarManager.AddCalendar(new Models.Calendar {
				Title = nTitle.Text,
				EventDate = DateTime.ParseExact(EventDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture),
				Classification = int.Parse(Classification.Text),
				BerryId = int.Parse(BerryId.Text)
			});

			Response.Redirect("/admin/AddEvent.aspx");
		}
	}
}