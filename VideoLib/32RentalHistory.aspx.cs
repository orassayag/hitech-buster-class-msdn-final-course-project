using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _32RentalHistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.rentalHistoryGrid.DataSource = this.Master.VideoDB.RentalHistoryRents
                          (this.Master.LoggedInUser.memberID, CurrentTime.TimeNow);
        this.rentalHistoryGrid.DataBind();
    }
}
