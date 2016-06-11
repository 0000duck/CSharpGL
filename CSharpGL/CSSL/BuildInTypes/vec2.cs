using System;
using System.Runtime.InteropServices;

namespace CSharpGL.CSSL
{
    /// <summary>
    /// ר����CSSL������������ѧ���㡣
    /// <para>Specially designed for CSSL. Not for glm.</para>
    /// </summary>
    public class vec2
    {
        internal float a0;
        internal float a1;

        #region compositions

        public float x { get { return 0.0f; } set { } }
        public float y { get { return 0.0f; } set { } }

        public vec2 xx { get { return null; } set { } }
        public vec2 xy { get { return null; } set { } }
        public vec2 yx { get { return null; } set { } }
        public vec2 yy { get { return null; } set { } }

        public float r { get { return 0.0f; } set { } }
        public float g { get { return 0.0f; } set { } }

        public vec2 rr { get { return null; } set { } }
        public vec2 rg { get { return null; } set { } }
        public vec2 gr { get { return null; } set { } }
        public vec2 gg { get { return null; } set { } }

        public float s { get { return 0.0f; } set { } }
        public float t { get { return 0.0f; } set { } }

        public vec2 ss { get { return null; } set { } }
        public vec2 st { get { return null; } set { } }
        public vec2 ts { get { return null; } set { } }
        public vec2 tt { get { return null; } set { } }

        #endregion compositions

        public float this[int index]
        {
            get
            {
                return 0.0f;
            }
            set
            {
            }
        }

        private vec2() { }

        public static vec2 operator -(vec2 lhs)
        {
            return null;
        }

        public static vec2 operator +(vec2 lhs, vec2 rhs)
        {
            return null;
        }

        public static vec2 operator +(vec2 lhs, float rhs)
        {
            return null;
        }

        public static vec2 operator -(vec2 lhs, vec2 rhs)
        {
            return null;
        }

        public static vec2 operator -(vec2 lhs, float rhs)
        {
            return null;
        }

        public static vec2 operator *(vec2 self, float s)
        {
            return null;
        }

        public static vec2 operator *(float lhs, vec2 rhs)
        {
            return null;
        }

        public static vec2 operator *(vec2 lhs, vec2 rhs)
        {
            return null;
        }

        public static vec2 operator /(vec2 lhs, float rhs)
        {
            return null;
        }

        public override string ToString()
        {
            return string.Format("CSSL's vec2 type.");
        }
    }
}