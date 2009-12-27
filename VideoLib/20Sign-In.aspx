<%@ Page Title="" Language="C#" MasterPageFile="~/01VideoLib.master" AutoEventWireup="true" CodeFile="20Sign-In.aspx.cs" Inherits="_20Sign_In" %>
<%@ MasterType VirtualPath="~/01VideoLib.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
<div id="signInDiv">

    <table style="width: 100%">
        <tr>
            <td style="width: 117px">
                <h2>First Name</h2></td>
            <td>
                <asp:TextBox ID="FirstName" runat="server" Width="77px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqFirstName" runat="server" 
                    Display="Dynamic" ErrorMessage="Required" ControlToValidate="FirstName"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="exFirstName" runat="server" ControlToValidate="FirstName" 
                    Display="Dynamic" ErrorMessage="Letters Only" ValidationExpression="^[a-zA-Z, ,,-,]"></asp:RegularExpressionValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 117px">
                <h2>Last Name</h2></td>
            <td>
                <asp:TextBox ID="LastName" runat="server" Width="77px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqLastName" runat="server" 
                    Display="Dynamic" ErrorMessage="Required" ControlToValidate="LastName"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="exLastName" runat="server" ControlToValidate="LastName"
                    Display="Dynamic" ErrorMessage="Letters Only" ValidationExpression="^[a-zA-Z, ,,-,]"></asp:RegularExpressionValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 117px">
                <h2>ID</h2></td>
            <td>
                <asp:TextBox ID="ID" runat="server" Width="77px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqID" runat="server" 
                    Display="Dynamic" ErrorMessage="Required" ControlToValidate="ID"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="exID" runat="server" ControlToValidate="ID"
                    Display="Dynamic" ErrorMessage="Numbers Only" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                <br />
                <asp:CustomValidator ID="cusID" runat="server" ControlToValidate="ID"
                    ErrorMessage="illegal ID" onservervalidate="cusID_ServerValidate"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 117px">
                <h2>Birth Date</h2></td>
            <td>
                &nbsp;<asp:TextBox ID="BirthDate" runat="server" Width="77px"></asp:TextBox>
                <asp:CustomValidator ID="cusBirthDate" runat="server"  ControlToValidate="BirthDate"
                    ErrorMessage="Illegal Date" onservervalidate="cusBirthDate_ServerValidate"></asp:CustomValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 117px">
                <h2>Street</h2></td>
            <td>
                <asp:TextBox ID="Street" runat="server" Width="77px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="reStreet" runat="server" ValidationExpression="^[a-zA-Z, ,,-,]" 
                    Display="Dynamic" ErrorMessage="Letters Only" ControlToValidate="Street"></asp:RegularExpressionValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 117px">
                <h2>House Number</h2></td>
            <td>
                <asp:TextBox ID="HouseNumber" runat="server" Width="37px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="exHouseNumber" ControlToValidate="HouseNumber" runat="server" ValidationExpression="^[0-9]+$" 
                    Display="Dynamic" ErrorMessage="Numbers Only"></asp:RegularExpressionValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 117px">
                <h2>City</h2></td>
            <td>
                <asp:TextBox ID="City" runat="server" Width="77px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="exCity" runat="server" ControlToValidate="City" ValidationExpression="^[a-zA-Z, ,,-,]"
                    Display="Dynamic" ErrorMessage="Letters Only"></asp:RegularExpressionValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 117px">
                <h2>Home Phone</h2></td>
            <td>
                <asp:DropDownList ID="PreHomePhone" runat="server" ForeColor="#BC7908">
                </asp:DropDownList>
            &nbsp;<asp:TextBox ID="HomePhone" runat="server" Width="91px"></asp:TextBox>
                <br />
                <asp:RegularExpressionValidator ID="exHomePhone" ControlToValidate="HomePhone" runat="server" ValidationExpression="^[0-9]{7}$" 
                    Display="Dynamic" ErrorMessage="7 Numbers Only"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 117px">
                <h2>Mobile Phone</h2></td>
            <td>
                <asp:DropDownList ID="PreMobilePhone" runat="server" ForeColor="#BC7908">
                </asp:DropDownList>
            &nbsp;<asp:TextBox ID="MobilePhone" runat="server" Width="91px"></asp:TextBox>
                <br />
                <asp:RegularExpressionValidator ID="exMobilePhone" runat="server" ControlToValidate="MobilePhone" ValidationExpression="^[0-9]{7}$"  
                    Display="Dynamic" ErrorMessage="7 Numbers Only"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rqMobilePhone" runat="server" ControlToValidate="MobilePhone" 
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 117px">
                <h2>E-Mail</h2></td>
            <td>
                <asp:TextBox ID="EMail" runat="server" Width="77px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqEMail" runat="server" ControlToValidate="EMail" 
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="exEMail" runat="server" ControlToValidate="EMail"
                    ErrorMessage="Illegal Mail" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 117px">
                <h2>Password</h2></td>
            <td>
                <asp:TextBox ID="Password1" runat="server" Width="77px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rePassword1" runat="server" ControlToValidate="Password1" 
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 117px">
                <h2>Repeat Password</h2></td>
            <td>
                <asp:TextBox ID="Password2" runat="server" Width="77px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqPassword2" runat="server" 
                    Display="Dynamic" ErrorMessage="Required" ControlToValidate="Password2"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="comPassword2" runat="server"  ControlToCompare="Password1" ControlToValidate="Password2"
                    ErrorMessage="Passwords Don't Match"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 117px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr align="center">
            <td style="width: 117px">
                <asp:Button 
                                            ID="cancelBut" runat="server" 
                    BackColor="White" ForeColor="#BC7908" 
                                Text="Cancel" ToolTip="Click To Reutrn Main Page" Width="67px" 
                                            onclick="cancelBut_Click" 
                    CausesValidation="False" />
                        
                                    </td>
            <td>
                <asp:Button 
                                            ID="signInBut" runat="server" 
                    BackColor="White" ForeColor="#BC7908" 
                                Text="Sign In!" ToolTip="Click To Sign In" Width="85px" 
                                            onclick="signInBut_Click" />
                        
                                    </td>
        </tr>
        </table>

</div>
</asp:Content>

