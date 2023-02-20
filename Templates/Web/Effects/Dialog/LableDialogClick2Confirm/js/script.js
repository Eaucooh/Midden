let activeCard = 1;

$('.button').bind('click', function () {
    $('.cardWrapper:nth-child(' + activeCard + ')').removeClass('active').addClass('inactive');
    if (activeCard === 3) {
        activeCard = 0;
    }
    activeCard++;
    $('.cardWrapper:nth-child(' + activeCard + ')').removeClass('inactive').addClass('active');
});