<template>
  <div v-if="isShow" class="m-pup-up-main">
    <div
      class="m-pop-up w-700"
      :style="{ padding: padding, minWidth: minWidth }"
    >
      <div class="m__e-form-header">
        <div class="m__e-form-title">
          {{ $state.titleForm }}
        </div>
      </div>
      <div class="m-form-dialog">
        <FormColor
          v-if="$state.form == formNameEnum.color"
          :ref="$state.nameTable"
          v-model="model"
        />
        <FormSize
          v-if="$state.form == formNameEnum.size"
          :ref="$state.nameTable"
          v-model="model"
        />
        <FormBrand
          v-if="$state.form == formNameEnum.brand"
          :ref="$state.nameTable"
          v-model="model"
        />
        <FormType
          v-if="$state.form == formNameEnum.type"
          :ref="$state.nameTable"
          v-model="model"
        />
        <FormProduct
          v-if="$state.form == formNameEnum.product"
          :ref="$state.nameTable"
          v-model="model"
        />
        <FormSupplier
          v-if="$state.form == formNameEnum.supplier"
          :ref="$state.nameTable"
          v-model="model"
        />
        <FormProductVariant
          v-if="$state.form == formNameEnum.productvariant"
          :ref="$state.nameTable"
          v-model="model"
        />
        <FormShipment
          v-if="$state.form == formNameEnum.shipment"
          :ref="$state.nameTable"
          v-model="model"
        />
        <FormAdmin
          v-if="$state.form == formNameEnum.admin"
          :ref="$state.nameTable"
          v-model="model"
        />
      </div>
      <div class="m__e-form-footer-btn">
        <div class="m__e-form-btn__left">
          <MButton
            typeBtn="close"
            :tabIndex="20"
            name="EndForm"
            ref="EndForm"
            @click="closeForm"
            >Hủy</MButton
          >
        </div>
        <div class="m__e-form-btn__right">
          <MButton
            margin="0 16px 0 0"
            typeBtn="close"
            :tabIndex="18"
            @click="onSubmitFormItem(actionButtonForm.save)"
            dataTip="Lưu (Ctrl + S)"
            >Lưu</MButton
          >
          <MButton
            :tabIndex="19"
            @click="onSubmitFormItem(actionButtonForm.addAndSave)"
            dataTip="Lưu và thêm (Ctrl + Shift + S)"
            >Thêm và lưu</MButton
          >
        </div>
      </div>
      <div
        class="m-pop-up-close"
        :class="iconCloseClass"
        :data-tip-icon="dataTipIcon"
        @click="closePopUp"
      ></div>
    </div>
  </div>
</template>
<script>
import MButton from "../button/MButton.vue";
import FormColor from "@/views/color/FormColor.vue";
import FormSize from "@/views/size/FormSize.vue";
import enumD from "@/assets/js/enum";
import baseApi from "@/api/baseApi";
import fileApi from "@/api/fileApi";
import FormBrand from "@/views/brand/FormBrand.vue";
import FormProduct from "@/views/product/FormProduct.vue";
import FormProductVariant from "@/views/productvariant/FormProductVariant.vue";
import FormType from "@/views/type/FormType.vue";
import FormSupplier from "@/views/supplier/FormSupplier.vue";
import FormShipment from "@/views/shipment/FormShipment.vue";
import FormAdmin from "@/views/admin/FormAdmin.vue";
export default {
  name: "MFormPopup",
  components: {
    MButton,
    FormColor,
    FormSize,
    FormBrand,
    FormProduct,
    FormType,
    FormProductVariant,
    FormSupplier,
    FormShipment,
    FormAdmin,
  },
  props: {
    submitForm: String,
    formData: Object,
    isShow: Boolean,
  },
  created() {},
  data() {
    return {
      formNameEnum: enumD.formName,
      model: {},
      baseApi: new baseApi(this.$state.nameTable),
      actionButtonForm: enumD.enumActionButtonForm, // Chức năng button form
      FileModel : null
    };
  },
  methods: {
    async getInfo() {
      const res = await this.baseApi.getById(this.$state.idModel);
      this.model = res;
    },
    async onSubmitFormItem(method) {
      try {
        this.$state.isMask();
        // if (method) {
        //   console.log(method);
        // }
        if (!this.checkValidateFormSubmit()) {
          this.$state.unMask();
          return;
        }

        this.FileModel = this.model?.FileModel;
        delete this.model.FileModel;
        delete this.model.Images;

        // kiểm tra là thêm hay sửa
        var res = this.$state.idModel
          ? await this.baseApi.update(this.$state.idModel, this.model) // Gọi api Update
          : await this.baseApi.create(this.model); // Gọi api Create

        // Xử lý custom
        await this.insertOrUpdateCustom(res.Data.ProductId);

        this.model = {};
        this.$state.idModel = "";
        this.$state.isSaveForm = true;
        this.$state.unMask();
        if (method != enumD.enumActionButtonForm.addAndSave) {
          this.$state.isShowForm = false;
        }
        this.$state.unMask();
      } catch (error) {
        this.$state.unMask();
        console.log(error);
      }
    },
    /**
     * Hàm validate form true : không lỗi
     */
    checkValidateFormSubmit() {
      for (const property in this.$refs[this.$state.nameTable].$refs) {
        this.$refs[this.$state.nameTable].$refs[property]?.checkValidate();
      }
      for (const property in this.$refs[this.$state.nameTable].errorMsgObject) {
        if (this.$refs[this.$state.nameTable].errorMsgObject[property]) {
          this.$refs[this.$state.nameTable].$refs[property].onFocus();
          return false;
        }
      }
      return true;
    },
    closeForm() {
      this.$state.isShowForm = false;
      this.$state.idModel = "";
      this.model = {};
    },

    async insertOrUpdateCustom(id) {
      try {
        if (this.$state.form == this.formNameEnum.product) {
          let formData = new FormData();
          for (
            let index = 0;
            index < this.FileModel.files.length;
            index++
          ) {
            formData.append("Files", this.FileModel.files[index]);
          }
          for (let index = 0; index < this.FileModel.images.length; index++) {
            formData.append("Images[]", this.FileModel.images[index].ImageId);
          }

          formData.append("ObjectId", id);
          const api = new fileApi();
          await api.insertImages(formData);
          this.model.Images = null;
        }
      } catch (error) {
        console.log(error);
      }
    },
  },
  watch: {
    "$state.isShowForm": async function () {
      if (this.$state.isShowForm) {
        if (this.$state.idModel) {
          await this.getInfo();
        }
      }
    },
    "$state.nameTable": function () {
      this.baseApi = new baseApi(this.$state.nameTable);
    },
  },
};
</script>
<style scoped>
.m-pop-up{
    background-color: white;
    position: relative;
    padding: 24px;
    border-radius: 4px;
    min-width: 800px;
    margin-bottom: 20px;
}
</style>