<template>
    <div class="m-color">
        <m-grid :data="_data" />
    </div>
</template>
<script>
import MGrid from '@/components/grid/MGrid.vue';
import OrderConfig from "@/views/order/OrderConfig.js";
import mixinPage from "@/mixins/mixinPage.js";
export default {
    name:"MOrder",
    mixins:[mixinPage],
    components:{
        MGrid
    },
    data() {
        return {
            // eslint-disable-next-line vue/no-reserved-keys
            _data : new OrderConfig()
        }
    },
}
</script>
<style scoped>
</style>