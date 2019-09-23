$(function () {
    $(document).bind('keydown', function (e) {
        console.log('e.keyCode:' + e.keyCode);
        if (e.keyCode == 13) {	// when press ENTER key, accept the inputed value.
            $("#btnSubmit").click();
        }
    });
})