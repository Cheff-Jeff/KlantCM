import signalR, { HubConnectionBuilder } from "@microsoft/signalr"
const connection = new HubConnectionBuilder().withUrl("localhost:/signalr").build()

connection.on("ReceiveMessage", function (message) {
    ///Event to get message 
    ///here you have to imput the message in the chatbox
});

connection.on("nattebafkont28", function (message) {
    ///Event to get message 
    ///here you get the connection id of the end user
});

function StartRoom(id,FirstName){
    connection.invoke("StartRoom",id, FirstName).catch(function (err) {
        return console.error(err.toString())
    }
    )
}

function AddUser(RoomId){
    connection.invoke("AddEndUserToRoom",RoomId).catch(function (err) {
        return console.error(err.toString())
    }
    )
}

function SendMessage(message,RoomId,EndUser){
    connection.invoke("SendMessage", message,RoomId,EndUser).catch(function (err) {
        return console.error(err.toString())
    }
    )
}