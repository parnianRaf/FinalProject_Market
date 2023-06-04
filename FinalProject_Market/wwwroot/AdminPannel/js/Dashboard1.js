$(document).ready(function () {
    debugger;
    $("#Dashboard1").click(function () {
        $("#mainPage").load("/Account/GetCustomerList");

    });
    $("#Dashboard2").click(function () {
        $("#mainPage").load("/Account/GetSellerList");

    });
    $("#Dashboard3").click(function () {
        $("#mainPage").load("/Admin/Account/GetSellerList");

    });
    $("#Orders").click(function () {
        $("#mainPage").load("/Admin/Account/GetSellerList");

    });
    $("#GoogleIcon").click(function () {
        var clientId = "";
        var redirectUrl = "";
        window.location.href=

    });

});

