﻿using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace GridViewer
{
    public partial class BoundedRenderer : RendererBase, IModelTransform
    {
        /// <summary>
        /// Gets bounding box's renderer.
        /// </summary>
        public BoundingBoxRenderer BoxRenderer { get; private set; }

        /// <summary>
        /// Gets scientific model's renderer.
        /// </summary>
        public GridViewRenderer Renderer { get; private set; }

        public BoundedRenderer(GridViewRenderer renderer, vec3 lengths)
        {
            if (renderer == null)
            { throw new ArgumentNullException(); }

            this.BoxRenderer = BoundingBoxRenderer.Create(lengths);
            this.Renderer = renderer;
        }

        protected override void DoInitialize()
        {
            RendererBase boundingBox = this.BoxRenderer;
            if (boundingBox != null) { boundingBox.Initialize(); }

            RendererBase scientific = this.Renderer;
            if (scientific != null) { scientific.Initialize(); }
        }

        protected override void DoRender(RenderEventArg arg)
        {
            mat4 projection = arg.Camera.GetProjectionMat4();
            mat4 view = arg.Camera.GetViewMat4();

            Renderer boundingBox = this.BoxRenderer;
            if (boundingBox != null) { boundingBox.Render(arg); }

            Renderer renderer = this.Renderer;
            if (renderer != null) { renderer.Render(arg); }
        }

        protected override void DisposeUnmanagedResources()
        {
            IDisposable boundingBox = this.BoxRenderer;
            if (boundingBox != null) { boundingBox.Dispose(); }

            IDisposable scientific = this.Renderer;
            if (scientific != null) { scientific.Dispose(); }
        }

        /// <summary>
        /// transforms model from model's sapce to world's space.
        /// </summary>
        public mat4 ModelMatrix
        {
            get
            {
                return this.BoxRenderer.ModelMatrix;
            }
            set
            {
                this.BoxRenderer.ModelMatrix = value;
                this.Renderer.ModelMatrix = value;
            }
        }
    }
}
