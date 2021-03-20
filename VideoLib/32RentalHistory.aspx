<%@ Page Title="" Language="C#" MasterPageFile="~/01VideoLib.master" AutoEventWireup="true" CodeFile="32RentalHistory.aspx.cs" Inherits="_32RentalHistory" %>
<%@ MasterType VirtualPath="~/01VideoLib.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    <div id="gridDiv" runat="server" style="width: 341px">
<h4 style="text-align:center; width: 341px;">Rental History</h4>
    <asp:GridView ID="rentalHistoryGrid" runat="server"
            AutoGenerateColumns="False"
            GridLines="None"
            CssClass="mGrid"
            PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt" >
        <Columns>
            <asp:BoundField DataField="MovieID" HeaderText="ID" />
            <asp:BoundField DataField="MovieName" HeaderText="Name" />
            <asp:BoundField DataField="RentStartToString" HeaderText="Rent Start" />
            <asp:BoundField DataField="RentEndToString" HeaderText="Rent End" />
            <asp:BoundField DataField="IsPastDue" HeaderText="Is Past Due?" />
            <asp:BoundField DataField="Days" HeaderText="Rent Days" />
        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>

<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
        </asp:GridView>
</div>
</asp:Content>

