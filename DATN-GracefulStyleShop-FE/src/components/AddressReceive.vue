<template>
  <m-pop-up :isShow="isShow" minWidth="600px">
    <template #header>
      <h4>Địa chỉ của bạn</h4>
      <hr />
    </template>
    <div class="address-receive-body">
      <div class="" v-if="formTab == 0">
        <div
          class="address-customer"
          v-for="(address, index) in listAddressReceive"
          :key="index"
        >
          <div class="radio-default">
            <m-radio-button
              :id="address.AddressReceiveId"
              v-model="address.IsDefault"
              @selected="selectDefault"
              nameInput="AddressReceive"
            />
          </div>
          <div class="body-address">
            <div class="i-f-address">
              {{ address.Receiver }}<span>{{ address.Phone }}</span>
            </div>
            <div class="i-f-address-detail">
              {{ address.AddressDetail }}
            </div>
            <div class="btn-default-address" v-if="address.IsDefault">
              mặc định
            </div>
          </div>
          <div
            class="i-f-address-update"
            @click="updateAddressReceive(address)"
          >
            Cập nhật
          </div>
        </div>
        
      </div>
      <div class="m__e-form" v-else-if="formTab == 1">
        <div class="form__row" style="width: 100%">
          <div class="form__row f-bw" style="width: 48%">
            <MInput
              textField="Họ và tên"
              v-model="formData.Receiver"
              :required="true"
              ref="Receiver"
              name="Receiver"
              :tabIndex="1"
              :errorMsg="errorMsgObject?.Receiver"
              :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|100`]"
              @message-error-input="handleBindMessageInput"
            />
          </div>
          <div class="form__col" style="width: 48%">
            <MInput
              textField="Số điện thoại"
              v-model="formData.Phone"
              :required="true"
              ref="Phone"
              name="Phone"
              :tabIndex="2"
              :errorMsg="errorMsgObject?.Phone"
              type="number"
              :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|20`]"
              @message-error-input="handleBindMessageInput"
            />
          </div>
        </div>
        <div class="form__row" style="width: 100%">
          <div class="form__row f-bw" style="width: 32%">
            <MCombobox
              :data="Provinces"
              v-model="ProvinceID"
              ref="ProvinceID"
              propName="RegionName"
              propValue="RegionID"
              :rules="[rules.NOT_EMPTY]"
              name="Provinces"
              textField="Tỉnh/Thành phố"
              :tabIndex="6"
              :required="true"
              :errorMsg="errorMsgObjectInput?.ProvinceID"
              @message-error-input="handleBindMessageInput"
            />
          </div>
          <div class="form__row f-bw" style="width: 32%">
            <MCombobox
              :data="Districts"
              v-model="DistrictID"
              ref="DistrictID"
              propName="RegionName"
              propValue="RegionID"
              :rules="[rules.NOT_EMPTY]"
              name="Districts"
              textField="Quận/Huyện"
              :tabIndex="6"
              :required="true"
              :errorMsg="errorMsgObjectInput?.DistrictID"
              @message-error-input="handleBindMessageInput"
            />
          </div>
          <div class="form__row f-bw" style="width: 32%">
            <MCombobox
              :data="Wards"
              v-model="WardID"
              ref="WardID"
              propName="RegionName"
              propValue="RegionID"
              :rules="[rules.NOT_EMPTY]"
              name="Wards"
              textField="Xã/Phường"
              :tabIndex="6"
              :required="true"
              :errorMsg="errorMsgObjectInput?.WardID"
              @message-error-input="handleBindMessageInput"
            />
          </div>
        </div>
        <div class="m-t-20"></div>
        <MInput
          textField="Địa chỉ cụ thể"
          v-model="formData.Address"
          :required="true"
          ref="Address"
          name="Address"
          :tabIndex="2"
          :errorMsg="errorMsgObject?.Address"
          :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|255`]"
          @message-error-input="handleBindMessageInput"
        />
      </div>
    </div>
    <template #footer>
      <hr />
      <div class="m-f-bw">
        <div @click="isPopUpDelete = false">
          <m-button typeBtn="close" v-if="formTab == 0" @click="closePopup"
            >Hủy</m-button
          >
          <m-button typeBtn="close" v-if="formTab == 1" @click="formTab = 0"
            >Trở lại</m-button
          >
        </div>
        <div>
          <m-button
            backgroundColor="var(--input-primary)"
            v-if="formTab == 0"
            @click="
            () => {
              (formTab = 1), (formData = {});
            }
          "
            >Thêm địa chỉ</m-button
          >
          <m-button
            backgroundColor="var(--input-primary)"
            v-if="formTab == 1"
            @click="addAddressReceice"
            >{{ getBtnMode }}</m-button
          >
        </div>
      </div>
    </template>
  </m-pop-up>
</template>
<script>
import MPopUp from "@/components/pop-up/MPopUp.vue";
import MButton from "@/components/button/MButton.vue";
import MRadioButton from "@/components/radio-button/MRadioButton.vue";
import MInput from "@/components/input/MInput.vue";
import MCombobox from "@/components/combobox/MCombobox.vue";
import regionApi from "@/api/regionApi";
import resources from "@/common/resource";
import mixinForm from "@/mixins/mixinForm.js";

import addressReceiveApi from "@/api/addressReceiveApi";
export default {
  name: "AddressReceive",
  components: {
    MPopUp,
    MButton,
    MRadioButton,
    MInput,
    MCombobox,
  },
  props: {
    modelValue: Object,
    isShow: Boolean,
  },
  created: async function () {
    await this.getLocaltionByParentId(234,"Provinces");
    await this.getListAddressReceive();
  },
  mixins: [mixinForm],
  data() {
    return {
      formData: {},
      rules: resources.FORM_RULES, // Rules validate
      formTab: 0, // 0 chọn dịa chỉ , 1 là thêm địa chỉ
      formMode: 0, // 0 insert , 1 update
      Provinces: [],
      Districts: [],
      Wards: [],
      ProvinceID: 0,
      DistrictID: 0,
      WardID: 0,
      api: new regionApi(),
      apiAddressReceiveApi: new addressReceiveApi(),
      listAddressReceive: [],
    };
  },
  computed: {
    getBtnMode() {
      return this.formMode == 0 ? " Thêm" : "Cập nhật";
    },
  },
  methods: {
    closePopup() {
      this.$emit("update:isShow", false);
    },
    async getListAddressReceive() {

      const data = await this.apiAddressReceiveApi.getByFilter({});
      this.listAddressReceive = data.Data;
      const addressDefault = this.listAddressReceive.find(
        (x) => x.IsDefault == true
      );
      this.apiAddressReceiveApi.setDefault({
        AddressReceiveId: addressDefault.AddressReceiveId,
        CustomerId: addressDefault.CustomerId,
      });
      this.$emit("update:modelValue", addressDefault);
    },
    getAddressDetail() {
      const ProvinceName = this.Provinces.find(
        (x) => x.RegionID == this.ProvinceID
      ).RegionName;
      const DistrictName = this.Districts.find(
        (x) => x.RegionID == this.DistrictID
      ).RegionName;
      const WardName = this.Wards.find(
        (x) => x.RegionID == this.WardID
      ).RegionName;
      var addressDetail =
        this.formData.Address +
        ", " +
        WardName +
        ", " +
        DistrictName +
        ", " +
        ProvinceName;
      return addressDetail;
    },
    async addAddressReceice() {
      try {
        if (!this.checkValidateFormSubmit) {
          return;
        }
        this.formData.AddressDetail = this.getAddressDetail();
        this.formData.CustomerId = "78a7263f-db45-11ed-8d99-00ffe749b949";
        this.formData.ProvinceID = this.ProvinceID;
        this.formData.WardID = this.WardID;
        this.formData.DistrictID = this.DistrictID;
        this.$state.isMask();
        this.formMode == 0
          ? await this.apiAddressReceiveApi.create(this.formData)
          : await this.apiAddressReceiveApi.update(this.formData);
        await this.getListAddressReceive();
        this.formTab = 0;
        this.formData = {};
        this.formMode = 0;
        this.unMask();
      } catch (error) {
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
    selectDefault(id) {
      this.listAddressReceive.forEach((x) => {
        x.IsDefault = false;
        if (x.AddressReceiveId == id) x.IsDefault = true;
      });
      const addressDefault = this.listAddressReceive.find(
        (x) => x.IsDefault == true
      );
      this.apiAddressReceiveApi.setDefault({
        AddressReceiveId: addressDefault.AddressReceiveId,
        CustomerId: addressDefault.CustomerId,
      });
      this.$emit("update:modelValue", addressDefault);
    },
    async updateAddressReceive(address) {
      this.formData = address;
      this.ProvinceID = address.ProvinceID;
      await this.getLocaltionByParentId(234,"Provinces");
      this.DistrictID = address.DistrictID;
      await this.getLocaltionByParentId(address.DistrictID,"Districts");
      this.WardID = address.WardID;
      await this.getLocaltionByParentId(address.WardID,"Wards");
      this.formTab = 1;
      this.formMode = 1;
    },
    async getLocaltionByParentId(id,localtionName){
      var data = await this.api.getRegionByParentId(id);
      if(localtionName == "Provinces"){
        this.Provinces = data ? data : [];
      }
      else if(localtionName == "Districts"){
        this.Districts = data ? data : [];
      }
      else{
        this.Wards = data ? data : [];
      }
    }
  },
  watch: {
    ProvinceID: async function () {
      this.DistrictID = 0;
      await this.getLocaltionByParentId(this.ProvinceID,"Districts");
    },
    DistrictID: async function () {
      this.WardID = 0;
      await this.getLocaltionByParentId(this.DistrictID,"Wards");
    },
  },
};
</script>
<style scoped>
.co-address {
  margin-top: 20px;
  background-color: white;
  padding: 20px;
}
.co-address h1 {
  display: flex;
  align-items: center;
  font-size: 1.125rem;
  color: #ee4d2d;
  margin-bottom: 20px;
  text-transform: capitalize;
  flex: 1 1 auto;
}
.co-info {
  display: flex;
  justify-content: space-between;
  align-items: center;
}
.co-st {
  flex-basis: 20%;
  font-weight: bold;
}
.co-address-detail {
  flex-basis: 70%;
  text-align: center;
}
.co-address-btn {
  flex-basis: 10%;
  text-align: right;
  font-weight: bold;
  cursor: pointer;
}
.m-pop-up__main {
  max-height: 200px !important;
}
.address-customer {
  display: flex;
  border-bottom: 1px solid #bcbaba;
  padding: 8px 8px 12px 0;
  position: relative;
}
.i-f-address {
  font-weight: 600;
  /* display: flex;
  justify-content: space-between;
  width: 100%; */
}
.body-address {
  max-width: 400px;
}
.i-f-address-update {
  position: absolute;
  left: 90%;
  top: 50%;
  width: max-content;
  padding: 2px 4px;
  border: 1px solid rgb(0, 245, 8);
  cursor: pointer;
  border-radius: 4px;
  font-size: 12px;
  color: rgb(0, 245, 8);
  transform: translate(-50%, -50%);
  cursor: pointer;
}
.i-f-address span {
  margin-left: 8px;
  padding-left: 8px;
  border-left: 1px solid #a7a4a4;
  font-weight: 400;
}
.acction-address {
  color: rgb(29, 76, 244);
}
.i-f-address-detail {
  padding: 8px 0;
}
.btn-default-address {
  padding: 4px 8px;
  border: 1px solid #d57373;
  width: max-content;
  font-size: 12px;
  color: red;
  border-radius: 4px;
}
.add-address {
  display: flex;
  align-items: center;
  padding: 4px 8px;
  border: 1px solid var(--input-primary);
  width: max-content;
  cursor: pointer;
  border-radius: 4px;
  justify-content: center;
  text-align: center;
  margin-top: 20px;
}
.add-address .icon-add {
  margin-right: 8px;
}
.address-receive-body {
  max-height: 400px;
  min-height: 400px;
  overflow: auto;
}
.radio-default {
  margin-right: 12px;
}
</style>
