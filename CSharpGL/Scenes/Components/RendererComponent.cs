﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public abstract class RendererComponent : Component, IRenderable
    {
     
        public RendererComponent(SceneObject bindingObject = null)
            : base(bindingObject)
        { }

        //protected override void DoInitialize()
        //{
        //    base.DoInitialize();

        //    int location;
        //    location = this.shaderProgram.GetUniformLocation(projection);
        //    if (location < 0)
        //    { throw new Exception(string.Format("No uniform found for the name [{0}]", projection)); }
        //    else
        //    { this.projectionLocation = (uint)location; }
        //    location = this.shaderProgram.GetUniformLocation(view);
        //    if (location < 0)
        //    { throw new Exception(string.Format("No uniform found for the name [{0}]", view)); }
        //    else
        //    { this.viewLocation = (uint)location; }
        //    location = this.shaderProgram.GetUniformLocation(model);
        //    if (location < 0)
        //    { throw new Exception(string.Format("No uniform found for the name [{0}]", model)); }
        //    else
        //    { this.modelLocation = (uint)location; }

        //}

        protected bool TryGetMatrix(RenderEventArgs arg,
            out mat4 projection, out mat4 view, out mat4 model)
        {
            SceneObject bindingObject = this.BindingObject;
            if (bindingObject != null)
            {
                projection = arg.Camera.GetProjectionMat4();
                view = arg.Camera.GetViewMat4();

                SceneObject parent = bindingObject.Parent;
                if (parent != null)
                {
                    model = parent.Transform.GetModelMatrix() * bindingObject.Transform.GetModelMatrix();
                }
                else
                {
                    model = bindingObject.Transform.GetModelMatrix();
                }

                return true;
            }
            else
            {
                projection = new mat4(); view = new mat4(); model = new mat4();
                return false;
            }
        }

        public abstract void Render(RenderEventArgs arg);
    }
}
