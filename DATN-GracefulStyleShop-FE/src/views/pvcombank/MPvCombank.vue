<template>
    <div class="pv-main">
        <div class="pv-bank-header pv-flex">
            <div class="pv-bank-logo"></div>
            <div class="pv-bank-text">THANH TOÁN TRỰC TUYẾN</div>
        </div>
        <div class="pv-form-login">
            <div class="pv-form-header pv-flex">
                <div class="pv-form-icon"></div>
                <div class="pv-form-title">Đăng nhập</div>
            </div>
            <div action="" class="">
                <div class="pv-input-wrapper pv-flex">
                    <div class="pv-input-icon"><i class="fa-solid fa-user"></i></div>
                    <input type="text"  v-model="formAccount.AccountNumber" class="pv-input" placeholder="Tên đăng nhập">
                </div>
                <div class="pv-input-wrapper pv-flex">
                    <div class="pv-input-icon"><i class="fa-solid fa-lock"></i></div>
                    <input type="password"  v-model="formAccount.Password" class="pv-input" placeholder="Mật khẩu">
                </div>
                <button class="pv-form-button-login" @click="checkoutCredit">Thanh toán</button>
            </div>
        </div>
    </div>
</template>
<script>
    export default{
        name: "PvCombank",
        props:{
            modelValue : Object
        },
        data(){
            return {
                formAccount:{
                    AccountNumber: "",
                    Password :""
                }
            }
        },
        methods:{
            checkoutCredit() {
                this.$emit("submit:submitForm",this.formAccount);
            }
        }
    }
</script>
<style scoped>

.pv-flex{
    display: flex;
}
.pv-main{
    width: 100%;
}
.pv-bank-header{
    align-items: center;
    width: 750px;
    margin: 0 auto;
    padding-top: 30px;
}
.pv-bank-logo{
    background-image: url(../../assets/img/logo-viviet.png);
    width: 200px;
    height: 100px;
    background-size: contain;
    background-repeat: no-repeat;
}
.pv-bank-text{
    color: #2980b9;
    font-size: 40px;
    font-weight: bold;
}
.pv-form-login{
    width: 550px;
    height: 280px;
    margin: 30px auto;
    border-top: 5px solid #fed330;
    box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
    border-radius: 10px;
}
.m-pop-up__main{
    height: max-content !important;
}
.pv-form-header{
    margin: 20px 20px;
}
.pv-form-icon{
    width: 30px;
    height: 30px;
    border-radius: 50%;
    background-image: url(../../assets/img/group-icon-bluee.png);
    background-repeat: no-repeat;
    background-size: contain;
    border: 1px solid #2980b9;
    margin-right: 10px;
}
.pv-form-login{
    margin-top: 50px;
    text-align: center;
}
.pv-form-title{
    color: #2980b9;
    font-weight: bold;
    font-size: 26px;
}
.pv-input-wrapper{
    height:36px;
    border-radius: 4px;
    border: 1px solid #808080;
    margin: 20px 20px;
    align-items: center;
}
.pv-input-icon{
    padding: 0 8px;
    color: #808080;
}
.pv-input{
    border: none;
    outline: none;
    color: #808080;
    font-size: 15px;
}
.pv-form-button-login{
    background-color: #fed330;
    cursor: pointer;
    border: none;
    outline: none;
    height: 36px;
    width: 150px;
    border-radius: 20px;
    font-size: 15px;
    color: #576574;
    margin-top: 20px;
    font-weight: bold;
}
.pv-form-button-login:hover{
    background-color: #feca57;
}
</style>