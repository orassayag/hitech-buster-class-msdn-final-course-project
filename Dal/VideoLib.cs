using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    public class VideoLib
    {
        private VideoLibDBDataContext videoDB = new VideoLibDBDataContext();

        public VideoLib()
        {
            foreach (var a in this.videoDB.Movies)
            {
                a.MoviePicUrl = "MoviesPics/" + a.MovieName + ".jpg";
            }
        }

        public void AddMember(Member m)
        {
            Member e = this.GetMember_MemberID(m.MemberID);
            if (e == null)
            {
                this.videoDB.Members.InsertOnSubmit(m);
                this.videoDB.SubmitChanges();
            }
        }

        public void AddMovie(Movie m)
        {
            Movie me = this.GetMovie_MovieID(m.MovieID);
            if (me == null)
            {
                this.videoDB.Movies.InsertOnSubmit(m);
                this.videoDB.SubmitChanges();
            }
        }

        public void AddReview(int memberID, string movieID, string reviewText, byte rate)
        {
            Member me = this.GetMember_MemberID(memberID);
            Movie mo = this.GetMovie_MovieID(movieID);
            if (me != null && mo != null)
            {
                Review r = this.GetReview(memberID, movieID);
                if (r == null)
                {
                    this.videoDB.Reviews.InsertOnSubmit(new Review
                    {
                        MemberID = memberID,
                        MovieID = movieID,
                        ReviewText = reviewText,
                        Rate = rate
                    });
                }
                else
                {
                    r.ReviewText = reviewText;
                    r.Rate = rate;
                }
                this.videoDB.SubmitChanges();
            }
        }

        public void AddCopies(string movieID, short copies)
        {
            Movie m = this.GetMovie_MovieID(movieID);
            if (m != null && copies > 0)
            {
                m.Copies += copies;
                this.videoDB.SubmitChanges();
            }
        }

        public void AddSubscriptions(int memberID, short days)
        {
            Member m = this.GetMember_MemberID(memberID);
            if (m != null && days > 0)
            {
                m.DaysBalance += days;
                this.videoDB.SubmitChanges();
            }
        }

        public void RemoveMovie(string movieID)
        {
            Movie m = this.GetMovie_MovieID(movieID);
            if (m != null && m.Active == 1)
            {
                m.Active = 2;
                this.videoDB.SubmitChanges();
            }
        }

        public void ReActiveMovie(string movieID)
        {
            Movie m = this.GetMovie_MovieID(movieID);
            if (m != null && m.Active == 2)
            {
                m.Active = 1;
                this.videoDB.SubmitChanges();
            }
        }

        public void UpdateMember(Member m)
        {
            Member me = this.GetMember_MemberID(m.MemberID);
            if (me != null)
            {
                me.MemberID = m.MemberID;
                me.BirthDate = m.BirthDate;
                me.City = m.City;
                me.DaysBalance = m.DaysBalance;
                me.Email = m.Email;
                me.FirstName = m.FirstName;
                me.HomePhone = m.HomePhone;
                me.HouseNumber = m.HouseNumber;
                me.ID = m.ID;
                me.LastName = m.LastName;
                me.MemberLevel = m.MemberLevel;
                me.MemberSince = m.MemberSince;
                me.MobilePhone = m.MobilePhone;
                me.Password = m.Password;
                me.Street = m.Street;
                this.videoDB.SubmitChanges();
            }
        }

        public void UpdateMovie(Movie m)
        {
            Movie me = this.GetMovie_MovieID(m.MovieID);
            if (me != null)
            {
                me.MovieID = m.MovieID;
                me.Active = m.Active;
                me.Copies = m.Copies;
                me.Country = m.Country;
                me.DateAdded = m.DateAdded;
                me.Lenght = m.Lenght;
                me.MovieName = m.MovieName;
                me.MovieType = m.MovieType;
                me.Summary = m.Summary;
                me.TrailerUrl = m.TrailerUrl;
                me.Year = m.Year;
                me.MoviePicUrl = m.MoviePicUrl;
                this.videoDB.SubmitChanges();
            }
        }

        public IEnumerable<Country> GetAllContries()
        {
            var q = from co in this.videoDB.Countries
                    select co;
            return q;
        }

        public IEnumerable<Movie> GetPopularMovies(int chartNumber)
        {
            if (chartNumber <= 0)
            {
                return null;
            }

            var q = from rent in this.videoDB.Rents
                    group rent by rent.Movie.MovieID into list
                    orderby list.Count() descending
                    join mov in this.videoDB.Movies
                    on list.Key equals mov.MovieID
                    select mov;
            return q.Take(chartNumber);
        }

        public IEnumerable<PastDuDate> CurrentlyRented(int memberID, DateTime timeNow)
        {
            Member m = this.GetMember_MemberID(memberID);
            if (m == null)
            {
                return null;
            }
            var q = from rent in this.videoDB.Rents
                    where rent.MemberID == memberID &&
                    rent.RentEnd == null
                    orderby rent.RentStart ascending
                    select new PastDuDate(rent, timeNow);
            return q;
        }

        public int CurrentlyRentedCount(int memberID)
        {
            Member m = this.GetMember_MemberID(memberID);
            if (m == null)
            {
                return -1;
            }

            var q = from rent in this.videoDB.Rents
                    where rent.MemberID == memberID &&
                    rent.RentEnd == null
                    orderby rent.RentStart ascending
                    select rent;
            return q.Count();
        }

        public IEnumerable<Rent> PastDuDate(int memberID, DateTime timeNow)
        {
            Member m = this.GetMember_MemberID(memberID);
            if (m == null || timeNow == default(DateTime))
            {
                return null;
            }

            var q = from rent in this.videoDB.Rents
                    where rent.MemberID == memberID &&
                    rent.RentEnd == null &&
                    rent.RentDays < (timeNow - rent.RentStart).Days
                    orderby rent.RentStart ascending
                    select rent;
            return q;
        }

        public int PastDuDateCount(int memberID, DateTime timeNow)
        {
            Member m = this.GetMember_MemberID(memberID);
            if (m == null || timeNow == default(DateTime))
            {
                return -1;
            }

            var q = from rent in this.videoDB.Rents
                    where rent.MemberID == memberID &&
                    rent.RentEnd == null &&
                    rent.RentDays < (timeNow - rent.RentStart).Days
                    orderby rent.RentStart ascending
                    select rent;
            return q.Count();
        }

        public IEnumerable<PastDuDate> RentalHistoryRents(int memberID, DateTime timeNow)
        {
            Member m = this.GetMember_MemberID(memberID);
            if (m == null)
            {
                return null;
            }

            var q = from rent in this.videoDB.Rents
                    where rent.MemberID == memberID
                    orderby rent.RentStart ascending
                    select new PastDuDate(rent, timeNow);
            return q;
        }

        public IEnumerable<PastDuDate> RentalHistoryMovies(int memberID, DateTime timeNow)
        {
            Member m = this.GetMember_MemberID(memberID);
            if (m == null)
            {
                return null;
            }

            var q = from rent in this.videoDB.Rents
                    where rent.MemberID == memberID
                    orderby rent.RentStart ascending
                    select new PastDuDate(rent, timeNow);
            return q.Distinct();
        }

        public IEnumerable<Review> GetMemberReviews(int memberID)
        {
            Member m = this.GetMember_MemberID(memberID);
            if (m == null)
            {
                return null;
            }

            var q = from rev in this.videoDB.Reviews
                    where rev.MemberID == memberID
                    orderby rev.MovieID ascending
                    select rev;
            return q;
        }

        public IEnumerable<MovieType> GetAllMovieTypes()
        {
            var q = from mov in this.videoDB.MovieTypes
                    orderby mov.MovieTypeID ascending
                    select mov;
            return q;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            var q = from mov in this.videoDB.Movies
                    orderby mov.MovieID ascending
                    select mov;
            return q;
        }

        public IEnumerable<Member> GetAllMembers()
        {
            var q = from mem in this.videoDB.Members
                    orderby mem.MemberID ascending
                    select mem;
            return q;
        }

        public IEnumerable<Review> GetAllReviews(string movieID)
        {
            Movie m = this.GetMovie_MovieID(movieID);
            if (m == null)
            {
                return null;
            }

            var q = from rev in this.videoDB.Reviews
                    where rev.MovieID == movieID
                    orderby rev.MemberID ascending
                    select rev;
            return q;
        }

        public IEnumerable<Movie> GetAllMoviesByMovieTypeID(int movieTypeID)
        {
            MovieType m = this.GetMovieType(movieTypeID);
            if (m == null)
            {
                return null;
            }

            var q = from mov in this.videoDB.Movies
                    where mov.MovieTypeID == movieTypeID
                    orderby mov.MovieID ascending
                    select mov;
            return q;
        }

        public IEnumerable<WaitingList> GetMemberWaitingList(int memberID)
        {
            Member m = this.GetMember_MemberID(memberID);
            if (m == null)
            {
                return null;
            }

            var q = from wa in this.videoDB.WaitingLists
                    where wa.MemberID == memberID
                    orderby wa.MovieID ascending
                    select wa;
            return q;
        }

        public IEnumerable<PastDuDate> GetAllPastDuDates(DateTime timeNow)
        {
            if (timeNow == default(DateTime))
            {
                return null;
            }

            var q = from rent in this.videoDB.Rents
                    where rent.RentEnd == null &&
                    rent.RentDays < (timeNow - rent.RentStart).Days
                    orderby (timeNow - rent.RentStart).Days descending
                    select new PastDuDate(rent, timeNow);
            return q;
        }

        public IEnumerable<Movie> GetMoviesWithWaiters(int waiters)
        {
            if (waiters <= 0)
            {
                return null;
            }

            var q = from wa in this.videoDB.WaitingLists
                    group wa by wa.MovieID into list
                    where list.Count() == waiters
                    join mov in this.videoDB.Movies
                    on list.Key equals mov.MovieID
                    select mov;
            return q;
        }

        public IEnumerable<Movie> DeadMoviesReport(DateTime since)
        {
            if (since == default(DateTime))
            {
                return null;
            }

            var q1 = from rent in this.videoDB.Rents
                     where rent.RentStart > since
                     select rent;
            var q2 = from mov in this.videoDB.Movies
                     join la in q1 on mov.MovieID equals la.MovieID into list
                     where list.Count() == 0
                     orderby mov.MovieID ascending
                     select mov;
            return q2;
        }

        public IEnumerable<Member> GetInactiveRenters(DateTime since)
        {
            if (since == default(DateTime))
            {
                return null;
            }

            var q1 = from rent in this.videoDB.Rents
                     where rent.RentStart > since
                     select rent;
            var q2 = from mem in this.videoDB.Members
                     join la in q1 on mem.MemberID equals la.MemberID into list
                     where list.Count() == 0
                     orderby mem.MemberID ascending
                     select mem;
            return q2;
        }

        public IEnumerable<RentPerMonth> GetRentPerMonth(DateTime timeNow, DateTime since)
        {
            if (timeNow == default(DateTime) || since == default(DateTime))
            {
                return null;
            }

            List<RentPerMonth> list = new List<RentPerMonth>();
            while (timeNow > since)
            {
                var q = from rent in this.videoDB.Rents
                        where rent.RentStart > since &&
                        rent.RentStart < since.AddMonths(1)
                        orderby rent.MemberID ascending
                        select rent;
                list.Add(new RentPerMonth(since.ToShortDateString(), q.Count()));
                since = since.AddMonths(1);
            }
            return (IEnumerable<RentPerMonth>)list;
        }

        public IEnumerable<Movie> GetMoviesContains(string word)
        {
            var q = from mov in this.videoDB.Movies
                    where mov.MovieName.Contains(word)
                    orderby mov.MovieID ascending
                    select mov;
            return q;
        }

        public Member GetMember_MemberID(int memberID)
        {
            return this.videoDB.Members.SingleOrDefault(g => g.MemberID == memberID);
        }

        public Member GetMember_ID(int ID)
        {
            return this.videoDB.Members.SingleOrDefault(g => g.ID == ID);
        }

        public Member GetMember_FullName(string fullName)
        {
            return this.videoDB.Members.SingleOrDefault(g => g.FullName == fullName);
        }

        public Member GetMember_Password(string password)
        {
            return this.videoDB.Members.SingleOrDefault(g => g.Password == password);
        }

        public Movie GetMovie_MovieID(string movieID)
        {
            return this.videoDB.Movies.SingleOrDefault(g => g.MovieID == movieID);
        }

        public Movie GetMovie_MovieName(string movieName)
        {
            return this.videoDB.Movies.SingleOrDefault(g => g.MovieName == movieName);
        }

        public Rent GetUnreturnedRent(int memberID, string movieID)
        {
            return this.videoDB.Rents.SingleOrDefault(g => g.MemberID == memberID &&
                                                           g.MovieID == movieID &&
                                                           g.RentEnd == null);
        }

        public WaitingList GetWaitObject(int memberID, string movieID)
        {
            return this.videoDB.WaitingLists.SingleOrDefault(g => g.MemberID == memberID &&
                                                                  g.MovieID == movieID);
        }

        public Review GetReview(int memberID, string movieID)
        {
            return this.videoDB.Reviews.SingleOrDefault(g => g.MemberID == memberID &&
                                                             g.MovieID == movieID);
        }

        public MovieType GetMovieType(int movieTypeID)
        {
            return this.videoDB.MovieTypes.SingleOrDefault(g => g.MovieTypeID == movieTypeID);
        }

        public bool Rent(int memberID, string movieID, DateTime timeNow, short days)
        {
            Member me = this.GetMember_MemberID(memberID);
            Movie mo = this.GetMovie_MovieID(movieID);

            if (me == null || mo == null || timeNow == default(DateTime) || days <= 0)
            {
                return false;
            }

            if (me.DaysBalance >= days)
            {
                if (mo.Copies > 0)
                {
                    mo.Copies--;
                    this.videoDB.Rents.InsertOnSubmit(new Rent
                    {
                        MemberID = memberID,
                        MovieID = movieID,
                        RentDays = days,
                        RentStart = timeNow
                    });
                    this.RemoveFromWaitingList(memberID, movieID);
                    this.videoDB.SubmitChanges();
                    return true;
                }
                else
                {
                    this.AddToWaitingList(memberID, movieID, timeNow);
                    this.videoDB.SubmitChanges();
                }
            }
            return false;
        }

        public void Return(int memberID, string movieID, DateTime timeNow)
        {
            Member me = this.GetMember_MemberID(memberID);
            Movie mo = this.GetMovie_MovieID(movieID);

            if (me != null && mo != null && timeNow != default(DateTime))
            {
                Rent r = this.GetUnreturnedRent(memberID, movieID);
                if (r != null)
                {
                    mo.Copies++;
                    me.DaysBalance -= (short)r.RentDays;
                    r.RentEnd = timeNow;
                    this.videoDB.SubmitChanges();
                }
            }
        }

        public void AddToWaitingList(int memberID, string movieID, DateTime timeNow)
        {
            Member me = this.GetMember_MemberID(memberID);
            Movie mo = this.GetMovie_MovieID(movieID);

            if (me != null && movieID != null && timeNow != default(DateTime))
            {
                WaitingList wa = this.GetWaitObject(memberID, movieID);
                if (wa == null)
                {
                    this.videoDB.WaitingLists.InsertOnSubmit(new WaitingList
                    {
                        MemberID = memberID,
                        MovieID = movieID,
                        WaitDate = timeNow
                    });
                    this.videoDB.SubmitChanges();
                }
            }
        }

        public void RemoveFromWaitingList(int memberID, string movieID)
        {
            Member me = this.GetMember_MemberID(memberID);
            Movie mo = this.GetMovie_MovieID(movieID);

            if (me != null && mo != null)
            {
                WaitingList wa = this.GetWaitObject(memberID, movieID);
                if (wa != null)
                {
                    this.videoDB.WaitingLists.DeleteOnSubmit(wa);
                    this.videoDB.SubmitChanges();
                }
            }
        }

        public int WaitersCount(string movieID)
        {
            Movie m = this.GetMovie_MovieID(movieID);
            if (m == null)
            {
                return -1;
            }

            var q = from wa in this.videoDB.WaitingLists
                    where wa.MovieID == movieID
                    orderby wa.WaitDate ascending
                    select wa;
            return q.Count();
        }

        public int GetAvailableMemberID()
        {
            return this.GetAllMembers().Count() + 1;
        }

        public string GetAvailableMovieID(int movieTypeID)
        {
            MovieType m = this.GetMovieType(movieTypeID);
            if (m == null)
            {
                return null;
            }

            return m.MovieTypeName[0].ToString() + this.GetAllMovies().Count() + 1;
        }
    }

    public partial class Member
    {
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        public IEnumerable<Rent> CurrentlyRented
        {
            get
            {
                var q = from rent in this.Rents
                        where rent.RentEnd == null
                        orderby rent.RentStart ascending
                        select rent;
                return q;
            }
        }

        public int CurrentlyRentedCount
        {
            get
            {
                var q = from rent in this.Rents
                        where rent.RentEnd == null
                        orderby rent.RentStart ascending
                        select rent;
                return q.Count();
            }
        }

        public IEnumerable<Rent> PastDuDate(DateTime timeNow)
        {
            if (timeNow == default(DateTime))
            {
                return null;
            }

            var q = from rent in this.Rents
                    where rent.RentEnd == null &&
                    rent.RentDays < (timeNow - rent.RentStart).Days
                    orderby rent.RentStart ascending
                    select rent;
            return q;
        }

        public int PastDuDateCount(DateTime timeNow)
        {
            if (timeNow == default(DateTime))
            {
                return -1;
            }

            var q = from rent in this.Rents
                    where rent.RentEnd == null &&
                    rent.RentDays < (timeNow - rent.RentStart).Days
                    orderby rent.RentStart ascending
                    select rent;
            return q.Count();
        }

        public IEnumerable<Rent> RentalHistoryRent
        {
            get
            {
                var q = from rent in this.Rents
                        orderby rent.RentStart ascending
                        select rent;
                return q;
            }
        }

        public IEnumerable<Movie> RentalHistoryMovie
        {
            get
            {
                var q = from rent in this.Rents
                        orderby rent.RentStart ascending
                        select rent.Movie;
                return q.Distinct();
            }
        }

        public string LastRent
        {
            get
            {
                return this.RentalHistoryRent.Last().RentStart.ToShortDateString();
            }
        }

        public double Average
        {
            get
            {
                var q = from rev in this.Reviews
                        select rev;
                return q.Average(g => g.Rate);
            }
        }
    }

    public partial class Movie
    {
        public int Waiters
        {
            get
            {
                var q = from wa in this.WaitingLists
                        select wa;
                return q.Count();
            }
        }
        
        public double Rate
        {
            get
            {
                if (this.Reviews.Count > 0)
                {
                    return this.Reviews.Average(g => g.Rate);
                }
                return 0;
            }
        }

        public string StarRate
        {

            get
            {
                string s = "<img alt=\"\" src=\"Images/trailers-star.gif\" style=\"width: 17px; height: 17px\" />";
                string hs = "<img alt=\"\" src=\"Images/trailers-starhalf.gif\" style=\"width: 17px; height: 17px\" />";
                string c = "";

                for (int i = 0; i < (int)this.Rate; i++)
                {
                    c += s;
                }

                if ((this.Rate % 1) != 0)
                {
                    c += hs;
                }
                return c;
            }
        }

        public string HalfSummery
        {
            get
            {
                return this.Summary.Substring(0, this.Summary.Length / 2);
            }
        }

        public string OneLineSummery
        {
            get
            {
                return this.Summary.Substring(0, 30);
            }
        }

        public string InStock
        {
            get
            {
                if (this.Copies > 0)
                {
                    return "";
                }
                return "Not";
            }
        }

        public string LastRent
        {
            get
            {
                var q = from rent in this.Rents
                        orderby rent.RentStart descending
                        select rent;
                if (q.Count() > 0)
                {
                    return q.First().RentStart.ToShortDateString();
                }
                return "Never Rented";
            }
        }

        public string Cast
        {
            get
            {
                var q = from ac in this.ActorMovies
                        where ac.MovieID == this.MovieID
                        select ac;
                string g = "";
                foreach (var a in q)
                {
                    g += a.Actor.ActorName + ", ";
                }
                return g;
            }
        }
    }

    public partial class Rent
    {
        public string RentStartToString
        {
            get
            {
                return this.RentStart.ToShortDateString();
            }
        }

        public string RentEndToString
        {
            get
            {
                if (this.RentEnd.HasValue)
                {
                    return this.RentEnd.Value.ToShortDateString();
                }
                return "";
            }
        }

        public string RentUntilToString
        {
            get
            {
                return this.RentStart.AddDays(this.RentDays.Value).ToShortDateString();
            }
        }

        public string MemberName
        {
            get
            {
                return this.Member.FullName;
            }
        }

        public string MovieName
        {
            get
            {
                return this.Movie.MovieName;
            }
        }

        public int Days
        {
            get
            {
                if (this.RentDays.HasValue)
                {
                    return this.RentDays.Value;
                }
                else
                {
                    if (this.RentEnd.HasValue)
                    {
                        return (this.RentEnd.Value - this.RentStart).Days;
                    }
                }
                return 0;
            }
        }
    }

    public partial class Review
    {
        public string StarRate
        {
            get
            {
                string s = "<img alt=\"\" src=\"Images/trailers-star.gif\" style=\"width: 17px; height: 17px\" />";
                string hs = "<img alt=\"\" src=\"Images/trailers-starhalf.gif\" style=\"width: 17px; height: 17px\" />";
                string c = "";

                for (int i = 0; i < (int)this.Rate; i++)
                {
                    c += s;
                }

                if ((this.Rate % 1) != 0)
                {
                    c += hs;
                }
                return c;
            }
        }

        public string MemberName
        {
            get
            {
                return this.Member.FullName;
            }
        }

        public string MovieName
        {
            get
            {
                return this.Movie.MovieName;
            }
        }

        public string MoviePicUrl
        {
            get
            {
                return this.Movie.MoviePicUrl;
            }
        }
    }

    public partial class WaitingList
    {

        public string InStock
        {
            get
            {
                if (this.Movie.Copies == 0)
                {
                    return "No";
                }
                return "Yes";
            }
        }

        public string MovieName
        {
            get
            {
                return this.Movie.MovieName;
            }
        }

        public string WateDateToString
        {
            get
            {
                return this.WaitDate.ToShortDateString();
            }

        }
    }

    public class PastDuDate
    {
        private Rent rent;
        private DateTime timeNow;

        public PastDuDate(Rent rent, DateTime timeNow)
        {
            this.timeNow = timeNow;
            this.rent = rent;
        }

        public string IsPastDu
        {
            get
            {
                if (this.PastDays > 0)
                {
                    return "Yes";
                }
                return "No";
            }
        }

        public int MemberID
        {
            get
            {
                return this.rent.MemberID;
            }
        }

        public string MovieID
        {
            get
            {
                return this.rent.MovieID;
            }
        }

        public string MemberName
        {
            get
            {
                return this.rent.Member.FullName;
            }
        }

        public string MovieName
        {
            get
            {
                return this.rent.Movie.MovieName;
            }
        }

        public string RentStartToString
        {
            get
            {
                return this.rent.RentStart.ToShortDateString();
            }
        }

        public string RentEndToString
        {
            get
            {
                if (this.rent.RentEnd.HasValue)
                {
                    return this.rent.RentEnd.Value.ToShortDateString();
                }
                return "";
            }
        }

        public int Days
        {
            get
            {
                if (this.rent.RentEnd.HasValue)
                {
                    return (this.rent.RentStart - this.rent.RentEnd.Value).Days;
                }
                return -1;
            }
        }

        public string RentUntilToString
        {
            get
            {
                if (this.rent.RentDays.HasValue)
                {
                    return this.rent.RentStart.AddDays(this.rent.RentDays.Value).ToShortDateString();
                }
                return "";
            }
        }

        public int PastDays
        {
            get
            {
                return (timeNow - rent.RentStart).Days;
            }
        }
    }

    public class RentPerMonth
    {
        private string monthName;
        private int rents;

        public RentPerMonth(string monthName, int rents)
        {
            this.monthName = monthName;
            this.rents = rents;
        }

        public string MonthName
        {
            get
            {
                return this.monthName;
            }
        }

        public int Rents
        {
            get
            {
                return this.rents;
            }
        }
    }
}
