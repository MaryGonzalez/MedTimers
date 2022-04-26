
$(document).ready(function () {


    /*Current Hospital Table */
    $(".search").keyup(function () {
        var searchTerm = $(".search").val();
        var listItem = $('.results tbody').children('tr');
        var searchSplit = searchTerm.replace(/ /g, "'):containsi('")

        $.extend($.expr[':'], {
            'containsi': function (elem, i, match, array) {
                return (elem.textContent || elem.innerText || '').toLowerCase().indexOf((match[3] || "").toLowerCase()) >= 0;
            }
        });

        $(".results tbody tr").not(":containsi('" + searchSplit + "')").each(function (e) {
            $(this).attr('visible', 'false');
        });

        $(".results tbody tr:containsi('" + searchSplit + "')").each(function (e) {
            $(this).attr('visible', 'true');
        });

        var jobCount = $('.results tbody tr[visible="true"]').length;
        $('.counter').text(jobCount + ' items');

        if (jobCount == '0') { $('.no-result').show(); }
        else { $('.no-result').hide(); }
    });







    var phoneField6 = document.getElementById('phoneField6');
    phoneField6.addEventListener('keyup', function () {
        var phoneValue = phoneField6.value;
        var output;
        phoneValue = phoneValue.replace(/[^0-9]/g, '');
        var area = phoneValue.substr(0, 3);
        var pre = phoneValue.substr(3, 3);
        var tel = phoneValue.substr(6, 4);
        if (area.length < 3) {
            output = "(" + area;
        } else if (area.length == 3 && pre.length < 3) {
            output = "(" + area + ")" + " " + pre;
        } else if (area.length == 3 && pre.length == 3) {
            output = "(" + area + ")" + " " + pre + " - " + tel;
        }
        phoneField6.value = output;

    });

    //Search bar
    $("#transferUserInput").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#transferTableBody tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });


    $('.selectpicker').selectpicker({
        liveSearch: true,
        showSubtext: true
    });

});