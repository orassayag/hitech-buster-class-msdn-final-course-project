<%@ Page Title="" Language="C#" MasterPageFile="~/01VideoLib.master" AutoEventWireup="true" CodeFile="53PastDuDate.aspx.cs" Inherits="_53PastDuDate" %>
<%@ MasterType VirtualPath="~/01VideoLib.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    <div id="resultsDiv" runat="server">
<h4 style="text-align:center; width: 398px;">Past Du Date</h4>
    <asp:GridView ID="pastDuDateGrid" runat="server"
            AutoGenerateColumns="False"
            GridLines="None"
            CssClass="mGrid"
            PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt" >
        <Columns>
            <asp:BoundField DataField="MovieID" HeaderText="Movie ID" />
            <asp:BoundField DataField="MovieName" HeaderText="Movie Name" />
            <asp:BoundField DataField="MemberID" HeaderText="Member ID" />
            <asp:BoundField DataField="MemberName" HeaderText="Member Name" />
            <asp:BoundField DataField="RentStartToString" HeaderText="Rent Start" />
            <asp:BoundField DataField="RentUntilToString" HeaderText="Rent Until" />
            <asp:BoundField DataField="PastDays" HeaderText="Past Days" />
        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>

<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
        </asp:GridView>
</div>
</asp:Content>

