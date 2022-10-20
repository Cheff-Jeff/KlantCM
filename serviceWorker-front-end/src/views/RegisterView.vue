<script setup>
import RegisterForm from '../components/RegisterForm.vue'
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

<style lang="scss" scoped>
  @import "../assets/styles/pages/login.scss";
</style>