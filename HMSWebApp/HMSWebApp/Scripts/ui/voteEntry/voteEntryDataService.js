var voteEntryDataService = (function () {

    var deleteVoteEntries = function (currentDeleteButton) {
        var options = {
            url: currentDeleteButton.data("action"),
            data: "voteEntryId=" + parseInt(currentDeleteButton.data("voteentryid")),
            type: "PUT"
        };

        return $.ajax(options);
    }

    return {
        deleteVoteEntries : deleteVoteEntries
    }
})();