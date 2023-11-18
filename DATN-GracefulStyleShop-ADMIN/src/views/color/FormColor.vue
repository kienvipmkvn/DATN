<template>
  <div class="form-submit">
    <div class="m__e-form" >
      <div class="form__col" style="width: 100%">
        <MInput
          textField="Mã màu"
          v-model="formData.ColorCode"
          ref="ColorCode"
          name="ColorCode"
          type="color"
          :tabIndex="1"
        />
        <MInput
          textField="Tên màu"
          v-model="formData.ColorName"
          :required="true"
          name="ColorName"
          ref="ColorName"
          :tabIndex="2"
          :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|100`]"
          :errorMsg="errorMsgObject?.ColorName"
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
  name: "FormColor",
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
