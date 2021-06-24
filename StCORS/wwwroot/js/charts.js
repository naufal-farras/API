  //var salary1 = [];
    //var salary2= [];

    //for (var i = 0; i < result.salary.length; i++) {
    //    if (result[i].salary > 50) {
    //        salary1.push(result[i]);
    //    }
    //}
    //for (var i = 0; i < result.salary.length; i++) {
    //    if (result[i].salary < 50) {
    //        salary2.push(result[i]);
    //    }
    //    console.log(salary2);

    //}

$.ajax({
    url: '/home/getsemuadata',
    type: "GET",
    headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
    },
 
}).done((result) => {  
    var options = {
        series: [12, 55, 41, 17, 15],
        chart: {
            type: 'donut',
        },
        responsive: [{
            breakpoint: 480,
            options: {
                chart: {
                    width: 200
                },
                legend: {
                    position: 'bottom'
                }
            }
        }]
    };
    var chart = new ApexCharts(document.querySelector("#donutChart"), options);
    chart.render();

    //$("#nik").val(result.nik);
    //$("#firstname").val(result.firstName);
    //$("#lastname").val(result.lastName);
    //$("#phone").val(result.phone);
    //$("#birthdate").val(result.birthDate.split("T")[0]);
    //$("#salary").val(result.salary);
    //$("#email").val(result.email);
    //$("#password").val(result.password);
    //$("#degree").val(result.degree);
    //$("#gpa").val(result.gpa);
    //$("#universityid").val(result.universityid);

}).fail((error) => {
    Swal.fire(
        'Failed !',
        'Data Gagal di Update',
        'error'
    )
   
});



var options2 = {
    series: [{
        name: 'Net Profit',
        data: [44, 55, 57, 56, 61, 58, 63, 60, 66]
    }, {
        name: 'Revenue',
        data: [76, 85, 101, 98, 87, 105, 91, 114, 94]
    }, {
        name: 'Free Cash Flow',
        data: [35, 41, 36, 26, 45, 48, 52, 53, 41]
    }],
    chart: {
        type: 'bar',
        height: 350
    },
    plotOptions: {
        bar: {
            horizontal: false,
            columnWidth: '55%',
            endingShape: 'rounded'
        },
    },
    dataLabels: {
        enabled: false
    },
    stroke: {
        show: true,
        width: 2,
        colors: ['transparent']
    },
    xaxis: {
        categories: ['Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct'],
    },
    yaxis: {
        title: {
            text: '$ (thousands)'
        }
    },
    fill: {
        opacity: 1
    },
    tooltip: {
        y: {
            formatter: function (val) {
                return "$ " + val + " thousands"
            }
        }
    }
};

var chart2 = new ApexCharts(document.querySelector("#barChart"), options2);
chart2.render();
