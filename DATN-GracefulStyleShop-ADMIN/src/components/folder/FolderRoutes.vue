<template>
  <div class="folder-routes">
     <router-link
      :to="`${item.path}`"
      v-for="(item, index) in folderRoutesTest"
      :key="index"
      :style="{
        color: routesNow(index) ? 'var(--color-text-grey)' : 'black',
      }"
        >
    <span
      >{{item.name}}{{!routesNow(index) ? " / " : ""}}</span
    >
    </router-link>
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
  created(){
    if(this.$state.parentName){
      this.folderRoutesTest.push({
        name : "Trở lại",
        path : this.$state.parentPath
      });
    }
  },
  data() {
    return {
        folderRoutesTest : []
    }
  },
  methods:{
    routesNow(index){
        return index === this.folderRoutesTest.length - 1;
    }
  }
};
</script>
<style scoped>
.folder-routes {
  color: rgb(55, 55, 55);
  font-size: 13px;
}
.folder-routes span{
  font-weight: bold;
  text-decoration: none;
  color: rgb(96, 95, 95);
}
</style>
