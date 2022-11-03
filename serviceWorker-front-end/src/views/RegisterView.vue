<script setup>
import RegisterForm from '../components/RegisterForm.vue'
import Header from '../components/Header.vue';
</script>

<template>
  <Header/>
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
                <h1>Register</h1>
                <RegisterForm/>
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
  components:{
    Header
  }
}

</script>

<style lang="scss" scoped>
  @import "../assets/styles/pages/login.scss";
</style>