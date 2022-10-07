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

        this.connection.on("ReceiveMessageWorker", function (message) {
            //Here we have to input revieved message in correct chat
            console.log(message)
            localStorage.setItem('NewChat',message)
            window.dispatchEvent(NewChat)
        });

        this.connection.on("ReceiveRoomId", function (message) {
                this.RoomId = message
                localStorage.setItem('roomId', this.RoomId)
                console.log(message)
        });

        this.connection.on("RecieveEndUserId", function (message) {
            ///Event to get message 
            ///here you get the connection id of the end user
            localStorage.setItem('demo', message) // here for demostation 
            console.log(message)
        });

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
        // this.connection.invoke("SendMessage", message,RoomId,EndUser).catch(function (err) {
        //     return console.error(err.toString())
        // })
            let demo = localStorage.getItem('demo')
            let roomid = localStorage.getItem('roomId')
            this.connection.invoke("SendMessage", message,roomid,demo).catch(function (err) {
            return console.error(err.toString())
         })
    }

    AddUser(){
        let RoomId = localStorage.getItem('roomId')
        this.connection.invoke("AddEndUserToRoom",RoomId).catch(function (err) {
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