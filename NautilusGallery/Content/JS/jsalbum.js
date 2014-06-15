var sum = 0;
var dWidth = 0;
var dWidthTemp = 0;
var firstimagegallery;
var result;
$(function () {
    //$("#scroll_left").on("click", click_left);
    //$("#scroll_right").on("click", click_right);
});

$(window).load(function () {

    $("div.container_img > a").each(function () {
        //console.log(index + ": " + $(this).text());
        sum = sum + $(this).width();

        $(this).find('img').on("click", click_image);

    });

    var position = $("div.container_gallery").position();
    console.log(position.top);
    if (position.top < 450) {
        $("div.container_gallery").css("top", "190px");
        $("div.container_gallery").css("margin-top", "0px");
    }

    $("div.container_img").width(sum);
    console.log(sum);
    dWidth = sum - $("div.container_scroll").width();
    dWidthTemp = dWidth;
    console.log(dWidth);

    if (dWidth > 0) {
        $("#scroll_left").on("click", click_left);
        $("#scroll_right").on("click", click_right);
    }

    //выбрать первый источник из картинки

    var imageindiv = $(".container_img").find('img:first');
    var imgsrc = imageindiv[0].src;
    //firstimagegallery = $(".container_gallery").find('img');
    //firstimagegallery[0].src = imgsrc;

    var re = /Preview/g;
    result = imgsrc.replace(re, "Main");
    $("div.container_gallery").load(result);
    console.log(result);
});

function click_image() {
    var re = /Preview/g;
    var imgsrc = this.src
    result = imgsrc.replace(re, "Main");
    //firstimagegallery[0].src = this.src;
    //console.log("нажата картинка" + this.src);
    $("div.container_gallery").load(result);


};
function click_left() {
    console.log("Нажата влево");
    //$(".container_img").animate({ "margin-left": "+=100px" }, "slow");
    if (dWidthTemp <= (dWidth - 100)) {
        $(".container_img").animate({ "margin-left": "+=100px" }, "slow");
        dWidthTemp = dWidthTemp + 100;
    }
    else {
        if (dWidthTemp != dWidth) {
            $(".container_img").animate({ "margin-left": "+=" + (dWidth - dWidthTemp) + "px" }, "slow");
            dWidthTemp = dWidth;
        }

    }
};

function click_right() {
    console.log("Нажата вправо");
    if (dWidthTemp >= 100) {
        //$(".container_img").animate({ "margin-left": "-=100px" }, "slow");
        $(".container_img").animate({ "margin-left": "-=" + 100 + "px" }, "slow");
        dWidthTemp = dWidthTemp - 100;
    }
    else {
        if (dWidthTemp > 0) {
            $(".container_img").animate({ "margin-left": "-=" + dWidthTemp + "px" }, "slow");
            dWidthTemp = 0;
        }
    }

};