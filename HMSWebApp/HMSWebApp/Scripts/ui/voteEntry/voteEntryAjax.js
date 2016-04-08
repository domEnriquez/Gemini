$(document).ready(function () {
    var voteEntryAjax = {
        self : this,
        onReady: function () {
            this.cacheDom();
            this.bindEvents();
        },
        cacheDom: function () {
            this.$deleteButton = $(".deleteLink");
        },
        bindEvents: function () {
            var self = this;
            this.$deleteButton.on("click", this.deleteVoteEntries)
        },
        deleteVoteEntries: function (e) {
            var currentDeleteButton = $(e.target);
            voteEntryDataService.deleteVoteEntries(currentDeleteButton)
                .done(function () {
                    var currentVoteEntry = currentDeleteButton.closest(".voteEntryItem");
                    currentVoteEntry.remove();
                })
                .fail(function (jqXHR, textStatus, err) {
                    alert(textStatus);
                });
        }
         
    }
    voteEntryAjax.onReady();
});