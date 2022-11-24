<script setup>
import {ChangeLanguage} from '../assets/javascript/translate';
</script>

<template>
  <form action="#" @submit.prevent="submit">
    <div class="row">
      <div class="col-10 col-md-11">
        <div class="form-group">
          <div class="form-row">
            <div class="form-input-special">
              <input
                id="sendBox"
                type="text"
                class="form-control spacing-right-icons-2"
                autocomplete="off"
                placeholder="Start typing… "
                v-model="input"
              />
              <span class="input-left icon">
                <span class="cm-icon cm-icon-comment" aria-hidden="true"></span>
              </span>
              <span class="input-right icon">
                <span class="cm-icon cm-icon-attachment m-r-8" aria-hidden="true"></span>
              </span>
            </div>
            <span v-if="inputError" class="small text-danger mt-1 d-block errorBlock">
              {{inputError}}
            </span>
          </div>
        </div>
      </div>
      <div class="col-2 col-md-1">
        <button type="submit" class="btn btn-cta-icon">
          <span class="cm-icon cm-icon-send" aria-hidden="true"></span>
        </button>
      </div>
    </div>
  </form>
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
      checkKeyEnter() {
        if(this.input.length != 0)
        {
          this.inputError = '';
        }
      },
      checkInput()
      {
        this.inputError = this.input.length == 0 ? 'Message can not be empty.' : ''
      },
      submit() {
        this.checkInput();
        if(this.inputError == '')
        {
          this.$emit('text', this.input);
          this.input = '';
          this.inputError = '';
        }
      }
    }
  };
</script>