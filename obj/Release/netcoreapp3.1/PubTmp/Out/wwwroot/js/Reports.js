//Admits Breakdown by Disposition
const myChart = new Chart(document.getElementById('DispositionChart').getContext("2d"), {
  type: 'doughnut',
  data: {
    labels: ['Med Tx', 'Admitted', 'IOP', 'CoMo Tx', 'PO Assessment', 'Refusal', 'Information Only'],
        datasets: [{
            data: [31, 25, 19, 10, 5, 5, 5],
            backgroundColor: [
                '#54478C',
                "#16DB93",
                "#048BA8",
                "#FFC700",
                "#B9E769",
                "#EFEA5A",
                "#70A8D7",
            ],
            borderColor: [
                '#54478C',
                "#16DB93",
                "#048BA8",
                "#FFC700",
                "#B9E769",
                "#EFEA5A",
                "#70A8D7",
            ],
            borderWidth: 1
        }]
  },
    options: {
        cutoutPercentage: 90,
        legend: {
            position: 'bottom',
            labels: {
                boxWidth: 10,
                fontColor: '#000000',
                usePointStyle: true,
            }
        },
        title: {
            display: true,
            text: 'Admits Breakdown by Disposition',
            fontSize: 15,
        },
  	animation: {
    	duration: 1500,
    }
  }
});

// Get the chart's base64 image string
var image = myChart.toBase64Image();
console.log(image);

document.getElementById('dispositionChartDownload').onclick = function() {
  // Trigger the download
  var a = document.createElement('a');
  a.href = myChart.toBase64Image();
  a.download = 'Diposition_Breakdown.png';
  a.click();
}


//Admits Breakdown by Chief Complaint 
var ctx = document.getElementById("ComplaintChart");
var complaintChart = new Chart(ctx, {
    type: 'doughnut',
    data: {
        labels: ['Detox', 'Res - CD', 'IOP', 'Info Only', 'Mental Health', 'Phone Assessment'],
        datasets: [{
            data: [31, 25, 24, 10, 5, 5],
            backgroundColor: [
                '#F9844A',
                "#F9C74F",
                "#90BE6D",
                "#43AA8B",
                "#577590",
                "#277DA1",
            ],
            borderColor: [
                '#F9844A',
                "#F9C74F",
                "#90BE6D",
                "#43AA8B",
                "#577590",
                "#277DA1",
            ],
            borderWidth: 1
        }]
    },
    options: {
        cutoutPercentage: 90,
        legend: {
            position: 'bottom',
            labels: {
                boxWidth: 10,
                fontColor: '#000000',
                usePointStyle: true,
                
            }
        },
        //scales: {
        //    y: {
        //        beginAtZero: true
        //    }
        //}
        title: {
            display: true,
            text: 'Admits Breakdown by Chief Complaint',
            fontSize: 15,
        }
    }

});


////Admits Breakdown by Reason 
var ctx = document.getElementById("ReasonChart");
var reasonChart = new Chart(ctx, {
    type: 'doughnut',
    data: {
        labels: ['Residental Treatment', 'Suicidal', 'Homicidal', 'Auditory', 'CD', 'Visual'],
        datasets: [{
            data: [25, 25, 25, 10, 10, 5],
            backgroundColor: [
                '#EE3838',
                "#0058FF",
                "#21D59B",
                "#FFC700",
                "#E55AE0",
                "#F99600",
            ],
            borderColor: [
                '#EE3838',
                "#0058FF",
                "#21D59B",
                "#FFC700",
                "#E55AE0",
                "#F99600",
            ],
            borderWidth: 1
        }]
    },
    options: {
        cutoutPercentage: 90,
        legend: {
            position: 'bottom',
            labels: {
      //          boxWidth: 10,
                fontColor: '#000000',
                usePointStyle: true,
            }
        },
        //scales: {
        //    y: {
        //        beginAtZero: true
        //    }
        //}
        title: {
            display: true,
            text: 'Admits Breakdown by Reason',
            fontSize: 15,
        }
    }

});


//Average Assessment Time Per Assessor 
var ctx = document.getElementById("AssessorTimeChart");
var assessorChart = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: ['Jo Stahl', 'Melissa Young', 'Jim Omalley', 'Haley Cayce', 'Karen Edwards', 'Peter Kerry', 'Jo Stahl', 'Melissa Young', 'Jim Omalley', 'Haley Cayce', 'Karen Edwards', 'Peter Kerry', 'Haley Kerry', 'Jim Edwards', 'Melissa Omalley', 'Peter Stahl', 'Jim Omalley', 'Haley Cayce', 'Karen Edwards', 'Peter Kerry', 'Haley Kerry', 'Jim Edwards', 'Melissa Omalley', 'Peter Stahl', 'Haley Cayce', 'Karen Edwards', 'Peter Kerry', 'Haley Kerry', 'Jim Edwards', 'Melissa Omalley', 'Peter Stahl'],
        datasets: [{
            data: [31, 25, 28, 10, 7, 15, 23, 17, 9, 21, 16, 35, 15, 23, 27, 19, 12, 6, 30, 31, 25, 28, 10, 7, 15, 23, 17, 9, 21, 16, 35],
            backgroundColor: [
                "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1",
                "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1",
                "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1",
                "#3DABC1", "#3DABC1", "#3DABC1",
                
            ],
            borderColor: [
                "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1",
                "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1",
                "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1", "#3DABC1",
                "#3DABC1", "#3DABC1", "#3DABC1",
            ],
            borderWidth: 1
        }]
    },
    options: {
        title: {
            display: true,
            text: 'Average Assessment Time Per Assessor',
            fontSize: 15,
        },
        legend: {
            display: false
        },
        scales: {
            yAxes: [{
                ticks:{
                    beginAtZero: true
                }
          }],
            xAxes: [{
                barPercentage: 0.6
            }]
        }
    }


});


///*Prev & current toggle*/
//$('.btn-group').on('click', '.btn', function () {
//    $(this).addClass('active').siblings().removeClass('active');
//});