import {reactive} from 'vue'

/**
 * các biến global
 */
const state = reactive({
  form : 0,
  titleForm : "",
  isSaveForm : false,
  nameTable: "",
  idModel : "",
  level : 0,
  parentName :"",
  parentPath  : "",
  isShowForm : false,
  isLoadding : false,
  mode:1, 
  /**
   * Mảng chứa các toast message
   */
  toastMessage: [],
  /**
   * Biến to nhỏ Sidebar
   */
  toggleSidebar : true,
  /**
   * Hàm hiển thị toast message
   */
  addToastMessage: function (me, msg) {
    me.$state.toastMessage.unshift(msg);
    if (this.timeout) clearTimeout(this.timeout);
    setTimeout(() => {
     me.$state.toastMessage.splice(me.$state.toastMessage.length-1, 1);
     clearTimeout();
   }, 4000);
  },
  setUser(user) {
    // const encodedUser = window.btoa(JSON.stringify(user));
    localStorage.setItem("user_admin", JSON.stringify(user));
    this.user = user;
  },
  getUser() {
    try {
      const encodedUser = localStorage.getItem("user_admin");
      if (encodedUser) {
        const user = JSON.parse(encodedUser);
        this.user = user;
      } else {
        localStorage.removeItem("token_admin");
      }
    } catch (error) {
      localStorage.removeItem("token_admin");
    }
  },
  isMask(){
    this.isLoadding = true;
  },
  unMask(){
    this.isLoadding = false;
  },
  formatPrice(price) {
    if (!price) return "";
    return new Intl.NumberFormat("vi-VN", {
      style: "currency",
      currency: "VND",
    }).format(price);
  },
});

export default {
  state
};
