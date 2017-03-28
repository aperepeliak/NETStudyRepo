﻿var FolloweesController = function (followingService) {
    var button;

    var init = function () {
        $(".js-toggle-follow").on("click", toggleFollowing);
    };

    var toggleFollowing = function (e) {

        button = $(e.target);
        var followeeId = button.attr("data-user-id");

        if (button.hasClass("btn-default"))
            followingService.createFollowing(followeeId, done, fail);
        else
            followingService.deleteFollowing(followeeId, done, fail);
    };

    var fail = function () {
        alert("Error");
    };

    var done = function () {
        var text = (button.text() == "Following") ? "Follow" : "Following";
        button
            .toggleClass("btn-default")
            .toggleClass("btn-info")
            .text(text);
    };

    return {
        init
    };

}(FollowingService);