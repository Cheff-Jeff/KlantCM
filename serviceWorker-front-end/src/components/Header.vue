<script setup>
  import { RouterLink } from 'vue-router'
  import {Logout} from '../assets/javascript/Authenticate'
  import {GetUserById} from '../assets/javascript/Authenticate'

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
        data-label="Hallo"
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
</script>

<style lang="scss">
  @import "../assets/styles/components/header.scss";
</style>