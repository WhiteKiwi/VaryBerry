<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="VaryBerry.Calendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<!-- Top-Image -->
	<div class="background-image-long" style="width: 100%; height: 40%;"></div>

	<!-- Calendar -->
	<div class="container">
		<div style="width: 100%; padding-top: 50px; padding-left: 100px; padding-right: 100px; text-align: left;">
			<h3><strong>일정</strong></h3>
			<hr class="hr-sky" />
			<%
				try {
					var calendarList = VaryBerry.Models.CalendarManager.GetCalendars();

					foreach (var calendar in calendarList) {
						// Write on Page
						Response.Write("<div style=\"text-align: center;\">");
						Response.Write("<span style=\"float: left; margin-left: 20px;\">" + calendar.EventDate.ToString("yyyy-MM-dd") + "</span>");
						Response.Write("<span><a class=\"alert-link\" href=\"/Berries.aspx?classification=" + calendar.Classification + "&berry=" + calendar.BerryId + " \">" + calendar.Title + "</a></span>");
						Response.Write("</div><hr class=\"hr-gray\" />");
					}
				} catch (Exception e) {
					Response.Write(e.Message);
				}
			%>
		</div>
	</div>
	<footer style="width: 100%; margin-top: 1.5em; margin-bottom: 1.5em; color: #C9C9C9; text-align: center;">
		<a href="/DevInfo.aspx" style="color: #C9C9C9;">
			<h6>2017 Copyright © Team VaryBerry All Right Reserved.</h6>
		</a>
	</footer>
</asp:Content>
