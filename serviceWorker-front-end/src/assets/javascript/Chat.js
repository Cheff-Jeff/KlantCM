import { HubConnectionBuilder } from "@microsoft/signalr"
import {createPost} from './MessageReceiver2';

export class ChatHub {
    constructor(){
        console.log("in hub")
        this.connection = new HubConnectionBuilder().withUrl("https://localhost:44302/signalr").build()

        this.connection.onclose(async () => {
            await this.connect();
        })

        this.connect()

        this.connection.on("ReceiveMessage", function (message) {
            console.log(message)
        });

        this.connection.on("ReceiveRoomId", function (message) {
                console.log(message)
                this.RoomId = message
        });

        this.connection.on("nattebafkont28", function (message) {
            ///Event to get message 
            ///here you get the connection id of the end user
            console.log(message)
            this.demorecieve =message
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
        // this.connection.invoke("SendMessage", message,RoomId,EndUser).catch(function (err) {
        //     return console.error(err.toString())
        // })
            this.connection.invoke("SendMessage", message,this.RoomId,this.demorecieve).catch(function (err) {
            return console.error(err.toString())
         })
    }

    AddUser(){
        this.connection.invoke("AddEndUserToRoom",this.RoomId).catch(function (err) {
            return console.error(err.toString())
        }
        )
    }
    StartRoom(id,FirstName){
        if(this.connection.state != 'Connected'){
            this.connect()
        }
        this.connection.invoke("StartRoom",id, FirstName).catch(function (err) {
            return console.error(err)
        }
    )
    }


}