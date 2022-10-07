<script setup>
  import ConverzationSend from '../components/ConverzationSend.vue';
  import ConverzationHelp from '../components/ConverzationHelp.vue';
  import Input from '../components/ChatInput.vue';
  import {ChatHub} from '../assets/javascript/Chat'
  import {createPost} from '../assets/javascript/MessageReceiver2';
  import Header from '../components/Header.vue';
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
            <cm-button
                data-label="active chat 1"
                data-button-style="ghost"
                data-button-size="medium"
                @click="ActivateChat(0)">
            </cm-button><br>
            <cm-button
                data-label="chat 2"
                data-button-style="primary"
                data-button-size="medium"
                @click="ActivateChat(1)">
            </cm-button><br>
            <cm-button
                data-label="chat 3"
                data-button-style="primary"
                data-button-size="medium"
                @click="ActivateChat(2)">
            </cm-button><br>
            <cm-button
                data-label="chat 4"
                data-button-style="primary"
                data-button-size="medium"
                @click="ActivateChat(3)">
            </cm-button><br>
            <cm-button
                data-label="chat 5"
                data-button-style="primary"
                data-button-size="medium"
                @click="ActivateChat(4)">
            </cm-button><br>
          </div>

          <div class="chat-btn-wrap-bottom">
            <button type="button" class="btn btn-light mb-3" @click="chat.StartRoom(1,'andreas')">
              Start chat
            </button>
            <button type="button" class="btn btn-light mb-5" @click="chat.AddUser()">
              Add client
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
        newChats: [],
        ChatWindows:[
          {newChats:[],
          UserConnection:''},
          {newChats:[],
          UserConnection:''},
          {newChats:[],
          UserConnection:''},
          {newChats:[],
          UserConnection:''},
          {newChats:[],
          UserConnection:''},
        ],
        activeChatKey : 0
      }
    },
    mounted(){
      this.chat = new ChatHub()
      window.addEventListener('NewChat',()=>{
        this.reciveConverzation(localStorage.getItem('NewChat'))
      })

      window.addEventListener('NewUser',()=>{
        console.log(localStorage.getItem('User'))
        this.AddUser(localStorage.getItem('User'))
      })

      this.reciveConverzation('hi')
    },
    methods:{
      sendPost(){
        createPost(1, "hoi")
      },
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
      reciveConverzation(text) {
        const time = new Date();

        const bubble = {
          Text: text, 
          Time: `${time.getHours()}:${time.getMinutes()}`, 
          White: true
        };

        this.ChatWindows[this.activeChatKey].newChats = [...this.ChatWindows[this.activeChatKey].newChats, bubble];
      },
      ActivateChat(index){
        this.activeChatKey = index
      },
      AddUser(connection){
        this.ChatWindows.forEach(e => {
          if(e.UserConnection == ''){
            e.UserConnection = connection
          }
      
        });
      }
    }
  }
</script>

<style lang="scss">
  @import "../assets/styles/pages/home.scss";
</style>