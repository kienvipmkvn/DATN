import Thehome from "@/views/home/TheHome.vue";
import ProductDetail from "@/views/product/ProductDetail.vue";
import MProducts from "@/views/product/MProducts.vue";
import TheCart from "@/views/TheCart.vue";
import MRegister from "@/views/account/MRegister";
import MCheckout from "@/views/checkout/MCheckout.vue";
import MProfile from "@/views/profile/MProfile.vue";

/**
 * Các routes của page
 */
const routes = [
  {
    path: "",
    component:Thehome,
 },
 {
  path: "/products/:id",
    component:ProductDetail,
 },
 {
   path: "/products",
     component:MProducts,
  },
 {
  path: "/cart",
    component:TheCart,
 },
 {
 path: "/account/register",
    component:MRegister,
 },
 {
 path: "/account/profile",
    component:MProfile,
 },
 {
   path: "/checkout",
    component:MCheckout,
 },
];

export default routes;
