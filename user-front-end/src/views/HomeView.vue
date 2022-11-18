<script setup>
  import ConverzationSend from '../components/ConverzationSend.vue';
  import ConverzationHelp from '../components/ConverzationHelp.vue';
  import Input from '../components/ChatInput.vue';
  import { ChatHub } from '../assets/javascript/Chat';
  import { uploadImage } from '../assets/javascript/base64';
</script>

<template>
  <div class="wraper">
    <div class="page-wrap" v-auto-animate>
      <div class="chat-wrap" v-if="modal" :class="modal">
        <svg class="close-cross" @click="toggleModal" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512"><!--! Font Awesome Pro 6.2.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2022 Fonticons, Inc. --><path d="M175 175C184.4 165.7 199.6 165.7 208.1 175L255.1 222.1L303 175C312.4 165.7 327.6 165.7 336.1 175C346.3 184.4 346.3 199.6 336.1 208.1L289.9 255.1L336.1 303C346.3 312.4 346.3 327.6 336.1 336.1C327.6 346.3 312.4 346.3 303 336.1L255.1 289.9L208.1 336.1C199.6 346.3 184.4 346.3 175 336.1C165.7 327.6 165.7 312.4 175 303L222.1 255.1L175 208.1C165.7 199.6 165.7 184.4 175 175V175zM512 256C512 397.4 397.4 512 256 512C114.6 512 0 397.4 0 256C0 114.6 114.6 0 256 0C397.4 0 512 114.6 512 256zM256 48C141.1 48 48 141.1 48 256C48 370.9 141.1 464 256 464C370.9 464 464 370.9 464 256C464 141.1 370.9 48 256 48z"/></svg>
        <div class="converzation-wrap">
          <cm-conversation style="height: 424px;margin-bottom: 10px;border-bottom: solid #f5f5f5 2px;">
            <div class="body">
              <cm-conversation-divider>
                <span class="title"> Today </span>
              </cm-conversation-divider>

              <div 
                v-for="chat in newChats" :key="chat"
              >
                <div v-if="chat.White">
                  <ConverzationHelp :Text="chat.Text" :Time="chat.Time"/>
                </div>
                <div v-else>
                  <ConverzationSend :Text="chat.Text" :Time="chat.Time" :img="chat.img"/>
                </div>
              </div>
            </div>
          </cm-conversation>
        </div>
        <div class="footer">
          <Input @text="sendConverzation" @uploadFile="uploadFile"/>
        </div>
      </div>
    </div>
    <div v-auto-animate>
      <button class="btn-chat" v-if="opner != 'hide'" @click="toggleModal">
        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 512">
          <path d="M208 0C322.9 0 416 78.8 416 176C416 273.2 322.9 352 208 352C189.3 352 171.2 349.7 153.9 345.8C123.3 364.8 79.13 384 24.95 384C14.97 384 5.93 378.1 2.018 368.9C-1.896 359.7-.0074 349.1 6.739 341.9C7.26 341.5 29.38 317.4 45.73 285.9C17.18 255.8 0 217.6 0 176C0 78.8 93.13 0 208 0zM164.6 298.1C179.2 302.3 193.8 304 208 304C296.2 304 368 246.6 368 176C368 105.4 296.2 48 208 48C119.8 48 48 105.4 48 176C48 211.2 65.71 237.2 80.57 252.9L104.1 277.8L88.31 308.1C84.74 314.1 80.73 321.9 76.55 328.5C94.26 323.4 111.7 315.5 128.7 304.1L145.4 294.6L164.6 298.1zM441.6 128.2C552 132.4 640 209.5 640 304C640 345.6 622.8 383.8 594.3 413.9C610.6 445.4 632.7 469.5 633.3 469.9C640 477.1 641.9 487.7 637.1 496.9C634.1 506.1 625 512 615 512C560.9 512 516.7 492.8 486.1 473.8C468.8 477.7 450.7 480 432 480C350 480 279.1 439.8 245.2 381.5C262.5 379.2 279.1 375.3 294.9 369.9C322.9 407.1 373.9 432 432 432C446.2 432 460.8 430.3 475.4 426.1L494.6 422.6L511.3 432.1C528.3 443.5 545.7 451.4 563.5 456.5C559.3 449.9 555.3 442.1 551.7 436.1L535.9 405.8L559.4 380.9C574.3 365.3 592 339.2 592 304C592 237.7 528.7 183.1 447.1 176.6L448 176C448 159.5 445.8 143.5 441.6 128.2H441.6z"/>
        </svg>
      </button>
    </div>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        newChats: [],
        chat: null,
        modal: '', 
        opner: '',
      }
    },
    mounted(){
      this.chat = new ChatHub()
      
      setTimeout(()=>{
        this.chat.ConnectUser()
      },3000)

      window.addEventListener('NewChat',()=>{
        this.reciveConverzation(localStorage.getItem('NewChat'))
      })
      window.addEventListener("resize", this.checkWindow);
    },
    methods: {
      checkWindow() {
        if(window.innerWidth <= 500)
        {
          this.opner = this.opner == '' ? 'hide': '' 
        }
        else
        {
          this.opner = ''
        }
      },
      async uploadFile(e){
        let img = await uploadImage(e)
        this.chat.SendMedia(String(img))
        this.sendMedia(img)
      },
      toggleModal(){
        this.modal = this.modal == '' ? 'open' : ''
        if(window.innerWidth <= 500)
        {
          this.opner = this.opner == '' ? 'hide': '' 
        }
        else
        {
          this.opner = ''
        }
      },
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
      sendMedia(File) {
        const time = new Date();

        const bubble = {
          Text: '', 
          Time: `${time.getHours()}:${time.getMinutes()}`, 
          White: false,
          img: File
        };

        this.newChats = [...this.newChats, bubble];
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