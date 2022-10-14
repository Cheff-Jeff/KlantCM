<script setup>
defineProps({
    active: {
        type:Boolean,
        required:false,
        default :false
    },
    index:{
        type:Number,
        required:true
    }
});
</script>
<script>
 export default{
    mounted(){
        console.log(this.active)
        console.log(this.index)
    }
}
</script>

<template>
    
    <cm-button 
    v-if="active"
    data-label={{index}}
    data-button-style="ghost"
    data-button-size="medium"
    >
    </cm-button>

    <cm-button 
    v-else
    data-label="chat {{index}}"
    data-button-style="primary"
    data-button-size="medium"
    >
    </cm-button><br>
</template>