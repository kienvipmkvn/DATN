<template>
  <div class="m-main">
    <TheSidebar ></TheSidebar>
    <div class="m-content">
      <TheHeader ></TheHeader>
      <div class="m-main-content">
          <router-view />
          <MFormDialog :isShow="$state.isShowForm" />
          <MLoadding :isLoadding="$state.isLoadding" />
      </div>
    </div>
  <MToastList  />
  </div>
</template>
<script>
import TheHeader from '@/components/header/TheHeader.vue'
import TheSidebar from '@/components/slidebar/TheSidebar.vue';
import MFormDialog from '@/components/form-dialog/MFormDialog.vue';
import MLoadding from '@/components/loadding/MLoadding.vue';
export default {
  name: "MainLayout",
  components: {
    TheHeader,
    TheSidebar,
    MFormDialog,
    MLoadding
  },
  mounted(){
  }
};
</script>
<style scoped>
</style>
