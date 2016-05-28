﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{

    public class UniformSampler : UniformVariable
    {

        private samplerValue value;

        public samplerValue Value
        {
            get { return this.value; }
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    this.Updated = true;
                }
            }
        }

        public UniformSampler(string varName) : base(varName) { }

        public override void SetUniform(ShaderProgram program)
        {
            OpenGL.GetDelegateFor<OpenGL.glActiveTexture>()(value.ActiveTextureIndex);
            //OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, value.TextureId);
            OpenGL.BindTexture(value.target, value.TextureId);
            program.SetUniform(VarName, (int)((uint)value.ActiveTextureIndex - OpenGL.GL_TEXTURE0));
        }

        public override void ResetUniform(ShaderProgram program)
        {
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, 0);
            OpenGL.BindTexture(value.target, 0);
        }

        internal override bool SetValue(ValueType value)
        {
            if (value.GetType() != typeof(samplerValue))
            {
                throw new ArgumentException(string.Format("[{0}] not match [{1}]'s value.",
                    value.GetType().Name, this.GetType().Name));
            }

            var v = (samplerValue)value;
            if (v != this.value)
            {
                this.value = v;
                this.Updated = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        internal override ValueType GetValue()
        {
            return value;
        }

    }

    [TypeConverter(typeof(SamplerValueTypeConverter))]
    public struct samplerValue
    {
        internal uint target;

        public BindTextureTarget Target
        {
            get { return (BindTextureTarget)target; }
            set { target = (uint)value; }
        }

        private uint textureId;

        public uint TextureId
        {
            get { return textureId; }
            set { textureId = value; }
        }

        private uint activeTextureIndex;

        public uint ActiveTextureIndex
        {
            get { return activeTextureIndex; }
            set { activeTextureIndex = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="textureId"></param>
        /// <param name="activeTextureIndex">OpenGL.GL_TEXTURE0 etc</param>
        public samplerValue(BindTextureTarget target, uint textureId, uint activeTextureIndex)
        {
            this.target = (uint)target;
            this.textureId = textureId;
            this.activeTextureIndex = activeTextureIndex;
        }

        static readonly char[] separator = new char[] { '[', ']', };

        public static samplerValue Parse(string value)
        {
            string[] parts = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            BindTextureTarget target = (BindTextureTarget)Enum.Parse(typeof(BindTextureTarget), parts[1]);
            uint textureId = uint.Parse(parts[3]);
            uint activeTextureIndex = uint.Parse(parts[5]);

            return new samplerValue(target, textureId, activeTextureIndex);
        }

        public override string ToString()
        {
            return string.Format("texture target: [{0}] texture id:[{1}] active texture index:[{2}]", target, textureId, activeTextureIndex);
        }

        public static bool operator ==(samplerValue left, samplerValue right)
        {
            object leftObj = left, rightObj = right;
            if (leftObj == null)
            {
                if (rightObj == null) { return true; }
                else { return false; }
            }
            else
            {
                if (rightObj == null) { return false; }
            }

            return left.Equals(right);
        }

        public static bool operator !=(samplerValue left, samplerValue right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            var p = (samplerValue)obj;

            //return this.HashCode == p.HashCode;
            return (this.activeTextureIndex == p.activeTextureIndex && this.textureId == p.textureId);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

    }

    public enum BindTextureTarget : uint
    {
        Texture1D = OpenGL.GL_TEXTURE_1D,
        Texture2D = OpenGL.GL_TEXTURE_2D,
        Texture3D = OpenGL.GL_TEXTURE_3D,
    }
}
