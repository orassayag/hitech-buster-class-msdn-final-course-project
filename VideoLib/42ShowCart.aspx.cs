using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _42ShowCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void addMoreCart_Click(object sender, EventArgs e)
    {
        if (this.Master.SecretMasterValue != "")
        {
            Response.Redirect("10Default.aspx?type" + this.Master.SecretMasterValue);
        }
        Response.Redirect("10Default.aspx");
    }
    protected void rentBut_Click(object sender, EventArgs e)
    {
        this.Master.Cart.RentCart(this.Master.LoggedInUser.memberID);
        this.Master.LoggedInUser.UpdateStatistics();
        this.beforeRentDiv.Visible = false;
        this.afterRentDiv.Visible = true;
    }
    protected void cartGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        this.Master.Cart.RemoveMovie(e.RowIndex);
        Response.Redirect("42ShowCart.aspx");
    }
    protected void cartGrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Response.Redirect("41AddToCart.aspx?movieId=" +
        this.cartGrid.Rows[e.NewEditIndex].Cells[0].Text +
        "&index=" + e.NewEditIndex);
        Response.Redirect("42ShowCart.aspx");
    }
    protected void finishBut_Click(object sender, EventArgs e)
    {
        this.beforeRentDiv.Visible = true;
        this.afterRentDiv.Visible = false;
        this.Master.Cart.RemovAll();
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        this.cartGrid.DataSource = this.Master.Cart;
        this.cartGrid.DataBind();
    }
}
