<%@ Page Language="C#" MasterPageFile="~/master/Navbar-Admin.Master" AutoEventWireup="true" CodeBehind="AddNotice.aspx.cs" Inherits="VaryBerry.AddNotice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<!-- Notices -->
	<div style="width: 100%; height: 70%; padding-top: 50px; margin-bottom: 150px; padding-left: 100px; padding-right: 100px; text-align: left;">
		<h3><strong>공지사항 등록</strong></h3>
		<hr class="hr-sky" />
		<form runat="server" style="height: 100%;">
			<!-- Title -->
			<asp:TextBox ID="nTitle" runat="server" Width="100%" />
			<br />

			<!-- Contents -->
			<asp:ScriptManager ID="BytesCountScriptManager" runat="server"></asp:ScriptManager>
			<asp:UpdatePanel runat="server" ID="BytesPanel" UpdateMode="Always" style="height: 100%;">
				<ContentTemplate>
					<fieldset style="height: 100%;">
						<asp:TextBox ID="Contents" runat="server" TextMode="MultiLine" Width="100%" Height="100%" OnTextChanged="CountBytes" AutoPostBack="true" />
						<asp:Label runat="server" ID="BytesCount" CssClass="float-left" AutoPostBack="true" />
					</fieldset>
				</ContentTemplate>
			</asp:UpdatePanel>
			<br />
			<asp:Button runat="server" CssClass="btn btn-primary float-right" OnClick="NoticeUpload" Text="등록" />
		</form>
	</div>
</asp:Content>
