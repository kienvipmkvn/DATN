<template>
  <div
    :style="{ marginBottom: errorMsg ? '32px' : marginBottom ? marginBottom :'24px', width: width,display:'flex' }"
    class="m-input-component "
    :class="{ error: errorMsg }"
  >
    <label for="m-input" class="m-lable"
      >{{ textField
      }}<span>{{ required && textField ? " *" : "" }}</span></label
    >
    <div
      :style="{
        height: height,
        marginTop: !textField ? '' : marginTopInput,
        left : absoluteLeftInput ? absoluteLeftInput + 'px': '120px'
      }"
      class="m-input-main" 
    >
      <input
        class="m-input"
        :type="type"
        id="m-input"
        :ref="name"
        :placeholder="placeholder"
        :value="modelValue"
        :style="{
          paddingRight: paddingRight,
        }"
        :readonly="isReadonly"
        @input="changeValue($event)"
        :name="name"
        :tabindex="tabIndex"
      />
        <!-- autocomplete="off" -->
      <p class="m-input__error-msg">{{errorMsg}}</p>
      <div
        class="m-input-icon"
      >
        <div :class="classIcon" class="m-input-icon-rotate" ></div>
      </div>
    </div>
  </div>
</template>
<script>
import common from '@/common/common';

export default {
  name: "MInputV2",
  emits:["change-input","message-error-input","update:modelValue"],
  data() {
    return {
      valueInput: null,
    };
  },
  props: {
    textField: String,
    modelValue: String,
    type: String,
    width: String,
    height: String,
    marginBottom: {
      type:String,
      default : "24px"
    },
    placeholder: String,
    required: Boolean,
    classIcon: String,
    top: String,
    isReadonly: Boolean,
    originValue: {
      type: [String, Number]
    },
    name: {
      type: String,
      default: "",
    },
    errorMsg : {
      type : String,
      default : ""
    },
    rules: {
      type: Array,
      default : new Array(0)
    },
    tabIndex : Number,
    absoluteLeftInput: Number,
  },
  methods: {
    /**
     * Truyền sự kiển đổi value input
     */
    changeValue(event) {
      this.$emit("update:modelValue", event.target.value);
        this.$emit("message-error-input",this.name, "");
    },
    /**
     * Check vaidate theo rules truyen vao
     */
    checkValidate(){
      if(this.rules.length > 0){
        var msgErrorInput = common.inputValidation(this.rules,this.name,this.modelValue);
        this.$emit("message-error-input",this.name, msgErrorInput);
      }
    },
    /**
     * Focus input
     */
    onFocus() {
      this.$refs[this.name].focus();
    },
  },
  computed: {
    /**
     * căn trái
     */
    paddingRight() {
      return this.classIcon ? "36px" : "16px";
    },
    /**
     * Cách lable
     */
    marginTopInput() {
      return this.textField ? "5px" : "";
    },
  },
};
</script>

<style scoped>
@import url(./input.css);
.m-input-component{
  display:flex;
  align-items: center;
  position: relative;
}
.m-input-main{
  position: absolute;
}
</style>
