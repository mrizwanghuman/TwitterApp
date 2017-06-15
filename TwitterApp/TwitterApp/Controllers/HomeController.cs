using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinqToTwitter;
using System.Configuration;
using TwitterApp.Models;

namespace TwitterApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private SingleUserAuthorizer authorizer = new SingleUserAuthorizer
        {

            CredentialStore = new SingleUserInMemoryCredentialStore
            {

                ConsumerKey =
                 "OAlPacTwzsUujEjYz5jqySRSj",
                ConsumerSecret =
                   "1y1MiDVqB9g2IzvfXtnMo5MUR8qqoXqwMKEo8foOCbvwASKjmB",
                AccessToken =
                   "1689376910-vD9II4pLc2L90lLOxx1H22zhM0L8m3mohM0E0a5",
                AccessTokenSecret =
                   "AWuX5lqTHCp7htEoPQYPVJo8kjJm1VjlE2BegqoW2TMJq"
            }
        };
        private List<Status> currentTweets;
        // Search user Tweets
        private void GetTweetsByUserName(int count, string userScreenName)
        {
            if (count !=0 && userScreenName != "")
            {
                var twitterContext = new TwitterContext(authorizer);

                var tweets = from tweet in twitterContext.Status
                             where tweet.Type == StatusType.User && tweet.ScreenName == userScreenName &&
                             tweet.Count == count
                             select tweet;

                currentTweets = tweets.ToList();
            }
           
        }
        // Search Tweets
        private void SearchTweet(int count, string SearchTerm)
        {
            var twitterContext = new TwitterContext(authorizer);

            var searches = Enumerable.SingleOrDefault((from search in twitterContext.Search
                         where search.Type == SearchType.Search && search.Query == SearchTerm &&
                         search.Count == count
                         select search));
            if (searches !=null && searches.Statuses.Count !=0)
            {
                currentTweets= searches.Statuses.ToList();
            }
           
        }
        public ActionResult Index()
        {
              return View();

        }

        public ActionResult UserScreenName()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserScreenName(TweetScreenName model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                  
                    int count = 0;
                    if (model.TweetsUserNumber != "")
                    {
                        count = Int32.Parse(model.TweetsUserNumber);
                    }
                   
                        if (count != 0 && model.SearchByUser != "")
                        {
                            GetTweetsByUserName(count, model.SearchByUser);
                            ViewBag.currtweet = currentTweets;
                        }
                    
                }
                catch (ArgumentNullException ex)
                {
                    ViewBag.error = string.Format("cannot be blank {0}", ex.Message);
                }
                catch (AggregateException ex)
                {
                    ViewBag.error = string.Format("No user found error {0}", ex.Message);
                }
            }
            return View("~/Views/Home/Index.cshtml");

        }
        public ActionResult TweetSearch()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TweetSearch (SearchTweetsModel modelSearch)
        {

            if (ModelState.IsValid)
            {
                int count = 0;
                if (modelSearch.TweetsSearchNumber != "")
                {
                    count = Int32.Parse(modelSearch.TweetsSearchNumber);
                }
                try {
                    SearchTweet(count, modelSearch.SearchByText);
                    ViewBag.searchResutl = currentTweets;

                }
                catch (ArgumentNullException ex)
                {
                    ViewBag.error = string.Format("cannot be blank {0}", ex.Message);
                }
                catch (AggregateException ex)
                {
                    ViewBag.error = string.Format("No Serch found error {0}", ex.Message);
                }
            }
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
