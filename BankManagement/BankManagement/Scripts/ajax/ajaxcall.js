$(document).ready(
    function () {
        showBatches();
        $("#tbletrans").hide();
        $("#formtrans").hide();
        $("#btnSave").click(function () {
            var batch = {
                Name: $("#accountName").val(),
                Address: $("#address").val(),
                Phone: $("#phone").val(),
                Balance: $("#balance").val()
            };

            $.ajax({
                type: "POST",
                url: "/Home/Post",
                dataType: "json",
                data: batch,
                success: function (tempBatch) {
                    showBatches();
                }
            });
        });
    }
);

function showBatches() {
    $.ajax({
        type: "GET",
        url: "/Home/Get",
        dataType: "json",
        success: function (data) {
            var tableBody = "";
            $.each(data, function (i, item) {
                tableBody += "<tr>";
                tableBody += "<td>" + item.Name + "</td>";
                tableBody += "<td>" + item.Address + "</td>";
                tableBody += "<td>" + item.Phone + "</td>";
                tableBody += "<td>" + item.Balance + "</td>";
                tableBody += "<td onclick=\"showTransaction('" + item.Id + "')\"> Show Transaction</td>";
                tableBody += "<td onclick=\"transactionFunction('" + item.Id + "')\"> Do Transaction </td>";
                tableBody += "</tr>";
            });
            $("#tble > tbody").html(tableBody);
        }
    });
}


function transactionFunction(id) {
    $("#formtrans").show();

    $("#btntrans").off().on("click",
        function () {
            var transaction = {
                TransactionDate: $("#date").val(),
                Amount: $("#amount").val(),
                Description: $("#description").val(),
                Operation: $("#operation").val()
            };
            $.ajax({
                type: "POST",
                url: "/Home/TransactionPost/" + id,
                dataType: "json",
                data: transaction,
                success: function (data) {
                    console.log("Inserted!!");
                    $("#formtrans").hide();
                    showBatches();
                }
            });
        }
    );
}

function showTransaction(id) {
    $("#tbletrans").show();

    $.ajax({
        type: "GET",
        url: "/Home/TransactionGet/" + id,
        dataType: "json",
        success: function (data) {
            console.log(data);
            var tableBody = "";
            $.each(data, function (i, item) {
                tableBody += "<tr>";
                tableBody += "<td>" + item.TransactionDate + "</td>";
                tableBody += "<td>" + item.Amount + "</td>";
                tableBody += "<td>" + item.Description + "</td>";
                tableBody += "<td>" + item.Operation + "</td>";
                tableBody += "</tr>";
            });
            $("#tbletrans > tbody").html(tableBody);
        }
    });

}