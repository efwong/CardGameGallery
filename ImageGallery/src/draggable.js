/*
* Implements drag and drop events
*/

// allow drop event
export function allowDrop(ev) {
    ev.preventDefault();
}

// fires on drag, sets the target image zone
export function drag(ev) {
    ev.dataTransfer.setData("myimage", ev.target.id);
}


// fires on drop, sets the dropped image zone's image to that of the dragged imagezone
export function drop(dropzone) {
    dropzone.preventDefault();
    var data = dropzone.dataTransfer.getData("myimage");
    var dragzoneTarget = document.getElementById(data);
    dropzone.target.src = dragzoneTarget.src;

}