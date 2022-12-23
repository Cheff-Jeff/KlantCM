<script setup>
import RatingGraph from '../components/RatingGraph.vue';
import Header from '@/components/Header.vue';
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

    <RatingGraph/>

</template>

<script>

</script>

<style scoped>

</style>