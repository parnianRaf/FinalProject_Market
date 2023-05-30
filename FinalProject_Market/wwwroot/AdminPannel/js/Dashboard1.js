$(document).ready(function () {
    debugger;
    $("#Dashboard2").click(function () {
        $("#mainPage").load("/Admin/GetSellerList");

    });
    $("#Dashboard3").click(function () {
        $("#mainPage").load("/Admin/GetOrdersList");

    });
    $("#Dashboard1").click(function () {
        $("#mainPage").load("/Admin/GetCustomerList");

    });

});

