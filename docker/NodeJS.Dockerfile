FROM node:18.12.1

COPY . /client

WORKDIR /client

CMD npm install -y && npm run dev