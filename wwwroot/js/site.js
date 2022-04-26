//Search bar
$(document).ready(function () {
    $("#homepageUserInput").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#homepageTableBody tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });


    //var table = $('#patientTable').DataTable({
    //    "ordering": false,
    //    "order": [],  // not set any order rule for any column.
    //    "scrollX": true
    //});
});








//function pageLoad() {
//    document.getElementById("saveRow").style.display = "none";
//}

//$('.edit').on('click', function () {
//    document.getElementById("saveRow").style.display = "inline";
//    document.getElementById("editRow").style.display = "none";

//    //x for triage
//    $(".TriageCloseLowHigh").show();
//});

//$('.save').on('click', function () {

//    alert("test");

//    //document.getElementById("saveRow").style.display = "none";
//    //document.getElementById("editRow").style.display = "inline";
//});


///**************************/
///*Drop Down Hambuger Menu*/
///*************************/

//function myFunction() {
//    document.getElementById("myDropdown").classList.toggle("show");
//}

//// Close the dropdown if the user clicks outside of it
//window.onclick = function (event) {
//    if (!event.target.matches('.dropbtn')) {
//        var dropdowns = document.getElementsByClassName("dropdown-content");
//        var i;
//        for (i = 0; i < dropdowns.length; i++) {
//            var openDropdown = dropdowns[i];
//            if (openDropdown.classList.contains('show')) {
//                openDropdown.classList.remove('show');
//            }
//        }
//    }
//}


//Triage Buttons
//function TriageButtons() {

//    var low = document.getElementById("green");
//    var medium = document.getElementById("yellow");
//    var high = document.getElementById("red");


//    low.onclick = function () {
//        medium.style.display = "none";
//        high.style.display = "none";
//    }

//    medium.onclick = function () {
//        low.style.display = "none";
//        high.style.display = "none";
//    }

//    high.onclick = function () {
//        low.style.display = "none";
//        medium.style.display = "none";
//    }
//}

//$('.triageBtn#green').on('click', function () {
//    $(this).css('padding', '0');
//    $(this).css('width', '80px');
//    $(this).css('content', 'Low');
//    $('.triageBtn#yellow').hide();
//    $('.triageBtn#red').hide();
//});


//$('.triageBtn#yellow').on('click', function () {
//    $(this).css('padding', '0');
//    $(this).css('width', '80px');
//    $(this).css('content', 'Low');
//    $('.triageBtn#green').hide();
//    $('.triageBtn#red').hide();
//});

//$('.triageBtn#red').on('click', function () {
//    $(this).css('padding', '0');
//    $(this).css('width', '80px');
//    $(this).css('content', 'Low');
//    $('.triageBtn#green').hide();
//    $('.triageBtn#yellow').hide();
//});


//$('.TriageCloseLowHigh').on('click', function () {
//    $('.triageBtn').hide();
//});




//Triage Buttons

//var low = document.getElementById("green");
//var medium = document.getElementById("yellow");
//var high = document.getElementById("red");

//$(".TriageCloseMedium").hide();
//$(".TriageCloseLowHigh").hide();

//function TriageButtons() {
//    low.onclick = function () {
//        medium.style.display = "none";
//        high.style.display = "none";
//        $(".TriageCloseLowHigh").show();
//    };

//    medium.onclick = function () {
//        low.style.display = "none";
//        high.style.display = "none";
//        $(".TriageCloseMedium").show();
//    };

//    high.onclick = function () {
//        low.style.display = "none";
//        medium.style.display = "none";
//        $(".TriageCloseLowHigh").show();
//    };
//}

//$(".triageBtn#green").on("click", function () {
//    $(this).css("padding", "0");
//    $(this).css("width", "80px");
//    $(this).css("content", "Low");
//    $(".triageBtn#yellow").hide();
//    $(".triageBtn#red").hide();
//    $(".TriageCloseLowHigh").show();
//});

//$(".triageBtn#yellow").on("click", function () {
//    $(this).css("padding", "0");
//    $(this).css("width", "80px");
//    $(this).css("content", "Low");
//    $(".triageBtn#green").hide();
//    $(".triageBtn#red").hide();
//    $(".TriageCloseMedium").show();
//});

//$(".triageBtn#red").on("click", function () {
//    $(this).css("padding", "0");
//    $(this).css("width", "80px");
//    $(this).css("content", "Low");
//    $(".triageBtn#green").hide();
//    $(".triageBtn#yellow").hide();
//    $(".TriageCloseLowHigh").show();
//});

//$(".TriageCloseLowHigh").on("click", function () {
//    $(".TriageCloseMedium").hide();
//    $(".TriageCloseLowHigh").hide();
//    low.style.display = "inline";
//    medium.style.display = "inline";
//    high.style.display = "inline";
//    $(this).css("width", "30px");
//});

//$(".TriageCloseMedium").on("click", function () {
//    $(".TriageCloseMedium").show();
//    $(".TriageCloseLowHigh").hide();
//    low.style.display = "inline";
//    medium.style.display = "inline";
//    high.style.display = "inline";
//    $(this).css("width", "30px");
//});



////////////////////////////////
//Reason multi select dropdown//
////////////////////////////////
//Array.prototype.search = function (elem) {
//    for (var i = 0; i < this.length; i++) {
//        if (this[i] == elem) return i;
//    }

//    return -1;
//};

//var Multiselect = function (selector) {
//    if (!$(selector)) {
//        console.error("ERROR: Element %s does not exist.", selector);
//        return;
//    }
 
//    this.selector = selector;
//    this.selections = [];

//    (function (that) {
//        that.events();
//    })(this);
//};

//Multiselect.prototype = {
//    open: function (that) {
//        var target = $(that).parent().attr("data-target");

     
//        if (!this.selections) {
//            this.selections = [];
//        }

//        $(this.selector + ".multiselect").toggleClass("active");
//    },

//    close: function () {
//        $(this.selector + ".multiselect").removeClass("active");
//    },

//    events: function () {
//        var that = this;

//        $(document).on("click", that.selector + ".multiselect > .title", function (e) {
//            if (e.target.className.indexOf("close-icon") < 0) {
//                that.open();
//            }
//        });

//        $(document).on("click", that.selector + ".multiselect option", function (e) {
//            var selection = $(this).attr("value");
//            var target = $(this).parent().parent().attr("data-target");

//            var io = that.selections.search(selection);

//            if (io < 0) that.selections.push(selection);
//            else that.selections.splice(io, 1);

//            that.selectionStatus();
//            that.setSelectionsString();
//        });

//        $(document).on("click", that.selector + ".multiselect > .title > .close-icon", function (e) {
//            that.clearSelections();
//        });

//        $(document).click(function (e) {
//            if (e.target.className.indexOf("title") < 0) {
//                if (e.target.className.indexOf("text") < 0) {
//                    if (e.target.className.indexOf("-icon") < 0) {
//                        if (e.target.className.indexOf("selected") < 0 ||
//                            e.target.localName != "option") {
//                            that.close();
//                        }
//                    }
//                }
//            }
//        });
//    },

//    selectionStatus: function () {
//        var obj = $(this.selector + ".multiselect"); 

//        if (this.selections.length) obj.addClass("selection");
//        else obj.removeClass("selection");
//    },

//    clearSelections: function () {
//        this.selections = [];
//        this.selectionStatus();
//        this.setSelectionsString();
//    },
     
//    getSelections: function () {
//        return this.selections;
//    },

//    setSelectionsString: function () {
//        var selects = this.getSelectionsString().split(", ");
//        $(this.selector + ".multiselect > .title").attr("title", selects);

//        var opts = $(this.selector + ".multiselect option");

//        if (selects.length > 6) {
//            var _selects = this.getSelectionsString().split(", ");
//            _selects = _selects.splice(0, 6);
//            $(this.selector + ".multiselect > .title > .text")
//                .text(_selects + " [...]");
//        }
//        else {
//            $(this.selector + ".multiselect > .title > .text")
//                .text(selects);
//        }

//        for (var i = 0; i < opts.length; i++) {
//            $(opts[i]).removeClass("selected");
//        }

//        for (var j = 0; j < selects.length; j++) {
//            var select = selects[j];

//            for (var i = 0; i < opts.length; i++) {
//                if ($(opts[i]).attr("value") == select) {
//                    $(opts[i]).addClass("selected");
//                    break;
//                }
//            }
//        }
//    },

//    getSelectionsString: function () {
//        if (this.selections.length > 0)
//            return this.selections.join(", ");
//        else return "Select";
//    },

//    setSelections: function (arr) {
//        if (!arr[0]) {
//            error("ERROR: This does not look like an array.");
//            return;
//        }

//        this.selections = arr;
//        this.selectionStatus();
//        this.setSelectionsString();
//    },
//};

//$(document).ready(function () {
//    var multi = new Multiselect("#reason");

      

//});






//////////
//TABLE//
/////////
//$(document).ready(function () {
//    var t = $('#PatientTable').DataTable({

//        //columnDefs: [{ type: 'date', 'targets': [1] }],
//        //"order": [[0, "desc"]],     

//        //Remove ordering option
//        //"ordering": false,

//        //Options for drop down menu - show entries
//        "lengthMenu": [[10, 15, 25, -1], [10, 15, 25, "All"]], 

//        //Number of entries per page
//        "pageLength": 10,

//        //Freeze header column
//        "fixedHeader": true,

//        //Scroll bar on x-axis
//        "scrollX": "500px",

//        //Position of table length drop down, search bar, information summary, and pagination
//        "dom": '<lf>t<ip>',
        
//        "autoWidth": false,

//        //fixedColumns: {
//        //    leftColumns: 4,
//        //}
               
        
//    });

   
//    $('#editRow').on('click', function () {

//        //document.getElementById("saveRow").style.visibility = "visible";
//        //document.getElementById("editRow").style.visibility = "hidden";


//        //DateTime
//        $(this).parent().siblings('td.dataDate').each(function () {
//            var content = $(this).html();
//            $(this).html('<input value= "' + content + '" />');
//        });

//        //Textboxes
//        $(this).parent().siblings('td.dataText').each(function () {
//            var content = $(this).html();
//            $(this).html('<input value="' + content + '" />');
//        });        

//        //Dropdown boxes
//        $(this).parent().siblings('td.dataDrop').each(function () {
//            var content = $(this).html();
//            $(this).html('<input value="' + content + '" />');
//        });      

//        //Triage Buttons


//    });

//    $(document).on('click', '#saveRow', function () {

//        $('input').each(function () {
//            var content = $(this).val();
//            $(this).html(content);
//            $(this).contents().unwrap();
//        });      

//    });

 
    //Arrival Time Populate
    //$('#addRow').click(function () {
    //   var time = moment().format('YYYY-MM-DDThh:mm:ss');
    //   $('#time-holder').val(time);
    //});


    //function arriveTime() {
    //            var time = moment().format('YYYY-MM-DDThh:mm'); $('#time-holder').val(time);
    //        }
      

    //ADD NEW ROW & POPULATE FIELDS
    //$('#addRow').on('click', function () {
    //    t.row.add([
            

    //        //Index
    //        //document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><id="id" style="text-align:center; display:none"/>22</tr>',

    //        //Save
    //        //document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><td class="invalid"><a class="button button-small save" id="save" title="Save"><i style="font-size:20px" class="fa fa-save"></i></a></td></tr>',

    //        //document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><td class="invalid"><a class="button button-small save" id="save" title="Save"><i style="font-size:20px" class="fa fa-save"><script>SavePatient();</script></i></a></td></tr>',
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><td class="invalid savePatient"><a class="button button-small save" id="save" title="Save"><i style="font-size:20px" class="fa fa-save"></i></a></td></tr>',
            
    //        //Arrival Time
    //        //document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input type="datetime-local" class="DateTimeText" value="time" id="time-holder"><script>arriveTime();</script></tr>',
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input type="text" class="DateTimeText" value="time" id="time-holder"><script>arriveTime();</script></tr>',
            
    //        //Name
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr>name</tr>',

    //        //Age
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr>age</tr>',

    //        //Sex
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr>sex</tr>',

    //        //Reason
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><div class="multiselect" id="reason" multiple="multiple" data-target="multi-0"><div class="title noselect"><span class="text">Select</span><span class="close-icon" style="margin-top:-4px">&times;</span><span class="expand-icon" style="margin-top:-4px">&plus;</span></div><div class="container ReasonContainer"><option value="Suicidal">Suicidal</option><option value="Homicidal">Homicidal</option><option value="Auditory">Auditory</option><option value="CD">CD</option><option value="Residental Treatment">Residental Treatment</option></div></div></tr>',

    //        //Arrival Mode
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><select name="arrivalMode" id="arrivalMode" style="padding:5px"><option>Select</option><option value="car">Car</option><option value="police">Police</option><option value="emt">EMT</option><option value="other">Other</option></select></tr>',

    //        //Arrival Type
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><select name="arrivalType" id="arrivalType" style="padding:5px"><option>Select</option><option value="walkIn">Walk In</option><option value="transfer">Transfer</option></select></tr</tr>',

    //        //Chief Complaint
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><select name="chiefComplaint" id="chiefComplaint" style="padding:5px"><option>Select</option><option value="mentalHealth">Mental Health</option><option value="detox">Detox</option><option value="resCD">Res - CD</option><option value="iop">IOP</option><option value="phone">Phone</option><option value="infoOnly">Info Only</option></select></tr>',

    //        //Triage
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><div id="actionsection"><button type = "button" class= "btn btn-primary triageBtn" style = "background-color:#71BC78; margin: 0px 3px 0px 0px" id = "green" ><span class="btn-text">Low</span></button ><button type="button" class="btn btn-primary triageBtn" style="background-color:#EDD068; margin: 0px 4px 0px 2px" id="yellow"><span class="btn-text">Medium</span></button><button type="button" class="btn btn-primary triageBtn" style="background-color:#EE3838; margin: 0px 0px 0px 0px" id="red"><span class="btn-text">High</span></button></div></tr>',

    //        //SBAR Call Time
    //        //document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><div class="form-check"><input class="form-check-input dateCheck" type="checkbox" value="" id="flexCheckDefault"><input type="text" id="dateTime" style="text-align:center; display:none"/></div></tr>',
    //        //document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input class="sBarCheckBox" type="checkbox" name="dateCheckBox" value="0" id="DateCheck"/><input type="datetime-local" class="dateTimeBox" value="" id="time-holder" style="text-align:center; display:none"/></tr>',
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input class="sBarCheckBox" type="checkbox" name="dateCheckBox" value="0" id="sBarDateCheck"/><input type="datetime-local" class="sBardateTimeBox" value="" id="time-holdersBar" style="text-align:center; display:none"/></tr>',

    //        //MSE Start Time
    //        //document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input class="sBarCheckBox" type="checkbox" name="dateCheckBox" value="0" id="DateCheck"/><input type="datetime-local" class="dateTimeBox" value="" id="time-holder" style="text-align:center; display:none"/></tr>',
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input class="MSEStartCheckBox" type="checkbox" name="dateCheckBox" value="0" id="MSEStartDateCheck"/><input type="datetime-local" class="MSEStartdateTimeBox" value="" id="time-holderMSEStart" style="text-align:center; display:none"/></tr>',

    //        //MSE End Time
    //        //document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input class="sBarCheckBox" type="checkbox" name="dateCheckBox" value="0" id="DateCheck"/><input type="datetime-local" class="dateTimeBox" value="" id="time-holder" style="text-align:center; display:none"/></tr>',
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input class="MSEEndCheckBox" type="checkbox" name="dateCheckBox" value="0" id="MSEEndCheckBox"/><input type="datetime-local" class="MSEEnddateTimeBox" value="" id="time-holderMSEEnd" style="text-align:center; display:none"/></tr>',

    //        //Nurse
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr>name</tr>',

    //        //Assessment Wait Time
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr>25</tr>',
             
    //        //Assessment Start Time
    //        //document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input class="sBarCheckBox" type="checkbox" name="dateCheckBox" value="0" id="DateCheck"/><input type="datetime-local" class="dateTimeBox" value="" id="time-holder" style="text-align:center; display:none"/></tr>',
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input class="AssessStartCheckBox" type="checkbox" name="dateCheckBox" value="0" id="AssessStartCheckBox"/><input type="datetime-local" class="AssessStartdateTimeBox" value="" id="time-holderAssessStart" style="text-align:center; display:none"/></tr>',

    //        //Assessment End Time
    //        //document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input class="sBarCheckBox" type="checkbox" name="dateCheckBox" value="0" id="DateCheck"/><input type="datetime-local" class="dateTimeBox" value="" id="time-holder" style="text-align:center; display:none"/></tr>',
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input class="AssessEndCheckBox" type="checkbox" name="dateCheckBox" value="0" id="AssessEndCheckBox"/><input type="datetime-local" class="AssessEnddateTimeBox" value="" id="time-holderAssessEnd" style="text-align:center; display:none"/></tr>',

    //        //Assessor Name
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr>name</tr>',

    //        //Assessment Room
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><select name="assessmentRoom" id="assessmentRoom" style="padding:5px"><option>Select</option><option value="one">1</option><option value="two">2</option><option value="three">3</option><option value="four">4</option><option value="five">5</option><option value="six">6</option><option value="Lobby">Lobby</option><option value="Sub">Sub</option></select></tr</tr >',

    //        //Emergency Medical Condition
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><select name="emergencyMedCond" id="emergencyMedCon" style="padding:5px"><option>Select</option><option value="yes">Yes</option><option value="no">No</option></select></tr>',

    //        //Cert
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr> <select name="cert" id="cert" style="padding:5px"><option>Select</option><option value="deferred">Deferred</option><option value="Complete">Complete</option></select></tr>',

    //        //Patient Went To Unit
    //        //document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input class="sBarCheckBox" type="checkbox" name="dateCheckBox" value="0" id="DateCheck"/><input type="datetime-local" class="dateTimeBox" value="" id="time-holder" style="text-align:center; display:none"/></tr>',
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input class="PatientUnitCheckBox" type="checkbox" name="dateCheckBox" value="0" id="PatientUnitCheckBox"/><input type="datetime-local" class="PatientUnitdateTimeBox" value="" id="time-holderPatientUnit" style="text-align:center; display:none"/></tr>',

    //        //Departure Time (Non Admits)
    //        //document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input class="sBarCheckBox" type="checkbox" name="dateCheckBox" value="0" id="DateCheck"/><input type="datetime-local" class="dateTimeBox" value="" id="time-holder" style="text-align:center; display:none"/></tr>',
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input class="DepartNonCheckBox" type="checkbox" name="dateCheckBox" value="0" id="DepartNonCheckBox"/><input type="datetime-local" class="DepartNondateTimeBox" value="" id="time-holderDepartNon" style="text-align:center; display:none"/></tr>',

    //        //Arrival To Disposition
    //        //document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input class="sBarCheckBox" type="checkbox" name="dateCheckBox" value="0" id="DateCheck"/><input type="datetime-local" class="dateTimeBox" value="" id="time-holder" style="text-align:center; display:none"/></tr>',
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input class="ArriveDispCheckBox" type="checkbox" name="dateCheckBox" value="0" id="ArriveDispCheckBox"/><input type="datetime-local" class="ArriveDispdateTimeBox" value="" id="time-holderArriveDisp" style="text-align:center; display:none"/></tr>',

    //        //Disposition
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr> <select name="dispositionType" id="dispositionType" style="padding:5px"><option>Select</option><option value="admitted">Admitted</option><option value="IOP">IOP</option><option value="Refusal">Refusal</option><option value="MedTx">Med Tx</option><option value="CoMoTx">CoMo Tx</option><option value="POAssessment">PO Assessment</option><option value="InfoOnly">Info Only</option></select></tr>',

    //        //Departure Mode
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr> <select name="departureMode" id="departureMode" style="padding:5px"><option>Select</option><option value="admitted">Admitted</option><option value="car">Car</option><option value="Police">Police</option><option value="EMT">EMT</option><option value="Other">Other</option></select></tr>',

    //        //Complete
    //        //document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input class="sBarCheckBox" type="checkbox" name="dateCheckBox" value="0" id="DateCheck"/><input type="datetime-local" class="dateTimeBox" value="" id="time-holder" style="text-align:center; display:none"/></tr>',
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input class="CompleteCheckBox" type="checkbox" name="dateCheckBox" value="0" id="CompleteCheckBox"/><input type="datetime-local" class="CompletedateTimeBox" value="" id="time-holderComplete" style="text-align:center; display:none"/></tr>',

    //        //Process Time
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr></tr>',

    //        //Comments
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><button type="button" class="CommentsIcon" data-toggle="modal" data-target="#exampleModalCenter"><i style = "font-size:20px" class= "far" >&#xf27a;</i></button ></tr>',

    //        //Delete
    //        document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><a class="button button-small edit" title="Delete" id="DeleteButton"><i style="font-size:20px" class="fa fa-trash"></i></a></tr>'
                        
    //    ]).draw(true);      
    //});


  
           
//    $("#patientBtns").on("click", "#DeleteButton", function () {
//    $.confirm({
//        title: 'Password Required',
//        content: '' +
//            '<form action="" class="formPassword">' +
//            '<div class="form-group">' +
//            '<input type="text" class="password form-control" required />' +
//            '</div>' +
//            '</form>',
//        buttons: {
//            formSubmit: {
//                text: 'Submit',
//                btnClass: 'btn-blue',
//                action: function () {
//                    var password = this.$content.find('.password').val();
//                    if (!password) {
//                        $.alert('provide a valid password');
//                        return false;
//                    }
//                    $.alert('DELETE RECORD <br> This action cannot be undone.');
//                }
//            },
//            cancel: function () {
//                //close
//            },
//        },
//        onContentReady: function () {
//            // bind to events
//            var jc = this;
//            this.$content.find('form').on('submit', function (e) {
//                // if the user submits the form by pressing enter in the field.
//                e.preventDefault();
//                jc.$$formSubmit.trigger('click'); // reference the button and click it
//            });
//        }
//    });
//});


//    function DeleteRow() {
//        $(this).closest("tr").remove();
//    }

//});


////Assessment Wait Time Calculations
////Starts at MSE End Time checkbox to Assessment Start Time checkbox
//function assessmentWaitTimeCalc() {
//    var dt = new Date();
//    var time = dt.getHours() + ":" + dt.getMinutes() + ":" + dt.getSeconds();
//    var MSEEndTime = document.getElementById("MSEEndTime");

//    var waitTime = time - MSEEndTime;

//    alert(waitTime);

//    //document.getElementById("MSEEndTime").value = waitTime;

//}





///**********Settings Modal Password **************/
//$(document).ready(function () {

//    $('#password').keyup(function () {
//        var password = $('#password').val();
//        if (checkStrength(password) == false) {
//            $('#sign-up').attr('disabled', true);
//        }
//    });
//    $('#confirm-password').blur(function () {
//        if ($('#password').val() !== $('#confirm-password').val()) {
//            $('#popover-cpassword').removeClass('hide');
//            $('#sign-up').attr('disabled', true);
//        } else {
//            $('#popover-cpassword').addClass('hide');
//        }
//    });


//    function checkStrength(password) {
//        var strength = 0;


//        //If password contains both lower and uppercase characters, increase strength value.
//        if (password.match(/([a-z].*[A-Z])|([A-Z].*[a-z])/)) {
//            strength += 1;
//            $('.low-upper-case').addClass('text-success');
//            $('.low-upper-case i').removeClass('fa-file-text').addClass('fa-check');
//            $('#popover-password-top').addClass('hide');


//        } else {
//            $('.low-upper-case').removeClass('text-success');
//            $('.low-upper-case i').addClass('fa-file-text').removeClass('fa-check');
//            $('#popover-password-top').removeClass('hide');
//        }

//        //If it has numbers and characters, increase strength value.
//        if (password.match(/([a-zA-Z])/) && password.match(/([0-9])/)) {
//            strength += 1;
//            $('.one-number').addClass('text-success');
//            $('.one-number i').removeClass('fa-file-text').addClass('fa-check');
//            $('#popover-password-top').addClass('hide');

//        } else {
//            $('.one-number').removeClass('text-success');
//            $('.one-number i').addClass('fa-file-text').removeClass('fa-check');
//            $('#popover-password-top').removeClass('hide');
//        }

//        //If it has one special character, increase strength value.
//        if (password.match(/([!,%,&,@,#,$,^,*,?,_,~])/)) {
//            strength += 1;
//            $('.one-special-char').addClass('text-success');
//            $('.one-special-char i').removeClass('fa-file-text').addClass('fa-check');
//            $('#popover-password-top').addClass('hide');

//        } else {
//            $('.one-special-char').removeClass('text-success');
//            $('.one-special-char i').addClass('fa-file-text').removeClass('fa-check');
//            $('#popover-password-top').removeClass('hide');
//        }

//        if (password.length > 7) {
//            strength += 1;
//            $('.eight-character').addClass('text-success');
//            $('.eight-character i').removeClass('fa-file-text').addClass('fa-check');
//            $('#popover-password-top').addClass('hide');

//        } else {
//            $('.eight-character').removeClass('text-success');
//            $('.eight-character i').addClass('fa-file-text').removeClass('fa-check');
//            $('#popover-password-top').removeClass('hide');
//        }




//        // If value is less than 2

//        if (strength < 2) {
//            $('#result').removeClass()
//            $('#password-strength').addClass('progress-bar-danger');

//            $('#result').addClass('text-danger').text('Weak');
//            $('#password-strength').css('width', '10%');
//        } else if (strength == 2) {
//            $('#result').addClass('good');
//            $('#password-strength').removeClass('progress-bar-danger');
//            $('#password-strength').addClass('progress-bar-warning');
//            $('#result').addClass('text-warning').text('Medium')
//            $('#password-strength').css('width', '60%');
//            return 'Week'
//        } else if (strength == 4) {
//            $('#result').removeClass()
//            $('#result').addClass('strong');
//            $('#password-strength').removeClass('progress-bar-warning');
//            $('#password-strength').addClass('progress-bar-success');
//            $('#result').addClass('text-success').text('Strong');
//            $('#password-strength').css('width', '100%');

//            return 'Strong'
//        }

//    }

//});



