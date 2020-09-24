$(document).ready(function () {



    // window.addEventListener("scroll", function () {
    //     var header = document.querySelector("div.menu-header");
    //     header.classList.toggle("sticky", window.scrollY > 0);
    // })

    // $(window).scroll(function() {
    //     if ($(document).scrollTop() > 50) {
    //         $('nav').addClass('shrink');
    //         $('#enquire-btn').addClass('btn-shrink');
    //         $('#logo').css("max-height", "70px")
    //         $('#logo-link').css("padding-top", "7px")
    //     } else {
    //         $('nav').removeClass('shrink');
    //         $('#enquire-btn').removeClass('btn-shrink');
    //         $('#logo').css("max-height", "100px")
    //         $('#logo-link').css("padding-top", "15px")
    //     }
    //  });

    // scroll nav js

    $(window).scroll(ScrollChange);
    function ScrollChange() {
        if ($(document).scrollTop() > 0) {
            $('#stickyy').css("top", "0")
        }
        else {
            $('#stickyy').css("top", "54px")
        }
    };

    $(window).on('load', function () {
        ScrollChange();
    });

    // testimonials js

    $('#testimonials .owl-carousel').owlCarousel({
        loop: true,
        margin: 10,
        autoplay: true,
        autoplayTimeout: 4000,
        autoplayHoverPause: true,
        responsive: {
            0: {
                items: 1
            }
        }
    });

    // Adopt details js

    $('#adopt-details .owl-carousel').owlCarousel({
        loop: true,
        nav: true,
        dots: false,
        margin: 10,
        autoplay: true,
        autoplayTimeout: 4000,
        autoplayHoverPause: true,
        responsive: {
            0: {
                items: 1
            }
        }
    });

    // adopt article js

    $('#articles .owl-carousel').owlCarousel({
        loop: true,
        margin: 10,
        autoplay: true,
        autoplayTimeout: 4000,
        autoplayHoverPause: true,
        responsive: {
            0: {
                items: 1
            }
        }
    })

    // sevice js slider

    $('#service-slider .owl-carousel').owlCarousel({
        loop: true,
        margin: 30,
        autoplay: true,
        autoplayTimeout: 4000,
        autoplayHoverPause: true,
        responsive: {
            0: {
                items: 1
            },
            576: {
                items: 2
            },
            768: {
                items: 3
            },
            992: {
                items: 4
            }
        }
    });

    $('#shop-slider .owl-carousel').owlCarousel({
        loop: true,
        dots: false,
        nav: true,
        margin: 30,
        autoplay: true,
        autoplayTimeout: 4000,
        autoplayHoverPause: true,
        responsive: {
            0: {
                items: 1
            },
            576: {
                items: 2
            },
            768: {
                items: 3
            },
            992: {
                items: 4
            },
            1200: {
                items: 5
            }
        }
    });
    $('#team-slider .owl-carousel').owlCarousel({
        loop: true,
        nav: true,
        dots: false,
        margin: 30,
        autoplay: true,
        autoplayTimeout: 4000,
        autoplayHoverPause: true,
        responsive: {
            0: {
                items: 1
            },
            576: {
                items: 2
            },
            768: {
                items: 3
            },
            992: {
                items: 4
            }
        }
    });


    // team js slider


    //popup js

    //$(document).on('click', '[data-toggle="lightbox"]', function (event) {
    //    event.preventDefault();
    //    $(this).ekkoLightbox();
    //});

    //adopt click show content js

    $(".content-adopt").hide();
    $(".adopt-card").click(function () {
        $(this).children(".content-adopt").toggle();
    });

    //team hover show content js

    $(".team-content").hide();
    $(".team-image").mouseover(function () {
        $(this).children(".team-content").show();
    });
    $(".team-image").mouseleave(function () {
        $(this).children(".team-content").hide();
    });



    $(window).scroll(function () {
        if ($(document).scrollTop() > 1500) {
            //console.log($(document).scrollTop());
            if ($(".counter-area").length > 0) {
                $(".counter").counter({
                    autoStart: true, // true/false, default: true
                    duration: 2000, // milliseconds, default: 1500
                    countFrom: 1,// start counting at this number, default: 0
                    countTo: 1,// count to this number, default: 0
                    runOnce: true,// only run the counter once, default: false
                });
            }

        }
    });

    //Product Details image js

    $('.sp-wrap').smoothproducts();

    // Datetimepicker

    $('#DateAndTime').datetimepicker({
        format: 'd.m.Y H:i',
        minDate: 0,
        step: 15,
        minTime: '9:30',
        maxTime: '17:01',
        yearStart: 2020,
        disabledWeekDays: [0, 6]
    });

    //add wishlist

});

//var togglePassword = document.getElementById("toggle-password");

//if (togglePassword) {
//    togglePassword.addEventListener('click', function () {
//        var x = document.getElementById("password");
//        if (x.type === "password") {
//            x.type = "text";
//        } else {
//            x.type = "password";
//        }
//    });
//}
 



