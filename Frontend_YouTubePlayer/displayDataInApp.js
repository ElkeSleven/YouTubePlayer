
const apiUrl = "https://localhost:44344/api/values";
let dataYouTubePlayer = [];
const app = document.getElementById('app')
let appIndex = ``;
let playListIndex = ``;

window.onload = function(){
    createApp()
    fetchJSON()

}

function createApp(){
    appIndex =
        `
   <section>
   <div id="frameBox"></div>
   <div id="playList"></div>
   </section>
    
    
    `
    app.innerHTML = appIndex
}


// <iframe width="420" height="315" src="https://www.youtube.com/embed/xxxxxxxxxxxx"></iframe>
// {id: 5, title: 'Green Day - Basket Case', src: 'NUTGr5t3MoY', startAtSec: 15}
function dispalyDataInApp(){
    console.log(dataYouTubePlayer)
    dataYouTubePlayer.forEach(video => {
        let startTime = video.startAtSec == null ? "" : `?t=${video.startAtSec}`;
//   <iframe width="420" height="315" src="https://www.youtube.com/embed/${video.src}${startTime}"></iframe>
        playListIndex +=
            `
              <div class="videoRow">
                 <button onclick="btn_click(${video.id})">
                    <p>${video.title}</p>
                </button> 
              </div>
            `

    })

    document.getElementById('playList').innerHTML = playListIndex
}
function btn_click(id){
    let video = dataYouTubePlayer.find(video => {
        return video.id === id
    })
    let startTime = video.startAtSec == null ? "" : `?t=${video.startAtSec}`;
    document.getElementById('frameBox').innerHTML = ` <iframe width="420" height="315" src="https://www.youtube.com/embed/${video.src}${startTime}"></iframe>  `
}


// fetch
function fetchJSON() {
    fetch(apiUrl) // (1) (2)
        .then(validateResponse) // (3)
        .then(readResponseAsJSON) // (4)
        .then(logResult) // (5)
        .catch(logError); // (6)
}
function validateResponse(response) {
    console.log(response)
    if (!response.ok) { // (1)
        throw Error(response.statusText); // (2)
    }
    return response;
}
function readResponseAsJSON(response) {
    return response.json(); // (1)
}
function logResult(result) {
    console.log(result);
    dataYouTubePlayer = result
    dispalyDataInApp()
}
function logError(error) {
    console.log('Looks like there was a problem:', error);
}