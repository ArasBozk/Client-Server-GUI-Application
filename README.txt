In addition to step 1:

Server Gui changed: start game button and number of rounds textbox added
If appropriate text boxes are not filled program warns the user



After 2 or more player connected to the server game starts with START GAME button.
To start the game you must specify the number of rounds.

After the game starts any other new player is not allowed. In order to play, player should connect before game start.
After the game starts player can disconnect.
Players cannot connect with the name that other player uses.
Game is running on Round Robin fashion. 
Players starts to ask questions in alphabetical order.
In 1 round every player asks one question and answers all other players questions.


while game is running if asker disconnects nobody gets point and next turn starts.


Scores:
True answers are 1 point, false answers are 0 point.
There are two options to determine the scores.
1)If there is just 1 player left and every other players disconnects, that player is automatically winner.
2)After predetermined round count is reached the players who has the most scores are the winners.
There can be more than 1 winner (if they have the same highest scores)

After each round Question score table is send to the all players.


Problems:
After server disconnects  it cannot start with the same port number.
if one player press disconnect button after connection and before game starts, program crashes.

