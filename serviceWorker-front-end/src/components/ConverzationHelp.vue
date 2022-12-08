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
      type : Boolean,
      required:false,
      default:false
    }
  });
</script>

<template>
  <div class="row">
    <cm-conversation-bubble v-if="img">
      <img />
      <div class="time">{{ Time }}</div>
  </cm-conversation-bubble>
      <cm-conversation-bubble v-else>
          {{ Text }}
          <div class="time">{{ Time }}</div>
      </cm-conversation-bubble>
      <div>
        <span class="cm-icon cm-icon-user-fill" aria-hidden="true"></span>
      </div>
  </div>
</template>

<script>
export default{
  mounted(){
    const file = localStorage.getItem('img')
    let elList = document.getElementsByTagName('img')
    setTimeout(()=>{elList[elList.length- 1].src= file},2000)
  }
}
</script>