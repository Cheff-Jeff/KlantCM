<script setup>
  import ConverzationSend from '../components/ConverzationSend.vue';
  import ConverzationHelp from '../components/ConverzationHelp.vue';
  import Input from '../components/ChatInput.vue';
import { ChatHub } from '../assets/javascript/Chat';
</script>

<template>
  <div class="container customize">
    <div class="row justify-content-center">
      <div class="col-md-12 not-bootstrap">
        <div class="converzation-wrap">
          <cm-conversation style="height: 95vh">
            <div class="body">
              <cm-conversation-divider>
                <span class="title"> Today </span>
              </cm-conversation-divider>

              <ConverzationHelp />

              <ConverzationSend />
              <ConverzationSend />

              <ConverzationHelp />

              <ConverzationSend Text="Thank you." Time="00:15"/>

              <div 
                v-for="chat in newChats"
              >
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
    data() {
      return {
        newChats: [],
        chat :null
      }
    },
    mounted(){
      this.chat = new ChatHub()
      this.chat.ConnectUser()
    },
    methods: {
      sendConverzation(text) {
        const time = new Date();

        const bubble = {
          Text: text, 
          Time: `${time.getHours()}:${time.getMinutes()}`, 
          White: false
        };

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
  };
</script>

<style lang="scss">
  @import "../assets/styles/pages/home.scss";
</style>