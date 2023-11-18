<template>
  <div>
    <div class="editor">
    <Editor
      v-model="output"
      :config="config"
      :api-key="key"
      :initial-value="modelValue"
      ref="ref"
    />
  </div>
  </div>
</template>

<script>
import Editor from '@tinymce/tinymce-vue'
export default {
  name: 'MTinyMCE',
  emits:["update:modelValue"],
  components:{
    Editor
  },
  props: {
    modelValue: {
      type: String,
      required: true,
    },
    value:String
  },
  created(){
    
  },
  data() {
    return {
      key: "72wrbxbd7bto5lo710sxfsfq8z9cfn5n70e3oenk7nbrcjmm",
      output : ""
    }
  },
  methods:{
  },
  watch:{
    output:function(){
      this.$emit("update:modelValue", this.output);
    },
    modelValue:function(){
      this.output = this.modelValue;
    }
  }
};
</script>