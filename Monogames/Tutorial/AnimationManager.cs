using Microsoft.Xna.Framework;
using System.Diagnostics;


namespace Tutorial
{
    internal class AnimationManager
    {
        int numFrames;
        int numColumns;
        Vector2 size;

        int counter;
        int activeFrame;
        int interval;

        int rowPosition;
        int colPosition;

        public int OffsetX { get; set; } = 0;
        public int OffsetY { get; set; } = 0;

        public AnimationManager(int numFrames, int numColumns, Vector2 size) 
        {
            this.numFrames = numFrames;
            this.numColumns = numColumns;
            this.size = size;

            counter = 0;
            activeFrame = 0;
            interval = 5;
        }

        public void Update()
        {
            counter++;
            if (counter > interval)
            {
                counter = 0;
                NextFrame();
            }
        }

        private void NextFrame()
        {
            activeFrame++;
            colPosition++;

            if (activeFrame >= numFrames || rowPosition >= numFrames)
            {
                ResetAnimation();
            }

            //if (colPosition >= numColumns)
            //{
            //    colPosition = 0;
            //    rowPosition++;
            //}


            Debug.WriteLine($"Frame: {activeFrame}, Col: {colPosition}, Row: {rowPosition}");
        }

        private void ResetAnimation()
        {
            activeFrame = 0;
            colPosition = 0;
            rowPosition = 0;
        }

        public Rectangle GetFrame()
        {
            // Calculate the X and Y position based on current column and row
            int xPos = colPosition * (int)size.X + OffsetX;
            int yPos = rowPosition * (int)size.Y + OffsetX;

            // Return the rectangle representing the current frame
            return new Rectangle(xPos, yPos, (int)size.X, (int)size.Y);
        }
    }
}
