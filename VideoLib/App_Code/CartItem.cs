using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dal;

/// <summary>
/// Summary description for CartItem
/// </summary>
public class CartItem
{
    private Movie movie;
    private DateTime rentUntil;
    private string addedBy;
    private string rentStatus;

    public CartItem(Movie movie, DateTime rentUntil, string addedBy, string rentStatus)
    {
        this.movie = movie;
        this.rentUntil = rentUntil;
        this.addedBy = addedBy;
        this.rentStatus = rentStatus;
    }

    public string MovieID
    {
        get
        {
            return this.movie.MovieID;
        }
    }

    public string MovieName
    {
        get
        {
            return this.movie.MovieName;
        }
    }

    public string RentUntilToString
    {
        get
        {
            return this.rentUntil.ToShortDateString();
        }
    }

    public string InStock
    {
        get
        {
            if (this.movie.Copies == 0)
            {
                return "No";
            }
            return "Yes";
        }
    }

    public int Days
    {
        get
        {
            return (this.rentUntil - CurrentTime.TimeNow).Days;
        }
    }

    public string AddedBy
    {
        get
        {
            return this.addedBy;
        }
    }

    public string RentStatus
    {
        get
        {
            return this.rentStatus;
        }
    }

    public void UpdateRentUntil(DateTime rentUntil)
    {
        if (rentUntil != default(DateTime))
        {
            this.rentUntil = rentUntil;
        }
    }

    public void UpdateAddedBy(string addedBy)
    {
        this.addedBy = addedBy;
    }

    public void UpdateRentStatus(string rentStatus)
    {
        this.rentStatus = rentStatus;
    }

    public override string ToString()
    {
        return string.Format("{0},{1},{2},{3}",this.movie.MovieID,
                                               this.rentUntil.ToShortDateString(),
                                               this.addedBy,
                                               this.rentStatus);
    }
}
