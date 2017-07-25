using System;
using System.Collections.Generic;
using System.Text;

namespace ScrambleSquaresPuzzleSolver
{
    public enum TileID { A = 0, B, C, D, E, F, G, H, I };

    public class Tile
    {
        private Graphic[] topGraphicAtRotation = new Graphic[4];
        private Graphic[] rightGraphicAtRotation = new Graphic[4];
        private Graphic[] bottomGraphicAtRotation = new Graphic[4];
        private Graphic[] leftGraphicAtRotation = new Graphic[4];
        
        public TileID ID { get; set; } // the tile identifier where 3 x 3 boards have ids A - I starting at the top left and going across
        public int Rotations { get; set; } // number of rotations (0, 1, 2, or 3)
        public bool IsUsed { get; set; }
        public Graphic TopGraphic { get; set; }
        public Graphic RightGraphic { get; set; }
        public Graphic BottomGraphic { get; set; }
        public Graphic LeftGraphic { get; set; }

        public Tile(TileID id, Graphic topGraphic, Graphic rightGraphic, Graphic leftGraphic, Graphic bottomGraphic)
        {
            ID = id;
            TopGraphic = topGraphic;
            RightGraphic = rightGraphic;
            LeftGraphic = leftGraphic;
            BottomGraphic = bottomGraphic;

            InitializeGraphicsAtEachRotation();
        }

        void InitializeGraphicsAtEachRotation()
        {
            topGraphicAtRotation[0] = TopGraphic;
            topGraphicAtRotation[1] = LeftGraphic;
            topGraphicAtRotation[2] = BottomGraphic;
            topGraphicAtRotation[3] = RightGraphic;

            rightGraphicAtRotation[0] = RightGraphic;
            rightGraphicAtRotation[1] = TopGraphic;
            rightGraphicAtRotation[2] = LeftGraphic;
            rightGraphicAtRotation[3] = BottomGraphic;

            bottomGraphicAtRotation[0] = BottomGraphic;
            bottomGraphicAtRotation[1] = RightGraphic;
            bottomGraphicAtRotation[2] = TopGraphic;
            bottomGraphicAtRotation[3] = LeftGraphic;

            leftGraphicAtRotation[0] = LeftGraphic;
            leftGraphicAtRotation[1] = BottomGraphic;
            leftGraphicAtRotation[2] = RightGraphic;
            leftGraphicAtRotation[3] = TopGraphic;
        }

        public Graphic CurrentTopGraphic
        {
            get
            {
                return topGraphicAtRotation[Rotations];
            }
        }
        public Graphic CurrentRightGraphic
        {
            get
            {
                return rightGraphicAtRotation[Rotations];
            }
        }
        public Graphic CurrentBottomGraphic
        {
            get
            {
                return bottomGraphicAtRotation[Rotations];
            }        
        }
        public Graphic CurrentLeftGraphic
        {
            get
            {
                return leftGraphicAtRotation[Rotations];
            }
        }

        public void RotateClockwise()
        {
            Rotations++;
        }

        public void Reset()
        {
            IsUsed = false;
            Rotations = 0;
        }

        public override string ToString()
        {
            return "{ ID=" + ID + ", Rotations=" + Rotations + "}";
        }

    }
}
