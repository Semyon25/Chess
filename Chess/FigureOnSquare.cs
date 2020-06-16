﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class FigureOnSquare
    {
        public FigureOnSquare(Figure figure, Square square)
        {
            this.figure = figure;
            this.square = square;
        }

        public Figure figure { get; private set; }
        public Square square { get; private set; }


    }
}