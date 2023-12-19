<template>
  <footer class="footer" v-if="$state.isHeaderAndFooterShow" ref="footer">
    <!-- Footer -->
    <MDBFooter :text="['center', 'lg-start', 'muted']">
      <!-- Section: Social media -->
      <section
        class="d-flex justify-content-center justify-content-lg-between p-4 border-bottom"
      >
        <!-- Left -->
        <div class="me-5 d-none d-lg-block">
          <span>Kết nối với chúng tôi trên các mạng xã hội:</span>
        </div>
        <!-- Left -->

        <!-- Right -->
        <div>
          <a href="" class="me-4 text-reset">
            <MDBIcon
              class="link-secondary"
              iconStyle="fab"
              icon="facebook-f"
            ></MDBIcon>
          </a>
          <a href="" class="me-4 text-reset">
            <MDBIcon
              class="link-secondary"
              iconStyle="fab"
              icon="twitter"
            ></MDBIcon>
          </a>
          <a href="" class="me-4 text-reset">
            <MDBIcon
              class="link-secondary"
              iconStyle="fab"
              icon="google"
            ></MDBIcon>
          </a>
          <a href="" class="me-4 text-reset">
            <MDBIcon
              class="link-secondary"
              iconStyle="fab"
              icon="instagram"
            ></MDBIcon>
          </a>
          <a href="" class="me-4 text-reset">
            <MDBIcon
              class="link-secondary"
              iconStyle="fab"
              icon="linkedin"
            ></MDBIcon>
          </a>
          <a href="" class="me-4 text-reset">
            <MDBIcon
              class="link-secondary"
              iconStyle="fab"
              icon="github"
            ></MDBIcon>
          </a>
        </div>
        <!-- Right -->
      </section>
      <!-- Section: Social media -->

      <!-- Section: Links  -->
      <section class="">
        <MDBContainer class="text-center text-md-start mt-5">
          <!-- Grid row -->
          <MDBRow class="mt-3">
            <!-- Grid column -->
            <MDBCol md="3" lg="4" xl="3" class="mx-auto mb-4">
              <!-- Content -->
              <h6 class="text-uppercase fw-bold mb-4">
                <i class="fas fa-gem me-3 link-secondary"></i>juno
              </h6>
              <p>
                JUNO là cửa hàng bán lẻ đồ gia dụng, hóa mỹ phẩm, phụ kiện
                chính hãng các thương hiệu Nhật Bản. Hóa phẩm lành tính
                JUNO sản xuất tại Nhật Bản. Phụ kiện giày, túi, ví, balo và
                thời trang hiệu TokyoNow, TokyoBasic, TokyoSmart, TokyoSecret,
                In The Now và nhiều thương hiệu thời trang, phụ kiện khác sản
                xuất tại Việt Nam, Trung Quốc, Thái Lan…
              </p>
            </MDBCol>
            <!-- Grid column -->

            <!-- Grid column -->
            <MDBCol md="2" lg="2" xl="2" class="mx-auto mb-4">
              <!-- Links -->
              <h6 class="text-uppercase fw-bold mb-4">HỆ THỐNG CỬA HÀNG</h6>
              <p>
                <a href="#!" class="text-reset"><strong>Hotline CSKH: </strong>024.7300.6999</a>
              </p>
              <p>
                <a href="#!" class="text-reset"><strong>Email: </strong>cskh@juno.vn</a>
              </p>
            </MDBCol>
            <!-- Grid column -->

            <!-- Grid column -->
            <MDBCol md="3" lg="2" xl="2" class="mx-auto mb-4">
              <!-- Links -->
              <h6 class="text-uppercase fw-bold mb-4">Hỗ trợ Khách hàng</h6>
              <li class="sp-item">
                <a href="#!" class="text-reset">Giới thiệu & Liên hệ</a>
              </li>
              <li class="sp-item">
                <a href="#!" class="text-reset">Hướng dẫn mua hàng</a>
              </li>
              <li class="sp-item">
                <a href="#!" class="text-reset">HD thanh toán bằng VNPAY</a>
              </li>
              <li class="sp-item">
                <a href="#!" class="text-reset">Hướng dẫn chọn Size</a>
              </li>
              <li class="sp-item">
                <a href="#!" class="text-reset">Chính sách bảo mật</a>
              </li>
              <li class="sp-item">
                <a href="#!" class="text-reset">Điều khoản & Dịch vụ</a>
              </li>
            </MDBCol>
            <!-- Grid column -->

            <!-- Grid column -->
            <MDBCol md="4" lg="3" xl="3" class="mx-auto mb-md-0 mb-4">
              <!-- Links -->
              <h6 class="text-uppercase fw-bold mb-4">
                Hỗ trợ/Tư vấn mua online
              </h6>
              <p>
                <i class="fas fa-home me-3 link-secondary"></i>
                <span>Đường Tu Hoàng, Quận Nam Từ Liêm, Thành phố Hà Nội</span>
              </p>
              <p>
                <i class="fas fa-envelope me-3 link-secondary"></i>
                kienvipmkvn3199@gmail.com
              </p>
              <p>
                <MDBIcon icon="phone" class="me-3 link-secondary" />
                0965427872
              </p>
              <p>
                <MDBIcon icon="print" class="me-3 link-secondary" />
                0965427872
              </p>
            </MDBCol>
            <!-- Grid column -->
          </MDBRow>
          <!-- Grid row -->
        </MDBContainer>
      </section>
      <!-- Section: Links  -->

      <!-- Copyright -->
      <div
        class="text-center p-4"
        style="background-color: rgba(0, 0, 0, 0.05)"
      >
        © 2021 Copyright:
        <a class="text-reset fw-bold" href="https://mdbootstrap.com/"
          >MDBootstrap.com</a
        >
      </div>
      <!-- Copyright -->
    </MDBFooter>
    <!-- Footer -->
  </footer>
</template>
<script>
import {
  MDBFooter,
  MDBIcon,
  MDBRow,
  MDBCol,
  MDBContainer,
} from "mdb-vue-ui-kit";
export default {
  name: "TheHeader",
  components: {
    MDBFooter,
    MDBIcon,
    MDBRow,
    MDBCol,
    MDBContainer,
  },
  props:{
  }
};
</script>
<style scoped>
.text-muted {
  color: white !important;
}
.bg-light {
  background-color: #c92027 !important;
}
.link-secondary {
  color: white !important;
}
.sp-item {
  list-style-type: circle;
  font-size: 14px;
  margin-top: 12px;
}
.sp-item:hover {
  color: rgb(57, 252, 128);
}
.text-reset{
  font-size: 14px;
}
</style>
