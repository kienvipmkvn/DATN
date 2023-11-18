<template>
  <div class="form-submit">
    <div class="m__e-form" >
      <div class="form__col" style="width: 100%">
        <MInput
          textField="Mã thương hiệu"
          v-model="formData.BrandCode"
          :required="true"
          ref="BrandCode"
          name="BrandCode"
          :tabIndex="1"
          :errorMsg="errorMsgObject?.BrandCode"
          :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|20`]"
          @message-error-input="handleBindMessageInput"
        />
        <MInput
          textField="Tên thương hiệu"
          v-model="formData.BrandName"
          :required="true"
          name="BrandName"
          ref="BrandName"
          :tabIndex="2"
          :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|100`]"
          :errorMsg="errorMsgObject?.BrandName"
          @message-error-input="handleBindMessageInput"
        />
        <MInput
          textField="Mô tả"
          v-model="formData.Description"
          name="Description"
          ref="Description"
          :tabIndex="2"
          :rules="[`${rules.MAX_LENGTH}|255`]"
          :errorMsg="errorMsgObject?.Description"
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
  name: "FormBrand",
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
