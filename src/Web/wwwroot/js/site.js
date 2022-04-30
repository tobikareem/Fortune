// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// jquery currentSlide button onclick function
var slideIndex = 1;
showSlides(slideIndex);

function plusSlide(n) {
  showSlides((slideIndex += n));
}

function currentSlide(n) {
  showSlides((slideIndex = n));
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
    slideIndex = 1;
  }
  if (n < 1) {
    slideIndex = slides.length;
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
 
    // dynamically set the footer height
    var docHeight = $(window).height();
    var footerHeight = $("#footer").height();

    var footerTop = $("#footer").position().top + footerHeight;

    if(footerTop < docHeight) {
        $("#footer").css("margin-top", (docHeight - footerTop) + "px");
    }
 

  // jquery get the first tab content
  var firstTab = $(".tabcontent").first();
  // jquery display the first tab content
  firstTab.show();
  // add a class to the first tab
  $(".tablinks").first().addClass("active");

  // when document is ready
  // find breadcrumbs children
  var breadcrumbChildren = document.getElementsByClassName("breadcrumb-item");
  var about = breadcrumbChildren[1];
  var developer = breadcrumbChildren[2];
  var writer = breadcrumbChildren[3];
  var connections = breadcrumbChildren[4];

  // find active breadcrumb child
  var activeBreadcrumb = document.getElementsByClassName("active");

  if (activeBreadcrumb.length === 0 || activeBreadcrumb[0].id === undefined) {
    return;
  }

  // check the id of the active breadcrumb value
  var activeBreadcrumbId = activeBreadcrumb[0].id;

  // if the active breadcrumb id is equal to the BloPost. then set display = block for Id = Writer
  if (activeBreadcrumbId === "BlogPost") {
    // set display = block for the Writer
    writer.style.display = "block";
  }

  if (activeBreadcrumbId === "About") {
    developer.style.display = "block";
    writer.style.display = "block";
    connections.style.display = "block";
  }

  if (activeBreadcrumbId === "Developer") {
    about.style.display = "block";
    writer.style.display = "block";
  }

  if (activeBreadcrumbId === "Writer") {
    about.style.display = "block";
    developer.style.display = "block";
  }

  if (activeBreadcrumbId === "Connections") {
    about.style.display = "block";
    developer.style.display = "block";
  }

  // Find the a element child of the active breadcrumb
  var activeBreadcrumbA = activeBreadcrumb[0].getElementsByTagName("a")[0];

  // set the content to the value of a
  activeBreadcrumbA.href = "#";

  //// change text-decoration to none and color to black
  activeBreadcrumbA.style.textDecoration = "none";
  activeBreadcrumbA.style.color = "#6c757d";
  activeBreadcrumbA.style.display = "inline-block";

  // change cursor to default
  activeBreadcrumbA.style.cursor = "default";

  // disable the activebreadcrumb a element
  activeBreadcrumbA.disabled = true;
});

function openJob(evt, jobName) {
  var i;
  var tabcontent = document.getElementsByClassName("tabcontent");

  for (i = 0; i < tabcontent.length; i++) {
    tabcontent[i].style.display = "none";
  }

  var tablinks = document.getElementsByClassName("tablinks");
  for (i = 0; i < tablinks.length; i++) {
    tablinks[i].className = tablinks[i].className.replace(" active", "");
  }

  var tab = document.getElementById(jobName);
  tab.style.display = "block";
  evt.currentTarget.className += " active";
}

(function (i, s, o, g, r, a, m) {
  i["GoogleAnalyticsObject"] = r;
  (i[r] =
    i[r] ||
    function () {
      (i[r].q = i[r].q || []).push(arguments);
    }),
    (i[r].l = 1 * new Date());
  (a = s.createElement(o)), (m = s.getElementsByTagName(o)[0]);
  a.async = 1;
  a.src = g;
  m.parentNode.insertBefore(a, m);
})(
  window,
  document,
  "script",
  "https://www.google-analytics.com/analytics.js",
  "ga"
);

ga("create", "UA-76196878-1", "auto");
ga("send", "pageview");
