using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal;

public partial class _40MovieDetails : System.Web.UI.Page
{
    protected Movie movie;

    protected void Page_Init(object sender, EventArgs e)
    {
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request["movieID"] != null)
        {
            Member m = this.Master.VideoDB.GetMember_MemberID
                       (this.Master.LoggedInUser.memberID);
            this.movie = this.Master.VideoDB.GetMovie_MovieID(Request["movieID"]);
            this.addReviewControl.SetControl(m, this.movie, this.Master.VideoDB);
        }
    }

    protected void addCartBut_Click(object sender, EventArgs e)
    {
        this.addToCartDiv.Visible = true;
        //Response.Redirect("41AddToCart.aspx?movieID=" + this.movie.MovieID);
    }
    protected void addReviewBut_Click(object sender, EventArgs e)
    {
        Member m = this.Master.VideoDB.GetMember_MemberID
                   (this.Master.LoggedInUser.memberID);
        this.secert.Text = this.movie.MovieID;
        this.addReviewDiv.Visible = true;
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        this.rpReviews.DataSource = this.Master.VideoDB.GetAllReviews
                                    (this.movie.MovieID);
        this.rpReviews.DataBind();

        if (this.Master.LoggedInUser.IsLoggedIn())
        {
            this.addReviewBut.Enabled = true;
            this.addReviewBut.ToolTip = "Click To Add A Review";
        }
    }
    protected void addToCartCalender_SelectionChanged(object sender, EventArgs e)
    {
        if (CurrentTime.TimeNow >= this.addToCartCalender.SelectedDate)
        {
            this.Master.Cart.AddMovie(this.movie, this.addToCartCalender.SelectedDate, "User", "");
            Response.Redirect("42ShowCart.aspx");
        }
    }
}
