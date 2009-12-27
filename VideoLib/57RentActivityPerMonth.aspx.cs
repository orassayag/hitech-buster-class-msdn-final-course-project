using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _57RentActivityPerMonth : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        this.resultsDiv.Visible = false;
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

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void resultBut_Click(object sender, EventArgs e)
    {
        if (this.Day.SelectedIndex == 0 || 
            this.Month.SelectedIndex == 0 || 
            this.Year.SelectedIndex == 0)
        {
            this.errorLabel.Text = "Please Select A Full Date";
            return;
        }

        DateTime date = new DateTime(int.Parse(this.Year.Text),
                                     int.Parse(this.Month.Text),
                                     int.Parse(this.Day.Text));
        this.rentPerMonthGrid.DataSource = this.Master.VideoDB.GetRentPerMonth
                                           (CurrentTime.TimeNow, date);
        this.rentPerMonthGrid.DataBind();
        this.askForDateDiv.Visible = false;
        this.resultsDiv.Visible = true;
    }
}
