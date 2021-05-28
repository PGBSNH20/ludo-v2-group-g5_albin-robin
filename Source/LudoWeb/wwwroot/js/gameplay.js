"use strict";

//set up
function setUpPawns() {
    fetch('data/set-up-pawns.json')
        .then(response => response.json())
        .then(jsonResponse => AddInitialPawns(jsonResponse));
}
function AddInitialPawns(inPawns) {
    for (var i = 0; i < inPawns.length; i++) {

            let newPawn = inPawns[i];
       
            let gameSquareId = parseGameSquareId(newPawn);
            let gameSquare = select(gameSquareId);
            let color = inPawns[i].color;
            let pImg = createPawnImg(color);
            pImg.id = "pawn" + newPawn.id;
            pImg.onclick = function () { selectedPawn = newPawn; }
            //pImg.onclick = function () { gameSquare }
            gameSquare.appendChild(pImg);
    }
    boardPawns = inPawns;
    
}

function resetOnSend() {
    canTakeOutTwo = null;
    if (selectedSquare !== null) {
        selectedSquare.style.borderColor = "black";
        selectedSquare.style.borderWidth = "1px";
    }
    selectedSquare = null;
    selectedPawn = null;
    console.log("Resetting optionPawns!!");
    optionPawns = [];
    diceRoll = null;
}
var optionPawns = [];
var diceRoll = null;
var boardPawns = [];
var canTakeOutTwo = null;
var selectedSquare = null;
var selectedPawn = null;
setUpPawns();

//SignalR input to client
connection.on("ReceiveOption", function (returnPawnsToMove, returnCanTakeOutTwo, returnDiceRoll) {
    console.log("Received from networkmanager:")
    console.log("ReceiveOptionValues: " + returnCanTakeOutTwo + returnPawnsToMove);
    optionPawns = returnPawnsToMove;
    console.log("optionPawns was set to: " + optionPawns);
    diceRoll = returnDiceRoll;
    canTakeOutTwo = returnCanTakeOutTwo;
});
connection.on("UpdatePawns",
    function (inPawns) {
        let currentPawns = boardPawns;

        //Removes pawns that moved
        for (var i = 0; i < currentPawns.length; i++) {
            let oldPawn = currentPawns[i];
            if (isPawnEradicated(inPawns, oldPawn) || hasPawnMoved(inPawns, oldPawn)) {
                let pImg = select("#pawn" + oldPawn.id);
                pImg.parentNode.removeChild(pImg);
            }
        }
        console.log(inPawns.length);
        //Add new pawns
        for (var i = 0; i < inPawns.length; i++) {
            let newPawn = inPawns[i];
            if (hasPawnMoved(currentPawns, newPawn) === true) {
                console.log("I should now do stuff!");
                let gameSquareId = parseGameSquareId(newPawn);
                let gameSquare = select(gameSquareId);
                let color = inPawns[i].color;
                let pImg = createPawnImg(color);
                pImg.id = "pawn" + newPawn.id;
                pImg.onclick = function () { selectedPawn = newPawn; }
                //pImg.onclick = function () { gameSquare }
                gameSquare.appendChild(pImg);
            }
        }
        boardPawns = inPawns;
    });
//Button events (SignalR output)
function rollDice() {
    console.log("You pressed roll dice button.");
    if (diceRoll != null) {
        console.log(diceRoll);
    }
    if (optionPawns == null || optionPawns.length === 0) {
        console.log("You will pass.");
        resetOnSend();
        let sendPawns = [];
        sendPawnArray(sendPawns);
    }
    
}
function sendPawnSelection() {
    console.log("You pressed send pawn button.");
    let localParam = selectedPawn;
    if (selectedPawn !== null) {
        let sendPawns = [];
        sendPawns[0] = selectedPawn;
        sendPawnArray(sendPawns);
        resetOnSend();
    }
}
function sendTakeOutTwoSelection() {
    console.log("You pressed take out two button.");
    if (canTakeOutTwo === true) {
        let pawns = [];
        let pawn1 = {
            "Color": 0,
            "X": 0,
            "Y": 0
        }
        let pawn2 = {
            "Color": 0,
            "X": 0,
            "Y": 0
        }
        pawns[0] = pawn1;
        pawns[1] = pawn2;
        //Send
        resetOnSend();
    }
    canTakeOutTwo = null;
}
//Send SignalR
function sendPawnArray(pawns) {
    console.log("about to invoke ReceivePawns")
    console.log(pawns);
    connection.invoke("ReceivePawns", pawns).catch(function (err) {
        return console.error(err.toString());
    });
}
//onclick squares
function selectSquareAndPawn(square) {
    
    if (selectedSquare !== null) {
        selectedSquare.style.borderColor = "black";
        selectedSquare.style.borderWidth = "1px"; 
        selectedSquare = null;
    }
    if (selectedPawn !== null) {
        selectedPawn = null;
    }
    if (optionPawns.length === 0) {
        return;
    }
    if (square.hasChildNodes() === false) {
        return;
    }
    let optionPawn = validatePawnFromSquare(square);
    if (optionPawn !== null) {
        selectedSquare = square;
        selectedPawn = optionPawn;
        console.log("you selected: " + selectedPawn);
        selectedSquare.style.borderColor = "cyan";
        selectedSquare.style.borderWidth = "4px";
        selectedSquare = square;
    }
}
function validatePawnFromSquare(square) {
    let clickedPawn = getClickedPawn(square);
    if (pawnIsOption(clickedPawn)) {
        return clickedPawn;
    }
    return null;
}
function pawnIsOption(pawn) {
    let pawnId = pawn.id;
    for (var i = 0; i < optionPawns.length; i++) {
        let oPawn = optionPawns[i];
        let oPawnId = oPawn.id;
        if (pawnId === oPawnId) {
            return true;
        }
    }
}
function getClickedPawn(square) {
    let imgId = square.firstElementChild.id;
    let pawnId = imgId.split("n")[1];
    for (var i = 0; i < boardPawns.length; i++) {
        if (boardPawns[i].id.toString() === pawnId) {
            return boardPawns[i];
        }
    }
}
//if statements
function hasPawnMoved(inPawns, oldPawn) {
    for (var i = 0; i < inPawns.length; i++) {

        let inPawn = inPawns[i];
        if (inPawn.id === oldPawn.id && inPawn.x === oldPawn.y && inPawn.y === oldPawn.y) {
            return false;
        }
    }
    return true;
}
function isPawnEradicated(inPawns, oldPawn) {
    for (var i = 0; i < inPawns.length; i++) {
        let inPawn = inPawns[i];
        if (inPawn.id === oldPawn.id) {
            return false;
        }
    }
    return true;
}
//Helper functions
function createPawnImg(color) {

    let pawnImage = document.createElement("img");
    pawnImage.classList.add("pawn-image");
    pawnImage.classList.add(getColorClass(color));
    pawnImage.src = getPawnImagePath(color);
    return pawnImage;
}
function getColorClass(color) {
    //Blue
    if (color === 0) {
        return "blue-pawn";
    }
    //Red
    if (color === 1) {
        return "red-pawn";
    }
    //Yellow
    if (color === 2) {
        return "yellow-pawn";
    }
    //Green
    if (color === 3) {
        return "green-pawn";
    }
}
function getPawnImagePath(color) {
   
    //Blue
    if (color === 0) {
        return "images/Pawns/blue_64.png";
    }
    //Red
    if (color === 1) {
        return "images/Pawns/red_64.png";
    }
    //Yellow
    if (color === 2) {
        return "images/Pawns/yellow_64.png";
    }
    //Green
    if (color === 3) {
        return "images/Pawns/green_64.png";
    }
}
function getColorEnum(gameSquare) {
    let pawnImage = gameSquare.firstChild;

    if (pawnImage.classList.contains("blue-pawn")) {
        return 0;
    }
    if (pawnImage.classList.contains("red-pawn")) {
        return 1;
    }
    if (pawnImage.classList.contains("yellow-pawn")) {
        return 2;
    }
    if (pawnImage.classList.contains("green-pawn")) {
        return 3;
    }
}
function parseGameSquareId(pawn) {

    //This is a SignalR bug? Where if we parse value from model as json we get uppercase
    //Whereas from SignalR we get lowercase.
    return '#X' + pawn.x+ 'Y' + pawn.y;
}
function select(element) {
    if (document.querySelector(element) !== null) {
        return document.querySelector(element);
    } else {
        console.error('select(element): ' + element + ' is not found!');
        return null;
    }
}
/*
    "PawnsToMove": [
            {
                "Color": 0,
                "X": 4,
                "Y": 0
            },
            {
                "Color": 0,
                "X": 5,
                "Y": 0
            }
        ],
        "CanTakeOutTwo": true,
        "DiceRoll": 4
}*/