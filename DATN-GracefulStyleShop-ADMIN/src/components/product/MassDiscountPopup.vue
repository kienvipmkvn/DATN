<template>
  <div class="mass-discount" v-if="isShow">
    <div class="mass-discount-content">
    <h2>Giảm giá hàng loạt</h2>
      <div class="discount-header">
        <div class="mass-discount-number">
          <label for="mass-discount-number">Nhập % giảm giá : </label>
          <input
            type="number"
            id="mass-discount-number"
            v-model="disscountNumber"
            :min="0"
            :max="99"
          />
        </div>
        <div class="submit-mass-discount">
          <MButton @click="submitMassDiscount">Xác nhận</MButton>
        </div>
      </div>
      <div class="check-all-mass-discount">
        <MCheckBox
          id="check-all-mass"
          :checked="checkedAll"
          @checkboxSelected="checkboxSelectedAll"
        />
        <label for="check-all-mass">Chọn tất cả</label>
      </div>
      <div class="data-select">
        <div class="list-select-mass">
          <h3>Thể loại</h3>
          <div
            class="list-select-item"
            v-for="(type, index) in types"
            :key="index"
          >
            <MCheckBox
              :id="type.TypeId"
              :checked="typeSelected.includes(type.TypeId)"
              @checkboxSelected="checkboxSelectedType"
            />
            <div class="item-name">{{ type.TypeName }}</div>
          </div>
        </div>
        <div class="list-select-mass">
          <h3>Thương hiệu</h3>
          <div
            class="list-select-item"
            v-for="(brand, index) in brands"
            :key="index"
          >
            <MCheckBox
              :id="brand.BrandId"
              :checked="brandSelected.includes(brand.BrandId)"
              @checkboxSelected="checkboxSelectedBrand"
            />
            <div class="item-name">{{ brand.BrandName }}</div>
          </div>
        </div>
      </div>
      <div class="discount-footer" >
        <m-button typeBtn="delete" @click="$emit('close')">Hủy</m-button>
      </div>
    </div>
  </div>
</template>
<script>
import baseApi from "@/api/baseApi";
import MButton from "../button/MButton.vue";
import MCheckBox from "../checkbox/MCheckBox.vue";
import productApi from "@/api/productApi";
import resources from '@/assets/js/resource';
export default {
  props: {
    isShow: Boolean,
  },
  created: async function () {
    let res = await new baseApi("Brand").getByFilter({ PageSize: 100 });
    this.brands = res.Data;
    res = await new baseApi("Type").getByFilter({ PageSize: 100 });
    this.types = res.Data;

    res = await new productApi().GetMassDiscount();
    this.typeSelected = res.Types;
    this.brandSelected = res.Brands;
  },
  components: {
    MButton,
    MCheckBox,
  },
  data() {
    return {
      brands: [],
      types: [],
      brandSelected: [],
      typeSelected: [],
      checkedAll: false,
      disscountNumber: 0,
    };
  },
  methods: {
    checkboxSelectedType(isChecked, id) {
      try {
        // Kiểm tra các item check
        if (!isChecked) {
          this.typeSelected = this.typeSelected.filter((x) => x !== id);
        } else {
          this.typeSelected.push(id);
        }
        this.testCheckAll();
      } catch (error) {
        console.log(error);
      }
    },
    checkboxSelectedBrand(isChecked, id) {
      try {
        // Kiểm tra các item check
        if (!isChecked) {
          this.brandSelected = this.brandSelected.filter((x) => x !== id);
        } else {
          this.brandSelected.push(id);
        }
        this.testCheckAll();
      } catch (error) {
        console.log(error);
      }
    },
    checkboxSelectedAll(isChecked) {
      if (isChecked) {
        this.brandSelected = this.brands.map((item) => item.BrandId);
        this.typeSelected = this.types.map((item) => item.TypeId);
        this.checkedAll = true;
      } else {
        this.brandSelected = [];
        this.typeSelected = [];
        this.checkedAll = false;
      }
    },
    testCheckAll() {
      // Kiểm tra để check
      if (
        this.brandSelected.length == this.brands.length &&
        this.typeSelected.length == this.types.length
      ) {
        this.checkedAll = true;
      } else {
        this.checkedAll = false;
      }
    },
    async submitMassDiscount() {
      try {
         this.$state.isMask();
        const res = await new productApi().MassDiscount({
          Brands: this.brandSelected,
          Types: this.typeSelected,
          DiscountNumber : this.disscountNumber
        });
        if (res) {
          this.$emit("close");
          this.$state.unMask();
           this.$state.addToastMessage(this,
            resources.vi.TOAST_MESSAGE.SUCCESS("Giảm giá hàng loạt ")
          );
        }
      } catch (error) {
        this.$state.unMask();
        console.log(error);
        this.$state.addToastMessage(this,
            resources.vi.TOAST_MESSAGE.SUCCESS("Lỗi vui lòng thử lại.")
          );
      }
    },
  },
};
</script>
<style scoped>
.mass-discount {
  width: 100%;
  height: 100vh;
  background-color: #c6c2c26d;
  position: fixed;
  top: 0;
  left: 0;
  z-index: 999999;
}
.mass-discount-content {
  position: absolute;
  top: 50%;
  left: 50%;
  width: 700px;
  background-color: white;
  transform: translate(-50%, -50%);
  height: max-content;
  padding: 24px;
  border-radius: 4px;
}
.mass-discount-content h2{
    margin-bottom: 12px;
}
.discount-header {
  display: flex;
  margin-bottom: 12px;
  justify-content: space-between;
  align-items: center;
  border-bottom: 1px solid #919090;
  padding-bottom: 12px;
}

.mass-discount-number input {
  height: 34px;
  outline: none;
  width: 100px;
  padding: 0 8px;
  margin-left: 4px;
}
.submit-mass-discount {
  display: flex;
  justify-content: flex-end;
}
.check-all-mass-discount {
  display: flex;
  font-weight: bold;
  margin-bottom: 12px;
}
.check-all-mass-discount label {
  margin-left: 8px;
}
.data-select {
  display: flex;
    max-height: 480px;
  overflow: auto;
}
.list-select-mass {
  flex: 1;
}
.list-select-item {
  display: flex;
  padding: 12px 0;
}
.list-select-item .item-name {
  margin-left: 8px;
  font-weight: 500;
  font-style: italic;
}
.discount-footer{
    margin-top: 24px;
    display: flex;
    justify-content: center;
}
</style>
