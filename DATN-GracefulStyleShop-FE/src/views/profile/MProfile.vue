<template>
    <div class="u-profile-user">
        <div class="profile-left">
            <div class="title">
                <img src="https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_960_720.png" alt="">
                <div class="title-profile">
                    {{$state.user.FullName}}
                </div>
            </div>
            <div class="profile-list-tab">
                <div class="profile-tab-item-1">
                    <div class="div" @click="changeTab(1)"><i class="fa-regular fa-user"></i>Tài khoản của tôi</div>
                </div>
                 <div class="profile-list-tab-2" :style="{height : false  ? '0px' : 'auto'}">
                        <div class="profile-tab-item-2" :class="{active :$state.tabProfile == 1 }" @click="changeTab(1)">Hồ sơ</div>
                        <div class="profile-tab-item-2" :class="{active :$state.tabProfile == 2 }" @click="changeTab(2)">Địa chỉ</div>
                    </div>
                <div class="profile-tab-item-1" :class="{active :$state.tabProfile == 3 }" @click="changeTab(3)"><i class="fa-regular fa-money-bill-1"></i>Đơn mua</div>
            </div>
        </div>
        <div class="profile-right">
            <m-info-user  :isShow="$state.tabProfile == 1 ? true : false" />
            <m-address-user   :isShow="$state.tabProfile == 2 ? true : false" />
            <m-order-profile  :isShow="$state.tabProfile == 3 ? true : false" />
        </div>
    </div>
</template>
<script>
import MAddressUser from './MAddressUser.vue'
import MInfoUser from './MInfoUser.vue'
import MOrderProfile from './MOrderProfile.vue'
export default {
    name:"MProfile",
    components:{
        MInfoUser,
        MAddressUser,
        MOrderProfile,
    },
    data() {
        return {
            tabInfoStyle : true,
        }
    },
    methods:{
        changeTab(tab){
            this.$state.tabProfile = tab;
        }
    }
}
</script>
<style>

@import url(./profile.css);
</style>