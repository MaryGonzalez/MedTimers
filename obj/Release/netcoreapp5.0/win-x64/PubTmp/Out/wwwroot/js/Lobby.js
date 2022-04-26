﻿//Patient Arrival Checkbox
$(document).ready(function () {


  
    //Transfer Arrival Checkbox
    $('#ArrivalCheckBox').change(function () {
        if (this.checked) {
            $("#ArrivalCheckBox").hide();
            ArrivalTime();
        }
    });

    //Date Time of Departure Time
    function ArrivalTime() {
        $("#lblTransferArrivalDateTime").show();
        var today = new Date();
        var d = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
        var date = new Date();
        var hours = date.getHours() > 12 ? date.getHours() - 12 : date.getHours();
        var am_pm = date.getHours() >= 12 ? "PM" : "AM";
        hours = hours < 10 ? "0" + hours : hours;
        var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
        time = d + " " + hours + ":" + minutes + " " + am_pm;
        var lblTransferArrivalDateTime = document.getElementById("lblTransferArrivalDateTime");
        lblTransferArrivalDateTime.innerHTML = time;
    }
    //Refresh every minute
    //setTimeout(function () {
    //    alert('Reloading Page');
    //    location.reload(true);
    //  }, 60000);




    



    //Clear page confirmation
    $('#cancel').on('click', function () {
        //swal({
        //    title: "Reset",
        //    text: "Are you sure you want to clear the page? Patient data will not be saved",
        //    icon: "warning",


        //    buttons: {
        //        confirm: 'Yes',
        //        cancel: 'No'              
        //    },

        //})
        //    .then((value) => {
        //        switch (value) {

        //            case "confirm":
        //                swal("Pikachu fainted! You gained 500 XP!");
        //                break;                  

        //            default:
        //                swal("Got away safely!");

        //        }
        //        //clearPage();
        //    })



swal({
    title: "Reset",
        text: "Are you sure you want to clear the page? Patient data will not be saved",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                //swal("Poof! Your imaginary file has been deleted!", {
                //    icon: "success",
                //});
                clearPage();
            } else {
                
            }
        });


    });




    //Submit new patient
    $('.submitBtn').on('click', function () {

        
        if ($("#fullNames")[0].selectedIndex <= 0) {
            swal("Please select a patient")
            $('#fullNames').focus();

            return false;
        }

        if ($("#ArrivalCheckBox").prop('checked') == false) {
            swal("Please Add Arrival Time")
            $('#ArrivalCheckBox').focus();

            return false;
        }


        swal("Success", "Patient has been submitted", "success")
       
        //Clear page
        clearPage();
    });
    
});


//Clear Page
function clearPage() {
    //Reset dropdown selection
    $("#fullNames").val('').trigger("chosen:updated");

    //Show unchecked checkbox
    $("#ArrivalCheckBox").show();
    $('input[type=checkbox]').prop('checked', false);
    $('#lblDateTime').html('');
    $("#lblDateTime").hide();
        
}


//Date Time of patient arrival
function newPatientTime() {
    var today = new Date();
    var d = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
    var date = new Date();
    var hours = date.getHours() > 12 ? date.getHours() - 12 : date.getHours();
    var am_pm = date.getHours() >= 12 ? "PM" : "AM";
    hours = hours < 10 ? "0" + hours : hours;
    var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
    time = d + " " + hours + ":" + minutes + " " + am_pm;
    var lblDateTime = document.getElementById("lblDateTime");
    lblDateTime.innerHTML = time;

    $("#lblDateTime").show();
}



//Searchable Name list
$(function () {
    $('#fullNames').chosen();
});


