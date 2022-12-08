<script setup>
  import { RouterLink } from 'vue-router'
  import {Logout} from '../assets/javascript/Authenticate'
  import {GetUserById} from '../assets/javascript/Authenticate'
  import {switchLang} from '../assets/javascript/translate';
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
          <a href="#" language="english" class="active" @click="langToggle('en')">
            <img src="../assets/english_flag.jpg" alt="">
          </a>
          <a href="#" language="dutch" @click="langToggle('nl')">
            <img src="../assets/dutch_flag.webp" alt="">
          </a>
          <a href="#" language="turkish" @click="langToggle('tr')">
            <img src="../assets/turkish_flag.webp" alt="">
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
        var userid = JSON.parse(sessionStorage.getItem("user"));

        this.user = await GetUserById(userid)

        this.username = this.user[0].userName
        this.isadmin = this.user[0].isAdmin
      },
      langToggle(lang){
        switchLang(lang)
        this.$router.go();
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