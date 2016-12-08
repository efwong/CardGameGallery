import {allowDrop, drag, drop} from './draggable'

// Generate a grid object with # columns, when given an array of imageURLs
// tableName is an optional qualifier that you can pass to the image
export function generateGrid(imageURLs, columns, tableName = "main") {
  var tableDom = document.createElement("table");
  if (typeof imageURLs !== 'undefined'){
    tableDom.appendChild(generateBody(imageURLs, 3, tableName, tableName));
  }
  tableDom.className = "image-grid";
  return tableDom;
}


// Generate a body object
// Also parses the image url array into an Array of arrays to simulate the grid
// Maps the imageURLs to an object of {id: 123, url: "url"}
function generateBody(imageURLs, columns, tableName) {
  let tbodyDom = document.createElement("tbody");
  tbodyDom.className = "image-grid-body";

  let count = 0;
  // add an id to each url for the drag and drop feature
  let imageURLsWithId = imageURLs.map((obj) =>{
    return {
      url: obj,
      id: count++
    }
  });

  // splits array into groups of #columns
  let arrayChunks = getArrayChunks(imageURLsWithId, columns);
  if (arrayChunks.length > 0){
    arrayChunks.forEach((urlArr) => {
      let trowDom = generateRow(urlArr, tableName);
      tbodyDom.appendChild(trowDom);
    })
  }
  return tbodyDom;
}

// Generates a table row when given a list of url objects
function generateRow(imageURLs, tableName){
  let trowDom = document.createElement("tr");   
  imageURLs.forEach(function(urlObj){
    const tdDom = generateCell(urlObj, tableName);
    trowDom.appendChild(tdDom); 
  });
  return trowDom;
}

// generates a table cell when given a url obj {id: #, url:""}
function generateCell(urlObj, tableName){
  let tdDom = document.createElement("td");
  tdDom.className = "grid-cell";
  const imageZone = generateImageZone(urlObj, tableName);
  tdDom.appendChild(imageZone);
  return tdDom;
}

// Generates an image zone when given a url obj {id: #, url:""}
function generateImageZone(urlObj, tableName){
  let imageZone = document.createElement("img");
  imageZone.id = `${tableName}_image_${urlObj.id}`;
  imageZone.className = "image-zone";
  imageZone.ondragstart = drag;
  imageZone.ondrop = drop;
  imageZone.ondragover = allowDrop;
  imageZone.setAttribute("draggable", "true");
  imageZone.src=urlObj.url;
  return imageZone;
}

// return an array of arrays of urls
let getArrayChunks = (arr, chunkSize) =>{
  let resultAray = [];
  for (let i = 0; i < arr.length; i += chunkSize) {
      resultAray.push(arr.slice(i, i + chunkSize));
  }
  return resultAray;
};




