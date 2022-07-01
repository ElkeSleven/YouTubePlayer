

let fill = document.querySelector('.fill')
let empties = document.querySelectorAll('.empty')

//
fill.addEventListener('dragstart', dragStart)
fill.addEventListener('dragend', dragEnd)

for(const empty of empties){
    empty.addEventListener('dragover', dragOver);
    empty.addEventListener('dragenter', dragEnter);
    empty.addEventListener('dragleave', dragLeave);
    empty.addEventListener('drop', dragDrop);
}

function dragStart(){
    this.className +=' hold'
    setTimeout(() => (this.className +=' Red'),0);
}
function dragEnd(){
    this.className ='fill';
}



function dragOver(){console.log('dragOver')}
function dragEnter(){console.log('dragOver')}
function dragLeave(){console.log('dragOver')}
function dragDrop(){console.log('dragOver')}