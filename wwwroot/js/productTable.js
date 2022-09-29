$(document).ready(function () {

    $('#myTable').dataTable({

        "scrollY": "70vh",
        "scrollX": true,
        "sScrollXInner": "100%",
        "scrollCollapse": true,
        "paging": false,
        dom: '<"float-end"f><"#tableId"t>i<"#paginatorId"lp>',

    });
   
   
});
let startD;
let endD;

$(function () {

     startD = moment().subtract(29, 'days');
     endD = moment();
    alwaysShowCalenders: true;
    showCustomRangeLabel: false;
    $('#reportrange').daterangepicker({

        ranges: {
            'Today': [moment(), moment()],
            'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
            'Last 7 Days': [moment().subtract(6, 'days'), moment()],
            'This Week': [moment().startOf('isoWeek'), moment()],
            'Last 30 Days': [moment().subtract(29, 'days'), moment()],
            'This Month': [moment().startOf('month'), moment().endOf('month')],
            'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')],
            'This Year': [moment().startOf('year'), moment().endOf('year')],
            'Last Year': [moment().subtract(1, 'year').startOf('year'), moment().subtract(1, 'year').endOf('year')]
        },
        "linkedCalendars": false,
        "showCustomRangeLabel": false,
        "alwaysShowCalendars": true,
        "autoUpdateInput": false,

        "startDate": "08/31/2022",
        "endDate": "09/06/2022",
        "opens": "center",

        





    }, cb);
    

    function cb(start, end) {
       $('#reportrange span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
       
        
        endD = $("#reportrange").data('daterangepicker').endDate.format('DD-MM-YYYY');
        startD = $("#reportrange").data('daterangepicker').startDate.format('DD-MM-YYYY');
        
        
       
       

    }

   

    cb(start, end);
    


});





       






