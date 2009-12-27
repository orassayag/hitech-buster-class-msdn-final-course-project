<%@ Page Title="" Language="C#" MasterPageFile="~/01VideoLib.master" AutoEventWireup="true" CodeFile="52RemoveMovie.aspx.cs" Inherits="_52RemoveMovie" %>
<%@ MasterType VirtualPath="~/01VideoLib.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
<h4 style="text-align:center">Remove Movie</h4>
<div id="askMovieIDDiv" runat="server" style="width: 349px">
Please enter the movie ID of witch you would like to remove:
    <table style="width: 100%">
        <tr align="center">
            <td>
                <asp:TextBox ID="MovieID" runat="server" 
                    ToolTip="Enter The Movie ID You Wish To Remove"></asp:TextBox>
            </td>
        </tr>
        <tr align="center">
            <td>
                <asp:Button 
                                            ID="removeBut" runat="server" BackColor="White" ForeColor="#BC7908" 
                                Text="Remove" ToolTip="Click To Remove The Movie" 
                    Width="90px" onclick="removeBut_Click" />
                        
                                    <asp:Label ID="errorLabel" runat="server" 
                    EnableViewState="True" Font-Bold="True" ForeColor="#FF3300" 
                    Visible="False"></asp:Label>
                        
                                    </td>
        </tr>
    </table>

</div>
<div id="areYouSureDiv" runat="server" visible="false" 
        style="position:absolute; top: 387px; left: 224px; width: 338px;">
You chose to remove <%=this.movie.MovieID + " " +this.movie.MovieName %>. Are You Sure?
    <br />
    <table style="width: 100%">
        <tr align="center">
            <td>
                <asp:Button 
                                            ID="yesBut" runat="server" BackColor="White" ForeColor="#BC7908" 
                                Text="Yes, I'm Sure" ToolTip="Click To Remove The Movie" 
                    Width="90px" onclick="yesBut_Click" />
                        
                                    </td>
            <td>
                <asp:Button 
                                            ID="noBut" runat="server" BackColor="White" ForeColor="#BC7908" 
                                Text="Hell, No!" ToolTip="Click To Cancel This Action" 
                    Width="90px" onclick="noBut_Click" />
                        
                                    </td>
        </tr>
    </table>
</div>
<div id="afterRemoveDiv" runat="server" visible="false">
<p style="text-align:center">     
<%=this.movie.MovieID + " " + this.movie.MovieName %> Successfully removed. Note that you can reactive this movie any time you like.            
    <asp:Button 
                                            ID="okBut" runat="server" 
        BackColor="White" ForeColor="#BC7908" 
                                Text="OK" ToolTip="Click To Continue" 
                    Width="48px" onclick="okBut_Click" /></p>
                        
</div>
</asp:Content>

