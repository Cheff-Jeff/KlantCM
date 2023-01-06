<script setup>

  defineProps({
    Time: {
      type: String,
      required: true,
      default: "00:00"
    },
    Text: {
      type: String,
      required: true,
      default: `Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum sed nibh commodo mauris volutpat
        aliquet. Pellentesque hendrerit sapien dolor, eu malesuada arcu interdum et. Phasellus tincidunt dapibus
        enim, ut sollicitudin augue consequat id. Fusce pharetra mi sed tortor condimentum dictum. Nam ullamcorper
        nisi quam, non viverra ipsum dictum a. Cras ligula ligula, hendrerit interdum porttitor ac, malesuada id
        lorem. Vivamus facilisis ornare suscipit. Donec eu felis bibendum, blandit mauris eget, porttitor massa.
        Pellentesque bibendum fermentum iaculis. Nunc vitae blandit dolor. Phasellus in ipsum ac massa volutpat
        rhoncus fermentum nec felis. Curabitur scelerisque nunc quis turpis blandit, vehicula efficitur nibh
        pellentesque. Nam odio neque, dictum sed purus ut, pulvinar bibendum purus. Nam vitae eleifend ex, a
        lobortis tellus.`
    },
    img: {
      type : File,
      required:false,
      default:false
    }
  });
</script>

<template>
  <div class="row me">
    <cm-conversation-bubble v-if="img">
      <img class="sendImg" :src="imageUrl"/>
      <div class="time">{{ Time }}</div>
  </cm-conversation-bubble>
      <cm-conversation-bubble v-else>
          {{ Text }}
          <div class="time">{{ Time }}</div>
      </cm-conversation-bubble>
      <div class="speek-icon-wrap">
        <span>You</span>
        <span class="cm-icon cm-icon-user-fill" aria-hidden="true"></span>
      </div>
  </div>
</template>

<script>
export default{
  data() {
    return {
      imageUrl: null
    }
  },
  mounted(){
    if(this.img){
      this.imageUrl = URL.createObjectURL(this.img)
      console.log(this.imageUrl)
    }
  },
  unmounted(){
    URL.revokeObjectURL(this.imageUrl)
  }
}
</script>

<style lang="scss" scoped>
  @import '@/assets/styles/components/blueBubble.scss';
</style>