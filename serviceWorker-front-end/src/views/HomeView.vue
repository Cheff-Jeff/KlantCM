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
                data-label="active chat"
                data-button-style="ghost"
                data-button-size="medium">
            </cm-button><br>
            <cm-button
                data-label="2 new message('s')"
                data-button-style="primary"
                data-button-size="medium">
            </cm-button><br>
            <cm-button
                data-label="2 new message('s')"
                data-button-style="primary"
                data-button-size="medium">
            </cm-button><br>
            <cm-button
                data-label="2 new message('s')"
                data-button-style="primary"
                data-button-size="medium">
            </cm-button><br>
            <cm-button
                data-label="2 new message('s')"
                data-button-style="primary"
                data-button-size="medium">
            </cm-button><br>
          </div>

          <div class="chat-btn-wrap-bottom">
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

              <ConverzationHelp />

              <ConverzationSend />
              <ConverzationSend />
              <ConverzationSend />


              <ConverzationHelp Text="Thank you." Time="00:15"/>

              <div v-for="chat in newChats" :key="chat">
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
        newChats: []
      }
    },
    mounted(){
      console.log("test")
      this.chat = new ChatHub()
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

        console.log("tets");
        this.newChats = [...this.newChats, bubble];
        this.chat.SendMessage(text)
      },
      reciveConverzation(text) {
        const time = new Date();

        const bubble = {
          Text: text, 
          Time: `${time.getHours()}:${time.getMinutes()}`, 
          White: true
        };

        this.newChats = [...this.newChats, bubble];
      }
    }
  }
</script>

<style lang="scss">
  @import "../assets/styles/pages/home.scss";
</style>