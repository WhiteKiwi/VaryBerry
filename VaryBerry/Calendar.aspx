<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="VaryBerry.Calendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<!-- Top-Image -->
	<div class="background-image-long" style="width: 100%; height: 40%;"></div>

	<form runat="server" style="padding: 0 10% 0 10%;">
		<h4 style="text-align: left; margin: 4% 0 0 5%">달력</h4>
		<br />
		<br />
		<asp:Calendar ID="CNSACalendar" runat="server" BorderStyle="Solid" BorderColor="white" CellPadding="30" ShowGridLines="True" Width="100%">

			<NextPrevStyle Font-Bold="true" ForeColor="#2E9AFE" Font-Size="XX-Large" Width="10%" HorizontalAlign="Left" />
			<TitleStyle BackColor="White" ForeColor="Black" Font-Size="X-Large" Height="100%"></TitleStyle>
			<DayHeaderStyle CssClass="border border-primary border-left-0 border-right-0" />
			<DayStyle BackColor="white" ForeColor="Black"></DayStyle>
			<OtherMonthDayStyle ForeColor="LightGray"></OtherMonthDayStyle>
			<SelectedDayStyle BackColor="LightGray" Font-Bold="True"></SelectedDayStyle>
			<WeekendDayStyle ForeColor="Red" />

		</asp:Calendar>
	</form>

	<footer style="width: 100%; margin-top: 1.5em; margin-bottom: 1.5em; color: #C9C9C9; text-align: center;">
		<a href="/DevInfo.aspx" style="color: #C9C9C9;">
			<h5>2017 Copyright © Team VaryBerry All Right Reserved.</h5>
		</a>
	</footer>
</asp:Content>
