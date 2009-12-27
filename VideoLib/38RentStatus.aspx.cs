using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal;

public partial class _38RentStatus : System.Web.UI.Page
{
    protected Member member;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["memberID"] != null)
        {
            this.member = this.Master.VideoDB.GetMember_MemberID
                          (int.Parse(Request["memberID"]));
        }
    }
}
