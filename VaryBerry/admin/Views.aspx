<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar-Admin.master" AutoEventWireup="true" CodeBehind="Views.aspx.cs" Inherits="VaryBerry.admin.Views" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<!-- Views -->
	<div style="width: 100%; padding-top: 50px; padding-left: 100px; padding-right: 100px; text-align: left;">
		<h3><strong>공지사항</strong></h3>
		<!-- Table Head -->
		<hr class="hr-sky" />
		<div style="text-align: center;">
			<span style="float: left; margin-left: 15px;">조회수</span>
			<span>Berry</span>
		</div>
		<hr class="hr-sky" />
		<%
			try {
				// Connect to DB;
				var conn = new MySql.Data.MySqlClient.MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString);
				conn.Open();

				List<VaryBerry.Models.Berry> berryList = new List<VaryBerry.Models.Berry>();

				// Get Notices
				string sql = "SELECT Id, Title, Classification, Views FROM berries ORDER BY Views DESC, Id;";
				MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
				cmd.CommandText = sql;

				var rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					berryList.Add(new VaryBerry.Models.Berry {
						Id = (int)rdr["Id"],
						Title = (string)rdr["Title"],
						Classification = (VaryBerry.Models.Classification)rdr["Classification"],
						Views = (int)rdr["Views"]
					});
				}

				foreach (var berry in berryList) {
					// Write on Page
					Response.Write("<div style=\"text-align: center;\">");
					Response.Write("<span style=\"float: left; margin-left: 20px;\">" + berry.Views + "</span>");
					Response.Write("<span><a class=\"alert-link\" href=\"/Berries.aspx?classification=" + berry.Classification+ "&berry=" + berry.Id + " \">" + berry.Title + "</a></span>");
					Response.Write("</div><hr class=\"hr-gray\" />");
				}
			} catch (Exception e) {
				Response.Write(e.Message);
			}
		%>
	</div>
</asp:Content>
