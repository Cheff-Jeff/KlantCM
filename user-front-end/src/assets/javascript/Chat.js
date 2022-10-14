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
            localStorage.setItem('NewChat',message)
            window.dispatchEvent(NewChat)
        });

        this.connection.on("RecieveRoomId", function (message) {
            ///Event to get message 
            ///here you get the room id
            localStorage.setItem('roomId', message)
        });

        this.connection.on("CloseChat", () =>{
            this.connection.stop();
        })

        const NewChat = new Event('NewChat')
    }

    async connect(){
        try {
            await this.connection.start();
            console.log("SignalR Connected.");
        } catch (err) {
            console.log(err);
        }  
    }

    SendMessage(message){
        this.connection.invoke("SendMessage", message,localStorage.getItem('roomId'),null).catch(function (err) {
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