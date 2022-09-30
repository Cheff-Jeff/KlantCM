import signalR, { HubConnectionBuilder } from "@microsoft/signalr"
const connection = new HubConnectionBuilder().withUrl("localhost:/signalr").build()

connection.on("ReceiveMessage", function (message) {
    ///Event to get message 
    ///here you have to imput the message in the chatbox
});

connection.on("kutjebefje", function (message) {
    ///Event to get message 
    ///here you get the  id of the room nesssecary for the send message
});

function ConnectUser(){
    connection.invoke("ConnectUser").catch(function (err) {
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

function SendMessage(message,RoomId){
    connection.invoke("SendMessage", message,RoomId).catch(function (err) {
        return console.error(err.toString())
    }
    )
}