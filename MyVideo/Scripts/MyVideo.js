$(function () {
    var video = document.getElementById("mainVideo");
    var btn_play = document.getElementById("btnPlay");
    video.addEventListener("pause", function () {
        btn_play.innerHTML = "播放";
    })
    video.addEventListener("play", function () {
        btn_play.innerHTML = "暂停";
    });

    btn_play.addEventListener("click", function () {
        if (btn_play.innerHTML == "播放")
            video.play();
        else
            video.pause();
    });

    var selRate = document.getElementById("selRate");
    selRate.addEventListener("change", function () {
        video.playbackRate = this.value;
    });
});

