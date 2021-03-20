using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _53PastDueDate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.pastDueDateGrid.DataSource = this.Master.VideoDB.GetAllPastDueDates
                                         (CurrentTime.TimeNow);
        this.DataBind();
    }
}
