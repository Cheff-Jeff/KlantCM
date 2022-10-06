<script setup>

</script>

<template>
    <h1 class="mt-5 padtop7 text-center text-danger">Error</h1>
    <h2 class="text-center">Er is iets fout gegaan!</h2>
    <div class="buttonspace" v-if="login">
        <button class="btn btn-danger" @click="loginPage">Login</button>
    </div>
</template>

<script>
    export default {
        methods: {
            loginPage() {
                //Navigeer naar test view;
                this.$router.push("login");
            }
        }
    }
</script>

<style>
    .padtop7 {
        padding-top: 7rem;
    }

    .buttonspace {
        text-align: center;
    }
</style>