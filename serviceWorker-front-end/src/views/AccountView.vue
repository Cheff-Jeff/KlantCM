<script setup>
  import RatingGraph from '../components/RatingGraph.vue';
  import Header from '../components/Header.vue';
  import { getLang } from '@/assets/javascript/translate';
  import { ref } from 'vue';
  import MyProfileVue from '../components/MyProfile.vue';
  import {GetUserById} from '../assets/javascript/User'
  const text = ref(null);
  text.value = getLang();
  defineExpose({text})
</script>

<template>
  <Header 
    CompanyName="MasterChef"
    :Text="text.header"
  />
  <MyProfileVue v-if="user" :User="user[0]" />

  <RatingGraph/>
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

    sessionStorage.setItem('uDetails', this.userId)
  },
  methods: {
    async getUser() {
      this.userId = await JSON.parse(sessionStorage.getItem('user'))
      this.user = await GetUserById(this.userId.userId)
      console.log( this.user[0])
    }
  }
}
</script>