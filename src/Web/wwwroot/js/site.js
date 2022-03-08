// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// jquery currentSlide button onclick function
var slideIndex = 1;
showSlides(slideIndex);


function plusSlide(n) {
    showSlides(slideIndex += n);
}

function currentSlide(n) {
    showSlides(slideIndex = n);
}


function showSlides(n) {
    var i;

    var slides = document.getElementsByClassName("slide");
    var dots = document.getElementsByClassName("dot");

    var slideMobile = document.getElementsByClassName("slide-mobile");
    var mobileTitle = document.getElementsByClassName("mobile-title");

    if (slides.length === 0 && dots.length === 0) {
        return;
    }

    if (n > slides.length) {
        slideIndex = 1
    }
    if (n < 1) {
        slideIndex = slides.length
    }


    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
    }

    for (i = 0; i < slideMobile.length; i++) {
        slideMobile[i].style.display = "none";
        mobileTitle[i].style.display = "none";
    }

    slides[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " active";

    slideMobile[slideIndex - 1].style.display = "block";
    mobileTitle[slideIndex - 1].style.display = "block";
}


// when the document is loaded, use jquery display the first tab content
$(document).ready(function () {
    // jquery get the first tab content
    var firstTab = $(".tabcontent").first();
    // jquery display the first tab content
    firstTab.show();
    // add a class to the first tab
    $(".tablinks").first().addClass("active");

});

function openJob(evt, jobName) {

    let i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");

    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }

    const tab = document.getElementById(jobName);
    tab.style.display = "block";
    evt.currentTarget.className += " active";
}