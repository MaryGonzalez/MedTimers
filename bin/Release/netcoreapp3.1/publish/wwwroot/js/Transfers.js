
$(document).ready(function () {

    //Search bar
    $("#transferUserInput").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#transferTableBody tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });


    ////AssessmnetWaitTime > 30
    //$("#transferTable tr").each(function () {
    //    var td_value = $('td', this).eq(3).text();
    //    $(this).style.backgroundColor = "red";
    //});






    var phoneField1 = document.getElementById('phoneField1');
    phoneField1.addEventListener('keyup', function () {
        var phoneValue = phoneField1.value;
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
        phoneField1.value = output;

    });



    var phoneField2 = document.getElementById('phoneField2');
    phoneField2.addEventListener('keyup', function () {
        var phoneValue = phoneField2.value;
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
        phoneField2.value = output;

    });

    var phoneField5 = document.getElementById('phoneField5');
    phoneField5.addEventListener('keyup', function () {
        var phoneValue = phoneField5.value;
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
        phoneField5.value = output;

    });

    //////CHECKBOXES FOR DATETIME/////////////////////


    //PATIENT ARRIVAL//
    //Date Time of patient arrival
    $('#ArrivalCheckBox').change(function () {
        if (this.checked) {
            $("#ArrivalCheckBox").hide();
            ArriveTime();
        }
    });

    //Date Time of patient arrival
    function ArriveTime() {
        var today = new Date();
        var d = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
        var date = new Date();
        var hours = date.getHours() > 12 ? date.getHours() - 12 : date.getHours();
        var am_pm = date.getHours() >= 12 ? "PM" : "AM";
        hours = hours < 10 ? "0" + hours : hours;
        var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
        time = d + " " + hours + ":" + minutes + " " + am_pm;
        var lblArriveDateTime = document.getElementById("lblArriveDateTime");
        lblArriveDateTime.innerHTML = time;
    }



    //Date Time of Assessment Start
    $('#ArrivalCheckBox2').change(function () {
        if (this.checked) {
            $("#ArrivalCheckBox2").hide();
            $("#Arrival2checkboxClick").hide();            
            ArriveTime2();
        }
    });

    //Date Time of Assessment Start
    function ArriveTime2() {
        $("#lblArriveDateTime2").show();
        var today = new Date();
        var d = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
        var date = new Date();
        var hours = date.getHours() > 12 ? date.getHours() - 12 : date.getHours();
        var am_pm = date.getHours() >= 12 ? "PM" : "AM";
        hours = hours < 10 ? "0" + hours : hours;
        var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
        time = d + " " + hours + ":" + minutes + " " + am_pm;
        var lblArriveDateTime2 = document.getElementById("lblArriveDateTime2");
        lblArriveDateTime2.innerHTML = time;
    }

    //SBAR CALLED//
    //Date Time of SBAR Called
    $('#SBARCheckBox').change(function () {
        if (this.checked) {
            $("#SBARCheckBox").hide();
            $("#SBARcheckboxClick").hide();
            SBARTime();
        }
    });

    //Date Time of SBAR Called
    function SBARTime() {
        $("#lblSBARDateTime").show();
        var today = new Date();
        var d = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
        var date = new Date();
        var hours = date.getHours() > 12 ? date.getHours() - 12 : date.getHours();
        var am_pm = date.getHours() >= 12 ? "PM" : "AM";
        hours = hours < 10 ? "0" + hours : hours;
        var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
        time = d + " " + hours + ":" + minutes + " " + am_pm;
        var lblSBARDateTime = document.getElementById("lblSBARDateTime");
        lblSBARDateTime.innerHTML = time;
    }


    //SBAR CALLED transfer page//
    //Date Time of SBAR Called
    $('#SBARCheckBox2').change(function () {
        if (this.checked) {
            $("#SBARCheckBox2").hide();
            SBARTime2();
        }
    });

    //Date Time of SBAR Called
    function SBARTime2() {
        $("#lblSBARDateTime2").show();
        var today = new Date();
        var d = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
        var date = new Date();
        var hours = date.getHours() > 12 ? date.getHours() - 12 : date.getHours();
        var am_pm = date.getHours() >= 12 ? "PM" : "AM";
        hours = hours < 10 ? "0" + hours : hours;
        var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
        time = d + " " + hours + ":" + minutes + " " + am_pm;
        var lblSBARDateTime2 = document.getElementById("lblSBARDateTime2");
        lblSBARDateTime2.innerHTML = time;
    }




    //MSE ASSESSMENT START//
    //Date Time of MSE Assessment Start
    $('#MSEStartCheckBox').change(function () {
        if (this.checked) {
            $("#MSEStartCheckBox").hide();
            $("#MSEScheckboxClick").hide();            
            MSEStartTime();
        }
    });

    //Date Time of Assessment Start
    function MSEStartTime() {
        $("#lblMSEStartDateTime").show();
        var today = new Date();
        var d = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
        var date = new Date();
        var hours = date.getHours() > 12 ? date.getHours() - 12 : date.getHours();
        var am_pm = date.getHours() >= 12 ? "PM" : "AM";
        hours = hours < 10 ? "0" + hours : hours;
        var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
        time = d + " " + hours + ":" + minutes + " " + am_pm;
        var lblMSEStartDateTime = document.getElementById("lblMSEStartDateTime");
        lblMSEStartDateTime.innerHTML = time;
    }




    //MSE ASSESSMENT END
    //Date Time of MSE Assessment End
    $('#MSEEndCheckBox').change(function () {
        if (this.checked) {
            $("#MSEEndCheckBox").hide();
            $("#MSEEcheckboxClick").hide();
            MSEEndTime();
        }
    });

    //Date Time of Assessment End
    function MSEEndTime() {
        $("#lblMSEEndDateTime").show();
        var today = new Date();
        var d = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
        var date = new Date();
        var hours = date.getHours() > 12 ? date.getHours() - 12 : date.getHours();
        var am_pm = date.getHours() >= 12 ? "PM" : "AM";
        hours = hours < 10 ? "0" + hours : hours;
        var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
        time = d + " " + hours + ":" + minutes + " " + am_pm;
        var lblMSEEndDateTime = document.getElementById("lblMSEEndDateTime");
        lblMSEEndDateTime.innerHTML = time;
    }




    //ASSESSMENT START
    //Date Time of Assessment Start
    $('#AssessStartCheckBox').change(function () {
        if (this.checked) {
            $("#AssessStartCheckBox").hide();
            $("#AssessSScheckboxClick").hide();
            
            AssessStartTime();
        }
    });

    //Date Time of Assessment Start
    function AssessStartTime() {
        $("#lblAssessStartDateTime").show();
        var today = new Date();
        var d = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
        var date = new Date();
        var hours = date.getHours() > 12 ? date.getHours() - 12 : date.getHours();
        var am_pm = date.getHours() >= 12 ? "PM" : "AM";
        hours = hours < 10 ? "0" + hours : hours;
        var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
        time = d + " " + hours + ":" + minutes + " " + am_pm;
        var lblAssessStartDateTime = document.getElementById("lblAssessStartDateTime");
        lblAssessStartDateTime.innerHTML = time;
    }



    //ASSESSMENT END
    //Date Time of Assessment End
    $('#AssessEndCheckBox').change(function () {
        if (this.checked) {
            $("#AssessEndCheckBox").hide();
            $("#AssessEcheckboxClick").hide();            
            AssessEndTime();
        }
    });

    //Date Time of Assessment End
    function AssessEndTime() {
        $("#lblAssessEndDateTime").show();
        var today = new Date();
        var d = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
        var date = new Date();
        var hours = date.getHours() > 12 ? date.getHours() - 12 : date.getHours();
        var am_pm = date.getHours() >= 12 ? "PM" : "AM";
        hours = hours < 10 ? "0" + hours : hours;
        var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
        time = d + " " + hours + ":" + minutes + " " + am_pm;
        var lblAssessEndDateTime = document.getElementById("lblAssessEndDateTime");
        lblAssessEndDateTime.innerHTML = time;
    }


    //ARRIVAL TO DISPOSITION
    //Date Time of Arrival to Disposition
    $('#ArrivalDispCheckBox').change(function () {
        if (this.checked) {
            $("#ArrivalDispCheckBox").hide();
            $("#DispAcheckboxClick").hide();
            ArrivalDispTime();
        }
    });

    //Date Time of Arrival to Disposition
    function ArrivalDispTime() {
        $("#lblArrivalDispDateTime").show();
        var today = new Date();
        var d = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
        var date = new Date();
        var hours = date.getHours() > 12 ? date.getHours() - 12 : date.getHours();
        var am_pm = date.getHours() >= 12 ? "PM" : "AM";
        hours = hours < 10 ? "0" + hours : hours;
        var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
        time = d + " " + hours + ":" + minutes + " " + am_pm;
        var lblArrivalDispDateTime = document.getElementById("lblArrivalDispDateTime");
        lblArrivalDispDateTime.innerHTML = time;
    }



    //PATIENT WENT TO UNIT
    //Date Time of Patient Went To Unit
    $('#ToUnitCheckBox').change(function () {
        if (this.checked) {
            $("#ToUnitCheckBox").hide();
            $("#UnitcheckboxClick").hide();            
            ToUnitTime();
        }
    });

    //Date Time of Patient Went To Unit
    function ToUnitTime() {
        $("#lblToUnitDateTime").show();
        var today = new Date();
        var d = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
        var date = new Date();
        var hours = date.getHours() > 12 ? date.getHours() - 12 : date.getHours();
        var am_pm = date.getHours() >= 12 ? "PM" : "AM";
        hours = hours < 10 ? "0" + hours : hours;
        var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
        time = d + " " + hours + ":" + minutes + " " + am_pm;
        var lblToUnitDateTime = document.getElementById("lblToUnitDateTime");
        lblToUnitDateTime.innerHTML = time;
    }



    //DEPARTURE TIME
    //Date Time of Departure Time
    $('#DepartTimeCheckBox').change(function () {
        if (this.checked) {
            $("#DepartTimeCheckBox").hide();
            $("#DepartcheckboxClick").hide();            
            DepartTime();
        }
    });

    //Date Time of Departure Time
    function DepartTime() {
        $("#lblDepartTimeDateTime").show();
        var today = new Date();
        var d = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
        var date = new Date();
        var hours = date.getHours() > 12 ? date.getHours() - 12 : date.getHours();
        var am_pm = date.getHours() >= 12 ? "PM" : "AM";
        hours = hours < 10 ? "0" + hours : hours;
        var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
        time = d + " " + hours + ":" + minutes + " " + am_pm;
        var lblDepartTimeDateTime = document.getElementById("lblDepartTimeDateTime");
        lblDepartTimeDateTime.innerHTML = time;
    }





    //FAX RECEIVED
    //Date Time of Fax Received
    $('#FaxReceivedCheckBox').change(function () {
        if (this.checked) {
            $("#FaxReceivedCheckBox").hide();
            $("#FaxcheckboxClick").hide();            
            FaxReceivedTime();
        }
    });

    //Date Time of Fax Received
    function FaxReceivedTime() {
        $("#lblFaxReceivedDateTime").show();
        var today = new Date();
        var d = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
        var date = new Date();
        var hours = date.getHours() > 12 ? date.getHours() - 12 : date.getHours();
        var am_pm = date.getHours() >= 12 ? "PM" : "AM";
        hours = hours < 10 ? "0" + hours : hours;
        var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
        time = d + " " + hours + ":" + minutes + " " + am_pm;
        var lblFaxReceivedDateTime = document.getElementById("lblFaxReceivedDateTime");
        lblFaxReceivedDateTime.innerHTML = time;
    }




    //NOTIFIED OF ACCEPTANCE
    //Date Time of Notified Acceptance
    $('#NotifiedCheckBox').change(function () {
        if (this.checked) {
            $("#NotifiedCheckBox").hide();
            $("#NotifiedcheckboxClick").hide();            
            NotifiedTime();
        }
    });

    //Date Time of Fax Received
    function NotifiedTime() {
        $("#lblNotifiedDateTime").show();
        var today = new Date();
        var d = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
        var date = new Date();
        var hours = date.getHours() > 12 ? date.getHours() - 12 : date.getHours();
        var am_pm = date.getHours() >= 12 ? "PM" : "AM";
        hours = hours < 10 ? "0" + hours : hours;
        var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
        time = d + " " + hours + ":" + minutes + " " + am_pm;
        var lblNotifiedDateTime = document.getElementById("lblNotifiedDateTime");
        lblNotifiedDateTime.innerHTML = time;
    }





    //FOLLOW UP COMPLETE
    //Date Time of Follow Up
    $('#FollowUpCheckBox').change(function () {
        if (this.checked) {
            $("#FollowUpCheckBox").hide();
            $("#FollowcheckboxClick").hide();            
            FollowUpTime();
        }
    });

    //Date Time of Follow Up
    function FollowUpTime() {
        $("#lblFollowUpDateTime").show();
        var today = new Date();
        var d = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
        var date = new Date();
        var hours = date.getHours() > 12 ? date.getHours() - 12 : date.getHours();
        var am_pm = date.getHours() >= 12 ? "PM" : "AM";
        hours = hours < 10 ? "0" + hours : hours;
        var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
        time = d + " " + hours + ":" + minutes + " " + am_pm;
        var lblFollowUpDateTime = document.getElementById("lblFollowUpDateTime");
        lblFollowUpDateTime.innerHTML = time;
    }


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



    /*Multi select GENDER*/
    var elmGender2 = $('#genders');
    $(elmGender2).select2({
        placeholder: "Select",
        data: [
            //{ id: 0, text: "Agender" },
            //{ id: 1, text: "Cisgender (non-trans) Man" },
            //{ id: 2, text: "Cisgender (non-trans) Woman" },
            //{ id: 3, text: "Gender Non-conforming" },
            //{ id: 4, text: "Gender Varient" },
            //{ id: 5, text: "GenderQueer" },
            //{ id: 6, text: "Intersex" },
            //{ id: 7, text: "Non-Binary" },
            //{ id: 8, text: "Not Listed" },
            //{ id: 9, text: "Transgender Man" },
            //{ id: 10, text: "Transgender Woman" }
        ]
    }).change(function () {
        var genderIDs = $.map($(elmGender2).select2('data'), function (val, i) {
            return val.text;
        }).join(", ");
        $('#genderIDs').text(genderIDs);
    });







    //Emergency Contact Checkbox

    $('#checkbox-value').text($('#checkbox1').val());

    $("#checkbox1").on('change', function () {
        if ($(this).is(':checked')) {
            $(this).attr('value', 'true');
        } else {
            $(this).attr('value', 'false');
        }

        $('#checkbox-value').text($('#checkbox1').val());
    });

    //Guardian checkbox

    $("#checkbox1").click(function () {
        if ($(this).is(":checked")) {
            $(".dvGuardian").hide();
            $("#GuardianName").val("");
            $(".GuardianNumber").val("");
            $("#GuardianRelationship")[0].selectedIndex = 0;
        } else {
            $(".dvGuardian").show();
        }
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


    $('.selectpicker').selectpicker({
        liveSearch: false,
        showSubtext: false
    });






    //Character counter for textarea
    if ($('.character-counter').length > 0) {
        var maximumCharacters = 250;

        $('textarea').keyup(function () {
            var $this = $(this);
            var $parentElement = $this.parent();
            var $characterCounter = $parentElement.find('.character-counter');
            var $charactersRemaining = $parentElement.find('.characters-remaining');

            var typedText = $this.val();
            var textLength = typedText.length;
            var charactersRemaining = maximumCharacters - textLength;

            // chop the text to the desired length
            if (charactersRemaining <= 0) {
                $this.val(typedText.substr(0, maximumCharacters));
                charactersRemaining = 0;
                textLength = maximumCharacters;
            }
            if ($characterCounter.length) {
                $characterCounter.text(textLength);
            }
            if ($charactersRemaining.length) {
                $charactersRemaining.text(charactersRemaining);
            }
        });
    }





});

//DOB Date
$(function () {
    $("#datepicker").datepicker();
});

