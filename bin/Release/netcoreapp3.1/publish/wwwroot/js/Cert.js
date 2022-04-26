//Search bar
$(document).ready(function () {
    $("#certUserInput").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#certTableBody tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});






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

    }
}


/**************************/
/*Drop Down Hambuger Menu*/
/*************************/

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


////////////////////////////////
//Reason multi select dropdown//
////////////////////////////////
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
    var multi = new Multiselect("#reason");
});


//////////
//TABLE//
/////////
$(document).ready(function () {
    var t = $('#PatientTable').DataTable({

        columnDefs: [{ type: 'date', 'targets': [1] }],
        "order": [[0, "desc"]],

        //Remove ordering option
        //"ordering": false,

        //Options for drop down menu - show entries
        "lengthMenu": [[5, 10, 15, -1], [5, 10, 15, "All"]],

        //Number of entries per page
        "pageLength": 5,

        //Freeze header column
        "fixedHeader": true,

        //Scroll bar on x-axis
        "scrollX": "500px",

        //Position of table length drop down, search bar, information summary, and pagination
        "dom": '<lf>t<ip>',

        "autoWidth": false,

        //fixedColumns: {
        //    leftColumns: 4,
        //}


    });


    $(document).on('click', '#editRow', function () {
        //DateTime
        $(this).parent().siblings('td.dataDate').each(function () {
            var content = $(this).html();
            $(this).html('<input value= "' + content + '" />');
        });

        //Textboxes
        $(this).parent().siblings('td.dataText').each(function () {
            var content = $(this).html();
            $(this).html('<input value="' + content + '" />');
        });

        //Dropdown boxes
        $(this).parent().siblings('td.dataDrop').each(function () {
            var content = $(this).html();
            $(this).html('<input value="' + content + '" />');
        });

        $(this).siblings('.save').show();
        $(this).hide();




        //Hide pencil, show save btn
        //$("#addRow").hide();
        //$("#saveRow").show();




    });

    $(document).on('click', '#saveRow', function () {

        $('input').each(function () {
            var content = $(this).val();
            $(this).html(content);
            $(this).contents().unwrap();
        });
        $(this).siblings('.edit').show();
        $(this).hide();

    });





    //ADD NEW ROW & POPULATE FIELDS
    $('#addRow').on('click', function () {

        t.row.add([

            //Index
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><id="id" style="text-align:center; display:none"/>22</tr>',

            //Edit
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><a class="button button-small edit" id="editPencil" title="Edit"><i style="font-size:20px" class="fa fa-pencil"></i></a></tr>',

            //Arrival Time
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input type="datetime-local" id="arrivalTime"/></tr>',
            //document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr>06/09/2021 09:24 AM</tr>',

            //Name
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input type="text" id="patientName" style="text-align:center"/></tr>',

            //Assessor Name
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><input type="text"/></tr>',

            //Comments
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><button type="button" class="CommentsIcon" data-toggle="modal" data-target="#exampleModalCenter"><i style = "font-size:20px" class= "far" >&#xf27a;</i></button ></tr>',

            //Delete
            document.getElementById("PatientTable").insertRow(-1).innerHTML = '<tr><a class="button button-small edit" title="Delete" id="DeleteButton"><i style="font-size:20px" class="fa fa-trash"></i></a></tr>'

        ]).draw(true);
    });



    $("#PatientTable").on("click", "#DeleteButton", function () {
        $.confirm({
            title: 'Password Required',
            content: '' +
                '<form action="" class="formPassword">' +
                '<div class="form-group">' +
                '<input type="text" class="password form-control" required />' +
                '</div>' +
                '</form>',
            buttons: {
                formSubmit: {
                    text: 'Submit',
                    btnClass: 'btn-blue',
                    action: function () {
                        var password = this.$content.find('.password').val();
                        if (!password) {
                            $.alert('provide a valid password');
                            return false;
                        }
                        $.alert('DELETE RECORD <br> This action cannot be undone.');
                    }
                },
                cancel: function () {
                    //close
                },
            },
            onContentReady: function () {
                // bind to events
                var jc = this;
                this.$content.find('form').on('submit', function (e) {
                    // if the user submits the form by pressing enter in the field.
                    e.preventDefault();
                    jc.$$formSubmit.trigger('click'); // reference the button and click it
                });
            }
        });
    });


    function DeleteRow() {
        $(this).closest("tr").remove();
    }

});


//Populate Arrival DateTime
var now = new Date();
var utcString = now.toISOString().substring(0, 16);
var year = now.getFullYear();
var month = now.getMonth() + 1;
var day = now.getDate();
var hour = now.getHours();
var minute = now.getMinutes();
var localDatetime = year + "-" +
    (month < 10 ? "0" + month.toString() : month) + "-" +
    (day < 10 ? "0" + day.toString() : day) + "T" +
    (hour < 10 ? "0" + hour.toString() : hour) + ":" +
    (minute < 10 ? "0" + minute.toString() : minute) +
    utcString.substring(16, 19);
var datetimeField = document.getElementById("arrivalTime");
datetimeField.value = localDatetime;


//Count number of deferred patients
//Display in Patient Counter Header
var status = document.getElementById("certStatus");
var count = 0;

if (status == "Deferred") {

}

