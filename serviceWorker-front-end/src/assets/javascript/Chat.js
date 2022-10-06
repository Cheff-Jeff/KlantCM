import { HubConnectionBuilder } from "@microsoft/signalr"



export const ConnectHub = function(){
    const connection = new HubConnectionBuilder().withUrl("https://localhost:44302/signalr").build()

    connection.start(console.log("Connected"))

    connection.on("ReceiveMessage", function (message) {
        ///Event to get message 
        ///here you have to imput the message in the chatbox
    });

    connection.on("nattebafkont28", function (message) {
        ///Event to get message 
        ///here you get the connection id of the end user
    });
}

export const StartRoom  = function (id,FirstName){
    connection.invoke("StartRoom",id, FirstName).catch(function (err) {
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

export const SendMessage = function (message,RoomId,EndUser){
    connection.invoke("SendMessage", message,RoomId,EndUser).catch(function (err) {
        return console.error(err.toString())
    }
    )
}