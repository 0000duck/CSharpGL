﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// an object to be rendered in a scene.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public partial class SceneObject :
        IRenderable, // take part in rendering an object.
        ITreeNode<SceneObject>, // contains children objects and is contained by parent.
        IEnumerable<SceneObject> // enumerates self and all children objects recursively.
    {
        /// <summary>
        /// translate, rotate and scale this object in world space.
        /// </summary>
        private TransformComponent transform;
        private RendererComponent renderer;
        private ScriptComponent script;

        private const string strBasic = "Basic";

        /// <summary>
        /// name.
        /// </summary>
        [Category(strBasic)]
        [Description("Name.")]
        public string Name { get; set; }

        /// <summary>
        /// translate, rotate and scale this object in world space.
        /// </summary>
        public TransformComponent GetTransform() { return this.transform; }

        /// <summary>
        /// render this object.
        /// </summary>
        [Category(strBasic)]
        [Description("render this object.")]
        public RendererComponent Renderer
        {
            get { return this.renderer; }
            set
            {
                {
                    RendererComponent renderer = this.renderer;
                    if (renderer != null) { renderer.BindingObject = null; }

                    if (value != null) { value.BindingObject = this; }
                }
                {
                    this.renderer = value;
                }
            }
        }

        /// <summary>
        /// update state of this object.
        /// </summary>
        [Category(strBasic)]
        [Description("update state of this object.")]
        public ScriptComponent Script
        {
            get { return this.script; }
            set
            {
                {
                    ScriptComponent script = this.script;
                    if (script != null) { script.BindingObject = null; }

                    if (value != null) { value.BindingObject = this; }
                }
                {
                    this.script = value;
                }
            }
        }

        /// <summary>
        /// an object to be rendered in a scene.
        /// </summary>
        public SceneObject()
        {
            this.Name = typeof(SceneObject).Name;
            this.transform = new TransformComponent(this);
            this.Children = new SceneObjectList(this);
        }

        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }

        /// <summary>
        /// Update scene object's state.
        /// </summary>
        /// <param name="elapsedTime">elapsed time (in milliseconds)</param>
        public void Update(double elapsedTime)
        {
            ScriptComponent script = this.script;
            if (script != null)
            {
                script.Update(elapsedTime);
                foreach (var item in this.Children)
                {
                    item.Position = item.position;
                    item.Scale = item.scale;
                    item.Rotation = item.rotation;
                }
            }
        }
    }
}
