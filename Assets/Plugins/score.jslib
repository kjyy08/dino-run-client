mergeInto(LibraryManager.library, {
  SendHighScoreToJS: function (score) {
    window.receiveHighScore(score);
  },
});
