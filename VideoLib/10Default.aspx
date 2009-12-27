<%@ Page Theme="HitechBuster" Title="" Language="C#" MasterPageFile="~/01VideoLib.master"
    AutoEventWireup="true" CodeFile="10Default.aspx.cs" Inherits="_10Default" %>

<%@ MasterType VirtualPath="~/01VideoLib.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="Server">
    <asp:Repeater ID="rpMovies" runat="server">
        <HeaderTemplate>
            <h2>
                <%#Eval("MovieType.MovieTypeName") %></h2>
            <br />
        </HeaderTemplate>
        <SeparatorTemplate>
            <br />
            <br />
        </SeparatorTemplate>
        <ItemTemplate>
            <a href="40MovieDetails.aspx?movieID=<%#Eval("MovieID") %>">
                <img src="<%#Eval("MoviePicUrl") %>" onmouseover="onResizePic(this)" onmouseout="offResizePic(this)"
                    alt="film" id="leftImg" /></a>
            <h4>
                <a href="40MovieDetails.aspx?movieID=<%#Eval("MovieID")%>">
                    <%#Eval("MovieName") %></a></h4>
            <%#Eval("MovieID") %>
            <br />
                <span id="oneLineSummery"><%#Eval("OneLineSummery")%> </span> 
                <span id="showMore" onmouseover="onSummery(this)" onmouseout="offSummery(this)">Show More...
                      <span id="halfSummery" style="visibility:hidden"><%#Eval("HalfSummery") %></span>
               </span>
            <%#Eval("StarRate") %>
            <h2>
                <a href="40MovieDetails.aspx?movieID=<%#Eval("MovieID") %>">Read More...</a></h2>
            </ItemTemplate>
    </asp:Repeater>
</asp:Content> 