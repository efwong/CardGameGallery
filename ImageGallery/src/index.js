import 'babel-core/polyfill';

// // Because we're using webpack, importing css/scss from js will include them in the build
// // In development, the css is added to the page dynamically.
// // In prod, it is extracted into a separate css file for better loading performance.
import './index.scss';

import {generateGrid} from './gridGenerator';

// simulate fetch of image URLS
const input = {
  imageURLs: [
    '/public/1.png',
    '/public/2.png',
    '/public/3.png',
    '/public/4.png',
    '/public/5.png',
    '/public/6.png',
    '/public/7.png',
    '/public/8.png',
    '/public/9.png',
    '/public/10.png',
    '/public/11.png',
    '/public/12.png'
    ]
};
let rootDom = document.getElementById('root');
const tableDom = generateGrid(input.imageURLs, 3);
rootDom.appendChild(tableDom);

