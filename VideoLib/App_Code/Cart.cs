using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using Dal;

/// <summary>
/// Summary description for Cart
/// </summary>
public class Cart: IEnumerable<CartItem>
{
    private List<CartItem> itemList;
    private HttpRequest request;
    private HttpResponse response;
    private DataCache videoDB;

    public Cart(DataCache videoDB, HttpRequest request, HttpResponse response) : 
        this(videoDB, request, response, 10) { }

    public Cart(DataCache videoDB, HttpRequest request, HttpResponse response, int listSize)
    {
        this.itemList = new List<CartItem>(listSize);
        this.request = request;
        this.response = response;
        this.videoDB = videoDB;

        if (this.request.Cookies["Cart"] != null)
        {
            HttpCookie cart = this.request.Cookies["Cart"];

            for (int i = 0; i < cart.Values.Count; i++)
            {
                if (cart[i.ToString()] != null)
                {
                    string[] details = cart[i.ToString()].Split(',');
                    Movie m = this.videoDB.GetMovie_MovieID(details[0]);
                    DateTime d = DateTime.Parse(details[1]);
                    this.AddMovie(m, d, details[2], details[3]);
                }
            }
        }
    }

    public void UpdateCart()
    {
        if (this.response.Cookies["Cart"] != null)
        {
            this.response.Cookies["Cart"].Value = null;
        }

        HttpCookie cart = new HttpCookie("Cart");

        for (int i = 0; i < this.itemList.Count; i++)
        {
            cart[i.ToString()] = this.itemList[i].ToString();
        }

        this.response.Cookies.Add(cart);
    }

    public void AddMovie(Movie m, DateTime rentUntil, string addedBy, string rentStatus)
    {
        if (!this.itemList.Exists(g => g.MovieID == m.MovieID))
        {
            this.itemList.Add(new CartItem(m,rentUntil,addedBy,rentStatus));
            this.UpdateCart();
        }
    }

    public void RemoveMovie(int index)
    {
        CartItem c = this.itemList.ElementAtOrDefault(index);
        if (c != null)
        {
            this.itemList.RemoveAt(index);
            this.UpdateCart();
        }
    }

    public void RemovAll()
    {
        this.itemList.Clear();
        this.response.Cookies["Cart"].Value = null;
        this.UpdateCart();
    }

    public void UpdateCartItem(int index, DateTime rentUntil)
    {
        CartItem c = this.itemList.ElementAtOrDefault(index);
        if (c != null && rentUntil != default(DateTime))
        {
            this.itemList[index].UpdateRentUntil(rentUntil);
            this.UpdateCart();
        }
    }

    public void RentCart(int memberID)
    {
        Member me = this.videoDB.GetMember_MemberID(memberID);
        if (me != null)
        {
            foreach (var a in this.itemList)
            {
                if (me.DaysBalance >= a.Days)
                {
                    if (a.InStock == "Yes")
                    {
                        this.videoDB.Rent(memberID, a.MovieID,
                            CurrentTime.TimeNow, (short)a.Days);
                        a.UpdateRentStatus("Successfully Rented");
                        a.UpdateAddedBy("User");
                    }
                    else
                    {
                        this.videoDB.AddToWaitingList(memberID, a.MovieID,
                            CurrentTime.TimeNow);
                        a.UpdateRentStatus("No copies left, you are in a waiting list");
                    }
                }
                else
                {
                    a.UpdateRentStatus("No enough days in your subscription. Add some and try again");
                }
            }
        }
        this.UpdateCart();
    }

    #region IEnumerable<CartItem> Members

    public IEnumerator<CartItem> GetEnumerator()
    {
        foreach (var a in this.itemList)
        {
            yield return a;
        }
    }

    #endregion

    #region IEnumerable Members

    IEnumerator IEnumerable.GetEnumerator()
    {
        foreach (var a in this.itemList)
        {
            yield return a;
        }
    }

    #endregion
}
