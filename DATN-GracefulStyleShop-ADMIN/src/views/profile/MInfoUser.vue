<template>
  <div class="my-profile" >
    <h5>Hồ sơ của tôi</h5>
    <div class="zptdmA">Quản lý thông tin hồ sơ để bảo mật tài khoản</div>
    <hr class="hr" />
    <div class="profile-body">
      <div class="form-profile">
        <MInputV2 v-model="user.FullName" textField="Họ và tên :" :absoluteLeftInput="120"/>
        <MInputV2 v-model="user.Email" textField="Email :" :absoluteLeftInput="120" isReadonly />
        <MInputV2  v-model="user.Phone" textField="Số điện thoại :" :absoluteLeftInput="120" />
        <div class="my-profile-save">
          <m-button @click="updateUser">Lưu</m-button>
        </div>
      </div>
      <div class="profile-avt">
        <div class="avt">
          <img
            src="https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_960_720.png"
            alt=""
          />
        </div>
        <button>Chọn ảnh</button>
        <div class="suggest">
          Dụng lượng file tối đa 1 MB Định dạng:.JPEG, .PNG
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import MButton from "@/components/button/MButton.vue";
import MInputV2 from '@/components/input/MInputV2.vue';
import baseApi from '@/api/baseApi';
import resources from '@/assets/js/resource';
export default {
  name: "MInfoUser",
  components: {
    MButton,
    MInputV2
  },
  props:{
    hidden : Boolean,
  },
  data() {
    const user = {
      FullName : this.$state.user.FullName,
      Phone : this.$state.user.Phone,
      Email : this.$state.user.Email,
    }
    return {
      user:user
    }
  },
  methods:{
    async updateUser(){
      try {
        const res = await new baseApi("Admin").update(this.$state.user.CustomerId,this.user);
        if(res.Data){
          this.$state.setUser(res.Data);
          this.$state.toastMessage.unshift(
            resources.vi.TOAST_MESSAGE.SUCCESS("Sửa thông tin")
          );
        }
      } catch (error) {
        this.$state.toastMessage.unshift(
          resources.vi.TOAST_MESSAGE.ERROR("Có lỗi vui lòng thử lại!")
        );
      }
    }
  }
};
</script>
<style scoped>
.my-profile {
  padding: 24px;
  background-color: white;
}
.my-profile h5 {
  margin: 0;
  font-size: 1.125rem;
  font-weight: 500;
  line-height: 1.5rem;
  text-transform: capitalize;
  color: #333;
}
.hr{
  margin : 12px 0
}
.zptdmA {
  margin-top: 0.1875rem;
  font-size: 0.875rem;
  line-height: 1.0625rem;
  color: #555;
}
.profile-body {
  display: flex;
  margin-top: 24px;
}
.form-profile {
  position: relative;
  flex-basis: 75%;
}
.control-input {
  margin-top: 16px;
}
.control-input input {
  position: absolute;
  left: 120px;
  background: none;
  outline: none;
  border: 0;
  flex: 1;
  flex-shrink: 0;
  filter: none;
}
.control-input label {
  text-align: right;
  color: rgba(85, 85, 85, 0.8);
  overflow: hidden;

  padding-bottom: 15px;
  white-space: nowrap;
}
.profile-avt {
  flex-basis: 25%;
  padding: 0 0 0 24px;
  text-align: center;
  border-left: 1px solid #bcbbbb;
}
.profile-avt .avt img {
  width: 100px;
  height: 100px;
  border-radius: 50%;
  cursor: pointer;
}
.profile-avt button {
  outline: 0;
  background: #fff;
  color: #555;
  border: 1px solid rgba(0, 0, 0, 0.09);
  box-shadow: 0 1px 1px 0 rgba(0, 0, 0, 0.03);
  position: relative;
  overflow: visible;
  height: 40px;
  padding: 0 20px;
  min-width: 70px;
  max-width: 220px;
  margin: 12px 0;
}
.profile-avt .suggest {
  color: #999;
  font-size: 0.875rem;
  line-height: 1.25rem;
}
.my-profile-save {
  margin-left: 120px;
  margin-top: 12px;
}
</style>
