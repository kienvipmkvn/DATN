<template>
  <input :disabled ="disabled" type="checkbox" name="" :id="id" class="m-input-checkbox" :checked="modelValue" />
  <label :for="id" class="m-checkbox-lable" @click="onClick()" ><span></span></label>
</template>
<script>
export default {
    name:"MCheckBox",
    emits:["update:modelValue"],
    data() {
      return {
      }
    },
    props: {
      id : String,
      modelValue : Boolean,
      disabled : {
        type : Boolean,
        default : false
      }
    },
    /**
     * Truyền sự kiện chexbox
     */
    methods:{
      onClick(){
        console.log(13213);
        this.$emit("update:modelValue",!this.modelValue);
      }
    }
};
</script>
<style scoped>
@import url(./checkbox.css);
</style>
