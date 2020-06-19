﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class FigureMoving
    {
        public FigureMoving(Figure figure, Square from, Square to, Figure promotion = Figure.none)
        {
            this.figure = figure;
            this.from = from;
            this.to = to;
            this.promotion = promotion;
        }

        public FigureMoving(string move) // Pe2e4
        {
            this.figure = (Figure)move[0];
            this.from = new Square(move.Substring(1, 2));
            this.to = new Square(move.Substring(3, 2));
            this.promotion = (move.Length == 6) ? (Figure)move[5] : Figure.none;
        }

        public Figure figure { get; private set; }
        public Square from { get; private set; }
        public Square to { get; private set; }
        public Figure promotion { get; private set; }

        public int DeltaX => to.x - from.x;
        public int DeltaY => to.y - from.y;

        public int AbsDeltaX => Math.Abs(DeltaX);
        public int AbsDeltaY => Math.Abs(DeltaY);

        public int SignX => Math.Sign(DeltaX);
        public int SignY => Math.Sign(DeltaY);

    }
}
