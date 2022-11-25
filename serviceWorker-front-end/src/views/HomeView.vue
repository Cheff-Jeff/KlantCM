<script setup>
  import ConverzationSend from '../components/ConverzationSend.vue';
  import ConverzationHelp from '../components/ConverzationHelp.vue';
  import Input from '../components/ChatInput.vue';
  import {ChatHub} from '../assets/javascript/Chat'
  import Header from '../components/Header.vue';
import ChatIndexButton from '../components/ChatIndexButton.vue';
import {UploadChat} from '../assets/javascript/UploadChat'
import { ChangeLanguage } from '../assets/javascript/translate';
</script>

<template>
<Header />
  <div class="container-fluid">
    <div class="row">
      <div class="col-lg-2 col-md-3">
        <div class="chat-controller">
          <div class="chat-btn-wrap">
            <div class="queue">
              <span class="WaitingInLine">20 people waiting in line.</span>
            </div>
            <div v-for="(chats,index) in ChatWindows">
              <span @click="ActivateChat(index)">
                <ChatIndexButton  :active="chats.active" :key="chats.active" />
              </span>
            </div>
          </div>

          <div class="chat-btn-wrap-bottom">
            <button v-if="Working" type="button" class="btn btn-light mb-3 StartRoomBtn" @click="roomStop()">
              Stop chats
            </button>
            <button v-else type="button" class="btn btn-light mb-3 StartRoomBtn" @click="roomStart()">
              Start chats
            </button>
            
            <div v-if="Working">
              <cm-button
              data-label="Look for Clients"
              data-button-style="cta"
              data-button-size="medium"
              @click="openWorker()"
              v-if="OpenWorker == false">
              </cm-button>

              <cm-button
              data-label="Looking"
              data-button-style="cta"
              data-button-size="medium"
              @click="closeWorker()"
              v-else>
              </cm-button>
           

            <cm-button
              class="EndChatBtn"
              data-label="End active chat"
              data-button-style="cta"
              data-button-size="medium"
              data-custom-classes="terminate"
              @click="stopChat(null)">
            </cm-button>
          </div>
          </div>
        </div>
      </div>
      <div class="col-lg-10 col-md-9 not-bootstrap">
        <div class="converzation-wrap" v-if="ChatWindows.length != 0">
          <cm-conversation style="height: 85vh">
            <div class="body">
              <cm-conversation-divider>
                <span class="title"> Today </span>
              </cm-conversation-divider>
              <div v-for="chat in ChatWindows[activeChatKey].newChats" :key="chat">
                <div v-if="chat.White">
                  <ConverzationHelp :Text="chat.Text" :Time="chat.Time"/>
                </div>
                <div v-else>
                  <ConverzationSend :Text="chat.Text" :Time="chat.Time"/>
                </div>
              </div>
            </div>
            <div class="footer">
              <Input @text="sendConverzation"/>
            </div>
          </cm-conversation>
        </div>
        <div class="NoUsers" v-else>
            NO USERS 
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    data(){
      return{
        ChatWindows:[],
        activeChatKey : 0,
        OpenWorker:false,
        Room:false,
        Working:false
      }
    },
    mounted(){
      this.chat = new ChatHub()

      window.addEventListener('NewChat',()=>{
        this.reciveConverzation(localStorage.getItem('NewChat'), localStorage.getItem('FromUser'))
      })
      window.addEventListener('NewUser',()=>{
        this.AddUser(localStorage.getItem('User'))
        this.chat.CloseWorker()
        this.OpenWorker = false
      })
      window.addEventListener('DisconnectUser',()=>{
        //User gets disconnected
        this.RemoveUser(localStorage.getItem('DiscUser'))
      })
      window.addEventListener('StopRoom',this.roomStop())
    },
    methods:{
      sendConverzation(text) {
        const time = new Date();

        const bubble = {
          Text: text, 
          Time: `${time.getHours()}:${time.getMinutes()}`, 
          White: false
        };

        this.ChatWindows[this.activeChatKey].newChats.push(bubble);
        this.chat.SendMessage(text,this.ChatWindows[this.activeChatKey].UserConnection)
      },
      reciveConverzation(text, connection) {
        const time = new Date();

        const bubble = {
          Text: text, 
          Time: `${time.getHours()}:${time.getMinutes()}`, 
          White: true
        };
        let User = this.FindUser(connection)
        this.ChatWindows[User].newChats = [...this.ChatWindows[User].newChats, bubble];
      },
      ActivateChat(index){
        this.activeChatKey = index
        this.ChatWindows.forEach(element => {
          element.active =false;
        });
        this.ChatWindows[index].active = !this.ChatWindows[index].active
      },
      AddUser(connection){
        let json = {
          newChats:[],
          UserConnection:'',
          active:false
        }
        json.UserConnection = connection
        this.ChatWindows.push(json)
        if(this.ChatWindows.length === 1){
          this.ActivateChat(0)
        }
        console.log(this.ChatWindows)
      },
      FindUser(Connection){
        for (let i = 0; i < this.ChatWindows.length; i++) {
          if(Connection == this.ChatWindows[i].UserConnection){
            return i
          }
        }
      },
      RemoveUser(Connection){ 
        const i = this.FindUser(Connection)
        this.SaveChat(i, Connection)
        this.ChatWindows[i].newChats = []
        this.ChatWindows[i].UserConnection = ''
        this.ActivateChat(0)
        this.ChatWindows.splice(i,1)
        window.AddErrorNotification('User left')
      },
      stopChat(connection){
        if (connection == null){
          connection = this.ChatWindows[this.activeChatKey].UserConnection
        }
        this.RemoveUser(connection)
        this.chat.StopRoom(connection)
      },
      openWorker(){
          this.OpenWorker = true;
          this.chat.OpenWorker();
      },
      closeWorker(){
        this.OpenWorker = false;
        this.chat.CloseWorker()
      },
      roomStart(){
        this.chat.StartRoom(1,'andreas')
        console.log('het wekrt')
        this.Working = true

      },
      roomStop(){
        this.chat.StopRoom()
          if (this.ChatWindows.length > 0){
            this.ChatWindows.forEach(chatwin => {
              this.stopChat(chatwin.UserConnection)
            })
          }
          this.ChatWindows = []
          this.Working = false
          this
      },
      SaveChat(i){
        if(this.ChatWindows[i].newChats.length > 0){
          UploadChat(this.ChatWindows[i].UserConnection, this.ChatWindows[i].newChats)
        }
      }
    }
  }
</script>

<style lang="scss">
  @import "../assets/styles/pages/home.scss";
</style>