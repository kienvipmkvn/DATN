<template>
  <div class="form-submit">
    <div class="m__e-form" >
      <div class="form__col" style="width: 100%">
        <MInput
          textField="Mã kích cỡ"
          v-model="formData.SizeCode"
          :required="true"
          ref="SizeCode"
          name="SizeCode"
          :tabIndex="1"
          :errorMsg="errorMsgObject?.SizeCode"
          :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|20`]"
          @message-error-input="handleBindMessageInput"
        />
        <MInput
          textField="Số kích cỡ"
          v-model="formData.SizeNumber"
          :required="true"
          name="SizeNumber"
          ref="SizeNumber"
          :tabIndex="2"
          :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|100`]"
          :errorMsg="errorMsgObject?.SizeNumber"
          @message-error-input="handleBindMessageInput"
        />
      </div>
    </div>
  </div>
</template>

<script>
import MInput from "@/components/input/MInput.vue";
import resources from "@/assets/js/resource";
import mixinForm from "@/mixins/mixinForm.js";
export default {
  name: "FormSize",
  emits: ['update:modelValue'],
  components: {
    MInput,
  },
  mixins: [mixinForm],
  props:{
    modelValue : Object
  },
  data() {
    return {
      isShow: true,
      rules: resources.FORM_RULES, // Rules validate
      formData : this.modelValue,
      errorMsgObject : {}
    };
  },
  methods:{
  },
};
</script>
