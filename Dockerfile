FROM node:lts-alpine as build-admin
ARG VUE_APP_BASE_API_URL
ENV VUE_APP_BASE_API_URL ${VUE_APP_BASE_API_URL}
ENV NODE_ENV=production
WORKDIR /app
COPY ./DATN-GracefulStyleShop-ADMIN/package*.json .
RUN npm install
COPY ./DATN-GracefulStyleShop-ADMIN .
RUN npm run build

FROM node:lts-alpine as build-client
ARG VUE_APP_BASE_API_URL
ENV VUE_APP_BASE_API_URL ${VUE_APP_BASE_API_URL}
ENV NODE_ENV=production
WORKDIR /app
COPY ./DATN-GracefulStyleShop-FE/package*.json ./
RUN npm install
COPY ./DATN-GracefulStyleShop-FE .
RUN npm run build

FROM nginx:stable
COPY --from=build-admin /app/dist /app/admin
COPY --from=build-client /app/dist /app
COPY default.conf /etc/nginx/conf.d/default.conf