var connection = new signalR.HubConnectionBuilder().withUrl("/Chat").build();
connection.on("Wellcome", function (mess) {
    console.log(mess);
});
