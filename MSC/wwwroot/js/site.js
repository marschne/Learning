$(document).ready(function () {
    console.log('ready.');
    var $div1 = $('<div id="div1" class="row div1 gap-3"></div>');
    $div1.append('<div class="col divClick divRed"></div>');
    $div1.append('<div class="col divClick divGreen"></div>');
    $div1.append('<div class="col divClick divBlue"></div>');
    $div1.append('<div class="col divClick divGrey"></div>');
    $('main').append($div1);

    $('.divClick').on('click', function () {
        var color = $(this).css('background-color');
        $('input[change-color="true"]').each(function (i) {
            this.style.background = color;
        });
    });
    
    $('div').filter('.row').eq(1).addClass('mt-2');
});