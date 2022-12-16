<script setup>
  import ConverzationSend from '@/components/ConverzationSend.vue';
  import ConverzationHelp from '@/components/ConverzationHelp.vue';
  import Input from '@/components/ChatInput.vue';
  import Header from '@/components/Header.vue';
  import ChatIndexButton from '@/components/ChatIndexButton.vue';
  import {UploadChat} from '@/assets/javascript/UploadChat';
  import { getLang } from '@/assets/javascript/translate';
  import { ref } from 'vue';
  const text = ref(null);
  text.value = getLang();
  defineExpose({text})
</script>

<template>
  <Header 
    CompanyName="MasterChef"
    :Text="text.header"
  />
  <div class="container-fluid">
    <div class="row">
      <div class="col-lg-2 col-md-3">
        <div class="chat-controller">
          <div class="chat-btn-wrap" v-auto-animate>
            <div class="queue" v-if="Queue != 0">
              <span class="WaitingInLine">{{Queue}} {{text.home.PeopleInQueue}}</span>
            </div>
            <div v-for="(chats,index) in ChatWindows" :key="index" class="mb-2">
              <span @click="ActivateChat(index)">
                <ChatIndexButton  :active="chats.active" :messagealert="chats.messagealert" :key="chats.active"/>
              </span>
            </div>
          </div>

          <div class="chat-btn-wrap-bottom">
            <button v-if="Working" type="button" class="btn btn-light mb-3 StartRoomBtn" @click="roomStop()">
              {{text.home.EndChat}}
            </button>
            <button v-else type="button" class="btn btn-light mb-3 StartRoomBtn" @click="roomStart()">
              {{text.home.StartRoom}}
            </button>
            
            <div v-if="Working">
              <button 
                class="btn btn-primary" 
                v-if="OpenWorker == false" 
                @click="openWorker()"
              >
                {{text.home.Clients}}
              </button>

              <button 
                class="btn btn-primary"
                @click="closeWorker()"
                v-else
              >
                {{text.home.Looking}}
              </button>

              <button class="btn btn-primary EndChatBtn terminate mt-2" @click="stopChat(null)">
                {{text.home.EndActive}}
              </button>
            </div>
          </div>
        </div>
      </div>
      <div class="col-lg-10 col-md-9 not-bootstrap">
        <div class="converzation-wrap" v-if="ChatWindows.length != 0">
          <cm-conversation style="height: 85vh" id="chatWindow">
            <div id="chatWindow" class="body">
              <cm-conversation-divider>
                <span class="title"> {{text.home.Today}} </span>
              </cm-conversation-divider>
              <div v-for="chat in ChatWindows[activeChatKey].newChats" :key="chat">
                <div v-if="chat.White">
                    <ConverzationHelp :Text="chat.Text" :Time="chat.Time" :img="chat.Img"/>
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
          {{text.home.NoUsers}}
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
        Working:false,
        Queue: 0,
        messagealert:false,
        chatlist: [],
        newchatcounter: 0,
        chattest: []
      }
    },
    mounted(){
      this.chat = this.$chat

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
      window.addEventListener('StopRoom',()=>{
        this.roomStop()
      })

      window.addEventListener('NewQueue',()=>{
        this.Queue = sessionStorage.getItem('Queue')
      })

      window.addEventListener('NewMedia',()=>{
        this.AddMedia( localStorage.getItem('FromUser'))
      })

      window.onbeforeunload = (()=>{
        let obj = 
        {
          openworker: this.OpenWorker,
          chat: this.ChatWindows,
          working: this.Working,
        }
        sessionStorage.setItem('ActiveChats', JSON.stringify(obj));
      })
      this.GetAllActiveChats();
      const sessionQueue = sessionStorage.getItem('Queue')
      if (sessionQueue != null) {
        this.Queue = sessionQueue
      }
    },
    beforeUnmount() {
    this.closeWorker()
    let obj = 
    {
      openworker: this.OpenWorker,
      chat: this.ChatWindows,
      working: this.Working,
    }
    sessionStorage.setItem('ActiveChats', JSON.stringify(obj));
    },
    methods:{
      scroll(){
        let e = document.getElementById('chatWindow')
        e.style.scrollBehavior = 'smooth'
        if(e){
          setTimeout(()=>{
            e.scrollTo(0, e.scrollHeight)
          }, 50)
        }
      },
      UpdatePageTitle(){
        this.chatlist = []
        for (let i = 0; i < this.ChatWindows.length; i++) {
          if(this.ChatWindows[i].messagealert == true){
            this.chatlist.push(this.ChatWindows[i].messagealert)
          }
        }
        this.newchatcounter = this.chatlist.length
        if(this.newchatcounter >= 1){
          document.title = `CustomerService - ${this.newchatcounter} Unread chat('s)`
        }
        else{document.title = `CustomerService`}
      },
      GetAllActiveChats(){
        if(sessionStorage.getItem('ActiveChats') != null)
        {
          var obj = JSON.parse(sessionStorage.getItem('ActiveChats'))
          this.OpenWorker = obj.openworker
          this.ChatWindows = obj.chat
          this.Working = obj.working
        }
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
        this.scroll();
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
        this.ChatWindows[User].messagealert = true;
        if(this.ChatWindows[User].active){
          this.ChatWindows[User].messagealert = false;
        }
        this.UpdatePageTitle();

        let obj = 
        {
          openworker: this.OpenWorker,
          chat: this.ChatWindows,
          working: this.Working,
        }
        sessionStorage.setItem('ActiveChats', JSON.stringify(obj));
        this.scroll();
      },
      AddMedia(connection){
        const time = new Date();
        const bubble = {
          Text: '',
          Time: `${time.getHours()}:${time.getMinutes()}`, 
          White: true,
          Img: localStorage.getItem('img')
        };
        let User = this.FindUser(connection)
        this.ChatWindows[User].newChats = [...this.ChatWindows[User].newChats, bubble];
      },
      ActivateChat(index){
        if(this.ChatWindows.length == 0) return
        this.activeChatKey = index
        this.ChatWindows.forEach(element => {
          element.active =false;
        });
        this.ChatWindows[index].active = !this.ChatWindows[index].active
        this.ChatWindows[index].messagealert = false;
        this.UpdatePageTitle();
      },
      AddUser(connection){
        let json = {
          newChats:[],
          UserConnection:'',
          active:false,
          messagealert:false
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
      async RemoveUser(Connection){ 
        const i = this.FindUser(Connection)
        await this.SaveChat(i, Connection)
        this.ChatWindows.splice(i,1)
        this.ActivateChat(0)
        window.AddErrorNotification('User left')
      },
      async stopChat(connection){
        if (connection == null){
          connection = this.ChatWindows[this.activeChatKey].UserConnection
        }
        await this.RemoveUser(connection)
        await this.chat.StopRoom(connection)
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
        this.Working = true

      },
      async roomStop(){
        // for (let index = 0; index < this.ChatWindows.length; index++) {
        //   console.log(index+'Pls doe het waarom skkip je er een')
        //   const element = this.ChatWindows[index];
        //   console.log(element)
        //   await this.stopChat(element.UserConnection)
        // }
        while (this.ChatWindows.length != 0){
          console.log(this.ChatWindows[0])
          await this.stopChat(this.ChatWindows[0].UserConnection)
        } 
        this.Working = false
        this.chat.StopRoom()
      },
      async SaveChat(i){
        if(this.ChatWindows[i].newChats.length != 0){
          await UploadChat(this.ChatWindows[i].UserConnection, this.ChatWindows[i].newChats)
        }
      }
    }
  }
</script>

<style lang="scss">
  @import "../assets/styles/pages/home.scss";
</style>