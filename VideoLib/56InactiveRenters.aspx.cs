using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _56InactiveRenters : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        this.resultsDiv.Visible = false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 1, y = 1980; y <= CurrentTime.TimeNow.Year; i++, y++)
        {
            ListItem dm = new ListItem(i.ToString(), i.ToString());
            ListItem g = new ListItem(y.ToString(), y.ToString());
            if (i <= 30)
            {
                this.Day.Items.Add(dm);
            }
            if (i <= 12)
            {
                this.Month.Items.Add(dm);
            }
            this.Year.Items.Add(g);
        }
    }
    protected void resultBut_Click(object sender, EventArgs e)
    {
        if (this.Day.SelectedIndex == 0 || 
            this.Month.SelectedIndex == 0 || 
            this.Year.SelectedIndex == 0)
        {
            this.errorLabel.Text = "Please Select Full Date";
            return;
        }

        DateTime date = new DateTime(int.Parse(this.Year.SelectedValue),
                                     int.Parse(this.Month.SelectedValue),
                                     int.Parse(this.Day.SelectedValue));
        this.inactiveRentersGrid.DataSource = 
            this.Master.VideoDB.GetInactiveRenters(date);
        this.inactiveRentersGrid.DataBind();
        this.resultsDiv.Visible = true;
        this.askForDateDiv.Visible = false;
    }
}
