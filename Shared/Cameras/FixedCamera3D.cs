﻿// Copyright © 2018 Wave Engine S.L. All rights reserved. Use is subject to license terms.

#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Sound;
#endregion

namespace WaveEngine.Components.Cameras
{
    /// <summary>
    /// FixedCamera decorate class
    /// </summary>
    [DataContract(Namespace = "WaveEngine.Components.Cameras")]
    public class FixedCamera3D : BaseDecorator
    {
        #region Properties

        /// <summary>
        /// Gets or sets the filed of view.
        /// </summary>
        /// <value>
        /// The filed of view.
        /// </value>
        public float FieldOfView
        {
            get
            {
                return this.entity.FindComponent<Camera3D>(false).FieldOfView;
            }

            set
            {
                this.entity.FindComponent<Camera3D>(false).FieldOfView = value;
            }
        }

        /// <summary>
        /// Gets or sets the aspect ratio.
        /// </summary>
        /// <value>
        /// The aspect ratio.
        /// </value>
        public float AspectRatio
        {
            get
            {
                return this.entity.FindComponent<Camera3D>(false).AspectRatio;
            }

            set
            {
                this.entity.FindComponent<Camera3D>(false).AspectRatio = value;
            }
        }

        /// <summary>
        /// Gets or sets the far plane.
        /// </summary>
        /// <value>
        /// The far plane.
        /// </value>
        public float FarPlane
        {
            get
            {
                return this.entity.FindComponent<Camera3D>(false).FarPlane;
            }

            set
            {
                this.entity.FindComponent<Camera3D>(false).FarPlane = value;
            }
        }

        /// <summary>
        /// Gets or sets the near plane.
        /// </summary>
        /// <value>
        /// The near plane.
        /// </value>
        public float NearPlane
        {
            get
            {
                return this.entity.FindComponent<Camera3D>(false).NearPlane;
            }

            set
            {
                this.entity.FindComponent<Camera3D>(false).NearPlane = value;
            }
        }

        /// <summary>
        /// Gets or sets the RenderTarget associated to the camera.
        /// </summary>
        /// <value>
        /// The render target.
        /// </value>
        public RenderTarget RenderTarget
        {
            get
            {
                return this.entity.FindComponent<Camera3D>(false).RenderTarget;
            }

            set
            {
                this.entity.FindComponent<Camera3D>(false).RenderTarget = value;
            }
        }

        /// <summary>
        /// Gets or sets Clear flags used for clean FrameBuffer, stencilbuffer and Zbuffer.
        /// </summary>
        /// <value>
        /// The clear flags.
        /// </value>
        /// <exception cref="System.ObjectDisposedException">RenderManager has been disposed.</exception>
        public ClearFlags ClearFlags
        {
            get
            {
                return this.entity.FindComponent<Camera3D>(false).ClearFlags;
            }

            set
            {
                this.entity.FindComponent<Camera3D>(false).ClearFlags = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>
        /// The background color of the camera if it was setted, or the RenderManager default background color.
        /// </value>
        public Color BackgroundColor
        {
            get
            {
                return this.entity.FindComponent<Camera3D>(false).BackgroundColor;
            }

            set
            {
                this.entity.FindComponent<Camera3D>(false).BackgroundColor = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the camera is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the camera is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive
        {
            get
            {
                return this.entity.FindComponent<Camera3D>(false).IsActive;
            }

            set
            {
                this.entity.FindComponent<Camera3D>(false).IsActive = value;
            }
        }

        /// <summary>
        /// Gets the layer mask.
        /// </summary>
        /// <value>
        /// The layer mask.
        /// </value>
        public IDictionary<int, bool> LayerMask
        {
            get
            {
                return this.entity.FindComponent<Camera3D>(false).LayerMask;
            }
        }
        #endregion

        #region Initialize

         /// <summary>
        /// Initializes a new instance of the <see cref="FixedCamera3D" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="position">The position.</param>
        /// <param name="lookAt">The look at.</param>
        public FixedCamera3D(string name, Vector3 position, Vector3 lookAt)
        {
            this.entity = new Entity(name)
                        .AddComponent(new Transform3D() { Position = position })
                        .AddComponent(new Camera3D())
                        .AddComponent(new SoundListener3D());

            this.entity.FindComponent<Transform3D>().LookAt(lookAt);
        }

        #endregion
    }
}
