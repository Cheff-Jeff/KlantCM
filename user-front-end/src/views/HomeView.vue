<script setup>
  import ConverzationSend from '../components/ConverzationSend.vue';
  import ConverzationHelp from '../components/ConverzationHelp.vue';
  import Input from '../components/ChatInput.vue';
  import { ChatHub } from '../assets/javascript/Chat';
  import { ratingUpload } from '../assets/javascript/Stats';
  import {PostFormdata} from '../assets/javascript/UploadImage'
</script>

<template>
  <div class="wraper">
    <div class="page-wrap" v-auto-animate>
      <div class="chat-wrap" v-if="modal" :class="modal">
        <svg class="close-cross" @click="toggleModal" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512"><!--! Font Awesome Pro 6.2.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2022 Fonticons, Inc. --><path d="M175 175C184.4 165.7 199.6 165.7 208.1 175L255.1 222.1L303 175C312.4 165.7 327.6 165.7 336.1 175C346.3 184.4 346.3 199.6 336.1 208.1L289.9 255.1L336.1 303C346.3 312.4 346.3 327.6 336.1 336.1C327.6 346.3 312.4 346.3 303 336.1L255.1 289.9L208.1 336.1C199.6 346.3 184.4 346.3 175 336.1C165.7 327.6 165.7 312.4 175 303L222.1 255.1L175 208.1C165.7 199.6 165.7 184.4 175 175V175zM512 256C512 397.4 397.4 512 256 512C114.6 512 0 397.4 0 256C0 114.6 114.6 0 256 0C397.4 0 512 114.6 512 256zM256 48C141.1 48 48 141.1 48 256C48 370.9 141.1 464 256 464C370.9 464 464 370.9 464 256C464 141.1 370.9 48 256 48z"/></svg>
        <div class="chat-wrapper">
          <div class="converzation-wrap">
            <cm-conversation style="height: 424px;margin-bottom: 10px;border-bottom: solid #f5f5f5 2px;" id="chatWindow">
              <div class="body">
                <cm-conversation-divider>
                  <span class="title"> Today </span>
                </cm-conversation-divider>

                <div v-if="joined == true">
                  <cm-conversation-divider>
                    <span id="joined" class="joined">{{EmployeeName}} joined the room.</span>
                  </cm-conversation-divider>
                </div>

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
        <div class="review-wrapper" :class="rating">
          <div class="wrap">
            <div class="text">
              <p>The chat has been closed.</p>
              <p v-if="!clickedBad && !clickedGood">
                How would you rate this chat?
              </p>
              <p v-else>Thank you for your rating.</p> 
            </div>
            <div class="wrapper" v-auto-animate>
              <div class="thum-up" v-if="!clickedBad">
                <div class="t-wrap" :class="clickedGood" @click="ratingGood">
                  <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512">
                    <path d="M96 191.1H32c-17.67 0-32 14.33-32 31.1v223.1c0 17.67 14.33 31.1 32 31.1h64c17.67 0 32-14.33 32-31.1V223.1C128 206.3 113.7 191.1 96 191.1zM512 227c0-36.89-30.05-66.92-66.97-66.92h-99.86C354.7 135.1 360 113.5 360 100.8c0-33.8-26.2-68.78-70.06-68.78c-46.61 0-59.36 32.44-69.61 58.5c-31.66 80.5-60.33 66.39-60.33 93.47c0 12.84 10.36 23.99 24.02 23.99c5.256 0 10.55-1.721 14.97-5.26c76.76-61.37 57.97-122.7 90.95-122.7c16.08 0 22.06 12.75 22.06 20.79c0 7.404-7.594 39.55-25.55 71.59c-2.046 3.646-3.066 7.686-3.066 11.72c0 13.92 11.43 23.1 24 23.1h137.6C455.5 208.1 464 216.6 464 227c0 9.809-7.766 18.03-17.67 18.71c-12.66 .8593-22.36 11.4-22.36 23.94c0 15.47 11.39 15.95 11.39 28.91c0 25.37-35.03 12.34-35.03 42.15c0 11.22 6.392 13.03 6.392 22.25c0 22.66-29.77 13.76-29.77 40.64c0 4.515 1.11 5.961 1.11 9.456c0 10.45-8.516 18.95-18.97 18.95h-52.53c-25.62 0-51.02-8.466-71.5-23.81l-36.66-27.51c-4.315-3.245-9.37-4.811-14.38-4.811c-13.85 0-24.03 11.38-24.03 24.04c0 7.287 3.312 14.42 9.596 19.13l36.67 27.52C235 468.1 270.6 480 306.6 480h52.53c35.33 0 64.36-27.49 66.8-62.2c17.77-12.23 28.83-32.51 28.83-54.83c0-3.046-.2187-6.107-.6406-9.122c17.84-12.15 29.28-32.58 29.28-55.28c0-5.311-.6406-10.54-1.875-15.64C499.9 270.1 512 250.2 512 227z"/>
                  </svg>
                </div>
              </div>
              <div class="thum-down" v-if="!clickedGood">
                <div class="t-wrap" :class="clickedBad" @click="ratingbad">
                  <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512">
                    <path d="M128 288V64.03c0-17.67-14.33-31.1-32-31.1H32c-17.67 0-32 14.33-32 31.1v223.1c0 17.67 14.33 31.1 32 31.1h64C113.7 320 128 305.7 128 288zM481.5 229.1c1.234-5.092 1.875-10.32 1.875-15.64c0-22.7-11.44-43.13-29.28-55.28c.4219-3.015 .6406-6.076 .6406-9.122c0-22.32-11.06-42.6-28.83-54.83c-2.438-34.71-31.47-62.2-66.8-62.2h-52.53c-35.94 0-71.55 11.87-100.3 33.41L169.6 92.93c-6.285 4.71-9.596 11.85-9.596 19.13c0 12.76 10.29 24.04 24.03 24.04c5.013 0 10.07-1.565 14.38-4.811l36.66-27.51c20.48-15.34 45.88-23.81 71.5-23.81h52.53c10.45 0 18.97 8.497 18.97 18.95c0 3.5-1.11 4.94-1.11 9.456c0 26.97 29.77 17.91 29.77 40.64c0 9.254-6.392 10.96-6.392 22.25c0 13.97 10.85 21.95 19.58 23.59c8.953 1.671 15.45 9.481 15.45 18.56c0 13.04-11.39 13.37-11.39 28.91c0 12.54 9.702 23.08 22.36 23.94C456.2 266.1 464 275.2 464 284.1c0 10.43-8.516 18.93-18.97 18.93H307.4c-12.44 0-24 10.02-24 23.1c0 4.038 1.02 8.078 3.066 11.72C304.4 371.7 312 403.8 312 411.2c0 8.044-5.984 20.79-22.06 20.79c-12.53 0-14.27-.9059-24.94-28.07c-24.75-62.91-61.74-99.9-80.98-99.9c-13.8 0-24.02 11.27-24.02 23.99c0 7.041 3.083 14.02 9.016 18.76C238.1 402 211.4 480 289.9 480C333.8 480 360 445 360 411.2c0-12.7-5.328-35.21-14.83-59.33h99.86C481.1 351.9 512 321.9 512 284.1C512 261.8 499.9 241 481.5 229.1z"/>
                  </svg>
                </div>
              </div>
            </div>
          </div>
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
        clickedGood: '',
        clickedBad: '',
        rating: 'hide',
        connected: false,
        imgCount:0,
        joined: false,
        EmployeeName:null,
      }
    },
    mounted(){
      this.chat = new ChatHub();
      
      window.addEventListener('NewChat',()=>{
        this.reciveConverzation(localStorage.getItem('NewChat'))
      })
      window.addEventListener('Joined',()=>{
        setTimeout(()=>{
          this.EmployeeName = sessionStorage.getItem('EmployeeName')
          this.joined = true
        },1000)
      })

      window.addEventListener("CloseChat",()=>{
        if(this.newChats.length > 0){
          this.openRating()
        }
      })

      window.addEventListener('resize', () => {
        this.resize();
      });
      this.resize();
    },
    methods: {
      resize(){
        const size = window.innerHeight * 0.01;
        document.documentElement.style.setProperty('--vh', `${size}px`);
      },
      scroll(){
        let e = document.getElementById('chatWindow')
        if(e){
          e.style.scrollBehavior = 'smooth'
          setTimeout(()=>{
            e.scrollTo(0, e.scrollHeight)
          }, 50)
        }
      },
      openRating(){
        this.rating ='open'
      },
      ratingGood(){
        this.clickedGood = 'clicked'
        ratingUpload(true)
      },
      ratingbad(){
        this.clickedBad = 'clicked'
        ratingUpload(false)
      },
      async uploadFile(e){
        await PostFormdata(e)
        this.sendMedia(e)
        this.chat.SendMedia(this.imgCount++)
      },
      toggleModal(){
        if(!this.connected){
          setTimeout(()=>{
            this.chat.ConnectUser()
          },3000)
        }
        this.connected = true

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
        this.scroll();
      },
      sendMedia(File) {
        console.log(File)
        const time = new Date();

        const bubble = {
          Text: `loading`, 
          Time: `${time.getHours()}:${time.getMinutes()}`, 
          White: false,
          img: File
        }
        this.newChats = [...this.newChats, bubble];
        this.scroll();
      },
      reciveConverzation(text) {
        const time = new Date();

        const bubble = {
          Text: text, 
          Time: `${time.getHours()}:${time.getMinutes()}`, 
          White: true
        };

        this.newChats = [...this.newChats, bubble];
        this.scroll();
      }
    }
  };
</script>

<style lang="scss">
  @import "../assets/styles/pages/home.scss";
</style>