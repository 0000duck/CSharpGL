﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// gets model's original size.
    /// transform a model from model's sapce to world's space.
    /// </summary>
    public interface IModelSpace
    {
        /// <summary>
        /// world position before model is scaled or rotated.
        /// </summary>
        vec3 OriginalWorldPosition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        float RotationAngle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        vec3 RotationAxis { get; set; }

        /// <summary>
        /// 
        /// </summary>
        vec3 Scale { get; set; }

        /// <summary>
        /// Length in X/Y/Z axis.
        /// </summary>
        vec3 Lengths { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class IModelSpaceHelper
    {
        /// <summary>
        /// Get model matrix that transform model from model space to world space.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static mat4 GetMatrix(this IModelSpace model)
        {
            mat4 matrix = glm.translate(mat4.identity(), model.OriginalWorldPosition);
            matrix = glm.scale(matrix, model.Scale);
            matrix = glm.rotate(matrix, model.RotationAngle, model.RotationAxis);
            return matrix;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static BoundingBox GetBoundingBox(this IModelSpace model)
        {
            vec3 max, min;
            {
                vec3 position = model.OriginalWorldPosition + model.Lengths / 2;
                max = position;
            }
            {
                vec3 position = model.OriginalWorldPosition - model.Lengths / 2;
                min = position;
            }

            return new BoundingBox(min, max);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static vec3 GetMaxPosition(this IModelSpace model)
        {
            return model.OriginalWorldPosition + model.Lengths / 2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static vec3 GetMinPosition(this IModelSpace model)
        {
            return model.OriginalWorldPosition - model.Lengths / 2;
        }
    }
}
