import { HubConnectionBuilder } from "@microsoft/signalr"

let Queuetimer

export class ChatHub {

    constructor() {
        console.log("in hub")

        this.connection = new HubConnectionBuilder().withUrl("https://localhost:44302/signalr").build()

        this.connect()

        this.connection.on("ReceiveMessage", function(message) {
            ///Event to get message 
            ///here you have to imput the message in the chatbox
            localStorage.setItem('NewChat', message)
            window.dispatchEvent(NewChat)
        });

        this.connection.on("Count", function(message) {
            console.log(message)
        });

        this.connection.on("RecieveRoomId", function(message) {
            ///here you get the room id
            sessionStorage.setItem('roomId', message)
            
            window.dispatchEvent(Joined)
            console.log("Connected to room")
            clearInterval(Queuetimer)
        });

        this.connection.on("CloseChat", () => {
            window.dispatchEvent(CloseChat)
            this.connection.stop()
        })

        this.connection.on("RecieveEmployeeName", (message) => {
            sessionStorage.setItem('EmployeeName',message)
        })


        const Joined = new Event('Joined')
        const CloseChat = new Event('CloseChat')
        const NewChat = new Event('NewChat')
    }
    async connect() {
        try {
            await this.connection.start();
            console.log("SignalR Connected.");
        } catch (err) {
            console.log(err);
        }
    }

    SendMessage(message) {
        this.connection.invoke("SendMessage", message, sessionStorage.getItem('roomId'), null).catch(function(err) {
            return console.error(err.toString())
        })
    }

    ConnectUser() {
        console.log("connect user")
        this.connection.invoke("ConnectUser").catch(function(err) {
            return console.error(err.toString())
        })

        this.startTimer()
    }

    SendQueueMessage() {
        localStorage.setItem('NewChat', 'We are busy!')

        const NewChat = new Event('NewChat')
        window.dispatchEvent(NewChat)
    }

    startTimer() {
        const message = `Welcome to MasterChef live chat, 
        currently we are experiencing alot of traffic.
        Please ask your question when an employee joins the room.`

        localStorage.setItem('NewChat', message)
        const NewChat = new Event('NewChat')
        window.dispatchEvent(NewChat)
    }

    SendMedia(base64){
        let RoomId = sessionStorage.getItem('roomId')
        this.connection.invoke("SendMedia",base64,RoomId, null).catch((err)=>{
            return console.error(err.toString())
        })
    }
}