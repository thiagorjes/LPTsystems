"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/ChatHub").build();

connection.on("ReceiveMessage", function (sensor,unittype,val) {
    var msg = val.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    document.getElementById(sensor).getElementsByTagName("input")[0].value = msg+" "+unittype;
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var medidorLeitura = document.getElementById("medidor").value;
    var tipoLeitura = document.getElementById("tipoMedida").value;
    var valorLeitura = document.getElementById("valorLido").value;
    connection.invoke("SendMessage", medidorLeitura,tipoLeitura,valorLeitura).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});