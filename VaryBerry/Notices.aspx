<%@ Page Title="" Language="C#" MasterPageFile="~/master/Navbar.Master" AutoEventWireup="true" CodeBehind="Notices.aspx.cs" Inherits="VaryBerry.Notice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<%/*
try {
// Connect Database
string connectionString = ConfigurationManager.ConnectionStrings["VaryBerry"].ConnectionString;
using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString)) {
	conn.Open();

	// Insert Data
	string sql = "INSERT INTO `Notices` (`Notice_At`, `Content`) VALUES ('" + DateTime.UtcNow.AddHours(9).Date.ToString("yyyy-MM-dd") + "', 'Test(" + DateTime.UtcNow.AddHours(9) + ")')";
	MySql.Data.MySqlClient.MySqlCommand msc = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
	msc.ExecuteNonQuery();

	// Reading Data
	sql = "SELECT * FROM Notices ORDER BY Id DESC limit 4";
	msc.CommandText = sql;
	MySql.Data.MySqlClient.MySqlDataReader rdr = msc.ExecuteReader();
	while (rdr.Read()) {
		// Write on Page
		Response.Write("<span>" + rdr["Content"] + "</span><span style=\"float: right;\">" + ((DateTime)rdr["Notice_At"]).ToString("yyyy-MM-dd") + "</span><br>");
	}

	rdr.Close();
}
} catch (Exception e) {
Response.Write(e.Message);
}*/
	%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
