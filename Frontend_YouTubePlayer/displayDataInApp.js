// <iframe width="420" height="315" src="https://www.youtube.com/embed/xxxxxxxxxxxx"></iframe>
// {id: 5, title: 'Green Day - Basket Case', src: 'NUTGr5t3MoY', startAtSec: 15}
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
   <div id="playListBox"></div>
   </section>
    <section>
    <div id="addData"> 
    <label>title: </label>
    <input name="title"> 
     <label>videoCode:</label>
    <input name="src" > 
     <label>start tijd(optie)(in sec): </label>
    <input name="startAtSec"> 
    <button onclick="addData_Click()">Toevoegen</button>
    </div>
    </section>
    
    `
    app.innerHTML = appIndex
}
function shuffle(array) {
    let currentIndex = array.length;
    let randomIndex;

    // While there remain elements to shuffle.
    while (currentIndex !== 0) {

        // Pick a remaining element.
        randomIndex = Math.floor(Math.random() * currentIndex);
        currentIndex--;

        // And swap it with the current element.
        [array[currentIndex], array[randomIndex]] = [
            array[randomIndex], array[currentIndex]];
    }

    return array;
}
function dispalyDataInApp(){
    playListIndex = ``
    shuffle(dataYouTubePlayer).forEach(video => {
        let startTime = video.startAtSec == null ? "" : `?t=${video.startAtSec}`;
//   <iframe width="420" height="315" src="https://www.youtube.com/embed/${video.src}${startTime}"></iframe>
        playListIndex +=
            `
              <div class="playListRow">
                 <button onclick="playListRow_click(${video.id})">
                    <p>${video.title}</p>
                </button> 
              </div>
            `
    })

    document.getElementById('playListBox').innerHTML = playListIndex
    playListRow_click(dataYouTubePlayer[0].id)
}
function playListRow_click(id){
    let video = dataYouTubePlayer.find(video => {
        return video.id === id
    })
    let startTime = video.startAtSec == null ? "" : `?t=${video.startAtSec}`;
    document.getElementById('frameBox').innerHTML =
        `<div class="box">
 <iframe src="https://www.youtube.com/embed/${video.src}${startTime}"
    title="${video.title}"  allowFullScreen></iframe></div>  `

}
function logResult(result) {
    //console.log(result);
    dataYouTubePlayer = result
    dispalyDataInApp()
}
function addData_Click(){
    if(document.getElementsByName('title')[0].value !== '' && document.getElementsByName('src')[0].value !== '' ){
        if(!document.getElementsByName('title')[0].value.includes("'")){
            DataToevoegen({
                title: document.getElementsByName('title')[0].value,
                src: document.getElementsByName('src')[0].value,
                startAtSec: document.getElementsByName('startAtSec')[0].value === ""? null : document.getElementsByName('startAtSec')[0].value
            })
        }
        else {
            alert('title bevat \'' )
        }

    }
    else{
        alert('voeg eerst waarde toe')
    }


}


// fetch
// post
function DataToevoegen(Data) {
    const messageHeaders = new Headers({ // (1)
        'Content-Type': 'application/json'
    });
    fetch(apiUrl,{
        method: 'POST', // or 'PUT'
        headers: messageHeaders,
        body: JSON.stringify(Data),
    })
        .then(validateResponse)
        .then(readResponseAsJSON)
        .then(logResult)
        .catch(logError);
}

// get
function fetchJSON() {
    fetch(apiUrl) // (1) (2)
        .then(validateResponse) // (3)
        .then(readResponseAsJSON) // (4)
        .then(logResult) // (5)
        .catch(logError); // (6)
}

function validateResponse(response) {
    //console.log(response)
    if (!response.ok) { // (1)
        throw Error(response.statusText); // (2)
    }
    return response;
}
function readResponseAsJSON(response) {
    return response.json(); // (1)
}
function logError(error) {
    //console.log('Looks like there was a problem:', error);
    document.getElementById('app').innerHTML = `<div class="errowMess">
            <p> Sorry er is een probleem </p>
            <p> dit kan de oorzaak zijn : </p>
            <p> om deze applicatie te gerbuiken zal de backend moeten draaien </p>
            <p> 1. download de backendfile van mijn github (als je deze nog niet hebt) </p>
            <p> 2. open het project solution 'WebApplication_YouTubePlayerer' </p>
            <p> 3. zet de WebApplication_YouTubePlayer als start project </p>
            <p> 4. start project </p>
            <p> 5. KLAAR open deze website opnieuw</p>
</div>`


}

