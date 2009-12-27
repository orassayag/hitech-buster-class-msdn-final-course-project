using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _34Reviews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.rpReviews.DataSource = this.Master.VideoDB.GetMemberReviews
                                    (this.Master.LoggedInUser.memberID);
        this.rpReviews.DataBind();
    }
}
