<template>
  <div class="wrapbox-content-account">
    <div class="userbox customers_accountForm">
      <div class="header-page">
        <h1>Tạo tài khoản</h1>
      </div>
      <div class="create_customer">
        <div class="errors" v-if="errors">{{ errors }}</div>
        <div class="form__row" style="width: 100%">
          <div class="form__row f-bw" style="width: 48%">
            <m-input
              textField="Họ"
              :required="true"
              ref="FirstName"
              name="FirstName"
              :rules="[rules.NOT_EMPTY]"
              :errorMsg="errorMsgObject?.FirstName"
              @message-error-input="handleBindMessageInput"
              v-model="modelRegister.FirstName"
            />
          </div>
          <div class="form__row f-bw" style="width: 48%">
            <m-input
              textField="Tên"
              :required="true"
              name="LastName"
              ref="LastName"
              :rules="[rules.NOT_EMPTY]"
              :errorMsg="errorMsgObject?.LastName"
              @message-error-input="handleBindMessageInput"
              v-model="modelRegister.LastName"
            />
          </div>
        </div>
        <div class="form__row" style="width: 100%">
          <div class="form__row f-bw" style="width: 48%">
            <m-input
              textField="Email"
              :required="true"
              name="Email"
              ref="Email"
              :rules="[rules.NOT_EMPTY,rules.HAS_FORMAT]"
              :errorMsg="errorMsgObject?.Email"
              @message-error-input="handleBindMessageInput"
              v-model="modelRegister.Email"
            />
          </div>
          <div class="form__row f-bw" style="width: 48%">
            <m-input
              textField="Số điện thoại"
              :required="true"
              name="Phone"
              ref="Phone"
              :rules="[rules.NOT_EMPTY,rules.HAS_FORMAT]"
              :errorMsg="errorMsgObject?.Phone"
              @message-error-input="handleBindMessageInput"
              v-model="modelRegister.Phone"
            />
          </div>
        </div>
        <m-input
          textField="Mật khẩu"
          :required="true"
          type="password"
          name="Password"
          ref="Password"
          :rules="[rules.NOT_EMPTY]"
          :errorMsg="errorMsgObject?.Password"
          @message-error-input="handleBindMessageInput"
          v-model="modelRegister.Password"
        />
        <m-input
          textField="Nhập lại mật khẩu"
          :required="true"
          type="password"
          ref="ComfirmPassword"
          name="ComfirmPassword"
          :rules="[rules.NOT_EMPTY]"
          :errorMsg="errorMsgObject?.ComfirmPassword"
          @message-error-input="handleBindMessageInput"
          v-model="modelRegister.ComfirmPassword"
        />
        <div class="btn-register">
          <MButton @click="registerSubmit" width="20%">Đăng ký</MButton>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import MInput from "@/components/input/MInput.vue";
import msEnum from "@/common/enum";
import resources from "@/common/resource";
import MButton from "@/components/button/MButton.vue";
import baseApi from "@/api/baseApi";
import mixinForm from "@/mixins/mixinForm";
export default {
  name: "MRegister",
  components: {
    MInput,
    MButton,
  },
  mixins: [mixinForm],
  data() {
    return {
      msEnum: msEnum,
      modelRegister: {},
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
        this.modelRegister.FullName = this.modelRegister.FirstName.trim() + " " + this.modelRegister.LastName.trim();
        const res = await new baseApi("Customer").create(this.modelRegister);
        if(!res.ErrorCode){
          localStorage.setItem('token', res.Data.Token);
          this.$state.setUser(res.Data.Customer);
          this.$router.push("/");
        }
        this.$state.unMask();
      } catch (error) {
        console.log(error);
        var res = error?.response?.data;
        // Kiểm tra lỗi validate
        if (res?.ErrorCode == msEnum.ERROR_RESPONSE.BADREQUEST) {
          for (const key in res.MoreInfo) {
            this.errorMsgObject[key] = res.MoreInfo[key];
            this.errorMessage = res.MoreInfo[key];
            this.firstInputNameError = key;
            this.errorMsgObjectInput = this.errorMsgObject;
            return;
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
      if (this.modelRegister.Password != this.modelRegister.ComfirmPassword) {
        this.$refs.Password.onFocus();
        this.errorMsgObject.Password = "Mật khẩu không trùng khớp";
        this.errorMsgObject.ComfirmPassword = "Mật khẩu không trùng khớp";
        return false;
      }
      return true;
    },
  },
};
</script>
<style scoped>
.customers_accountForm {
  max-width: 620px;
  margin: 35px auto 50px;
  background: #ffffff;
  padding: 25px 30px 30px;
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
