<template>
  <form action="#" @submit.prevent="submit">
    <div class="row">
      <div class="col-11">
        <div class="form-group">
          <div class="form-row">
            <div class="form-input-special">
              <input
                id="sendBox"
                type="text"
                class="form-control spacing-right-icons-2"
                autocomplete="off"
                placeholder="Start typing… "
                v-model="message"
              />
              <!-- <span class="input-left icon noHover">
                <span class="cm-icon cm-icon-comment noHover" aria-hidden="true"></span>
              </span> -->
              <span class="input-right icon" @click="toggleImgUpload">
                <span class="cm-icon cm-icon-attachment m-r-8" aria-hidden="true"></span>
              </span>
            </div>
            <span v-if="inputError" class="small text-danger mt-1 d-block errorBlock">
              {{inputError}}
            </span>
          </div>
        </div>
        <div class="upload-box" :class="boxWrapper">
          <svg class="close-cross" @click="toggleImgUpload" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512"><!--! Font Awesome Pro 6.2.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2022 Fonticons, Inc. --><path d="M175 175C184.4 165.7 199.6 165.7 208.1 175L255.1 222.1L303 175C312.4 165.7 327.6 165.7 336.1 175C346.3 184.4 346.3 199.6 336.1 208.1L289.9 255.1L336.1 303C346.3 312.4 346.3 327.6 336.1 336.1C327.6 346.3 312.4 346.3 303 336.1L255.1 289.9L208.1 336.1C199.6 346.3 184.4 346.3 175 336.1C165.7 327.6 165.7 312.4 175 303L222.1 255.1L175 208.1C165.7 199.6 165.7 184.4 175 175V175zM512 256C512 397.4 397.4 512 256 512C114.6 512 0 397.4 0 256C0 114.6 114.6 0 256 0C397.4 0 512 114.6 512 256zM256 48C141.1 48 48 141.1 48 256C48 370.9 141.1 464 256 464C370.9 464 464 370.9 464 256C464 141.1 370.9 48 256 48z"/></svg>
          <div class="box">
            <label for="file" :class="inputToggle">
              <span>
                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512">
                  <path d="M246.6 9.4c-12.5-12.5-32.8-12.5-45.3 0l-128 128c-12.5 12.5-12.5 32.8 0 45.3s32.8 12.5 45.3 0L192 109.3V320c0 17.7 14.3 32 32 32s32-14.3 32-32V109.3l73.4 73.4c12.5 12.5 32.8 12.5 45.3 0s12.5-32.8 0-45.3l-128-128zM64 352c0-17.7-14.3-32-32-32s-32 14.3-32 32v64c0 53 43 96 96 96H352c53 0 96-43 96-96V352c0-17.7-14.3-32-32-32s-32 14.3-32 32v64c0 17.7-14.3 32-32 32H96c-17.7 0-32-14.3-32-32V352z"/>
                </svg>
              </span>
              <span v-html="name" class="txt"></span>
              <span v-if="imgError" class="err">
                {{imgError}}
              </span>
              <cm-button
                data-label="Submit image"
                data-button-style="cta"
                data-button-size="medium"
                >
              </cm-button>
            </label>
            <input 
              type="file" 
              id="fileInput"
              @dragenter="toggleInput"
              @dragleave="toggleInput"
              @blur="toggleInput"
              @drop="toggleInput"
              @focus="toggleInput"
              @click="toggleInput"
              @change="checkImg"
            >
          </div>
        </div>
      </div>
      <div class="col-1">
        <button type="submit" class="btn btn-cta-icon">
          <span class="cm-icon cm-icon-send" aria-hidden="true"></span>
        </button>
      </div>
    </div>
  </form>
</template>

<script>
  import {
    validateDescription, errDescriptionEmp, errDescription, validateFile, errImage, errImageEmp
  } from '@/assets/javascript/validation'
  export default {
    data() {
      return{
        message: '',
        imgInput: '',
        imgType: '',
        name: 'Drag & drop <b style="display: block;">or browse</b>',
        inputError: '',
        imgError: '',
        boxWrapper: '',
        inputToggle: '',
      }
    },
    methods: {
      toggleImgUpload(){
        this.boxWrapper = this.boxWrapper == '' ? 'open' : ''
      },
      toggleInput(){
        this.inputToggle = this.inputToggle == ''? 'active' : ''
      },
      checkImg(e){
        this.imgInput = e.target.files[0] 
        this.name = e.target.files[0].name
        this.imgType = e.target.files[0].type.split('/')
        this.imgType = this.imgType[1]
        this.valitImg()
      },
      valitImg(){
        this.imgError = this.imgInput == '' ? errImageEmp() : (
          validateFile(this.imgType) ? '' : errImage()) 
      },
      checkKeyEnter() {
        if(this.message.length != 0)
        {
          this.inputError = '';
        }
      },
      checkInput()
      {
        this.inputError = this.message.length == 0 ? 'Message can not be empty.' : ''
      },
      submit() {
        console.log('ik perform')
        if(!this.boxWrapper)
        {
          this.checkInput();
          if(this.inputError == '')
          {
            this.$emit('text', this.message);
            this.message = '';
            this.inputError = '';
          } 
        }
        else
        {
          this.valitImg()
          if(this.imgError == '')
          {
            this.$emit('uploadFile',this.imgInput)
            this.toggleImgUpload()
          }
        }
      }
    }
  };
</script>

<style lang="scss" scoped>
  @import '@/assets/styles/components/input.scss';
</style>