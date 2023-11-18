<template>
  <Carousel v-bind="config" :breakpoints="breakpoints">
    <slot>
      <Slide v-for="(item, index) in data" :key="index">
        
      </Slide>
    </slot>
    <template #addons>
      <Navigation />
      <Pagination />
    </template>
  </Carousel>
</template>
<script>
import "vue3-carousel/dist/carousel.css";
import { Carousel, Slide, Pagination, Navigation } from "vue3-carousel";
export default {
  name:"SlideCarousel",
  components: {
    Carousel,
    Slide,
    Pagination,
    Navigation,
  },
  props: {
    data: {
      type: Array,
    },
    itemsToShow: {
      type: Number,
      default: 1,
    },
    itemsToScroll: Number,
    autoplay: Number,
    snapAlign: {
      type: String,
      default: "center",
    },
  },
  data() {
    return {
      config: {
        itemsToShow: this.itemsToShow,
        itemsToScroll: this.itemsToScroll,
        autoplay: this.autoplay,
        snapAlign: this.snapAlign,
      },
      breakpoints: {
        // 700px and up
        700: {
          itemsToShow: 3.5,
          snapAlign: "center",
        },
        // 1024 and up
        1024: {
          itemsToShow: 5,
          snapAlign: "start",
        },
      },
    };
  },
  methods: {},
  computed: {},
};
</script>
