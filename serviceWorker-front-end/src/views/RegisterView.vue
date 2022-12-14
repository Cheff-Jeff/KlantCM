<script setup>
import { getLang } from '@/assets/javascript/translate';
import { ref } from 'vue';
  const text = ref(null);
  text.value = getLang();
  defineExpose({text})
</script>
<template>
  <Header
    CompanyName="MasterChef"
    :Text="text.header"
  />
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
                <h1>{{text.SignUp.Heading}}</h1>
                <RegisterForm :Text="text.SignUp.form"/>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import RegisterForm from '../components/RegisterForm.vue'
import Header from '../components/Header.vue';
export default{
  components:{
    Header,
    RegisterForm
  }
}

</script>

<style lang="scss" scoped>
  @import "../assets/styles/pages/login.scss";
</style>