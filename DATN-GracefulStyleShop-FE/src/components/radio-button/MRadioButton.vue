<template>
  <div class="m-radio-base">
    <input
      type="radio"
      :id="id"
      :name="nameInput"
      :checked="modelValue"
      @change="onChange"
      class="m-radio-button"
      :tabindex="tabIndex"
    />
    <label
      :for="id"
      :style="{
        margin: margin,
      }"
      >{{ textField }}
    </label>
  </div>
</template>
<script>
export default {
  name: "MRadioButton",
  emits:["change"],
  props: {
    textField: String,
    margin: String,
    nameInput: String,
    id: String,
    checked: Boolean,
    tabIndex :Number,
    modelValue : Boolean
  },
  methods: {
    /**
     * Bắt sự kiện onChange
     */
    onChange() {
      console.log(this.id);
      this.$emit("selected",this.id);
    },
  },
};
</script>
<style scoped>
@import url(./radio.css);
</style>
