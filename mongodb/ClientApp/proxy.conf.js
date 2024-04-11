const { env } = require('process');

const target = 'http://localhost:45919';

const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
   ],
    target: target,
    secure: false
  }
]

module.exports = PROXY_CONFIG;
