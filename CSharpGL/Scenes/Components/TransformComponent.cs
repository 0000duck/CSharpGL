﻿using System;

namespace CSharpGL
{
    /// <summary>
    /// Transform model's position from model space to world space,
    /// including translation, scale and rotation.
    /// </summary>
    public partial class TransformComponent : Component
    {
        /// <summary>
        /// translate this object.
        /// </summary>
        public vec3 Position { get; set; }
        /// <summary>
        /// rotate this object.
        /// </summary>
        public vec3 Rotation { get; set; }
        /// <summary>
        /// scale this object.
        /// </summary>
        public vec3 Scale { get; set; }

        /// <summary>
        /// Transform model's position from model space to world space,
        /// including translation, scale and rotation.
        /// </summary>
        /// <param name="bindingObject"></param>
        public TransformComponent(SceneObject bindingObject = null)
            : base(bindingObject)
        {
            this.Scale = new vec3(1, 1, 1);
        }

        static readonly vec3 xAxis = new vec3(1, 0, 0);
        static readonly vec3 yAxis = new vec3(0, 1, 0);
        static readonly vec3 zAxis = new vec3(0, 0, 1);

        mat4 selfMatrix = mat4.identity();

        /// <summary>
        /// Get model matrix that transform model's position from model space to world space,
        /// Make sure the scene object list is traversed in pre-order.
        /// </summary>
        /// <returns></returns>
        public mat4 GetModelMatrix()
        {
            SceneObject obj = this.BindingObject;
            if (obj != null)
            {
                mat4 matrix = mat4.identity();
                matrix = glm.translate(matrix, this.Position);
                matrix = glm.scale(matrix, this.Scale);
                matrix = glm.rotate(matrix, (float)(this.Rotation.x * Math.PI / 180.0), xAxis);
                matrix = glm.rotate(matrix, (float)(this.Rotation.y * Math.PI / 180.0), yAxis);
                matrix = glm.rotate(matrix, (float)(this.Rotation.z * Math.PI / 180.0), zAxis);

                //SceneObject parent = obj.Parent;
                //if (parent != null)
                //{
                //    this.selfMatrix = parent.Transform.selfMatrix * matrix;
                //}
                //else
                //{
                    this.selfMatrix = matrix;
                //}
            }

            return this.selfMatrix;
        }
    }
}
