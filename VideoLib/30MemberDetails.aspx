<%@ Page Title="" Language="C#" MasterPageFile="~/01VideoLib.master" AutoEventWireup="true" CodeFile="30MemberDetails.aspx.cs" Inherits="_30MemberDetails" %>
<%@ MasterType VirtualPath="~/01VideoLib.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
<div id="memberDetailsDiv" style="height: 328px">
<img alt="" src="" class="leftImg" />
<h1><%=this.member.FullName %></h1>
<h2>Member ID:</h2> <%=this.member.MemberID %>
<h2>Member Level:</h2> <%=this.member.MemberLevel %>
<h2>First Name:</h2> <%=this.member.FirstName %>
<h2>Last Name:</h2> <%=this.member.LastName %>
<h2>ID:</h2> <%=this.member.ID %>
<% if (this.member.BirthDate.HasValue) %>
<h2>Birth Day:</h2> <%=this.member.BirthDate.Value.ToShortDateString() %>
<h2>Street:</h2> <%=this.member.Street %>
<h2>House Number:</h2> <%=this.member.HouseNumber %>
<h2>&nbsp;</h2>
<h2>City:</h2> <%=this.member.City %>
<h2>Home Phone:</h2> <%=this.member.HomePhone %>
<h2>Mobile Phone:</h2> <%=this.member.MobilePhone %>
<h2>E-Mail:</h2> <%=this.member.Email %>
<h2>Password:</h2> <%=this.member.Password %>
<h2>Member Since:</h2> <%=this.member.MemberSince.ToShortDateString() %>
<h2>Day Balance:</h2> <%=this.member.DaysBalance %>
<h2>Currently Rented:</h2> <%=this.member.CurrentlyRentedCount %>
<h2>Past Du Date:</h2> <%=this.member.PastDuDateCount(CurrentTime.TimeNow) %>
    <table style="width: 100%">
        <tr align="center">
            <td>
                <asp:Button 
                                            ID="changeDetailsBut" runat="server" 
                    BackColor="White" ForeColor="#BC7908" 
                                Text="Change Details" ToolTip="Click To Change Details" Width="99px" 
                                            onclick="changeDetailsBut_Click" />
                        
                                    </td>
            <td>
                <asp:Button 
                                            ID="okBut" runat="server" BackColor="White" ForeColor="#BC7908" 
                                Text="OK" ToolTip="Click To Continue" Width="90px" 
                                            onclick="okBut_Click" />
                        
                                    </td>
        </tr>
    </table>
</div>
</asp:Content>

