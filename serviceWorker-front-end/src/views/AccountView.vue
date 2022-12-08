<script setup>
import {GetUserById} from '../assets/javascript/User'
import Header from '../components/Header.vue';
import MyProfileVue from '../components/MyProfile.vue';
</script>

<template>
  <Header />
  <MyProfileVue v-if="user" :User="user[0]" />
</template>

<script>
export default {
  data(){
    return{
      user: '',
      userId: ''
    }
  },
  async mounted() {
    await this.getUser()
  },
  methods: {
    async getUser() {
      this.userId = await JSON.parse(sessionStorage.getItem('user'))
      this.user = await GetUserById(this.userId)
      console.log( this.user[0])
    }
  }
}
</script>