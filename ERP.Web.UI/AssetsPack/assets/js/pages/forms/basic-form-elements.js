'use strict';
$(function () {
    //Textare auto growth
    autosize($('textarea.auto-growth'));

    //Datetimepicker plugin
    $('.datetimepicker').bootstrapMaterialDatePicker({
        format: 'dddd DD MMMM YYYY - HH:mm',
        clearButton: false,
        weekStart: 1
    });

    $('.datepicker').datepicker({
        autoclose: true,
        clearBtn: true,
        format: 'dd/mm/yyyy',
        container: $(document.activeElement).parent()
    });

    $('.datepicker2').datepicker({
        autoclose: true,
        clearBtn: true,
        assumeNearbyYear: true,
        container: $(document.activeElement).parent()
    });

    //$('.datepicker2').bootstrapMaterialDatePicker({
    //    format: 'DD MMMM YYYY',
    //    clearButton: false,
    //    weekStart: 1,
    //    time: false
    //});

    $('.timepicker').bootstrapMaterialDatePicker({
        format: 'HH:mm',
        clearButton: false,
        date: false
    });

    $('.datepicker').datepicker()
        .on('show', function (e) {            
            console.log($(e.target).parent());
            //console.log($('body').siblings('.datepicker'));
            let html = $('.datepicker-dropdown');
            $(e.target).parent().append(html);
        });

    $('input#input_text, textarea#textarea2').characterCounter();

    $('.datepicker,.datetimepicker,.datepicker2,.timepicker').on('change', function (e, date) {        
        $(this).parent().addClass("focused");
        //$(this).siblings('label').focus();
        //$(this).siblings('label').addClass('active');
    });

    function isDeleteKey(key) {
        if (key === 8 || key === 46) {
            return true;
        } else {
            return false;
        }
    }

    $('.datepicker,.datepicker2').on('keyup', function (event) {
        let key = event.keyCode;
        if (key === 32) {
            event.preventDefault();
        }
        if ($(this).val().length === 2 && !isDeleteKey(key)) {
            $(this).val($(this).val() + '/');
        } else if ($(this).val().length === 5 && !isDeleteKey(key)) {
            $(this).val($(this).val() + '/');
        }
    });

    $('.datepicker').attr('maxlength', '10');
});




$('#main-modal input.form-control').focus(function () {
    $(this).parent('.form-line').addClass('focused');    
});

$('#main-modal input.form-control').blur(function () {

    $(this).parent('.form-line').removeClass('focused');

    if ($(this).val() !== '') {
        $(this).parent('.form-line').addClass('focused');
    }

});