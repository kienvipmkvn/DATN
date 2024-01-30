<template>
  <div class="m-upload" @dragover.prevent @drop="handleDropFile">
    <div class="m-upload-title">
      <label for="name" @dragover.prevent @drop="handleDropFile"
        >Chọn ảnh</label
      >
      <input
        type="file"
        style="display: none"
        id="name"
        ref="uploadFile"
        multiple
        @change="handleSelectFile"
      />
    </div>
    <div class="m-upload-list">
      <div class="m-upload-item" v-for="(image, index) in images" :key="index">
            <img
            :src="image.ImageLink"
            />
            <div class="m-upload-item-close" @click="closeImage(index)">
                <div class="icon-close"></div>
            </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "MUpload",
  props: {
    name: String,
    modelValue:Object,
    dataImages: Object,
  },
  components: {},
  created(){
    this.images = this.dataImages && this.dataImages[0] != null ? this.dataImages : [] ;
    this.files = Array(!this.dataImages?.length ? 0 : this.dataImages?.length).fill(false);
  },
  data() {
    return {
      files: [],
      images: [],
    };
  },
  methods: {
    /**
     * Lấy file khi khéo vào
     */
    async handleDropFile(event) {
      event.preventDefault();
      let files = event.dataTransfer;
      this.processFileSelect(files);
    },
    /**
     * Lấy file chọn input
     */
    async handleSelectFile(event) {
      const files = event.target.files;
      this.processFileSelect(files);
      this.$refs.uploadFile.value = null;
    },
    processFileSelect(files){
      for (let index = 0; index < files.length; index++) {
        let url = URL.createObjectURL(files[index]);
        this.images.push({
          ImageId : "",
          ImageLink: url,
          ImageName: files[index].name,
          local: true
        });
        this.files.push(files[index]);
      }
      this.updateModelValue();
    },
    updateModelValue(){
      const data = {
        files : this.files,
        images : this.images.filter(x => x.local !== true)
      }
      this.$emit("update:modelValue",data);
    },
    /**
     * Xóa ảnh
     */
    closeImage(index){
      this.files.splice(index, 1); 
      this.images.splice(index, 1); 
      this.updateModelValue();
    }
  },
  watch:{
    dataImages:function(){
      if(!this.images?.length > 0){
        this.images = this.dataImages && this.dataImages[0] != null ? this.dataImages : [] ;
      }
    }
  }
};
</script>
<style scoped>
.m-upload {
  margin: 20px 0;
  width: 100%;
  display: column;
  font-weight: bold;
  cursor: pointer;
}
.m-upload-title {
  cursor: pointer;
  height: var(--height-default);
  border-radius: 4px;
  border: 1px solid #c8c3c3;
  display: flex;
  justify-content: center;
  align-items: center;
}
.m-upload-list {
  max-width: 100%;
  overflow: hidden;
  display: flex;
}
.m-upload-item {
  width: 130px;
  height: 180px;
  padding: 4px;
  border: 1px solid #9d9b9b;
  margin: 4px 4px 2px 4px;
  position: relative;
}
.m-upload-item img{
    width: 100%;
    height: 150px !important;
}
.m-upload-item-close{
    background-color: white;
    height: 14px;
    width: 100%;
    display: flex;
    justify-content: center;
}
</style>
