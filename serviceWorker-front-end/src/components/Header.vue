<script setup>
  import { RouterLink } from 'vue-router'
  import {Logout} from '../assets/javascript/Authenticate'

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
        data-label="Register"
        data-button-style="cta"
        data-button-size="medium"
        >
      </cm-button>
      <cm-button
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
  </header>
</template>

<script>
  export default {
    methods: {
      accountBtn() {
        //Navigeer naar test view;
        this.$router.push("account");
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