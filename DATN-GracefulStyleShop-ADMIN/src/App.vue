<template>
  <MainLayout />
</template>
  
<script>
import MainLayout from './layout/MainLayout.vue'
export default {
  name: 'App',
  components: {
    MainLayout
  },
  created : async function(){
    this.$state.getUser();
  }
}
</script>
<style> 
@import url(./assets/css/index);
</style>

