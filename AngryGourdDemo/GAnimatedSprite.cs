using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryGourdDemo
{
    public class GAnimatedSprite : GSprite
    {
        private readonly int _rowCount;
        private readonly int _columnCount;
        private int _totalFrameTime; // it's a counter in Milliseconds
        private Rectangle _frameRectangle;

        /// <summary>
        /// Number of frames in the sprite sheet.
        /// </summary>
        public int NumFrames { get; private set; }
        /// <summary>
        /// frame size, X = width and Y = Height
        /// </summary>
        public Point FrameSize { get; private set; }
        public int CurrentFrame { get; private set; }
        public bool IsPlaying { get; private set; }
        public bool IsPaused { get; private set; }

        /// <summary>
        /// The interval at which the frames should be drawn.
        /// The interval for each frame is speficied in Milliseconds.
        /// </summary>
        public int FrameInterval { get; set; }
        public bool IsLooping { get; set; }

        public GAnimatedSprite(string contentFilepath, int numFrames, int frameInterval, 
            Point frameSize, int framesPerRow) : base(contentFilepath)
        {
            NumFrames = numFrames;
            FrameInterval = frameInterval;
            FrameSize = frameSize;

            _frameRectangle = new Rectangle(0, 0, frameSize.X, frameSize.Y);
            _rowCount = 1;
            _columnCount = framesPerRow;

            if(framesPerRow < numFrames)
            {
                _rowCount = (numFrames / framesPerRow); // + (((float)numFrames / (float) framesPerRow != numFrames / framesPerRow)? 1 : 0);
                _columnCount = framesPerRow;
            }

            DrawRectangle = _frameRectangle;
        }

        public GAnimatedSprite(string contentFilepath, int numFrames, int frameInterval,
            Point frameSize): this(contentFilepath, numFrames, frameInterval, frameSize, numFrames)
        { }

        public void PlayAnimation(bool loop = true)
        {
            if(IsPaused)
            {
                IsPaused = false;
                return;
            }

            IsPlaying = true;
            IsLooping = loop;
        }

        public void StopAnimation()
        {
            IsPlaying = false;
            CurrentFrame = 0;
            _totalFrameTime = 0;
        }

        public void PauseAnimation()
        {
            IsPaused = true;
        }

        public override void Update(RenderContainer renderContainer)
        {
            if (IsPlaying && !IsPaused)
            {
                _totalFrameTime += renderContainer.GameTime.ElapsedGameTime.Milliseconds;

                if (_totalFrameTime >= FrameInterval)
                {
                    _totalFrameTime = 0;
                    _frameRectangle.Location = new Point(
                        FrameSize.X * (CurrentFrame % _columnCount),
                        FrameSize.Y * (int)Math.Floor(
                            (double)((double)CurrentFrame / (double)_columnCount)
                            )
                            );

                    DrawRectangle = _frameRectangle;
                    CurrentFrame++;
                    if (CurrentFrame >= NumFrames)
                    {
                        CurrentFrame = 0;
                        IsPlaying = IsLooping;
                    }

                }
            }
        }

    }
}
