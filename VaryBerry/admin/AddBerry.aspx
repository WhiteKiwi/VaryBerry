<%@  Language="C#" MasterPageFile="~/master/Navbar-Admin.master" AutoEventWireup="true" CodeBehind="AddBerry.aspx.cs" Inherits="VaryBerry.AddBerry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<!-- Berries -->
	<div style="width: 100%; height: 70%; padding-top: 50px; margin-bottom: 150px; padding-left: 100px; padding-right: 100px; text-align: left;">
		<h3><strong>Berry 추가</strong></h3>
		<hr class="hr-sky" />
		<form runat="server" style="height: 100%;">
			<div style="float: left; margin-left: 50px; margin-right: 30px;">
				<h4>분류 선택</h4>
				<br />
				<br />
				<h4>제목</h4>
				<br />
				<br />
				<h4>내용</h4>
			</div>
			<div style="float: left; width: 70%; width: calc(100% - 300px); height: 70%;">
				<asp:DropDownList runat="server" ID="ClassificationList" CssClass="custom-select">
				</asp:DropDownList>

				<br />
				<br />
				<br />

				<!-- Title -->
				<asp:TextBox ID="nTitle" runat="server" Width="100%" />

				<br />
				<br />
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
				<asp:Button runat="server" CssClass="btn btn-primary float-right" OnClick="BerryUpload" Text="등록" />
			</div>
		</form>
	</div>
</asp:Content>
