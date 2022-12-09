<script setup>
  import Header from '../components/Header.vue';
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
  <h1 class="mt-5 pt-5">Account</h1>
</template>