<template>
  <div>
    <the-header />
      <div class="m-main-content" ref="content">
        <router-view />
      </div>
    <the-footer/>
  </div>
  <m-search v-if="$state.isSearch" />
  <MToastList  />
  <MLoadding :isLoadding="$state.isLoadding" />
</template>
<script>
import TheHeader from "@/components/TheHeader.vue";
import TheFooter from "@/components/TheFooter.vue";
import MToastList from "@/components/toast-list/MToastList.vue";
import MSearch from '@/components/search/MSearch.vue';
import MLoadding from '@/components/loadding/MLoadding.vue';
export default {
  name: "MainLayout",
  components: {
    TheHeader,
    TheFooter,
    MToastList,
    MSearch,
    MLoadding
  },
  data() {
    return {
      styleFooter: {}
    }
  },
};
</script>
<style></style>
