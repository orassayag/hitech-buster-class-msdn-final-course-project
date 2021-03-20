<%@ Page Title="" Language="C#" MasterPageFile="~/01VideoLib.master" AutoEventWireup="true" CodeFile="38RentStatus.aspx.cs" Inherits="_38RentStatus" %>
<%@ MasterType VirtualPath="~/01VideoLib.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
<div id="rentStatus" style="text-align:center">
<h1><%=this.member.FullName %></h1>
<h5><%=this.member.MemberID %></h5>
<h4>Currently Rented: <%=this.member.CurrentlyRentedCount%></h4>
<br />
<h4>Day Balance: <%=this.member.DaysBalance %></h4>
<br />
<h4>Past Due Date: <%=this.member.PastDueDateCount(CurrentTime.TimeNow) %></h4>
</div>
</asp:Content>

