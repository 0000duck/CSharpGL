﻿using System;
using System.Linq;

namespace CSharpGL
{
    public static class HighlightShaderHelper //: IDisposable
    {

        public static ShaderCode[] GetHighlightShaderCode()
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(GetShaderSource(ShaderType.VertexShader), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(GetShaderSource(ShaderType.FragmentShader), ShaderType.FragmentShader);

            return shaderCodes;
        }

        public static ShaderProgram GetHighlightShaderProgram()
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(GetShaderSource(ShaderType.VertexShader), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(GetShaderSource(ShaderType.FragmentShader), ShaderType.FragmentShader);

            var shaderProgram = new ShaderProgram();
            shaderProgram.Create((from item in shaderCodes select item.CreateShader()).ToArray());

            return shaderProgram;
        }

        /// <summary>
        /// vertex shader's cache.
        /// </summary>
        static string vertexShader = null;

        /// <summary>
        /// fragmente shader's cache.
        /// </summary>
        static string fragmentShader = null;

        /// <summary>
        /// Gets shader's source code for color coded picking.
        /// </summary>
        /// <param name="shaderType"></param>
        /// <returns></returns>
        private static string GetShaderSource(ShaderType shaderType)
        {
            string result = string.Empty;

            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    if (vertexShader == null)
                    {
                        vertexShader = ManifestResourceLoader.LoadTextFile(
                            @"OpenGLObjects.ColorCodedPicking.Highlight.vert");
                    }
                    result = vertexShader;
                    break;
                case ShaderType.FragmentShader:
                    if (fragmentShader == null)
                    {
                        fragmentShader = ManifestResourceLoader.LoadTextFile(
                            @"OpenGLObjects.ColorCodedPicking.Highlight.frag");
                    }
                    result = fragmentShader;
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }

    }
}
