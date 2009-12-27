<%@ Page Title="" Language="C#" MasterPageFile="~/01VideoLib.master" AutoEventWireup="true" CodeFile="31AddSubscriptions.aspx.cs" Inherits="_31AddSubscriptions" %>
<%@ MasterType VirtualPath="~/01VideoLib.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
<div id="askForSubscriptionsDiv" runat="server" style="width: 349px">
Please a number of days to add:
    <table style="width: 100%">
        <tr align="center">
        <td>
                <h2>Number Of Days</h2>
                <asp:TextBox ID="Days" runat="server" 
                    ToolTip="Enter A Number Of Days To Add"></asp:TextBox>
            </td>
        </tr>
        <tr align="center">
            <td colspan="2">
                <asp:Button 
                                            ID="addBut" runat="server" BackColor="White" ForeColor="#BC7908" 
                                Text="Add Days" ToolTip="Click To Add Days" 
                    Width="90px" onclick="addBut_Click" />
                        
                                    <asp:Label ID="errorLabel" runat="server" 
                    EnableViewState="False" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
                        
                                    </td>
        </tr>
    </table>
</div>
</asp:Content>

