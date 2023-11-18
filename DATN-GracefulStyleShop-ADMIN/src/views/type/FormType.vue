<template>
  <div class="form-submit">
    <div class="m__e-form" >
      <div class="form__col" style="width: 100%">
        <MInput
          textField="Mã thể loại"
          v-model="formData.TypeCode"
          :required="true"
          ref="TypeCode"
          name="TypeCode"
          :tabIndex="1"
          :errorMsg="errorMsgObject?.TypeCode"
          :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|20`]"
          @message-error-input="handleBindMessageInput"
        />
        <MInput
          textField="Tên thể loại"
          v-model="formData.TypeName"
          :required="true"
          name="TypeName"
          ref="TypeName"
          :tabIndex="2"
          :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|100`]"
          :errorMsg="errorMsgObject?.TypeName"
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
  name: "FormType",
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
