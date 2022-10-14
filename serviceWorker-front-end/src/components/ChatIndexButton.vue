<script setup>
defineProps({
    active: {
        type:Boolean,
        required:true,
    }
});
</script>
<script>
 export default{
    mounted(){
    }
}
</script>

<template>
    
    <cm-button 
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
    </cm-button>
</template>