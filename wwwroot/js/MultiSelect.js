
$(document).ready(function () {

    /*Multi select REASON*/
    var elmReason2 = $('#reason');
    $(elmReason2).select2({
        placeholder: "Select",
        data: [
            //{ id: 0, text: "Auditory" },
            //{ id: 1, text: "CD" },
            //{ id: 2, text: "Homicidal" },
            //{ id: 3, text: "Residental Treatment" },
            //{ id: 4, text: "Suicidal" },
            //{ id: 5, text: "Visual" }
        ]
    }).change(function () {
        var reasonIDs = $.map($(elmReason2).select2('data'), function (val, i) {
            return val.text;
        }).join(", ");
        $('#reasonIDs').text(reasonIDs);
    });


    /*Multi select PRONOUNS*/
    var elmPronouns2 = $('#pronouns');
    $(elmPronouns2).select2({
        placeholder: "Select",
        data: [
            //{ id: 0, text: "She, Her, Hers" },
            //{ id: 1, text: "He, Him, His" },
            //{ id: 2, text: "They, Them, Theirs" },
            //{ id: 3, text: "No Pronoun" },
            //{ id: 4, text: "No Preference" },
            //{ id: 5, text: "Not Listed" }
        ]
    }).change(function () {
        var pronounIDs = $.map($(elmPronouns2).select2('data'), function (val, i) {
            return val.text;
        }).join(", ");
        $('#pronounIDs').text(pronounIDs);
    });


});