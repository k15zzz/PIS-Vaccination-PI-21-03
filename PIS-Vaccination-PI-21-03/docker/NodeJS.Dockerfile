FROM node:18.12.1-alpine

COPY ./client-app /client

WORKDIR /client

CMD npm install -y && npm run dev