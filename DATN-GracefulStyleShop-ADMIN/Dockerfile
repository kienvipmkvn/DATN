# build stage
FROM node:lts-alpine as build-stage
ARG VUE_APP_BASE_API_URL
ENV VUE_APP_BASE_API_URL ${VUE_APP_BASE_API_URL}
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

# production stage
FROM nginx:stable as production-stage
RUN mkdir /app
EXPOSE 3000
COPY --from=build-stage /app/dist /app
COPY nginx.conf /etc/nginx/nginx.conf