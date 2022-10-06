import  { HubConnectionBuilder } from "@microsoft/signalr"

export class ChatHub {
    constructor(){
        console.log("in hub")
        this.connection = new HubConnectionBuilder().withUrl("https://localhost:44302/signalr").build()

        this.connection.onclose(async () => {
            await this.connect();
        })

        this.connect()

        this.connection.on("ReceiveMessage", function (message) {
            ///Event to get message 
            ///here you have to imput the message in the chatbox
        });

        this.connection.on("kutjebefje", function (message) {
            ///Event to get message 
            ///here you get the connection id of the end user
            console.log(message)
            this.RoomId = message
        });
    }

    async connect(){
        try {
            await this.connection.start();
            console.log("SignalR Connected.");
        } catch (err) {
            console.log(err);
            setTimeout(start, 5000);
        }  
    }

    SendMessage(message){
        this.connection.invoke("SendMessage", message,this.RoomId).catch(function (err) {
            return console.error(err.toString())
        })
    }

    ConnectUser(){
        console.log("connect user")
        this.connection.invoke("ConnectUser").catch(function (err) {
            return console.error(err.toString())
        }
        )
    }


}