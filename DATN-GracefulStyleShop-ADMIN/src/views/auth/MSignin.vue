<template>
  <div class="wrapbox-content-account">
    <div class="userbox customers_accountForm">
      <div class="header-page">
        <h1>Đăng nhập</h1>
      </div>
      <div class="create_customer">
        <div class="errors" v-if="errors">{{ errors }}</div>
         <m-input
              textField="Email"
              :required="true"
              name="Email"
              ref="Email"
              :rules="[rules.NOT_EMPTY,rules.HAS_FORMAT]"
              :errorMsg="errorMsgObject?.Email"
              @message-error-input="handleBindMessageInput"
              v-model="modelSignin.Email"
            />
        <m-input
          textField="Mật khẩu"
          :required="true"
          type="password"
          name="Password"
          ref="Password"
          :rules="[rules.NOT_EMPTY]"
          :errorMsg="errorMsgObject?.Password"
          @message-error-input="handleBindMessageInput"
          v-model="modelSignin.Password"
        />
        <div class="btn-register">
          <MButton @click="registerSubmit" width="20%">Đăng nhập</MButton>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import MInput from "@/components/input/MInput.vue";
import MButton from "@/components/button/MButton.vue";
import authApi from "@/api/authApi";
import mixinForm from "@/mixins/mixinForm";
import enumD from '@/assets/js/enum';
import resources from '@/assets/js/resource';
export default {
  components: {
    MInput,
    MButton,
  },
  mixins: [mixinForm],
  data() {
    return {
      msEnum: enumD,
      modelSignin: {
        Email: "",
        Password : "",
        RoleType : 0
      },
      errors: "",
      rules: resources.FORM_RULES, // Rules validate,
    };
  },
  methods: {
    async registerSubmit() {
      try {
        if (!this.checkValidateFormSubmit()) {
          return;
        }
        this.$state.isMask();
        const res = await new authApi().signin(this.modelSignin);
        if (!res.ErrorCode) {
          localStorage.setItem("token_admin", res.Data.Token);
          this.$state.setUser(res.Data.Admin);
          this.$router.push("/");
        }
        this.$state.unMask();
      } catch (error) {
        console.log(error);
        var res = error?.response?.data;
        // Kiểm tra lỗi validate
        if (res?.ErrorCode == enumD.ERROR_RESPONSE.BADREQUEST) {
          for (const key in res.MoreInfo) {
            this.errors = res.MoreInfo[key];
            break;
          }
        }
        this.$state.unMask();
      }
    },
    /**
     * Hàm validate form true : không lỗi
     */
    checkValidateFormSubmit() {
      for (const property in this.$refs) {
        this.$refs[property]?.checkValidate();
      }
      for (const property in this.errorMsgObject) {
        if (this.errorMsgObject[property]) {
          this.modelRegister[property].onFocus();
          return false;
        }
      }
      return true;
    },
  },
};
</script>
<style scoped>
.wrapbox-content-account{
  position: fixed;
  width: 100%;
  height: 100vh;
  left: 0;
  top: 0;
  background-color: rgb(234, 251, 234);
} 
.customers_accountForm {
  max-width: 558px;
  margin: 150px auto 50px;
  background: #ffffff;
  padding: 25px 30px 30px;
  border-radius: 4px;
}
.header-page h1 {
  position: relative;
  text-align: center;
  font-size: 25px;
  color: #000000;
  font-weight: 700;
  margin: 0px 0;
  line-height: initial;
  padding-bottom: 12px;
  margin-bottom: 12px;
}
.header-page h1::after {
  position: absolute;
  content: "";
  width: 20%;
  height: 2px;
  background-color: rgb(124, 247, 43);
  bottom: 0;
  left: 50%;
  transform: translateX(-50%);
}
.errors {
  margin-top: 16px !important;
  border-radius: 5px;
  padding: 12px 15px;
  font-size: 13px;
  color: #856404;
  margin: 5px 0 15px;
  font-weight: 500;
  background-color: #fff3cd;
  border: 1px solid #ffeeba;
}
.btn-register {
  display: flex;
  justify-content: center;
}
</style>
