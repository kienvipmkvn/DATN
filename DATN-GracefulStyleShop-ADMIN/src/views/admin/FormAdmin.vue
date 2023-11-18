<template>
  <div class="form-submit">
    <div class="m__e-form">
      <MInput
        textField="Tên quản trị viên"
        v-model="formData.FullName"
        :required="true"
        ref="FullName"
        name="FullName"
        :tabIndex="1"
        :errorMsg="errorMsgObject?.FullName"
        :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|100`]"
        @message-error-input="handleBindMessageInput"
      />

      <div class="form__row" style="width: 100%">
        <div class="form__row f-bw" style="width: 48%">
          <MInput
            textField="Email"
            v-model="formData.Email"
            :required="true"
            name="Email"
            ref="Email"
            :tabIndex="2"
            :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|100`]"
            :errorMsg="errorMsgObject?.Email"
            @message-error-input="handleBindMessageInput"
          />
        </div>
        <div class="form__row f-bw" style="width: 48%">
          <MInput
            textField="Số điện thoại"
            v-model="formData.Phone"
            :required="true"
            name="Phone"
            ref="Phone"
            type="Number"
            :tabIndex="4"
            :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|50`]"
            :errorMsg="errorMsgObject?.Phone"
            @message-error-input="handleBindMessageInput"
          />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import MInput from "@/components/input/MInput.vue";
import resources from "@/assets/js/resource";
import mixinForm from "@/mixins/mixinForm.js";
export default {
  name: "FormAdmin",
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
