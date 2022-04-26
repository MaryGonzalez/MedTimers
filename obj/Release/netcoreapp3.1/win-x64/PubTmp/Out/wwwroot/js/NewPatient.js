$(document).ready(function () {

    //Hide Arrival Time text field
    $("#lblNewArriveDateTime").hide();

    //Hide Received Referral text field
    $("#lblReceivedReferralDateTime").hide();



    //Display text field if preferred name radio button is 'yes'
    $('input:radio[name="PreferredName"]').change(function () {
        if ($(this).val() === 'Yes') {
            document.getElementById('displayTextBox').style.display = 'block'
            $('.displayTextBox').attr('required');
        }
        if ($(this).val() === 'No') {
            document.getElementById('displayTextBox').style.display = 'none'
            $('.displayTextBox').removeAttr('required');
        }
    });

    //Format phone field for Guardian Phone Number
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

    //PATIENT ARRIVAL//
    //Date Time of patient arrival
    $('#NewArrivalCheckBox').change(function () {
        if (this.checked) {
            $("#NewArrivalCheckBox").hide();
            $("#InitialcheckboxClick").hide();
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
            $("#ReferralcheckboxClick").hide();
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
            { id: 0, text: "Anxiety/Depression" },
            { id: 1, text: "Auditory" },
            { id: 2, text: "CD" },
            { id: 3, text: "Homicidal" },
            { id: 4, text: "Information Only" },
            { id: 5, text: "Residential Treatment" },
            { id: 6, text: "Suicidal" },
            { id: 7, text: "Visual" }
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

    //Display walk-in info on refresh
    $(function () {
        var $radios = $('input:radio[id=Walkin]');
        if ($radios.is(':checked') === true) {
            $('#show-walk').show();
            $('#show-transfer').hide();
        }
    });

    //Display transfer/phone info on refresh
    $(function () {
        var $radios = $('input:radio[id=Transfer]');
        if ($radios.is(':checked') === true) {
            $('#show-walk').hide();
            $('#show-transfer').show();
        }
    });

      
    //If Arrival Type is Walk-in or Step Up, require Initial Arrival Time, Arrival Mode, and Admission Type
    //If Arrival Type is Transfer or Phone, require Received Referral
    $('input[name="Track_ArrivalType"]').change(function () {

        if ($(this).val() == 'Walk-in' || $(this).val() == 'Step Up') {

            //Require Initial Arrival Date/Time
            $('#NewArrivalCheckBox').prop('required', true);
           
            //Require Arrival Mode
            $("#submitNewPatient").click(function () {
                var inputMode = $("#inputMode");
                if (inputMode.val() == "") {
                    //If the "Please Select" option is selected display error.
                    document.getElementById("arrModeError").innerHTML = "*Arrival mode is required";
                    document.getElementById("arrModeError").style.color = "red";
                    return false;
                }

                return true;
            });



            //Require Admission Type
            $("#submitNewPatient").click(function () {
                var addmissionType = $("#addmissionType");
                if (addmissionType.val() == "") {
                    //If the "Please Select" option is selected display error.
                    document.getElementById("admitTypeError").innerHTML = "*Admission type is required";
                    document.getElementById("admitTypeError").style.color = "red";
                    return false;
                }
                return true;
            });
        } 

        if ($(this).val() == 'Transfer' || $(this).val() == 'Phone') {

            //Require Received Referral Date/Time
            $('#ReceivedReferralCheckBox').prop('required', true);         
            
        } 

       
    });


    //Emergency Contact Checkbox
    //$("#checkbox1").on('change', function () {
    //    if ($(this).is(':checked')) {
    //        $(this).attr('value', 'true');
    //        $(".dvGuardian").hide();
    //        $("#GuardianName").val("");
    //        $(".GuardianNumber").val("");
    //        $("#GuardianRelationship")[0].selectedIndex = 0;
    //    } else {
    //        $(this).attr('value', 'false');
    //        $(".dvGuardian").show();
    //    }        
    //});



    //Autofill disable text fields
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


    //Capitalize string first character to uppercase
    //Auto capital Patient's First Name
        jQuery('#txtcapital').keyup(function () {
            var caps = jQuery('#txtcapital').val();
            caps = caps.charAt(0).toUpperCase() + caps.slice(1);
            jQuery('#txtcapital').val(caps);
        });

    //Auto capital Patient's Last Name
    jQuery('#txtcapital2').keyup(function () {
        var caps = jQuery('#txtcapital2').val();
        caps = caps.charAt(0).toUpperCase() + caps.slice(1);
        jQuery('#txtcapital2').val(caps);
    });

    //Auto capital Patient's Preferred Name
    jQuery('#txtcapital3').keyup(function () {
        var caps = jQuery('#txtcapital3').val();
        caps = caps.charAt(0).toUpperCase() + caps.slice(1);
        jQuery('#txtcapital3').val(caps);
    });


    //Capitalize string every 1st chacter of word to uppercase
    //Auto capitalize Guardian Full Name
    jQuery('#txt_firstCapital').keyup(function () {
       var str = jQuery('#txt_firstCapital').val();
       var spart = str.split(" ");
       for (var i = 0; i < spart.length; i++) {
          var j = spart[i].charAt(0).toUpperCase();
          spart[i] = j + spart[i].substr(1);
       }
          jQuery('#txt_firstCapital').val(spart.join(" "));

       });
});