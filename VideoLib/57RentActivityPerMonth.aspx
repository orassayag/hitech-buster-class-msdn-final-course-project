<%@ Page Title="" Language="C#" MasterPageFile="~/01VideoLib.master" AutoEventWireup="true" CodeFile="57RentActivityPerMonth.aspx.cs" Inherits="_57RentActivityPerMonth" %>
<%@ MasterType VirtualPath="~/01VideoLib.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
<div id="askForDateDiv" runat="server" style="width: 70%">
Please select the date to start calculating rent activity per month:
    <table style="width: 100%">
        <tr align="center">
            <td>
                <asp:DropDownList ID="Day" runat="server" ForeColor="#BC7908" 
                    ToolTip="Select The Day">
                    <asp:ListItem Selected="True">Day</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="Month" runat="server" ForeColor="#BC7908">
                    <asp:ListItem Selected="True">Month</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="Year" runat="server" ForeColor="#BC7908">
                    <asp:ListItem Selected="True">Year</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr align="center">
            <td colspan="3">
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
<div id="resultsDiv" runat="server" visible="false" style=" text-align:center; width: 50%">
<h4 style="text-align:center">Rent Per Month</h4>
    <asp:GridView ID="rentPerMonthGrid" runat="server"
            AutoGenerateColumns="False"
            GridLines="None"
            CssClass="mGrid"
            PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt" Width="80%" >
        <Columns>
            <asp:BoundField DataField="MonthName" HeaderText="Month" />
            <asp:BoundField DataField="Rents" HeaderText="Number Of Rents" />
        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>

<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
        </asp:GridView>
</div>
</asp:Content>

