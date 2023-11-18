<template>
  <div class="cart-item">
    <div class="media-leff">
      <div class="item-img">
        <img
          :src="item.ImageLink ?? item.Images[0].ImageLink"
          alt=""
        />
        <div class="item-remove">{{item.Quantity}}</div>
      </div>
    </div>
    <div class="media-right">
      <div class="item-info">
        <h3 class="item--title">
          {{item.ProductName}}
        </h3>
        <div class="item--variant"><span>{{item.ColorName}} / {{item.SizeCode}}</span></div>
        <div class="item-price">
          <p>
            <span>{{ $state.formatPrice(item.PriceDel) }}</span>
            <sup v-if="item.Discount">{{ $state.formatPrice(item.PriceDel + (item.Discount*0.01*item.PriceDel)) }}</sup>
          </p>
        </div>
      </div>
    </div>
    <div class="media-total">
      <span>{{$state.formatPrice(item.PriceDel * item.Quantity)}}</span>
    </div>
  </div>
</template>
<script>
export default {
  props:{
    item: Object
  }
};
</script>
<style scoped>
.cart-item {
  position: relative;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  padding: 15px 10px;
  border-bottom: 1px solid #eae8e8;
}
.media-left {
  padding: 0;
  position: relative;
  display: block;
}
.item-img {
  position: relative;
  width: 60px;
  height: 60px;
}
.item-img img {
  border: 1px solid #ededed;
}
.item-remove {
  position: absolute;
  top: -7px;
  left: -10px;
  display: block;
  background: #8f9bb3;
  color: #fff;
  font-size: 8px;
  font-weight: 400;
  width: 20px;
  height: 20px;
  text-align: center;
  line-height: 20px;
  border-radius: 50%;
  cursor: pointer;
}

.media-right {
  -ms-flex: 1 1 auto;
  flex: 1 1 auto;
  max-width: 1 1 auto;
  padding-left: 18px;
  padding-right: 18px;
}
.item-info {
  margin-bottom: 10px;
}
.item--title {
  font-size: 15px;
  margin: 0px 0 2px;
  font-weight: 500;
}
.item--variant {
  font-size: 12px;
  color: #777;
  font-weight: 500;
}
.item--variant {
  font-size: 12px;
  color: #777;
  font-weight: 500;
}
.item-price p {
  margin: 0 0 10px;
}

.item-price span {
  font-weight: 600;
  color: #8f9bb3;
}
.item-price sup {
  color: #f31612;
  font-size: 80%;
  margin-left: 8px;
  text-decoration:line-through;
}
.media-total {
  text-align: righ;
  display: flex;
  align-items: center;
}
.line-item-total {
  font-size: 15px;
  font-weight: 600;
}
.item-total-price{
  text-align: right;
}
.quantity-partent {
  width: 100%;
  display: -ms-flexbox;
  display: -webkit-flex;
  display: flex;
  margin: 8px 0 3px;
}
.quantity-partent > button {
  float: left;
  font-weight: 500;
  font-size: 18px;
  padding: 0;
  height: 28px;
  width: 28px;
  text-align: center;
  background: #ffffff;
  border: 1px solid #f3f4f4;
  border-radius: 4px;
  outline: none;
  -webkit-appearance: none;
  -moz-appearance: none;
  -o-appearance: none;
  appearance: none;
}
.quantity-partent > input {
  float: left;
  font-weight: 500;
  font-size: 15px;
  width: 36px;
  height: 28px;
  padding: 0;
  background: #fff;
  text-align: center;
  outline: none;
  border: 1px solid #f3f4f4;
  margin: 0 3px;
  border-radius: 4px;
  -webkit-appearance: none;
  -moz-appearance: none;
  -o-appearance: none;
  appearance: none;
}
</style>
