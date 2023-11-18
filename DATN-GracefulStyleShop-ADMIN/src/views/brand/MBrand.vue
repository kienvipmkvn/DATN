<template>
    <div class="m-color">
        <m-grid :data="_data" />
    </div>
</template>
<script>
import MGrid from '@/components/grid/MGrid.vue';
import BrandConfig from "@/views/brand/BrandConfig.js";
import mixinPage from "@/mixins/mixinPage.js";
export default {
    name:"MBrand",
    mixins:[mixinPage],
    components:{
        MGrid
    },
    data() {
        return {
            // eslint-disable-next-line vue/no-reserved-keys
            _data : new BrandConfig()
        }
    },
}
</script>
<style scoped>
</style>