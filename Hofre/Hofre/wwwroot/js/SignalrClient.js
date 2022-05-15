"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});
document.getElementById("sendButton").addEventListener("click", function (event) {
    var sender = document.getElementById("senderInput").value;
    var receiver = document.getElementById("receiverInput").value;
    var message = document.getElementById("messageInput").value;
    var today = new Date();
    var date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();

   

    if (receiver != "") {

        connection.invoke("SendMessageToGroup", sender, receiver, message,date).catch(function (err) {
            return console.error(err.toString());
        });
    }
    else {
        connection.invoke("SendMessage", sender, receiver, message, date).catch(function (err) {
            return console.error(err.toString());
        });
    }
    event.preventDefault();
});
connection.on("ReceiveMessage", function (receiver, message,date) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = msg;
    var encodedRec = receiver;
    var encodedDate = date;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    li.textContent = encodedRec;
    li.textContent = encodedDate;
    document.getElementById("messages").appendChild(li);
    document.getElementById("username").appendChild(li);
    document.getElementById("date").appendChild(li);
});