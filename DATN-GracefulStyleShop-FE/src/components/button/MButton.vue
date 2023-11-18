<template>
  <button 
    class="m-btn"
    :tabindex="tabIndex"
    :name="name"
    :data-tip="dataTip"
    :ref="name"
    :style="{ 
        width: width, 
        height: height, 
        backgroundColor: backgroundColor,
        color : color ,
        padding: padding ,
        margin: margin,
        border : border
    }"
    :class="{close : typeBtn === 'close',delete :  typeBtn === 'delete','disabled-btn' :disabled }"
    @click="onClick"
    >
    <slot />
  </button>
</template>
<script>
export default {
  name: "MButton",
  emits:["click"],
  props: {
    text: String,
    height: Number,
    width: Number,
    backgroundColor: String,
    color : String,
    padding : String,
    border: String,
    typeBtn: String,
    margin : String,
    disabled : Boolean,
    tabIndex : Number,
    name : String,
    dataTip:String,
  },methods:{
    /**
     * Hàm xử lý sự kiện click
     */ 
    onClick(event){
      this.$emit("click",event);
    },
    /**
     * Hàm xử lý sự kiện focus
     */ 
    onFocus() {
      this.$refs[this.name].focus();
    },
  }
};
</script>
<style scoped>

@import url(./button.css);
</style>
