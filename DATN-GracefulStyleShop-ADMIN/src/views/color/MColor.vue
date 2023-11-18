<template>
    <div class="m-color">
        <m-grid :data="_data" />
    </div>
</template>
<script>
import MGrid from '@/components/grid/MGrid.vue';
import ColorConfig from "@/views/color/ColorConfig.js";
import mixinPage from "@/mixins/mixinPage.js";
export default {
    name:"MColor",
    mixins:[mixinPage],
    components:{
        MGrid
    },
    data() {
        return {
            // eslint-disable-next-line vue/no-reserved-keys
            _data : new ColorConfig()
        }
    },
}
</script>
<style scoped>
</style>