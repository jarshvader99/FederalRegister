$(document).ready(function () {

    $("#search").change(function () {
        if (!$('#search').val()) {
            $('.append-no-search').remove();
            $(".next-btn").hide();
        }
    });
    
    $("#search").keyup(function () {
        if ($('#search').val()) {
            var filter = $(this).val(), count = 0, cardHide = 0, cardShow = 0;
            $(".card-text").each(function () {
                if ($(this).text().search(new RegExp(filter, "i")) < 0) {
                    $(this).fadeOut();
                    $(this.parentElement).fadeOut();
                    cardHide++;
                }
                else {
                    $(this).show();
                    $(this.parentElement).show();
                    cardShow++;
                    $(".next-btn").show();
                }
                count++;
            });
            if (cardShow === 0 && cardHide === count) {
                if (!$('.append-no-search').text()) {
                    var txt3 = document.createElement("p");
                    txt3.className = "append-no-search d-flex justify-content-center";
                    txt3.innerHTML = "There is nothing here.";
                    $(".no-search").prepend(txt3);
                    $(".next-btn").hide();
                }
            }
            if (cardShow > 0 && cardHide < count)
            {
                $(this).fadeIn();
                $('.append-no-search').remove();
                $(".next-btn").show();
            }
        }
        else {
            $(".card-body").fadeIn();
            $(".card-text").fadeIn();
            $('.append-no-search').remove();
        }
    });

    $("#close-icon").click(function () {
        $(".card-body").fadeIn();
        $(".card-text").fadeIn();
        $("#search").val("");
        $('.append-no-search').remove();
        $(".next-btn").show();
    });
});



