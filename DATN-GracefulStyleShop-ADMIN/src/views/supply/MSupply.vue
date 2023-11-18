<template>
    <div class="m-supply">
        <m-grid :data="_data" />
    </div>
</template>
<script>
import MGrid from '@/components/grid/MGrid.vue';
import SupplyConfig from "@/views/supply/SupplyConfig.js";
import mixinPage from "@/mixins/mixinPage.js";
export default {
    name:"MSupply",
    mixins:[mixinPage],
    components:{
        MGrid
    },
    data() {
        return {
            // eslint-disable-next-line vue/no-reserved-keys
            _data : new SupplyConfig()
        }
    },
}
</script>
<style scoped>
</style>