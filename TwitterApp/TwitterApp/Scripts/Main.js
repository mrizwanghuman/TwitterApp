function searchTweetsApi(typeSeach, partViewShow) {
    $(typeSeach).on("click", function () {

        $(partViewShow).slideToggle();

        
    })

}
searchTweetsApi(".screenName", ".searchTweetUser");
searchTweetsApi(".SearchString", ".searchTweet");

