<%@ Page Title="" Language="C#" MasterPageFile="~/01VideoLib.master" AutoEventWireup="true" CodeFile="34Reviews.aspx.cs" Inherits="_34Reviews" %>
<%@ MasterType VirtualPath="~/01VideoLib.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
<div id="reviewsDiv">
    <asp:Repeater ID="rpReviews" runat="server">
    <HeaderTemplate>
    <h1 style="text-align:center">Reviews</h1>
    </HeaderTemplate>
    <SeparatorTemplate>
        <hr />
    </SeparatorTemplate>
    <ItemTemplate>
        <div id="leftImage">
<img id="leftImg" alt="film" src="<%#Eval("MoviePicUrl") %>" />
<h4><%#Eval("MovieName") %></h4>
<h6><%#Eval("MovieID") %></h6>
<h2>Rate:</h2> <%#Eval("StarRate") %>
<br style="clear:left" />
<%#Eval("ReviewText")%>
</div>
    </ItemTemplate>
    </asp:Repeater>
</div>
</asp:Content>

