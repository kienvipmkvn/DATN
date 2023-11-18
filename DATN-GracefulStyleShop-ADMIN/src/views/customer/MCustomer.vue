<template>
    <div class="m-customer">
        <m-grid :data="_data" />
    </div>
</template>
<script>
import MGrid from '@/components/grid/MGrid.vue';
import CustomerConfig from "@/views/customer/CustomerConfig.js";
import mixinPage from "@/mixins/mixinPage.js";
export default {
    name:"MCustomer",
    mixins:[mixinPage],
    components:{
        MGrid
    },
    data() {
        return {
            // eslint-disable-next-line vue/no-reserved-keys
            _data : new CustomerConfig()
        }
    },
}
</script>
<style scoped>
</style>