import 'babel-core/polyfill';

// // Because we're using webpack, importing css/scss from js will include them in the build
// // In development, the css is added to the page dynamically.
// // In prod, it is extracted into a separate css file for better loading performance.
import './index.scss';
// import './test';
// let initialState = {users: []],
//   activeUser: {},
//   todos: []
// };
// const store = createStore(allReducers, initialState);

