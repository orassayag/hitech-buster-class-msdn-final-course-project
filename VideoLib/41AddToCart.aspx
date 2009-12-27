<%@ Page Title="" Language="C#" MasterPageFile="~/01VideoLib.master" AutoEventWireup="true" CodeFile="41AddToCart.aspx.cs" Inherits="_41AddToCart" %>
<%@ MasterType VirtualPath="~/01VideoLib.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    <div id="addCartCalenderDiv" style="text-align:center">
    You chose to rent <%=this.movie.MovieName %>. Please select the date to return the movie:
    <asp:Calendar ID="addCartCalender" runat="server" 
        onselectionchanged="addCartCalender_SelectionChanged"></asp:Calendar>
    <asp:Label ID="errorLabel" runat="server" Visible="False" ForeColor="Red" 
        Font-Bold="True" EnableViewState="False"></asp:Label>
</div>
</asp:Content>


