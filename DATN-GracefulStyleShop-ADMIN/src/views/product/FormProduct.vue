<template>
  <div class="form-submit">
    <div class="m__e-form">
      <div class="form__row" style="width: 100%">
        <div class="form__row f-bw" style="width: 48%">
          <MInput textField="Mã sản phẩm" v-model="formData.ProductCode" :required="true" ref="ProductCode"
            name="ProductCode" :tabIndex="1" :errorMsg="errorMsgObject?.ProductCode"
            :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|20`]" @message-error-input="handleBindMessageInput" />
        </div>
        <div class="form__col" style="width: 48%">
          <MDatePicker textField="Ngày ra mắt" name="PublicDate" ref="PublicDate" :tabIndex="10"
            :rules="[rules.NOT_EMPTY, rules.ADULT]" v-model="formData.PublicDate"
            :errorMsg="errorMsgObjectInput?.PublicDate" @message-error-input="handleBindMessageInput" />
        </div>
      </div>
      <MInput textField="Tên sản phẩm" v-model="formData.ProductName" :required="true" name="ProductName"
        ref="ProductName" :tabIndex="2" :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|100`]"
        :errorMsg="errorMsgObject?.ProductName" @message-error-input="handleBindMessageInput" />
      <div class="form__col" style="width: 100%">
        <div class="form__row" style="width: 100%">
          <div class="form__row f-bw" style="width: 48%">
            <MInput textField="Giá bán" v-model="formData.PriceSale" :required="true" ref="PriceSale" name="PriceSale"
              type="number" :tabIndex="3" dis :errorMsg="errorMsgObject?.PriceSale" :rules="[rules.NOT_EMPTY]"
              @message-error-input="handleBindMessageInput" />
          </div>
          <div class="form__row f-bw" style="width: 48%">
            <MInput textField="Giảm giá %" v-model="formData.Discount" :required="true" name="Discount" ref="Discount"
              type="number" :tabIndex="4" :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|100`]"
              :maxNumber="100" :minNumber="0"
              :errorMsg="errorMsgObject?.Discount" @message-error-input="handleBindMessageInput" />
          </div>
        </div>
        <div class="form__row f-bw" style="width: 100%">
            <MInput textField="Giảm bán khi giảm"  v-model="priceDel" :required="true" name="priceDel" ref="priceDel"
              type="number" :tabIndex="4" :rules="[rules.NOT_EMPTY, `${rules.MAX_LENGTH}|100`]" 
              :isReadonly="true"
              :errorMsg="errorMsgObject?.Discount" @message-error-input="handleBindMessageInput" />
        </div>
        <div class="form__row" style="width: 100%">
          <div class="form__row f-bw" style="width: 48%">
            <MCombobox :data="listBrand" v-model="formData.BrandId" ref="BrandId" propName="BrandName" propValue="BrandId"
              propCode="BrandCode" :rules="[rules.NOT_EMPTY]" name="BrandId" textField="Thương hiệu" :tabIndex="5"
              :required="true" :errorMsg="errorMsgObjectInput?.BrandId" @message-error-input="handleBindMessageInput" />
          </div>
          <div class="form__col" style="width: 48%">
            <MCombobox :data="listType" v-model="formData.TypeId" ref="TypeId" propName="TypeName" propValue="TypeId"
              propCode="TypeCode" :rules="[rules.NOT_EMPTY]" name="TypeId" textField="Thể loại" :tabIndex="6"
              :required="true" :errorMsg="errorMsgObjectInput?.TypeId" @message-error-input="handleBindMessageInput" />
          </div>
        </div>
        <MUpload v-model="formData.FileModel" :dataImages="formData.Images" />
        <div class="m-t-20">
          <MTinyMCE v-model="formData.Description" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import MInput from "@/components/input/MInput.vue";
import resources from "@/assets/js/resource";
import mixinForm from "@/mixins/mixinForm.js";
import MTinyMCE from "@/components/TinyMCE/MTinyMCE.vue";
import MCombobox from "@/components/combobox/MCombobox.vue";
import baseApi from "@/api/baseApi";
import MDatePicker from "@/components/datepicker/MDatePicker.vue";
import MUpload from '@/components/upload/MUpload.vue';
export default {
  name: "FormColor",
  emits: ["update:modelValue"],
  components: {
    MInput,
    MTinyMCE,
    MCombobox,
    MDatePicker,
    MUpload
  },
  mixins: [mixinForm],
  created: async function () {
    this.listBrand = await this.getDataCombobox("Brand");
    this.listType = await this.getDataCombobox("Type");
  },
  props: {
    modelValue: Object,
  },
  data() {
    return {
      isShow: true,
      rules: resources.FORM_RULES, // Rules validate
      formData: this.modelValue,
      errorMsgObject: {},
      listBrand: [],
      listType: [],
      api: baseApi,
      priceDel : 0
    };
  },
  methods: {
    async getDataCombobox(tableName) {
      this.api = new baseApi(tableName);
      let res = await this.api.getByFilter({ pageSize: 100, numberPage: 1 });
      return res.Data;
    },
  },
  watch:{
    'modelValue.Discount': function(){
        this.priceDel = Math.floor(this.modelValue.PriceSale -  this.modelValue.PriceSale * (this.modelValue.Discount*0.01));
    },
    'modelValue.PriceSale': function(){
        this.priceDel = Math.floor(this.modelValue.PriceSale -  this.modelValue.PriceSale * (this.modelValue.Discount*0.01));
    }
  }
};
</script>
<style scoped>
.m-pop-up {
  min-width: 1500px !important;
}
</style>
