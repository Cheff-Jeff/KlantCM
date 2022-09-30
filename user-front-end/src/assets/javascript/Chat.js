import  { HubConnectionBuilder } from "@microsoft/signalr"


export const ConnectHub = function(){
    const connection = new HubConnectionBuilder().withUrl("localhost:/signalr").build()

    connection.on("ReceiveMessage", function (message) {
        ///Event to get message 
        ///here you have to imput the message in the chatbox
    });
    
    connection.on("kutjebefje", function (message) {
        ///Event to get message 
        ///here you get the  id of the room nesssecary for the send message
    });
}


export const ConnectUser = function (){
    connection.invoke("ConnectUser").catch(function (err) {
        return console.error(err.toString())
    }
    )
}

export const AddUser = function (RoomId){
    connection.invoke("AddEndUserToRoom",RoomId).catch(function (err) {
        return console.error(err.toString())
    }
    )
}

export const SendMessage = function (message,RoomId){
    connection.invoke("SendMessage", message,RoomId).catch(function (err) {
        return console.error(err.toString())
    }
    )
}