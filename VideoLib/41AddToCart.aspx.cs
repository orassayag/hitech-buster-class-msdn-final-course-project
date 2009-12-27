using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal;

public partial class _41AddToCart : System.Web.UI.Page
{
    protected Movie movie;

    //protected void Page_Init(object sender, EventArgs e)
    //{
    //    this.addCartCalender.SelectedDate = CurrentTime.TimeNow;
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["movieID"] != null)
        {
            this.movie = this.Master.VideoDB.GetMovie_MovieID(Request["movieID"]);
        }
    }
    protected void addCartCalender_SelectionChanged(object sender, EventArgs e)
    {
        if (!this.Master.LoggedInUser.IsLoggedIn())
        {
            this.errorLabel.Visible = true;
            this.errorLabel.Text = "You have to sign in or login in order to rent movies";
            return;
        }

        if (this.addCartCalender.SelectedDate == CurrentTime.TimeNow)
        {
            this.errorLabel.Visible = true;
            this.errorLabel.Text = "You can't rent a movie for less then a day";
            return;
        }

        if (Request["index"] != null)
        {
            this.Master.Cart.UpdateCartItem(int.Parse(Request["index"]), 
                             this.addCartCalender.SelectedDate);
        }
        else
        {
            this.Master.Cart.AddMovie(this.movie, 
                             this.addCartCalender.SelectedDate, "", "");
        }
        Response.Redirect("42ShowCart.aspx");
    }
}
