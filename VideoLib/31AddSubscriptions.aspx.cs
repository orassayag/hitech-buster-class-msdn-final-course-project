using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class _31AddSubscriptions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void addBut_Click(object sender, EventArgs e)
    {
        short d = 0;
        if (short.TryParse(this.Days.Text, out d))
        {
            if (d <= 0)
            {
                this.errorLabel.Text = "Bigger Than 0";
                return;
            }

            this.Master.VideoDB.AddSubscriptions
                (this.Master.LoggedInUser.memberID, d);
            this.Master.LoggedInUser.UpdateStatistics();
            this.errorLabel.ForeColor = Color.Blue;
            this.errorLabel.Text = string.Format("You Now Have {0} Days",
                                   this.Master.LoggedInUser.dayBalance);

        }
        else
        {
            this.errorLabel.Text = "Numbers Only";
        }
    }
}
