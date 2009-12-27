<%@ Page Title="" Language="C#" MasterPageFile="~/01VideoLib.master" AutoEventWireup="true"
    CodeFile="40MovieDetails.aspx.cs" Inherits="_40MovieDetails" %>

<%@ MasterType VirtualPath="~/01VideoLib.master" %>
<%@ Register Src="~/43AddReview.ascx" TagName="AddReview" TagPrefix="oa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="Server">
    <div>
        <img class="leftImg" alt="" src="<%=this.movie.MoviePicUrl %>" />
        <h2>
            <%=this.movie.MovieName %></h2>
        <h6>
            <%=this.movie.MovieID %></h6>
        <%=this.movie.Summary %>
        <%=this.movie.StarRate %>
        <br />
        <%=this.movie.Lenght %>
        Minutes
        <br />
        <%=this.movie.Country.CountryName %>
        <br />
        <h2>
            With:</h2>
        <%=this.movie.Cast %>
        <br />
        <h2>
            <%=this.movie.InStock %>
            In Stock</h2>
        <br style="clear: left" />
        <table style="text-align: center; width: 100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="upAddToCart" runat="server">
                        <ContentTemplate>
                            <a href="41AddToCart.aspx?movieID=<%=this.movie.MovieID %>">
                                <img alt="" src="Images/cart.gif" style="width: 27px; height: 27px" /></a><asp:Button
                                    ID="addCartBut" runat="server" BackColor="White" ForeColor="#BC7908" Text="Add To Cart"
                                    ToolTip="Click To Add To Cart" Width="90px" OnClick="addCartBut_Click" />
                            <div id="addToCartDiv" runat="server" visible="false" style="background-color: Red;
                                position: absolute; top: 578px; left: 234px; width: 206px; height: 151px;">
                                <br />
                                Please Select When To Return The Movie:
                                <asp:Calendar ID="addToCartCalender" runat="server" OnSelectionChanged="addToCartCalender_SelectionChanged">
                                </asp:Calendar>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="upAddReviewMovieDetails" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:TextBox ID="secert" runat="server" Visible="false" Width="0px"></asp:TextBox>
                            <asp:Button ID="addReviewBut" runat="server" BackColor="White" ForeColor="#BC7908"
                                Text="Add Review" ToolTip="You Must Login To Add A Review" Width="90px" Enabled="False"
                                OnClick="addReviewBut_Click" />
                            <div id="addReviewDiv" runat="server" style="position: absolute; top: 574px; left: 216px;"
                                visible="false">
                                <oa:AddReview ID="addReviewControl" runat="server" />
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="addReviewBut" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <h4>Reviews</h4>
        <input id="hideReviews" type="button" value="Hide Reviews" onclick="onReviews(this)" />
        <div id="repeater" style="visibility:visible">
        <asp:UpdatePanel ID="upReviews" runat="server">
            <ContentTemplate>
                <asp:Repeater ID="rpReviews" runat="server">
                    <SeparatorTemplate>
                        <hr />
                    </SeparatorTemplate>
                    <ItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 278px">
                                    <h5>
                                        <a href="38RentStatus.aspx?memberID=<%#Eval("MemberID") %>">
                                            <%#Eval("MemberName") %></a></h5>
                                </td>
                                <td rowspan="2">
                                    <%#Eval("StarRate") %>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 278px">
                                    <%#Eval("ReviewText")%>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </div>
    <br />
</asp:Content>
