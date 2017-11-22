<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Navbar.Master" AutoEventWireup="true" CodeBehind="AddNotice.aspx.cs" Inherits="VaryBerry.Admin.AddNotice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
	<div class="jumbotron">
		<div class="container">
			<h1>공지 등록</h1>
			<form name="AddNotice" runat="server">
				<br />
				<%-- Notice Info --%>
				<asp:Table ID="Table" runat="server" Style="margin: auto; border-collapse: collapse;">
					<%-- Title --%>
					<asp:TableRow>
						<asp:TableCell><strong>[ 제목 ]</strong></asp:TableCell>
						<asp:TableCell>
							<asp:TextBox ID="NoticeTitle" runat="server" CssClass="form-control" Style="width: 40em;"></asp:TextBox>
							<asp:RequiredFieldValidator ID="valTitle" runat="server" ErrorMessage="제목을 작성해 주세요." ControlToValidate="txtName" Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
						</asp:TableCell>
					</asp:TableRow>
					<%-- Content --%>
					<asp:TableRow>
						<asp:TableCell Style="vertical-align: text-top"><strong>[ 내용 ]</strong></asp:TableCell>
						<asp:TableCell>
							<asp:TextBox ID="NoticeContent" runat="server" TextMode="MultiLine" CssClass="form-control" Style="width: 40em;" Rows="15"></asp:TextBox>
							<asp:RequiredFieldValidator ID="valContent" runat="server" ErrorMessage="제목을 작성해 주세요." ControlToValidate="txtName" Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
						</asp:TableCell>
					</asp:TableRow>
					<%-- UploadFile --%>
					<asp:TableRow>
						<asp:TableCell Style="vertical-align: text-top"><strong>[ 파일 첨부 ]</strong></asp:TableCell>
						<asp:TableCell>
							<asp:Button ID="FileUploadButton" runat="server" OnClick="FileUploadButton_Click" Text="File Upload"></asp:Button>
							<br />
							<asp:Panel ID="FilePanel" runat="server" Visible="false">
								<input id="txtFileName" type="file" name="txtFileName" runat="server" />
								<asp:Label ID="FileNamePreviousLabel" runat="server" Text="" Visible="false"></asp:Label>
							</asp:Panel>
						</asp:TableCell>
					</asp:TableRow>
					<%-- Encoding --%>
					<asp:TableRow>
						<asp:TableCell><strong>[ 인코딩 ]</strong></asp:TableCell>
						<asp:TableCell>
							<asp:RadioButtonList ID="EncodingMethod" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="Text" Selected="True">Text</asp:ListItem>
								<asp:ListItem Value="HTML"></asp:ListItem>
								<asp:ListItem Value="Mixed"></asp:ListItem>
							</asp:RadioButtonList>
						</asp:TableCell>
					</asp:TableRow>
				</asp:Table>
				<br />
				<%-- Buttons --%>
				<asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="SaveButton_Click" />
				<asp:Button ID="CancelButton" runat="server" Text="Cancel" CssClass="btn btn-light" OnClick="CancelButton_Click" />
				<br />
				<asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="false" ShowMessageBox="true" DisplayMode="List" />
				<br />
			</form>
		</div>
	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
