<script setup>
import LoginForm from '../components/LoginForm.vue'
import { getLang } from '@/assets/javascript/translate';
import { ref } from 'vue';
  const text = ref(null);
  text.value = getLang();
  defineExpose({text})
</script>

<template>
  <section class="login">
    <div class="container fix-padding">
      <div class="wrapper">
        <div class="row">
          <div class="col-md-6">
            <div class="inner img-wrapper">
              <img src="/images/login-wallpaper.jpg">
            </div>
          </div>
          <div class="col-md-6">
            <div class="inner form-wrapper">
              <div class="wrap">
                <h1>{{text.SignIn.Heading}}</h1>
                <LoginForm :Text="text.SignIn.form"/>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
export default{
  mounted(){
    sessionStorage.removeItem('ActiveChats');
  }
}
</script>

<style lang="scss" scoped>
  @import "../assets/styles/pages/login.scss";
</style>