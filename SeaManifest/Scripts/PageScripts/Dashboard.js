var labels = ['Freezed/Created', 'Generated', 'Rejected', 'Cancelled'];
var inwardBarChartData;
var outwardBarChartData;

$(document).ready(function() {
    prepareInwardChartData();
    prepareOutwardChartData();

    var ctx = document.getElementById('container').getContext('2d');
    window.myBar = new Chart(ctx, {
        type: 'bar',
        data: inwardBarChartData,
        options: {
            title: {
                display: true,
                text: 'Supply Type- Inward'
            },
            tooltips: {
                mode: 'index',
                intersect: false
            },
            responsive: true,
            scales: {
                xAxes: [{
                    stacked: true,
                }],
                yAxes: [{
                    stacked: true
                }]
            }
        }
    });

    var ctx2 = document.getElementById('container1').getContext('2d');
    window.myBar2 = new Chart(ctx2, {
        type: 'bar',
        data: outwardBarChartData,
        options: {
            title: {
                display: true,
                text: 'Supply Type- Outward'
            },
            tooltips: {
                mode: 'index',
                intersect: false
            },
            responsive: true,
            scales: {
                xAxes: [{
                    stacked: true,
                }],
                yAxes: [{
                    stacked: true
                }]
            }
        }
    });
});



function prepareInwardChartData() {
    var dataSets = [];
    $.each(JSON.parse($("#hdnModel").val()), function (i, e) {
        dataSets.push({
            label: e.SubSupply,
            backgroundColor: getRandomColor(),
            data: [
                e.TotalDocs - (e.Generated + e.Cancelled + e.Rejected),
                e.Generated,
                e.Rejected,
                e.Cancelled
            ]
        });
    });
    inwardBarChartData = {
        labels: labels,
        datasets: dataSets
    };
}


function prepareOutwardChartData() {
    var dataSets = [];
    $.each(JSON.parse($("#hdnModel1").val()), function (i, e) {
        dataSets.push({
            label: e.SubSupply,
            backgroundColor: getRandomColor(),
            data: [
                e.TotalDocs - (e.Generated + e.Cancelled + e.Rejected),
                e.Generated,
                e.Rejected,
                e.Cancelled
            ]
        });
    });
    outwardBarChartData = {
        labels: labels,
        datasets: dataSets
    };
}


function getRandomColor() {
    var letters = '0123456789ABCDEF';
    var color = '#';
    for (var i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}