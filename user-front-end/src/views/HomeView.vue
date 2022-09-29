<script setup>
  import ConverzationSend from '../components/ConverzationSend.vue';
  import ConverzationHelp from '../components/ConverzationHelp.vue';
  import Input from '../components/ChatInput.vue';
</script>

<template>
  <div class="container customize">
    <div class="row justify-content-center">
      <div class="col-md-12 not-bootstrap">
        <div class="converzation-wrap">
          <cm-conversation style="height: 95vh">
            <div class="body">
              <cm-conversation-divider>
                <span class="title"> Today </span>
              </cm-conversation-divider>

              <ConverzationHelp />

              <ConverzationSend />
              <ConverzationSend />

              <ConverzationHelp />

              <ConverzationSend Text="Thank you." Time="00:15"/>

            </div>
            <div class="footer">
              <Input />
            </div>
          </cm-conversation>
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="scss">
  @import "../assets/styles/pages/home.scss";
</style>