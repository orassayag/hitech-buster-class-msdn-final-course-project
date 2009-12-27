<%@ Control Language="C#" AutoEventWireup="true" CodeFile="43AddReview.ascx.cs" Inherits="_43AddReview" %>
<style type="text/css">
    .style1
    {
        width: 52%;
    }
    #secretValue
    {
        width: 0px;
    }
</style>
<div id="reviewControlDiv" runat="server" style="background-color: White; font-size: 12px; font-family: Arial, Helvetica, sans-serif">
    <table class="style1">
        <tr>
            <td colspan="2">
            Select Rate: 
                <img id="star1" alt="star1" src="Images/starempty.gif" onclick="rate(this)" onmouseover="onStar(this)" onmouseout="offStar(this)" />
                <img id="star2" alt="star2" src="Images/starempty.gif" onclick="rate(this)" onmouseover="onStar(this)" onmouseout="offStar(this)" />
                <img id="star3" alt="star3" src="Images/starempty.gif" onclick="rate(this)" onmouseover="onStar(this)" onmouseout="offStar(this)" />
                <img id="star4" alt="star4" src="Images/starempty.gif" onclick="rate(this)" onmouseover="onStar(this)" onmouseout="offStar(this)" />
                <img id="star5" alt="star5" src="Images/starempty.gif" onclick="rate(this)" onmouseover="onStar(this)" onmouseout="offStar(this)" /> &nbsp;
<%--                <asp:DropDownList ID="Rate" runat="server" ForeColor="#BC7908">
                    <asp:ListItem Selected="True">Select Rate</asp:ListItem>
                    <asp:ListItem Value="1">1 Stars</asp:ListItem>
                    <asp:ListItem Value="2">2 Srars</asp:ListItem>
                    <asp:ListItem Value="3">3 Stars</asp:ListItem>
                    <asp:ListItem Value="4">4 Stars</asp:ListItem>
                    <asp:ListItem Value="5">5 Stars</asp:ListItem>
                </asp:DropDownList>--%>
                <asp:Label ID="lblCar" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="Review" runat="server" Height="144px" TextMode="MultiLine" 
                    Width="415px"></asp:TextBox>
                <br />
                <asp:Label ID="errorLabel" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                    Visible="False"></asp:Label>
            </td>
        </tr>
        <tr align="center">
            <td>
                <asp:Button ID="addBut" runat="server" BackColor="White" ForeColor="#BC7908" 
                                Text="Add Review" ToolTip="Click To AddThe Review" 
                    Width="90px" onclick="addBut_Click" />
                        
                                    </td>
            <td>
                <asp:Button ID="cancelBut" runat="server" BackColor="White" ForeColor="#BC7908" 
                                Text="Cancel" ToolTip="Click To Continue Without Reviewing" 
                    Width="90px" onclick="cancelBut_Click" />
                        
                                    </td>
        </tr>
    </table>
</div>