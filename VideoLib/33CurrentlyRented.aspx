<%@ Page Title="" Language="C#" MasterPageFile="~/01VideoLib.master" AutoEventWireup="true" CodeFile="33CurrentlyRented.aspx.cs" Inherits="_33CurrentlyRented" %>
<%@ MasterType VirtualPath="~/01VideoLib.master" %>
<%@ Register Src="~/43AddReview.ascx" TagName="AddReview" TagPrefix="oa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    <div id="gridDiv" runat="server" style="width: 100%">
<h4 style="text-align:center">Currently Rented</h4>
    <asp:GridView ID="currentlyGrid" runat="server"
            AutoGenerateColumns="False"
            GridLines="None"
            CssClass="mGrid"
            PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt" 
        onrowediting="currentlyGrid_RowEditing">
        <Columns>
            <asp:BoundField DataField="MovieID" HeaderText="ID" />
            <asp:BoundField DataField="MovieName" HeaderText="Name" />
            <asp:BoundField DataField="RentStartToString" HeaderText="Rent Start" />
            <asp:BoundField DataField="RentUntilToString" HeaderText="Rent Until" />
            <asp:BoundField DataField="IsPastDu" HeaderText="Is Past Du?" />
            <asp:BoundField DataField="PastDays" HeaderText="Past Days" />
            <asp:CommandField CancelText="" DeleteText="" EditText="Return Movie" 
                ShowCancelButton="False" ShowEditButton="True" />
        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>

<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
        </asp:GridView>
</div>
    <asp:UpdatePanel ID="upReview" runat="server">
    <ContentTemplate>
<div id="askForReviewDiv" runat="server" visible="false">
Thank you for choosing Hi-Tech Buster. We hope you enjoyed the movie.
In order to improve our movie collection, we would like to ask you to
take a few moment of your time and add your review on the movie you just
returned.
    <asp:Label ID="a" runat="server" Visible="False"></asp:Label>
    <br />
    <table style="width: 100%">
        <tr align="center">
            <td>
                <asp:Button 
                                            ID="yesBut" runat="server" BackColor="White" ForeColor="#BC7908" 
                                Text="Yes, Please" ToolTip="Click To Add A Review" Width="90px" 
                                            onclick="yesBut_Click" />
                        
                                    </td>
            <td>
                <asp:Button 
                                            ID="noBut" runat="server" BackColor="White" ForeColor="#BC7908" 
                                Text="No, Thanks" 
                    ToolTip="Click To Continue Without Reviewing" Width="90px" 
                                            onclick="noBut_Click" />
                        
                                    </td>
        </tr>
    </table>
</div>
    <div id="addReviewDiv" runat="server" visible="false" 
        style="position:absolute; top: 461px; left: 221px;">
<oa:AddReview ID="addReviwControl" runat="server" />
</div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

