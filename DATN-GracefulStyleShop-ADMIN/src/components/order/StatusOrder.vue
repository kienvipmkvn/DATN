<template>
  <div
    :style="{
      width: width,
    }"
    class="m-input-component"
  >
    <div class="m-input-main">
      <input
        :ref="name"
        type="text"
        :tabindex="tabIndex"
        :readonly="true"
        class="m-input"
        v-model="textSelected"
        @input="onSearchItem"
        autocomplete="off"
        @keydown="inputOnKeyDown"
        @focus="inputFocus"
        @blur="inputBlur"
      />
      <div
        class="m-combobox-list"
        :style="{ marginTop: '-' + locationSize + 'px' }"
        v-if="isShowHideList"
        ref="listItemCombobox"
      >
        <li
          class="m-combobox-item"
          v-for="(item, index) in dataSearch"
          :key="index"
          :value="item[propValue]"
          :class="{
            active: index === indexItemSelected,
          }"
          @mousedown="itemSelected(item, index)"
        >
          <div style="display: flex">
             <div class="m-combobox-item-name" v-if="!isPaid || ( isPaid && item[propValue] != 6)">{{ item[propName] }}</div>
          </div>
        </li>
      </div>
    </div>
  </div>
</template>
<script>
import enumD from "@/assets/js/enum";
import orderApi from "@/api/orderApi";
import resources from '@/assets/js/resource';
export default {
  name: "StatusOrder",
  emits: ["update:modelValue", "message-error-input"],
  props: {
    propValue: String,
    propName: String,
    modelValue: [String, Number],
    textField: String,
    propCode: String,
    name: String,
    required: Boolean,
    isReadonly: Boolean,
    errorMsg: {
      type: String,
      default: "",
    },
    width: String,
    height: String,
    marginBottom: {
      type: String,
      default: "0",
    },
    locationList: {
      type: Number,
      default: 0,
    },
    rules: {
      type: Array,
      default: new Array(0),
    },
    tabIndex: Number,
    icon: {
      type: String,
      default: "icon-drop",
    },
    orderId: String,
    isPaid : Boolean
  },
  data() {
    return {
      isShowHideList: false, // Ẩn hiện list cbb
      textSelected: null, // Text hiển thị input
      dataSearch: [], // Data tìm kiếm
      indexItemSelected: null, // Vị trí được chọn
      // indexItemSelected: null, // Vị trí nhấn phím
      textItemSelected: null, // Text được chọn
      locationSize: 0, // Text được chọn
      data: [
        {
          Status: 1,
          Title: "Chờ xác nhận",
        },
        {
          Status: 2,
          Title: "Xác nhận",
        },
        {
          Status: 3,
          Title: "Đang giao",
        },
        {
          Status: 4,
          Title: "Đã nhận hàng",
        },
        {
          Status: 5,
          Title: "Hoàn thành",
        },
        {
          Status: 6,
          Title: "Hủy",
        },
      ],
    };
  },
  created() {
    this.dataSearch = this.data;
    // Hiển thị mặc định
    this.setItemSelected();
    // Xử lý nếu list hiện ở trên
    if (this.locationList == enumD.LoCATION_LIST_CBB.UP) {
      this.locationSize = 33.6 * this.data.length + 37;
    }
  },
  methods: {
    /**
     * Hàm ẩn hiện list combobox
     */
    onToggleList() {
      this.isShowHideList = true;
      if (!this.isShowHideList) this.textSelected = this.textItemSelected;
      this.dataSearch = this.data;
      if (this.textSelected) {
        this.indexItemSelected = this.dataSearch.findIndex(
          (x) =>
            x[this.propName].toLowerCase() == this.textSelected.toLowerCase()
        );
      }
    },
    /**
     * Hàm chọn item hiển thị lên input
     */
    async itemSelected(item, index) {
      const res = await new orderApi().updateStatus({
        Status: item[this.propValue],
        OrderId: this.orderId,
      });
       this.$state.addToastMessage(this,
            resources.vi.TOAST_MESSAGE.SUCCESS("Thay đổi trạng thái ")
          );
      if (res) {
        this.textSelected = item[this.propName];
        this.textItemSelected = item[this.propName];
        this.isShowHideList = false;
        this.$emit("update:modelValue", item[this.propValue]);
        this.indexItemSelected = index;
      }
    },
    /**
     * Hàm set item được chọn khi truyền vào
     */
    setItemSelected() {
      var item = this.data.find((x) => x[this.propValue] == this.modelValue);
      if (item) {
        this.textSelected = item[this.propName];
        this.textItemSelected = item[this.propName];
      }
    },
    /**
     * Hàm tìm kiếm tiem
     */
    onSearchItem() {
      this.dataSearch = this.data.filter((x) =>
        x[this.propName].toLowerCase().includes(this.textSelected.toLowerCase())
      );
      this.indexItemSelected = this.dataSearch.findIndex((x) =>
        x[this.propName].toLowerCase().includes(this.textItemSelected)
      );
      this.isShowHideList = true;
    },
    /**
     * Bắt sự kiện focus
     */
    inputFocus() {
      this.dataSearch = this.data;
      if(this.modelValue != 6 && this.modelValue != 5){
        this.isShowHideList = true;
      }
    },
    /**
     * Bắt sự kiện blur
     */
    inputBlur() {
      this.isShowHideList = false;
    },
    /**
     * Hàm xử lý bàn phím
     */
    async inputOnKeyDown(event) {
      switch (event.keyCode) {
        // Nhấn phím enter
        case enumD.KEY_CODE.ENTER:
          // check xem hover vào item nào chưa nếu rồi thì lưu item
          if (this.indexItemSelected !== null) {
            var me = this;
            this.dataSearch = this.data;
            var item = this.dataSearch[me.indexItemSelected];
            // this.indexItemSelected = this.dataSearch.findIndex(
            //   (x) => x[this.propValue] == item[me.propValue]
            // );
            await this.itemSelected(item, this.indexItemSelected);
            me.isShowHideList = false;
          }
          break;
        // Phím mũi tên lên
        case enumD.KEY_CODE.KEY_UP:
          // Hiển list nếu ẩn
          if (!this.isShowHideList) this.isShowHideList = true;
          else {
            // Nếu chưa hover thì hover vào phần tử cuối
            if (this.indexItemSelected === null) {
              this.indexItemSelected = this.dataSearch.length - 1; // nếu chưa tồn tại thì gán vào hover cuối
            } else if (this.indexItemSelected > 0) {
              // nếu đã tồn tại thì giảm đi 1
              this.indexItemSelected--;
            } else {
              this.indexItemSelected = this.dataSearch.length - 1; // Nếu hover đầu rồi thì xuống cuối
            }
          }
          break;
        case enumD.KEY_CODE.KEY_DOWN:
          // Phím mũi tên xuống
          if (!this.isShowHideList) this.isShowHideList = true;
          else {
            // Nếu chưa hover thì hover vào phần tử cuối
            if (this.indexItemSelected === null) {
              this.indexItemSelected = 0; // nếu chưa tồn tại thì gán vào hover đầu
            } else if (this.indexItemSelected < this.dataSearch.length - 1) {
              this.indexItemSelected++; // nếu đã tồn tại thì tăng lên 1
            } else {
              this.indexItemSelected = 0; // Nếu hover cuối rồi thì xuống 0
            }
          }
          break;
        default:
          break;
      }
    },
    /**
     * Hàm focus input
     */
    onFocus() {
      this.$refs[this.name].focus();
    },
  },
  watch: {
    /**
     * Phát hiện sự thay đổi của phòng ban
     */
    modelValue: function() {
      if (this.modelValue) {
        this.setItemSelected();
        this.dataSearch = this.data;
      } else {
        this.textSelected = "";
      }
    },
    data() {
      this.setItemSelected();
    },
    /**
     * Validate nếu text không tồn tại thì k hợp lệ
     */
    textSelected() {
      if (!this.textSelected) {
        this.$emit("update:modelValue", undefined);
      }
    },
  },
};
</script>

<style scoped>
.m-input-main {
  position: unset;
}
.m-combobox-list {
  width: 150px;
  top: unset !important;
}
.m-input{
  color: rgb(0, 0, 255) !important;
}
</style>
