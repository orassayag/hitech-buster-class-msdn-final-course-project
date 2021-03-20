using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal;

public partial class _33CurrentlyRented : System.Web.UI.Page
{
    public string SecretValue
    {
        get { return this.a.Text; }
        set { this.a.Text = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.SecretValue != "")
        {
            Member m = this.Master.VideoDB.GetMember_MemberID
                       (this.Master.LoggedInUser.memberID);
            this.addReviewControl.SetControl(m,
            this.Master.VideoDB.GetMovie_MovieID(this.SecretValue), this.Master.VideoDB);
        }
    }
    protected void currentlyGrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Movie m = this.Master.VideoDB.GetMovie_MovieID
                  (this.currentlyGrid.Rows[e.NewEditIndex].Cells[0].Text);
        this.Master.VideoDB.Return(this.Master.LoggedInUser.memberID, m.MovieID,
                            CurrentTime.TimeNow);
        this.Master.LoggedInUser.UpdateStatistics();
        this.SecretValue = m.MovieID;
        this.askForReviewDiv.Visible = true;
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        this.currentlyGrid.DataSource = this.Master.VideoDB.CurrentlyRented
                                       (this.Master.LoggedInUser.memberID,CurrentTime.TimeNow);
        this.currentlyGrid.DataBind();
    }
    protected void yesBut_Click(object sender, EventArgs e)
    {
        this.askForReviewDiv.Visible = false;
        this.addReviewDiv.Visible = true;
    }
    protected void noBut_Click(object sender, EventArgs e)
    {
        this.askForReviewDiv.Visible = false;
    }
}
