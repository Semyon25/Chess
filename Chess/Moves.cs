﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class Moves
    {
        FigureMoving fm;
        Board board;

        public Moves(Board board)
        {
            this.board = board;
        }
        public bool CanMove(FigureMoving fm)
        {
            this.fm = fm;
            return
                CanMoveFrom() &&
                CanMoveTo() &&
                CanFigureMove();
        }

        private bool CanFigureMove()
        {
            switch (fm.figure)
            {
                case Figure.whiteKing:
                case Figure.blackKing:
                    return CanKingMove();
                case Figure.whiteQueen:
                case Figure.blackQueen:
                    return CanStraightMove();
                case Figure.whiteRook:
                case Figure.blackRook:
                    return false;
                case Figure.whiteBishop:
                case Figure.blackBishop:
                    return false;
                case Figure.whiteKnight:
                case Figure.blackKnight:
                    return CanKnightMove();
                case Figure.whitePawn:
                case Figure.blackPawn:
                    return false;
                default:
                    return false;
            }
        }

        private bool CanStraightMove()
        {
            Square at = fm.from;
            do
            {
                at = new Square(at.x + fm.SignX, at.y + fm.SignY);
                if (at == fm.to)
                    return true;
            } while (at.onBoard() && board.GetFigureAt(at) == Figure.none);
            return false;
        }

        private bool CanKingMove()
        {
            if (fm.AbsDeltaX <= 1 && fm.AbsDeltaY <= 1)
                return true;
            return false;
        }

        private bool CanKnightMove()
        {
            if (fm.AbsDeltaX == 1 && fm.AbsDeltaY == 2) return true;
            if (fm.AbsDeltaX == 2 && fm.AbsDeltaY == 1) return true;
            return false;
        }

        private bool CanMoveFrom()
        {
            return fm.from.onBoard() &&
                fm.figure.GetColor() == board.moveColor;
        }

        private bool CanMoveTo()
        {
            return fm.to.onBoard() &&
                fm.from != fm.to &&
               board.GetFigureAt(fm.to).GetColor() != board.moveColor;
        }
    }
}
