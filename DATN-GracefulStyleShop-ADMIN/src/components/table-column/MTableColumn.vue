<template>
  <component
    :data-tip="dataTip"
    :is="tag"
    class="m__e-table-col"
    :class="className"
    @dblclick="this.$emit('dblclick')"
  >
  <div class="m__e-table-col-over"  :class="classStyle"
    :style="{ width: width ?width + 'px' : width  ,textAlign: textAlign,color:color,padding:padding}">
    <slot />
  </div>
  </component>
</template>
<script>
export default {
  name: "MTableColumn",
  props: {
    tag: {
      type: String,
      default: "td",
    },
    className: {
      type: String,
      default: "",
    },
    width: {
      type: Number,
    },
    dataTip: {
      type: String,
    },
    textCenter: {
      type: Boolean,
      default: false,
    },
    textAlign: {
      type: String,
      enum: ["left","right","center"],
      default: "left",
    },
    color:{
      type: String,
    },
    padding:String,
    classStyle : String
  },
};
</script>
<style scoped></style>
