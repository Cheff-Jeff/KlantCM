<script setup>
import MessageAlert from './MessageAlert.vue';
defineProps({
    active: {
        type:Boolean,
        required:true,
    },
    messagealert: {
        type:Boolean,
        required:true,
    },

});
</script>
<script>
 export default{
    mounted(){
        
    }
}
</script>

<template>

    <button 
    v-if="active == true"
    type="button" 
    class="btn btn-primary"
    >active chat 
    </button>

    <button 
    v-if="active == false"
    type="button" 
    class="btn btn-outline-primary"
    >chat
    <MessageAlert :messagealert="messagealert" :key="messagealert"/>
    </button>
    
    <!-- <cm-button 
    v-if="active == true"
    data-label="active chat"
    data-button-style="ghost"
    data-button-size="medium"
    >
    </cm-button>

    <cm-button 
    v-else
    data-label="chat"
    data-button-style="primary"
    data-button-size="medium"
    >
    </cm-button> -->
</template>