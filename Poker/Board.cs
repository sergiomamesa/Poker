using Poker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Board
    {
        public Card FirstCard { get; set; }

        public Card SecondCard { get; set; }

        public Card ThirdCard { get; set; }

        public Card FourthCard { get; set; }

        public Card FifthCard { get; set; }

        public BoardStateType BoardState { get; set; } 

        public void SetBoardState()
        {
            if (FirstCard == null)
                BoardState = BoardStateType.Preflop;

            if (FirstCard != null)
                BoardState = BoardStateType.Flop;

            if (FourthCard != null)
                BoardState = BoardStateType.Turn;

            if (FifthCard != null)
                BoardState = BoardStateType.River;
        }

    }
}
