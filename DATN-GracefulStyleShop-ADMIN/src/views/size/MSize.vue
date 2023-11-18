<template>
    <div class="m-color">
        <m-grid :data="_data" />
    </div>
</template>
<script>
import MGrid from '@/components/grid/MGrid.vue';
import SizeConfig from "@/views/size/SizeConfig.js";
import mixinPage from "@/mixins/mixinPage.js";
export default {
    name:"MSize",
    mixins:[mixinPage],
    components:{
        MGrid
    },
    data() {
        return {
            // eslint-disable-next-line vue/no-reserved-keys
            _data : new SizeConfig()
        }
    },
}
</script>
<style scoped>
</style>