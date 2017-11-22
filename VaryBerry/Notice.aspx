<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Navbar.Master" AutoEventWireup="true" CodeBehind="Notice.aspx.cs" Inherits="VaryBerry.Notices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<!-- Background -->
	<div class="background-image">
		<div style="display: table-cell; vertical-align: middle; background-size: cover; height: 100%; width: 100%; background-color: rgba(0, 0, 0, 0.12);">
			<!-- 좌측 Contents -->
			<div style="float: left; color: white;">
				<h1 style="font-size: 4.5em; font-weight: 400; margin-left: 5vw;">BlueBerry is delicious</h1>
			</div>
			<!-- 우측 Contents -->
			<div class="jumbotron notice" style="float: right;">
				<div class="container">
					<!-- Notices -->
					<h1>공지사항 </h1>
					<!-- Under Line -->
					<hr style="border-color: blue;" />
					<%
						try {
							// Connect Database
							string connectionString = ConfigurationManager.ConnectionStrings[ "VaryBerry" ].ConnectionString;
							using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString)) {
								conn.Open();

								// Insert Data
								string sql = "INSERT INTO `Notices` (`Notice_At`, `Content`) VALUES ('" + DateTime.UtcNow.AddHours(9).Date.ToString("yyyy-MM-dd") + "', 'Test(" + DateTime.UtcNow.AddHours(9) + ")')";
								MySql.Data.MySqlClient.MySqlCommand msc = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
								msc.ExecuteNonQuery();

								// Reading Data
								sql = "SELECT * FROM Notices ORDER BY Id DESC limit 20";
								msc.CommandText = sql;
								MySql.Data.MySqlClient.MySqlDataReader rdr = msc.ExecuteReader();
								while (rdr.Read()) {
									// Write on Page
									Response.Write("<span>Content[" + rdr[ "Id" ] + "]: " + rdr[ "Content" ] + "</span><span style=\"float: right;\">[" + ((DateTime)rdr[ "Notice_At" ]).ToString("yyyy-MM-dd") + "]</span><br/>");
								}

								rdr.Close();
							}
						} catch (Exception e) {
							Response.Write(e.Message);
						}
					%>
				</div>
			</div>
		</div>
	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
