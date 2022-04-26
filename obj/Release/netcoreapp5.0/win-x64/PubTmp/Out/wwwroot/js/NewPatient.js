$(document).ready(function() {

    $('input:radio[name="PreferredName"]').change(function () {
        if ($(this).val() === 'Yes') {
            document.getElementById('displayTextBox').style.display = 'block'
        }
        if ($(this).val() === 'No') {
            document.getElementById('displayTextBox').style.display = 'none'
        }
    });



    var phoneField3 = document.getElementById('phoneField3');
    phoneField3.addEventListener('keyup', function () {
        var phoneValue = phoneField3.value;
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
        phoneField3.value = output;

    });

    var phoneField4 = document.getElementById('phoneField4');
    phoneField4.addEventListener('keyup', function () {
        var phoneValue = phoneField4.value;
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
        phoneField4.value = output;

    });











    //function ShowHideDiv() {
    //    var chkYes = document.getElementById("chkYes");
    //    var divYes = document.getElementById("divYes");
    //    divYes.style.display = chkYes.checked ? "block" : "none";
    //}


    //PATIENT ARRIVAL//
    //Date Time of patient arrival
    $('#NewArrivalCheckBox').change(function () {
        if (this.checked) {
            $("#NewArrivalCheckBox").hide();
            ArriveTime();
        }
    });

    //Date Time of patient arrival
    function ArriveTime() {
    $("#lblNewArriveDateTime").show();
    var today = new Date();
    var d = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
    var date = new Date();
    var hours = date.getHours() > 12 ? date.getHours() - 12 : date.getHours();
    var am_pm = date.getHours() >= 12 ? "PM" : "AM";
    hours = hours < 10 ? "0" + hours : hours;
    var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
    time = d + " " + hours + ":" + minutes + " " + am_pm;
    var lblNewArriveDateTime = document.getElementById("lblNewArriveDateTime");
    lblNewArriveDateTime.innerHTML = time;
    }



    //Date Time of received referral
    $('#ReceivedReferralCheckBox').change(function () {
        if (this.checked) {
            $("#ReceivedReferralCheckBox").hide();
            ReceivedReferral();
        }
    });

    //Date Time of received referral
    function ReceivedReferral() {
        $("#lblReceivedReferralDateTime").show();
        var today = new Date();
        var d = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
        var date = new Date();
        var hours = date.getHours() > 12 ? date.getHours() - 12 : date.getHours();
        var am_pm = date.getHours() >= 12 ? "PM" : "AM";
        hours = hours < 10 ? "0" + hours : hours;
        var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
        time = d + " " + hours + ":" + minutes + " " + am_pm;
        var lblReceivedReferralDateTime = document.getElementById("lblReceivedReferralDateTime");
        lblReceivedReferralDateTime.innerHTML = time;
    }





    //Show/Hide Arrival time or Received Referral

    $('input[type="radio"]').click(function () {
        var arrivalvalue = $(this).val();
        $("div.myDiv").hide();
        $("#show" + arrivalvalue).show();
    });
  

    /*Multi select REASON*/
    var elmReason = $('#reason');
    $(elmReason).select2({
        placeholder: "Select",
        data: [
            { id: 0, text: "Auditory" },
            { id: 1, text: "CD" },
            { id: 2, text: "Homicidal" },
            { id: 3, text: "Residental Treatment" },
            { id: 4, text: "Suicidal" },
            { id: 5, text: "Visual" }
        ]
    }).change(function () {
        var reasonIDs = $.map($(elmReason).select2('data'), function (val, i) {
            return val.text;
        }).join(", ");
        $('#reasonIDs').text(reasonIDs);
    });


    /*Multi select PRONOUNS*/
    var elmPronouns = $('#pronouns');
    $(elmPronouns).select2({
        placeholder: "Select",
        data: [
            { id: 6, text: "He, Him, His" },
            { id: 7, text: "She, Her, Hers" },
            { id: 8, text: "They, Them, Theirs" },
            { id: 9, text: "No Pronoun" },
            { id: 10, text: "No Preference" },
            { id: 11, text: "Not Listed" }
        ]
    }).change(function () {
        var pronounIDs = $.map($(elmPronouns).select2('data'), function (val, i) {
            return val.text;
        }).join(", ");
        $('#pronounIDs').text(pronounIDs);
    });



    /*Multi select GENDER*/
    var elmGender = $('#gender');
    $(elmGender).select2({
        placeholder: "Select",
        data: [
            { id: 12, text: "Agender" },
            { id: 13, text: "Cisgender (non-trans) Man" },
            { id: 14, text: "Cisgender (non-trans) Woman" },
            { id: 15, text: "Gender Non-conforming" },
            { id: 16, text: "Gender Varient" },
            { id: 17, text: "GenderQueer" },
            { id: 18, text: "Intersex" },
            { id: 19, text: "Non-Binary" },
            { id: 20, text: "Not Listed" },
            { id: 21, text: "Transgender Man" },
            { id: 22, text: "Transgender Woman" }
        ]
    }).change(function () {
        var genderIDs = $.map($(elmGender).select2('data'), function (val, i) {
            return val.text;
        }).join(", ");
        $('#genderIDs').text(genderIDs);
    });




    ///*Arrival Type Radio Buttons*/
    //Arrival Type Radio Button show/hide
    $('input[type="radio"]').click(function () {
        if ($(this).attr('id') == 'Walkin') {
            $('#show-walk').show();
            $('#show-transfer').hide();
        }
        else if ($(this).attr('id') == 'Transfer') {
            $('#show-walk').hide();
            $('#show-transfer').show();
        }

    });




    //Emergency Contact Checkbox

  /*  $('#checkbox-value').text($('#checkbox1').val());*/

    $("#checkbox1").on('change', function () {
        if ($(this).is(':checked')) {
            $(this).attr('value', 'true');
            $(".dvGuardian").hide();
            $("#GuardianName").val("");
            $(".GuardianNumber").val("");
            $("#GuardianRelationship")[0].selectedIndex = 0;
        } else {
            $(this).attr('value', 'false');
            $(".dvGuardian").show();
        }
        /*$('#checkbox-value').text($('#checkbox1').val());*/
    });



    //Autofill disable
    function OnClientLoad(sender, args) {
        disableAutoFill(sender);
    }

    function disableAutoFill(control) {
        function focusHandler(ev) {
            this.originalName = this.name;
            this.name = new Date().toString();
        }
        function blurHandler(ev) {
            this.name = this.originalName;
        }

        if (Telerik.Web.UI.RadComboBox && control instanceof Telerik.Web.UI.RadComboBox) {
            $telerik.$(control.get_inputDomElement()).on({
                focus: focusHandler,
                blur: blurHandler
            });
        } else if (Telerik.Web.UI.RadTextBox && control instanceof Telerik.Web.UI.RadTextBox) {
            $telerik.$(control.get_element()).on({
                focus: focusHandler,
                blur: blurHandler
            });
        }
    }





});