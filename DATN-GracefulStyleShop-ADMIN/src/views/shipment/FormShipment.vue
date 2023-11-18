<template>
  <div class="form-submit">
    <div class="m__e-form">
      <MInput
        textField="Mã phương thức"
        v-model="formData.ShipmentCode"
        :required="true"
        ref="ShipmentCode"
        name="ShipmentCode"
        :tabIndex="1"
        :errorMsg="errorMsgObject?.ShipmentCode"
        :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|20`]"
        @message-error-input="handleBindMessageInput"
      />
      <MInput
        textField="Tên phương thức"
        v-model="formData.Method"
        :required="true"
        name="Method"
        ref="Method"
        :tabIndex="2"
        :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|100`]"
        :errorMsg="errorMsgObject?.Method"
        @message-error-input="handleBindMessageInput"
      />
      <div class="form__row" style="width: 100%">
          <div class="form__row f-bw" style="width: 48%">
            <MInput textField="Nhận hàng sau khoảng từ - đến (ngày):" 
            v-model="formData.DateFrom" 
            :required="true" 
            ref="DateFrom" 
            name="DateFrom"
            type="number" 
            placeholder="Từ"
            :tabIndex="3" dis 
            :errorMsg="errorMsgObject?.DateFrom" 
            :rules="[rules.NOT_EMPTY]"
              @message-error-input="handleBindMessageInput" />
          </div>
          <div class="form__row f-bw" style="width: 48%">
            <MInput textField="   " 
            v-model="formData.DateTo" 
            :required="true" 
            name="DateTo" 
            ref="DateTo"
            type="number"
            placeholder="Đến" 
            :tabIndex="4" 
            :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|100`]"
              :errorMsg="errorMsgObject?.DateTo" @message-error-input="handleBindMessageInput" />
          </div>
        </div>
        <MInput
          textField="Phí ship"
          v-model="formData.PriceShip"
          :required="true"
          name="PriceShip"
          ref="PriceShip"
          type="Number"
          :tabIndex="5"
          :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|50`]"
          :errorMsg="errorMsgObject?.PriceShip"
          @message-error-input="handleBindMessageInput"
        />
      </div>
    </div>
</template>

<script>
import MInput from "@/components/input/MInput.vue";
import resources from "@/assets/js/resource";
import mixinForm from "@/mixins/mixinForm.js";
export default {
  name: "FormShipment",
  emits: ["update:modelValue"],
  components: {
    MInput,
  },
  mixins: [mixinForm],
  props: {
    modelValue: Object,
  },
  data() {
    return {
      isShow: true,
      rules: resources.FORM_RULES, // Rules validate
      formData: this.modelValue,
      errorMsgObject: {},
    };
  },
};
</script>
<style scoped>
.m-pop-up {
  min-width: 1500px !important;
}
</style>
