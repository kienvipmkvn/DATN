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
EXPOSE 80
COPY --from=build-stage /app/dist /usr/share/nginx/html