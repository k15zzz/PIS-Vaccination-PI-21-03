FROM node:18.12.1-alpine

COPY ./client /client

WORKDIR /client

RUN npm i 

ENTRYPOINT npm run dev