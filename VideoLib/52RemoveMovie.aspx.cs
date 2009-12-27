using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal;

public partial class _52RemoveMovie : System.Web.UI.Page
{
    protected Movie movie;
    protected void Page_Init(object sender, EventArgs e)
    {
        this.afterRemoveDiv.Visible = false;
        this.areYouSureDiv.Visible = false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.errorLabel.Text != "")
        {
            this.movie = this.Master.VideoDB.GetMovie_MovieID(this.errorLabel.Text);
        }
    }
    protected void okBut_Click(object sender, EventArgs e)
    {
        this.askMovieIDDiv.Visible = true;
        this.errorLabel.Text = "";
    }
    protected void noBut_Click(object sender, EventArgs e)
    {
        this.areYouSureDiv.Visible = false;
    }
    protected void yesBut_Click(object sender, EventArgs e)
    {
        this.areYouSureDiv.Visible = false;
        this.Master.VideoDB.RemoveMovie(this.movie.MovieID);
        this.afterRemoveDiv.Visible = true;
    }
    protected void removeBut_Click(object sender, EventArgs e)
    {
        this.movie = this.Master.VideoDB.GetMovie_MovieID(this.MovieID.Text);
        if (this.movie == null)
        {
            this.errorLabel.Text = "Illegal ID";
            this.errorLabel.Visible = true;
            return;
        }

        if (this.movie.Active == 2)
        {
            this.errorLabel.Text = "This Movie Already Removed";
            this.errorLabel.Visible = true;
            return;
        }

        this.errorLabel.Text = this.movie.MovieID;
        this.areYouSureDiv.Visible = true;
    }
}
