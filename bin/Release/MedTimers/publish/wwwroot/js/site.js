//If checkbox is selected, log dateTime
$(document).ready(function () {
    dateTime.style.display = "none";
});

var checkBox = document.getElementById("flexCheckDefault");
var dateText = document.getElementById("dateTime");

$('.dateCheck').on('click', function () {
    checkBox.style.display = "none";
    dateTime.style.display = "block";
    DateTimeFunction();
});

function DateTimeFunction() {
    if (document.getElementById("flexCheckDefault").checked == true) {
        const time = new Date(Date.now()).toLocaleString('en-US', { dateStyle: 'short', timeStyle: 'short' });
        document.getElementById("dateTime").value = time;

        /*Add x clear button to text field*/
        //document.getElementById('Dateclear').style.display = 'block';

        /*Hide check box*/
    }
}



/*Drop Down Menu*/
/* When the user clicks on the button, 
toggle between hiding and showing the dropdown content */
function myFunction() {
    document.getElementById("myDropdown").classList.toggle("show");
}

// Close the dropdown if the user clicks outside of it
window.onclick = function (event) {
    if (!event.target.matches('.dropbtn')) {
        var dropdowns = document.getElementsByClassName("dropdown-content");
        var i;
        for (i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('show')) {
                openDropdown.classList.remove('show');
            }
        }
    }
}


//Triage Buttons
function TriageButtons() {

    var low = document.getElementById("green");
    var medium = document.getElementById("yellow");
    var high = document.getElementById("red");


    low.onclick = function () {
        medium.style.display = "none";
        high.style.display = "none";
    }

    medium.onclick = function () {
        low.style.display = "none";
        high.style.display = "none";
    }

    high.onclick = function () {
        low.style.display = "none";
        medium.style.display = "none";
    }
}

$('.triageBtn#green').on('click', function () {
    $(this).css('padding', '0');
    $(this).css('width', '80px');
    $(this).css('content', 'Low');
    $('.triageBtn#yellow').hide();
    $('.triageBtn#red').hide();
});


$('.triageBtn#yellow').on('click', function () {
    $(this).css('padding', '0');
    $(this).css('width', '80px');
    $(this).css('content', 'Low');
    $('.triageBtn#green').hide();
    $('.triageBtn#red').hide();
});

$('.triageBtn#red').on('click', function () {
    $(this).css('padding', '0');
    $(this).css('width', '80px');
    $(this).css('content', 'Low');
    $('.triageBtn#green').hide();
    $('.triageBtn#yellow').hide();
});


/////////////////
Array.prototype.search = function (elem) {
    for (var i = 0; i < this.length; i++) {
        if (this[i] == elem) return i;
    }

    return -1;
};

var Multiselect = function (selector) {
    if (!$(selector)) {
        console.error("ERROR: Element %s does not exist.", selector);
        return;
    }

    this.selector = selector;
    this.selections = [];

    (function (that) {
        that.events();
    })(this);
};

Multiselect.prototype = {
    open: function (that) {
        var target = $(that).parent().attr("data-target");

     
        if (!this.selections) {
            this.selections = [];
        }

        $(this.selector + ".multiselect").toggleClass("active");
    },

    close: function () {
        $(this.selector + ".multiselect").removeClass("active");
    },

    events: function () {
        var that = this;

        $(document).on("click", that.selector + ".multiselect > .title", function (e) {
            if (e.target.className.indexOf("close-icon") < 0) {
                that.open();
            }
        });

        $(document).on("click", that.selector + ".multiselect option", function (e) {
            var selection = $(this).attr("value");
            var target = $(this).parent().parent().attr("data-target");

            var io = that.selections.search(selection);

            if (io < 0) that.selections.push(selection);
            else that.selections.splice(io, 1);

            that.selectionStatus();
            that.setSelectionsString();
        });

        $(document).on("click", that.selector + ".multiselect > .title > .close-icon", function (e) {
            that.clearSelections();
        });

        $(document).click(function (e) {
            if (e.target.className.indexOf("title") < 0) {
                if (e.target.className.indexOf("text") < 0) {
                    if (e.target.className.indexOf("-icon") < 0) {
                        if (e.target.className.indexOf("selected") < 0 ||
                            e.target.localName != "option") {
                            that.close();
                        }
                    }
                }
            }
        });
    },

    selectionStatus: function () {
        var obj = $(this.selector + ".multiselect");

        if (this.selections.length) obj.addClass("selection");
        else obj.removeClass("selection");
    },

    clearSelections: function () {
        this.selections = [];
        this.selectionStatus();
        this.setSelectionsString();
    },

    getSelections: function () {
        return this.selections;
    },

    setSelectionsString: function () {
        var selects = this.getSelectionsString().split(", ");
        $(this.selector + ".multiselect > .title").attr("title", selects);

        var opts = $(this.selector + ".multiselect option");

        if (selects.length > 6) {
            var _selects = this.getSelectionsString().split(", ");
            _selects = _selects.splice(0, 6);
            $(this.selector + ".multiselect > .title > .text")
                .text(_selects + " [...]");
        }
        else {
            $(this.selector + ".multiselect > .title > .text")
                .text(selects);
        }

        for (var i = 0; i < opts.length; i++) {
            $(opts[i]).removeClass("selected");
        }

        for (var j = 0; j < selects.length; j++) {
            var select = selects[j];

            for (var i = 0; i < opts.length; i++) {
                if ($(opts[i]).attr("value") == select) {
                    $(opts[i]).addClass("selected");
                    break;
                }
            }
        }
    },

    getSelectionsString: function () {
        if (this.selections.length > 0)
            return this.selections.join(", ");
        else return "Select";
    },

    setSelections: function (arr) {
        if (!arr[0]) {
            error("ERROR: This does not look like an array.");
            return;
        }

        this.selections = arr;
        this.selectionStatus();
        this.setSelectionsString();
    },
};

$(document).ready(function () {
    var multi = new Multiselect("#countries");
});


///////////

//TABLE
$(document).ready(function () {
    var t = $('#PatientTable').DataTable({

        columnDefs: [{ type: 'date', 'targets': [1] }],
        "order": [[1, "desc"]],       

        //Remove ordering option
        //"ordering": false,

        //Options for drop down menu - show entries
        "lengthMenu": [[50, 75, 100, -1], [50, 75, 100, "All"]],

        //Number of entries per page
        "pageLength": 50,

        //Freeze header column
        "fixedHeader": true,

        //Scroll bar on x-axis
        "scrollX": "500px",

        //Position of table length drop down, search bar, information summary, and pagination
        "dom": '<"lobbyTitle"lf>t<"bottom"ip>',
        
        "autoWidth": false

        
    });
        
              
    $("#PatientTable").on("click", "#editRow", function () {
        $(this).closest("tr").edit();
    });


    //ADD NEW ROW & POPULATE FIELDS
    $('#addRow').on('click', function () {
      

        t.row.add([
                               
            //Edit
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><a class="button button-small edit" id="editPencil" title="Edit"><i style="font-size:20px" class="fa fa-pencil"></i></a></tr>',

            //Arrival Time
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input type="datetime-local" id="arrivalTime"/></tr>',
            //document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr>06/09/2021 09:24 AM</tr>',

            //Name
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input type="text" id="patientName" style="text-align:center"/></tr>',

            //Age
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input type="text" id="patientAge" style="width: 50px; text-align:center;"/></tr>',

            //Sex
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><select name="sex" id="sex" style="padding:5px"><option>Select</option><option value="male">Male</option><option value="female">Female</option></select></tr>',

            //Reason
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><div class="multiselect" id="countries" multiple="multiple" data-target="multi-0"><div class="title noselect"><span class="text">Select</span><span class="close-icon">&times;</span><span class="expand-icon">&plus;</span></div><div class="container"><option value="Suicidal">Suicidal</option><option value="Homicidal">Homicidal</option><option value="Auditory">Auditory</option><option value="CD">CD</option><option value="Residental Treatment">Residental Treatment</option></div></div></tr>',

            //Arrival Mode
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><select name="arrivalMode" id="arrivalMode" style="padding:5px"><option>Select</option><option value="car">Car</option><option value="police">Police</option><option value="emt">EMT</option><option value="other">Other</option></select></tr>',

            //Arrival Type
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><select name="arrivalType" id="arrivalType" style="padding:5px"><option>Select</option><option value="walkIn">Walk In</option><option value="transfer">Transfer</option></select></tr</tr>',

            //Chief Complaint
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><select name="chiefComplaint" id="chiefComplaint" style="padding:5px"><option>Select</option><option value="mentalHealth">Mental Health</option><option value="detox">Detox</option><option value="resCD">Res - CD</option><option value="iop">IOP</option><option value="phone">Phone</option><option value="infoOnly">Info Only</option></select></tr>',

            //Triage
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><div id="actionsection"><button type = "button" class= "btn btn-primary triageBtn" style = "background-color:#71BC78; margin: 0px 3px 0px 0px" id = "green" ></button ><button type="button" class="btn btn-primary triageBtn" style="background-color:#EDD068; margin: 0px 4px 0px 2px" id="yellow"></button><button type="button" class="btn btn-primary triageBtn" style="background-color:#EE3838; margin: 0px 0px 0px 0px" id="red"></button></div></tr>',

            //SBAR Call Time
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><div class="form-check"><input class="form-check-input dateCheck" type="checkbox" value="" id="flexCheckDefault"><input type="text" id="dateTime" style="text-align:center; display:none"/></div></tr>',

            //MSE Start Time
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input type="text"/></tr>',

            //MSE End Time
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input type="text"/></tr>',

            //Nurse
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input type="text"/></tr>',

            //Assessment Wait Time
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr></tr>',

            //Assessment Start Time
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input type="text"/></tr>',

            //Assessment End Time
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input type="text"/></tr>',

            //Assessor Name
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input type="text"/></tr>',

            //Assessment Room
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input type="text"/></tr>',

            //Emergency Medical Condition
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input type="text"/></tr>',

            //Cert
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input type="text"/></tr>',

            //Patient Went To Unit
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input type="text"/></tr>',

            //Departure Time (Non Admits)
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input type="text"/></tr>',

            //Arrival To Disposition
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input type="text"/></tr>',

            //Disposition
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input type="text"/></tr>',

            //Departure Mode
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input type="text"/></tr>',

            //Complete
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input type="text"/></tr>',

            //Process Time
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr></tr>',

            //Comments
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><button type="button" class="CommentsIcon" data-toggle="modal" data-target="#exampleModalCenter"><i style = "font-size:20px" class= "far" >&#xf27a;</i></button ></tr>',

            //Delete
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><a class="button button-small edit" title="Delete" id="DeleteButton"><i style="font-size:20px" class="fa fa-trash"></i></a></tr>'

            
        ]).draw(false);
        
    });

    $("#PatientTable").on("click", "#DeleteButton", function () {
        $(this).closest("tr").remove();
    });


});


//Populate Arrival DateTime
//function timestampToDatetimeInputString(timestamp) {
//    const date = new Date((timestamp + _getTimeZoneOffsetInMs()));
//    return date.toISOString().slice(0, 16);
//}

//function _getTimeZoneOffsetInMs() {
//    return new Date().getTimezoneOffset() * -60 * 1000;
//}

//document.getElementById('arrivalTime').value = timestampToDatetimeInputString(Date.now()); 


