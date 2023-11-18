<template>
  <main-layout />
</template>

<script>
import cartApi from './api/cartApi.js';
import MainLayout from './layout/MainLayout.vue';

export default {
  name: 'App',
  created : async function(){
    this.$state.getUser();
    if(this.$state.user){
      const cartNumber = await new cartApi("Cart").cartNumber();
      this.$state.cartNumber = cartNumber?.data == 0 ? 0 : cartNumber;
    }
  },
  components: {
    MainLayout,
  }
}
</script>

<style>
@import url(./assets/css/index.css);
</style>
