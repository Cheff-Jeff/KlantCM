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
      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512"><!--! Font Awesome Pro 6.2.1 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2022 Fonticons, Inc. --><path d="M495.9 166.6c3.2 8.7 .5 18.4-6.4 24.6l-43.3 39.4c1.1 8.3 1.7 16.8 1.7 25.4s-.6 17.1-1.7 25.4l43.3 39.4c6.9 6.2 9.6 15.9 6.4 24.6c-4.4 11.9-9.7 23.3-15.8 34.3l-4.7 8.1c-6.6 11-14 21.4-22.1 31.2c-5.9 7.2-15.7 9.6-24.5 6.8l-55.7-17.7c-13.4 10.3-28.2 18.9-44 25.4l-12.5 57.1c-2 9.1-9 16.3-18.2 17.8c-13.8 2.3-28 3.5-42.5 3.5s-28.7-1.2-42.5-3.5c-9.2-1.5-16.2-8.7-18.2-17.8l-12.5-57.1c-15.8-6.5-30.6-15.1-44-25.4L83.1 425.9c-8.8 2.8-18.6 .3-24.5-6.8c-8.1-9.8-15.5-20.2-22.1-31.2l-4.7-8.1c-6.1-11-11.4-22.4-15.8-34.3c-3.2-8.7-.5-18.4 6.4-24.6l43.3-39.4C64.6 273.1 64 264.6 64 256s.6-17.1 1.7-25.4L22.4 191.2c-6.9-6.2-9.6-15.9-6.4-24.6c4.4-11.9 9.7-23.3 15.8-34.3l4.7-8.1c6.6-11 14-21.4 22.1-31.2c5.9-7.2 15.7-9.6 24.5-6.8l55.7 17.7c13.4-10.3 28.2-18.9 44-25.4l12.5-57.1c2-9.1 9-16.3 18.2-17.8C227.3 1.2 241.5 0 256 0s28.7 1.2 42.5 3.5c9.2 1.5 16.2 8.7 18.2 17.8l12.5 57.1c15.8 6.5 30.6 15.1 44 25.4l55.7-17.7c8.8-2.8 18.6-.3 24.5 6.8c8.1 9.8 15.5 20.2 22.1 31.2l4.7 8.1c6.1 11 11.4 22.4 15.8 34.3zM256 336c44.2 0 80-35.8 80-80s-35.8-80-80-80s-80 35.8-80 80s35.8 80 80 80z"/></svg>
    </div>
  </header>

  <div @click="closeModal" :class="modalToggle" class="modal custom" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
      <div @click.stop class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">Settings</h5>
          <button @click="closeModal" type="button" class="close" data-dismiss="modal" aria-label="Close">
            <svg cm-icon-name="cm-icon-close" viewBox="0 0 24 24" fill="currentColor">
              <path d="M13.4261944,11.9997479 L17.7050296,7.72091264 C17.9016765,7.52426573 18.0005042,7.26610362 18.0005042,7.00794151 C18.0005042,6.7497794 17.9016765,6.49262574 17.7050296,6.29497038 C17.3107273,5.90167654 16.6723812,5.90167654 16.2790874,6.29497038 L12.0002521,10.5738056 L7.72141687,6.29497038 C7.32812303,5.90167654 6.68977688,5.90167654 6.2954746,6.29497038 C6.09882768,6.49262574 6,6.7497794 6,7.00794151 C6,7.26610362 6.09882768,7.52426573 6.2954746,7.72091264 L10.5743098,11.9997479 L6.2954746,16.2785831 C6.09882768,16.4752301 6,16.7333922 6,16.9915543 C6,17.2497164 6.09882768,17.50687 6.2954746,17.7045254 C6.49312996,17.9011723 6.75028363,18 7.00844573,18 C7.26660784,18 7.52476995,17.9011723 7.72141687,17.7045254 L12.0002521,13.4256902 L16.2790874,17.7045254 C16.4757343,17.9011723 16.7338964,18 16.9920585,18 C17.2502206,18 17.5073743,17.9011723 17.7050296,17.7045254 C17.9016765,17.50687 18.0005042,17.2497164 18.0005042,16.9915543 C18.0005042,16.7333922 17.9016765,16.4752301 17.7050296,16.2785831 L13.4261944,11.9997479 Z"></path>
            </svg>
          </button>
        </div>
        <div class="modal-body">
          <cm-button
            v-if="isadmin"
            data-label="Mange users"
            data-button-style="cta"
            data-button-size="medium"
            @click="registerBtn"
            >
          </cm-button>
          <cm-button
            class="My_Profile"
            data-label="My profile"
            data-button-style="cta"
            data-button-size="medium"
            @click="accountBtn">
          </cm-button>
          <cm-button
            data-label="Logout"
            data-button-style="cta"
            data-button-size="medium"
            data-custom-classes="logout"
            @click="LogoutBtn">
          </cm-button>
        </div>
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">Settings</h5>
        </div>
        <div class="modal-body">
          <div class="langWrap">
            <div class="dropdown">
              <cm-button 
                data-label="Choose language" 
                data-button-style="cta" 
                data-button-size="medium" 
                data-custom-classes="dropbtn"
                @click="myFunction()">
              </cm-button>
              <div id="myDropdown" class="dropdown-content">
                <a href="#" language="english" class="active" @click="ChangeLanguage()">
                  <img src="../assets/english_flag.jpg" alt="">
                </a>
                <a href="#" language="dutch" @click="ChangeLanguage()">
                  <img src="../assets/dutch_flag.webp" alt="">
                </a>
                <a href="#" language="turkish" @click="ChangeLanguage()">
                  <img src="../assets/turkish_flag.webp" alt="">
                </a>
              </div>
            </div>
          </div>
        </div>
        <div class="modal-footer">
          <button @click="closeModal" type="button" class="btn btn-secondary btn-close" data-dismiss="modal">Close</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    data(){
      return{
        // modalToggle: 'hide',
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
      accountBtn() {
        //Navigeer naar test view;
        this.$router.push("account");
      },
      registerBtn() {
        //Navigeer naar test view;
        this.$router.push("usermanagement");
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