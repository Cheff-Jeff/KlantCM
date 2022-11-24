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
      <cm-button
        v-if="isadmin"
        data-label="Register"
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
            <img src="../assets/english flag.jpg" alt="">
          </a>
          <a href="#" language="dutch" @click="ChangeLanguage()">
            <img src="../assets/dutch flag.webp" alt="">
          </a>
          <a href="#" language="turkish" @click="ChangeLanguage()">
            <img src="../assets/turkish flag.webp" alt="">
          </a>
        </div>
      </div>
    </div>
  </header>
</template>

<script>
  export default {
    data(){
      return{
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
        var userid = JSON.parse(localStorage.getItem("user"));

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
        this.$router.push("register");
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