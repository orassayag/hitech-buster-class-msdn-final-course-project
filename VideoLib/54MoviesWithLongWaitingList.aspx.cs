using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _54MoviesWithLongWaitingList : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        this.resultsDiv.Visible = false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void resultBut_Click(object sender, EventArgs e)
    {
        int d = 0;
        if (int.TryParse(this.Number.Text, out d))
        {
            if (d <= 0)
            {
                this.errorLabel.Text = "Larger Than 0";
                return;
            }

            this.waitingListGrid.DataSource =
                this.Master.VideoDB.GetMoviesWithWaiters(d);
            this.waitingListGrid.DataBind();
            this.resultsDiv.Visible = true;
            this.askForDateDiv.Visible = false;
        }
        else
        {
            this.errorLabel.Text = "Numbers Only";
        }
    }
}
