
#ifndef __SZQ_GAME_H__
#define __SZQ_GAME_H__
#define ROWS 3
#define COLS 3


void init_board(char board[ROWS][COLS], int rows, int cols);
void print_board(char board[ROWS][COLS], int rows, int cols);
void play_game(char board[ROWS][COLS], int input);
char check_win(char board[ROWS][COLS]);
void player_move(char board[ROWS][COLS]);
void com_move(char board[ROWS][COLS]);

#endif 