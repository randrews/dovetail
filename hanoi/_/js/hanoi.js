$(document).ready(function(){
    var game_state = newGameState(2);
    resetGame(2);

    // Pegs should handle discs being dropped on them
    $("ul[data-peg]").droppable()
        .on("drop", function(event, ui){
            // Try the move...
            attemptMove(game_state, ui.draggable, $(this));

            // Then check for the game being over
            if(checkForWin(game_state)){
                alertWin(game_state);
                game_state = newGameState(game_state.num_discs + 1);
                resetGame(game_state.num_discs);
            }
        });
});

// Create a game state for n discs. A game state has:
// - An array to represent the contents of each peg:
//     0th element is the bottom of the peg, so we can
//     use push() and pop(). Indices here correspond to
//     data-peg attributes on the table cells.
//
// - A number of discs in the game
// - A current number of moves used
function newGameState(n){
    var a = [];
    for(var k = n; k > 0; k--) a.push(k);
    return {
        pegs: [a, [], []],
        num_discs: n,
        moves: 0
    };
}

// Resets the game for n discs
function resetGame(n){
    // Remove old discs
    $("li[data-size]").remove();

    // Put all new discs on the first peg
    var first_peg = $("ul[data-peg=0]");

    // Create the discs
    for(var k = 1; k <= n; k++){
        var disc = document.createElement("li");
        $(disc).attr("data-size", k)
            .css("width", (k*25) + "px");
        
        first_peg.append(disc);
    }

    // Set the peg heights so there's room to see the discs
    $("ul[data-peg]").css("height", 25 * n);

    // The discs should be draggable
    first_peg.find("li[data-size]").draggable({
        revertDuration: 0,
        revert: true
    });
}

// Return the last element in an array
Array.prototype.last = function(){
    return this[this.length - 1];
};

// They've won iff all the arrays are empty except
// one, and that one isn't the first one.
function checkForWin(game_state){

    // Something in the first peg, no win
    if(game_state.pegs[0].length > 0) return false;

    var populated_pegs = 0;
    for(var k = 0; k < game_state.pegs.length; k++){
        if(game_state.pegs[k].length > 0) populated_pegs++;
    }

    return populated_pegs == 1;
};

// Move discs from one stack to another
// (this alters game_state)
function moveDisc(game_state, disc_el, peg_el){
    // Find the list for the peg we're moving from
    var src_num = disc_el.closest("ul[data-peg]").attr("data-peg");
    var src_list = game_state.pegs[ src_num ];

    // Find the list for the peg we're moving to
    var dest_list = game_state.pegs[ peg_el.attr("data-peg") ];

    // Actually move the disc
    peg_el.prepend(disc_el);
    src_list.pop();
    dest_list.push(disc_el.attr("data-size"));

    // Increment move counter
    game_state.moves++;
}

// Check if a move is valid, and if so, call moveDisc
function attemptMove(game_state, disc_el, peg_el){
    // List we're attempting to move from
    var src_num = disc_el.closest("ul[data-peg]").attr("data-peg");
    var src_list = game_state.pegs[ src_num ];

    // List we're attempting to move to
    var dest_list = game_state.pegs[ peg_el.attr("data-peg") ];

    // We're not the top thing on the src list; don't move
    if(src_list.last() != disc_el.attr("data-size")) return;

    // We're larger than what we're trying to move on to; don't move
    if(dest_list.last() && dest_list.last() < disc_el.attr("data-size")) return;

    // Otherwise, move
    moveDisc(game_state, disc_el, peg_el);
}

// The user has won; tell them so and then reload the game with more discs
function alertWin(game_state){
    var msg = "You have won, with " +
        game_state.num_discs +
        " disc" + (game_state.num_discs == 1 ? "" : "s") +
        " in " +
        game_state.moves +
        " move" + (game_state.moves == 1 ? "" : "s") +
        ". Click to try again with " +
        (game_state.num_discs + 1) + " discs!";

    alert(msg);
}