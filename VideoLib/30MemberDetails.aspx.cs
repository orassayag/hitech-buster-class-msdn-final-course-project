using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal;

public partial class _30MemberDetails : System.Web.UI.Page
{
    protected Member member;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.member = this.Master.VideoDB.GetMember_MemberID
                     (this.Master.LoggedInUser.memberID);
    }
    protected void changeDetailsBut_Click(object sender, EventArgs e)
    {
        Response.Redirect("20Sign-In.aspx?change=true");
    }
    protected void okBut_Click(object sender, EventArgs e)
    {
        Response.Redirect("10Default.aspx");
    }
}
