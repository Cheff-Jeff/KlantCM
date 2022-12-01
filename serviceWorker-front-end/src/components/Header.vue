<script setup>
  import { RouterLink } from 'vue-router'
  import {Logout} from '../assets/javascript/Authenticate'
  import {GetUserById} from '../assets/javascript/Authenticate'
  import {ChangeLanguage} from '../assets/javascript/translate';

  defineProps({
    CompanyName: {
      type: String,
      required: true,
      default: "Company name"
    }
  });
</script>

<template>
  <header>
    <div class="brand-wrap">
      <h1>
        <RouterLink :to="{name: 'home'}">
          {{ CompanyName }}
        </RouterLink>
      </h1>
    </div>
    <div class="nav-wrap">
      <svg @click="openMenu" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512"><!--! Font Awesome Pro 6.2.1 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2022 Fonticons, Inc. --><path d="M495.9 166.6c3.2 8.7 .5 18.4-6.4 24.6l-43.3 39.4c1.1 8.3 1.7 16.8 1.7 25.4s-.6 17.1-1.7 25.4l43.3 39.4c6.9 6.2 9.6 15.9 6.4 24.6c-4.4 11.9-9.7 23.3-15.8 34.3l-4.7 8.1c-6.6 11-14 21.4-22.1 31.2c-5.9 7.2-15.7 9.6-24.5 6.8l-55.7-17.7c-13.4 10.3-28.2 18.9-44 25.4l-12.5 57.1c-2 9.1-9 16.3-18.2 17.8c-13.8 2.3-28 3.5-42.5 3.5s-28.7-1.2-42.5-3.5c-9.2-1.5-16.2-8.7-18.2-17.8l-12.5-57.1c-15.8-6.5-30.6-15.1-44-25.4L83.1 425.9c-8.8 2.8-18.6 .3-24.5-6.8c-8.1-9.8-15.5-20.2-22.1-31.2l-4.7-8.1c-6.1-11-11.4-22.4-15.8-34.3c-3.2-8.7-.5-18.4 6.4-24.6l43.3-39.4C64.6 273.1 64 264.6 64 256s.6-17.1 1.7-25.4L22.4 191.2c-6.9-6.2-9.6-15.9-6.4-24.6c4.4-11.9 9.7-23.3 15.8-34.3l4.7-8.1c6.6-11 14-21.4 22.1-31.2c5.9-7.2 15.7-9.6 24.5-6.8l55.7 17.7c13.4-10.3 28.2-18.9 44-25.4l12.5-57.1c2-9.1 9-16.3 18.2-17.8C227.3 1.2 241.5 0 256 0s28.7 1.2 42.5 3.5c9.2 1.5 16.2 8.7 18.2 17.8l12.5 57.1c15.8 6.5 30.6 15.1 44 25.4l55.7-17.7c8.8-2.8 18.6-.3 24.5 6.8c8.1 9.8 15.5 20.2 22.1 31.2l4.7 8.1c6.1 11 11.4 22.4 15.8 34.3zM256 336c44.2 0 80-35.8 80-80s-35.8-80-80-80s-80 35.8-80 80s35.8 80 80 80z"/></svg>
    </div>
  </header>

  <div @click="openMenu" :class="modalToggle" class="modal custom" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
      <div @click.stop class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">{{CompanyName}}</h5>
          <button @click="openMenu" type="button" class="close" data-dismiss="modal" aria-label="Close">
            <svg cm-icon-name="cm-icon-close" viewBox="0 0 24 24" fill="currentColor">
              <path d="M13.4261944,11.9997479 L17.7050296,7.72091264 C17.9016765,7.52426573 18.0005042,7.26610362 18.0005042,7.00794151 C18.0005042,6.7497794 17.9016765,6.49262574 17.7050296,6.29497038 C17.3107273,5.90167654 16.6723812,5.90167654 16.2790874,6.29497038 L12.0002521,10.5738056 L7.72141687,6.29497038 C7.32812303,5.90167654 6.68977688,5.90167654 6.2954746,6.29497038 C6.09882768,6.49262574 6,6.7497794 6,7.00794151 C6,7.26610362 6.09882768,7.52426573 6.2954746,7.72091264 L10.5743098,11.9997479 L6.2954746,16.2785831 C6.09882768,16.4752301 6,16.7333922 6,16.9915543 C6,17.2497164 6.09882768,17.50687 6.2954746,17.7045254 C6.49312996,17.9011723 6.75028363,18 7.00844573,18 C7.26660784,18 7.52476995,17.9011723 7.72141687,17.7045254 L12.0002521,13.4256902 L16.2790874,17.7045254 C16.4757343,17.9011723 16.7338964,18 16.9920585,18 C17.2502206,18 17.5073743,17.9011723 17.7050296,17.7045254 C17.9016765,17.50687 18.0005042,17.2497164 18.0005042,16.9915543 C18.0005042,16.7333922 17.9016765,16.4752301 17.7050296,16.2785831 L13.4261944,11.9997479 Z"></path>
            </svg>
          </button>
        </div>
        <div class="modal-body account">
          <div class="nav-btn-wrapper" @click="accountBtn">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512">
              <path d="M272 304h-96C78.8 304 0 382.8 0 480c0 17.67 14.33 32 32 32h384c17.67 0 32-14.33 32-32C448 382.8 369.2 304 272 304zM48.99 464C56.89 400.9 110.8 352 176 352h96c65.16 0 119.1 48.95 127 112H48.99zM224 256c70.69 0 128-57.31 128-128c0-70.69-57.31-128-128-128S96 57.31 96 128C96 198.7 153.3 256 224 256zM224 48c44.11 0 80 35.89 80 80c0 44.11-35.89 80-80 80S144 172.1 144 128C144 83.89 179.9 48 224 48z"/>
            </svg>
            <p class="txt">Account</p>
          </div>
          <div class="nav-btn-wrapper" @click="HomeBtn">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512">
              <path d="M256 48C141.1 48 48 141.1 48 256v40c0 13.3-10.7 24-24 24s-24-10.7-24-24V256C0 114.6 114.6 0 256 0S512 114.6 512 256V400.1c0 48.6-39.4 88-88.1 88L313.6 488c-8.3 14.3-23.8 24-41.6 24H240c-26.5 0-48-21.5-48-48s21.5-48 48-48h32c17.8 0 33.3 9.7 41.6 24l110.4 .1c22.1 0 40-17.9 40-40V256c0-114.9-93.1-208-208-208zM144 208h16c17.7 0 32 14.3 32 32V352c0 17.7-14.3 32-32 32H144c-35.3 0-64-28.7-64-64V272c0-35.3 28.7-64 64-64zm224 0c35.3 0 64 28.7 64 64v48c0 35.3-28.7 64-64 64H352c-17.7 0-32-14.3-32-32V240c0-17.7 14.3-32 32-32h16z"/>
            </svg>
            <p class="txt">Chats</p>
          </div>
          <div class="nav-btn-wrapper" @click="registerBtn" v-if="isadmin">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 576 512">
              <path d="M208 256c35.35 0 64-28.65 64-64c0-35.35-28.65-64-64-64s-64 28.65-64 64C144 227.3 172.7 256 208 256zM464 232h-96c-13.25 0-24 10.75-24 24s10.75 24 24 24h96c13.25 0 24-10.75 24-24S477.3 232 464 232zM240 288h-64C131.8 288 96 323.8 96 368C96 376.8 103.2 384 112 384h192c8.836 0 16-7.164 16-16C320 323.8 284.2 288 240 288zM464 152h-96c-13.25 0-24 10.75-24 24s10.75 24 24 24h96c13.25 0 24-10.75 24-24S477.3 152 464 152zM512 32H64C28.65 32 0 60.65 0 96v320c0 35.35 28.65 64 64 64h448c35.35 0 64-28.65 64-64V96C576 60.65 547.3 32 512 32zM528 416c0 8.822-7.178 16-16 16H64c-8.822 0-16-7.178-16-16V96c0-8.822 7.178-16 16-16h448c8.822 0 16 7.178 16 16V416z"/>
            </svg>
            <p class="txt">Employees</p>
          </div>
          <div class="nav-btn-wrapper" @click="LogoutBtn">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512">
              <path d="M160 96c17.7 0 32-14.3 32-32s-14.3-32-32-32H96C43 32 0 75 0 128V384c0 53 43 96 96 96h64c17.7 0 32-14.3 32-32s-14.3-32-32-32H96c-17.7 0-32-14.3-32-32l0-256c0-17.7 14.3-32 32-32h64zM504.5 273.4c4.8-4.5 7.5-10.8 7.5-17.4s-2.7-12.9-7.5-17.4l-144-136c-7-6.6-17.2-8.4-26-4.6s-14.5 12.5-14.5 22v72H192c-17.7 0-32 14.3-32 32l0 64c0 17.7 14.3 32 32 32H320v72c0 9.6 5.7 18.2 14.5 22s19 2 26-4.6l144-136z"/>
            </svg>
            <p class="txt">Sign off</p>
          </div>
        </div>
        <div class="modal-header second">
          <h5 class="modal-title" id="exampleModalLabel">Settings</h5>
        </div>
        <div class="modal-body settings">
          <div class="lang-drop">
            <span class="head" :class="boxToggle" @click="dropToggle">Languages <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512"><path d="M233.4 406.6c12.5 12.5 32.8 12.5 45.3 0l192-192c12.5-12.5 12.5-32.8 0-45.3s-32.8-12.5-45.3 0L256 338.7 86.6 169.4c-12.5-12.5-32.8-12.5-45.3 0s-12.5 32.8 0 45.3l192 192z"/></svg></span>
            <div class="droper" :class="boxToggle">
              <a href="#" language="english" class="active" @click="ChangeLanguage()">
                <img src="/images/flags/english_flag.jpg">
              </a>
              <a href="#" language="dutch" @click="ChangeLanguage()">
                <img src="/images/flags/dutch_flag.webp">
              </a>
              <a href="#" language="turkish" @click="ChangeLanguage()">
                <img src="/images/flags/turkish_flag.webp">
              </a>
            </div>
          </div>
        </div>
        <div class="modal-footer">
          <button @click="openMenu" type="button" class="btn btn-secondary btn-close" data-dismiss="modal">Close</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    data(){
      return{
        modalToggle: 'noshow',
        boxToggle: 'hide',
        user: [],
        username: '',
        isadmin: ''
      }
    },
    mounted(){
      this.GetLoggedInUser()
    },
    methods: {
      async GetLoggedInUser(){
        //JSON.parse om de "" weg te halen.
        var userid = JSON.parse(sessionStorage.getItem("user"));

        this.user = await GetUserById(userid)

        this.username = this.user[0].userName
        this.isadmin = this.user[0].isAdmin
      },
      openMenu(){
        this.modalToggle = this.modalToggle == 'noshow' ? 'show' : 'noshow'
      },
      dropToggle(){
        this.boxToggle = this.boxToggle == 'hide' ? 'open' : 'hide'
      },
      accountBtn() {
        //Navigeer naar test view;
        this.$router.push("account");
      },
      registerBtn() {
        //Navigeer naar test view;
        this.$router.push("usermanagement");
      },
      HomeBtn(){
        this.$router.push("home");
      },
      LogoutBtn(){
        if(Logout()){
          this.$router.push("login");
        }
        else{
          //error
        }
      },
    }
  };
  function myFunction() {
    document.getElementById("myDropdown").classList.toggle("show");

    ChangeLanguage();
  }

window.onclick = function(event) {
  if (!event.target.matches('.dropbtn')) {
    var dropdowns = document.getElementsByClassName("dropdown-content");
    var i;
    for (i = 0; i < dropdowns.length; i++) {
      var openDropdown = dropdowns[i];
    }
  }
}

</script>

<style lang="scss">
  @import "../assets/styles/components/header.scss";
</style>