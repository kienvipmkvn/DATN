<template>
  <div class="m-input-custom" :style="{marginTop : marginTop }"> 
    <label :for="id" class="m-i-lable" :class="classLable">{{textField}}</label>
    <input
      type="text"
      :id="id"
      class="m-input"
      @input="onInput"
      @focus="onFocus"
      @blur="onBlur"
      :value="modelValue"
    />
  </div>
</template>
<script>
export default {
  name: "MInputCustom",
  props: {
    modelValue: String,
    textField: String,
    marginTop: String,
    id:String,
  },
  data() {
    return {
      classLable: "lable-default",
    };
  },
  methods: {
    onFocus(e) {
      this.$emit("focus", e);
      this.classLable = "lable-small"
    },
    onBlur(e) {
      this.$emit("blur", e);
      console.log("this.modelValue",this.modelValue);
      console.log(this.modelValue != "" && this.modelValue != undefined );
      this.classLable = this.modelValue != ""
        ? "lable-small"
        : "lable-default";
    },
    onInput(e) {
      console.log("onInput", e.target.value);
      this.$emit("update:modelValue", e.target.value);
    },
  },
};
</script>
<style scoped>
.m-input-custom {
  height: var(--height-default);
  padding: 4px 12px;
  border: 1px solid #d0cdcd;
  position: relative;
}
.m-i-lable {
  position: absolute;
  top: 50%;
  left: 12px;
  transform: translateY(-50%);
  transition: 0.2s ease-in-out;
  cursor: auto;
  font-weight: 700;
  font-size: 13px !important;
  color: #677279;
}
.m-input {
  border: none;
  outline: none;
  width: 100%;
  margin-top: 15px;
  height: 14px;
  font-size: 12px;
  color: #677279;
}
.m-input:focus{
  border: unset !important;
  padding: unset;
}
.lable-small {
  font-size: 10px !important;
  margin-top: -8px;
}
.lable-default {
  font-size: unset;
  margin-top: unset;
}
</style>
