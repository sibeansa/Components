﻿#region File Description
//-----------------------------------------------------------------------------
// CrossFadeTransition
//
// Copyright © 2014 Wave Corporation
// Use is subject to license terms.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Services;
#endregion

namespace WaveEngine.Components.Transitions
{
    /// <summary>
    /// This class make an effect between two <see cref="ColorFadeTransition"/> pasing first to a specified color (white for example)
    /// </summary>
    public class CrossFadeTransition : ScreenTransition
    {
        /// <summary>
        /// The sprite batch
        /// </summary>
        private SpriteBatch spriteBatch;

        /// <summary>
        /// Source transition renderTarget
        /// </summary>
        private RenderTarget sourceRenderTarget;

        /// <summary>
        /// Target transition renderTarget
        /// </summary>
        private RenderTarget targetRenderTarget;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CrossFadeTransition" /> class.
        /// </summary>
        /// <param name="duration">The transition duration.</param>
        public CrossFadeTransition(TimeSpan duration)
            : base(duration)
        {
            this.spriteBatch = new SpriteBatch(this.graphicsDevice);
            this.sourceRenderTarget = this.graphicsDevice.RenderTargets.CreateRenderTarget(WaveServices.Platform.ScreenWidth, WaveServices.Platform.ScreenHeight);
            this.targetRenderTarget = this.graphicsDevice.RenderTargets.CreateRenderTarget(WaveServices.Platform.ScreenWidth, WaveServices.Platform.ScreenHeight);
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        protected override void Initialize()
        {
        }

        /// <summary>
        /// Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        protected override void Update(TimeSpan gameTime)
        {
            this.UpdateSources(gameTime, this.sourceRenderTarget);
            this.UpdateTarget(gameTime, this.targetRenderTarget);        
        }

        /// <summary>
        /// Draws the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        protected override void Draw(TimeSpan gameTime)
        {
            if (this.Sources != null)
            {
                for (int i = 0; i < this.Sources.Length; i++)
                {
                    this.Sources[i].TakeSnapshot(this.sourceRenderTarget, gameTime);
                }
            }

            if (this.Target != null)
            {
                this.Target.TakeSnapshot(this.targetRenderTarget, gameTime);
            }

            Color blendColor = Color.White * this.Lerp;

            this.graphicsDevice.RenderTargets.SetRenderTarget(null);
            this.graphicsDevice.Clear(ref this.BackgroundColor, ClearFlags.Target | ClearFlags.DepthAndStencil, 1);

            this.spriteBatch.Draw(this.sourceRenderTarget, new Rectangle(0, 0, this.sourceRenderTarget.Width, this.sourceRenderTarget.Height), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.5f);
            this.spriteBatch.Draw(this.targetRenderTarget, new Rectangle(0, 0, this.sourceRenderTarget.Width, this.sourceRenderTarget.Height), null, blendColor, 0, Vector2.Zero, SpriteEffects.None, 0);
            this.spriteBatch.Render();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.graphicsDevice.RenderTargets.DestroyRenderTarget(this.sourceRenderTarget);
                    this.graphicsDevice.RenderTargets.DestroyRenderTarget(this.targetRenderTarget);
                    this.spriteBatch.Dispose();
                }

                this.disposed = true;
            }
        }
    }
}