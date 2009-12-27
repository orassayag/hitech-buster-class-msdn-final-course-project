<%@ Page Title="" Language="C#" MasterPageFile="~/01VideoLib.master" AutoEventWireup="true" CodeFile="54MoviesWithLongWaitingList.aspx.cs" Inherits="_54MoviesWithLongWaitingList" %>
<%@ MasterType VirtualPath="~/01VideoLib.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
<div id="askForDateDiv" runat="server" style="width: 349px">
Please enter a number of waiters to calculate all the movies:
    <table style="width: 100%">
        <tr align="center">
            <td>
                <asp:TextBox ID="Number" runat="server" 
                    ToolTip="Enter A Number Of Waiters To Get All The Movies With That Number"></asp:TextBox>
            </td>
        </tr>
        <tr align="center">
            <td>
                <asp:Button 
                                            ID="resultBut" runat="server" BackColor="White" ForeColor="#BC7908" 
                                Text="Calculate" ToolTip="Click To Get The Result" 
                    Width="90px" onclick="resultBut_Click" />
                        
                                    <asp:Label ID="errorLabel" runat="server" 
                    EnableViewState="False" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
                        
                                    </td>
        </tr>
    </table>

</div>
<div id="resultsDiv" runat="server" visible="false">
<h4 style="text-align:center">Movies With Numbers Of Waiters</h4>
    <asp:GridView ID="waitingListGrid" runat="server"
            AutoGenerateColumns="False"
            GridLines="None"
            CssClass="mGrid"
            PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt" >
        <Columns>
            <asp:BoundField DataField="MovieID" HeaderText="ID" />
            <asp:BoundField DataField="MovieName" HeaderText="Name" />
            <asp:BoundField DataField="Waiters" HeaderText="Number Of Waiters" />
        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>

<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
        </asp:GridView>
</div>
</asp:Content>

