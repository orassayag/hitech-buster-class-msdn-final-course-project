using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Dal;

public partial class _43AddReview : System.Web.UI.UserControl
{
    protected Movie movie;
    protected Member member;
    protected DataCache videoDB;

    protected void Page_Load(object sender, EventArgs e)
    {
       // HtmlGenericControl g = new HtmlGenericControl();
       //Control h = g.FindControl("secretValue1");
    }

    protected void addBut_Click(object sender, EventArgs e)
    {
        if (this.Review.Text == "")
        {
            this.errorLabel.Visible = true;
            this.errorLabel.Text = "Can't send an empty review";
            return;
        }
        //HtmlGenericControl g = new HtmlGenericControl();
        //g.FindControl("secretValue1");

        if (int.Parse(this.lblCar.Text) == 0)
        {
            this.errorLabel.Visible = true;
            this.errorLabel.Text = "Please rate the movie";
            return;
        }

        this.videoDB.AddReview(this.member.MemberID,
                               this.movie.MovieID,
                               this.Review.Text,
                               byte.Parse(this.lblCar.Text));
        this.reviewControlDiv.Visible = false;
    }
    protected void cancelBut_Click(object sender, EventArgs e)
    {
        this.reviewControlDiv.Visible = false;
    }

    public void SetControl(Member member, Movie movie, DataCache videoDB)
    {
        this.movie = movie;
        this.member = member;
        this.videoDB = videoDB;
    }
}
