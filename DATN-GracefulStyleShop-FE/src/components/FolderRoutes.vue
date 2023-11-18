<template>
  <div class="folder-routes">
    <a
      :href="routesNow(index) ? undefied : item.url"
      v-for="(item, index) in folderRoutes"
      :key="index"
      :style="{
        color: routesNow(index) ? 'var(--color-text-grey)' : 'black',
      }"
      >{{item.title}}{{!routesNow(index) ? "" : ""}}</a
    >
  </div>
</template>

<script>
export default {
  name: "FolderRoutes",
  props: {
    folderRoutes: {
      type: Array,
    },
  },
  data() {
    return {
    }
  },
  methods:{
    routesNow(index){
        return index === this.folderRoutesTest?.length - 2;
    }
  }
};
</script>
<style scoped>
.folder-routes {
  color: rgb(55, 55, 55);
  font-size: 13px;
  margin: 8px 0;
  padding-top: 12px;
}
</style>
