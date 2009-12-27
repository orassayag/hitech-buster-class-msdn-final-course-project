<%@ Page Title="" Language="C#" MasterPageFile="~/01VideoLib.master" AutoEventWireup="true" CodeFile="42ShowCart.aspx.cs" Inherits="_42ShowCart" %>
<%@ MasterType VirtualPath="~/01VideoLib.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    <div id="cartDiv" style=" text-align:center; width: 100%">
<h4 style="text-align:center; width: 484px;"><img alt="" src="Images/cart.gif" />Your Cart </h4>
                        
                                    
    <asp:GridView ID="cartGrid" runat="server"
            AutoGenerateColumns="False"
            GridLines="None"
            CssClass="mGrid"
            PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt" 
        onrowediting="cartGrid_RowEditing" 
        onrowdeleting="cartGrid_RowDeleting">
        <Columns>
            <asp:BoundField DataField="MovieID" HeaderText="ID" />
            <asp:BoundField DataField="MovieName" HeaderText="Name" />
            <asp:BoundField DataField="RentUntilToString" HeaderText="Rent Until" />
            <asp:BoundField DataField="Days" HeaderText="Rent Days" />
            <asp:BoundField DataField="AddedBy" HeaderText="Added By" />
            <asp:BoundField DataField="RentStatus" HeaderText="Rent Status" />
            <asp:CommandField CancelText="" DeleteText="Remove" EditText="Update" 
                ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" />
        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>

<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
        </asp:GridView>
        
</div>
<div id="beforeRentDiv" runat="server">
    <table style="width: 100%; margin-bottom: 0px;">
        <tr align="center">
            <td>
                <asp:Button 
                                            ID="rentBut" runat="server" BackColor="White" ForeColor="#BC7908" 
                                Text="Rent Movies" 
                    ToolTip="Click To Rent All The Movies In The Cart" Width="90px" 
                                            onclick="rentBut_Click" />
                        
                                    </td>
            <td>
                <asp:Button 
                                            ID="addMoreCart" runat="server" BackColor="White" ForeColor="#BC7908" 
                                Text="Add More" 
                    ToolTip="Click To Add More Movies To Your Cart" Width="90px" 
                                            onclick="addMoreCart_Click" />
                        
                                    </td>
        </tr>
    </table>
    </div>
    <div id="afterRentDiv" runat="server" visible="false" style="text-align:center">
                    <asp:Button 
                                            ID="finishBut" runat="server" 
        BackColor="White" ForeColor="#BC7908" 
                                Text="Complete Process" 
                    ToolTip="Click To Finish Rent Process" Width="131px" onclick="finishBut_Click" 
                                             />                     
    </div>
</asp:Content>

