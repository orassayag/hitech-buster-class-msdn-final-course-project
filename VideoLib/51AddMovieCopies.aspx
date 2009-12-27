<%@ Page Title="" Language="C#" MasterPageFile="~/01VideoLib.master" AutoEventWireup="true" CodeFile="51AddMovieCopies.aspx.cs" Inherits="_51AddMovieCopies" %>
<%@ MasterType VirtualPath="~/01VideoLib.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
<div id="askForCopiesDiv" runat="server" style="width: 349px">
Please enter Movie ID and a number of copies to add:
    <table style="width: 100%">
        <tr align="center">
            <td>
                <h2>Member ID</h2>
                <asp:TextBox ID="MovieID" runat="server" 
                    ToolTip="Enter A Number Of Waiters To Get All The Movies With That Number"></asp:TextBox>
            &nbsp;</td>
            <td>
                <h2>Number Of Copies</h2>
                <asp:TextBox ID="Copies" runat="server" 
                    ToolTip="Enter A Number Of Copies To Add"></asp:TextBox>
            </td>
        </tr>
        <tr align="center">
            <td colspan="2">
                <asp:Button 
                                            ID="addBut" runat="server" BackColor="White" ForeColor="#BC7908" 
                                Text="Add Copies" ToolTip="Click To Add Copies" 
                    Width="90px" onclick="addBut_Click" />
                        
                                    <asp:Label ID="errorLabel" runat="server" 
                    EnableViewState="False" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
                        
                                    </td>
        </tr>
    </table>
</div>
</asp:Content>

