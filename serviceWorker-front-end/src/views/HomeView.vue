<script setup>
  import ConverzationSend from '../components/ConverzationSend.vue';
  import ConverzationHelp from '../components/ConverzationHelp.vue';
  import Input from '../components/ChatInput.vue';
  import {ChatHub} from '../assets/javascript/Chat'
  import {createPost} from '../assets/javascript/MessageReceiver2';
  import Header from '../components/Header.vue';
import ChatIndexButton from '../components/ChatIndexButton.vue';
</script>

<template>
<Header />
  <div class="container-fluid">
    <div class="row">
      <div class="col-lg-2 col-md-3">
        <div class="chat-controller">
          <div class="chat-btn-wrap">
            <div class="queue">
              <span>20 people waiting in line.</span>
            </div>
            <div v-for="(chats,index) in ChatWindows">
              <ChatIndexButton :index="index" :active="chats.active" @click="ActivateChat(index)" />
            </div>
          </div>

          <div class="chat-btn-wrap-bottom">
            <button type="button" class="btn btn-light mb-3" @click="chat.StartRoom(1,'andreas')">
              Start chat
            </button>
            <button type="button" class="btn btn-light mb-5" @click="chat.AddUser()">
              Add client
            </button>
            <button type="button" class="btn btn-light mb-5" @click="stopChat()">
              stopChat
            </button>


            <cm-button
              data-label="End active chat"
              data-button-style="cta"
              data-button-size="medium"
              data-custom-classes="terminate"
              @click="Logout">
            </cm-button>
          </div>
        </div>
      </div>
      <div class="col-lg-10 col-md-9 not-bootstrap">
        <div class="converzation-wrap">
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
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    data(){
      return{
        chat: null,
        ChatWindows:[
          {newChats:[],
          UserConnection:'',
        active:true}
        ],
        newUser:{
          newChats:[],
          UserConnection:'',
          active:false
        },
        activeChatKey : 0
      }
    },
    mounted(){
      this.chat = new ChatHub()
      window.addEventListener('NewChat',()=>{
        this.reciveConverzation(localStorage.getItem('NewChat'), localStorage.getItem('FromUser'))
      })

      window.addEventListener('NewUser',()=>{
        this.AddUser(localStorage.getItem('User'))
      })

      window.addEventListener('DisconnectUser',()=>{
        //User gets disconnected
        this.RemoveUser(localStorage.getItem('DiscUser'))
      })

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
        this.ChatWindows[index].active = !this.ChatWindows[index].active
      },
      AddUser(connection){
        const json = this.newUser
        json.UserConnection = connection
        this.ChatWindows.push(json)
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
        this.ChatWindows[i].newChats = []
        this.ChatWindows[i].UserConnection = ''
        const emptyChat = this.ChatWindows[i]
        this.ChatWindows.splice(i,1)
        this.ChatWindows.push(emptyChat)
      },
      stopChat(){
        const connection = this.ChatWindows[this.activeChatKey].UserConnection
        this.RemoveUser(connection)
        this.chat.StopChat(connection)
      }
    }
  }
</script>

<style lang="scss">
  @import "../assets/styles/pages/home.scss";
</style>