const apiUrl = "https://localhost:44351/YT_Player";



window.onload = function(){
    fetchJSON()
}
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
}
function logError(error) {
    console.log('Looks like there was a problem:', error);
}