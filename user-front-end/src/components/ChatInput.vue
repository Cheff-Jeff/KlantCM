<template>
  <div class="row">
    <div class="col-10 col-md-11">
      <div class="form-group">
        <div class="form-row">
          <div class="form-input-special">
            <input
              id="sendBox"
              type="text"
              class="form-control spacing-right-icons-2"
              placeholder="Start typing… "
              v-model="input"
            />
            <span class="input-left icon noHover">
              <span class="cm-icon cm-icon-comment noHover" aria-hidden="true"></span>
            </span>
            <span class="input-right icon">
              <span class="cm-icon cm-icon-attachment m-r-8" aria-hidden="true"></span>
            </span>
          </div>
        </div>
      </div>
    </div>
    <div class="col-2 col-md-1">
      <button class="btn btn-cta-icon" @click="sendChatBubbel">
        <span class="cm-icon cm-icon-send" aria-hidden="true"></span>
      </button>
    </div>
  </div>
</template>

<script>
  export default {
    data() {
      return{
        input: '',
        inputError: '' 
      }
    },
    methods: {
      sendChatBubbel(){
        
      }
    }
  };
</script>