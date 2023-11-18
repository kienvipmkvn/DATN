<template>
  <div class="form-submit">
    <div class="m__e-form">
      <MInput
        textField="Mã nhà cung cấp"
        v-model="formData.SupplierCode"
        :required="true"
        ref="SupplierCode"
        name="SupplierCode"
        :tabIndex="1"
        :errorMsg="errorMsgObject?.SupplierCode"
        :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|20`]"
        @message-error-input="handleBindMessageInput"
      />

      <MInput
        textField="Tên nhà cung cấp"
        v-model="formData.SupplierName"
        :required="true"
        name="SupplierName"
        ref="SupplierName"
        :tabIndex="2"
        :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|100`]"
        :errorMsg="errorMsgObject?.SupplierName"
        @message-error-input="handleBindMessageInput"
      />
        <MInput
          textField="Số điện thoại"
          v-model="formData.Phone"
          :required="true"
          name="Phone"
          ref="Phone"
          type="Number"
          :tabIndex="3"
          :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|50`]"
          :errorMsg="errorMsgObject?.Phone"
          @message-error-input="handleBindMessageInput"
        />
        <MInput
          textField="Địa chỉ"
          v-model="formData.Address"
          name="Address"
          ref="Address"
          :tabIndex="4"
          :rules="[ `${rules.MAX_LENGTH}|255`]"
          :errorMsg="errorMsgObject?.Address"
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
  name: "FormSupplier",
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
