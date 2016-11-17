﻿namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public class PointSpriteSwitch : GLSwitch
    {
        /// <summary>
        ///
        /// </summary>
        public PointSpriteSwitch()
        {
            this.SwitchList = new GLSwitchList();
            this.SwitchList.Add(new PointSmoothSwitch());
            this.SwitchList.Add(new DepthTestSwitch());
            this.SwitchList.Add(new BlendSwitch(
                BlendingSourceFactor.SourceAlpha,
                BlendingDestinationFactor.OneMinusSourceAlpha));
        }

        //int m_ParticleSize = 30;
        /// <summary>
        ///
        /// </summary>
        protected override void SwitchOn()
        {
            int count = this.SwitchList.Count;
            for (int i = 0; i < count; i++) { this.SwitchList[i].On(); }

            OpenGL.Enable(OpenGL.GL_VERTEX_PROGRAM_POINT_SIZE);
            OpenGL.Enable(OpenGL.GL_POINT_SPRITE);
            OpenGL.TexEnv(OpenGL.GL_POINT_SPRITE, OpenGL.GL_COORD_REPLACE, OpenGL.GL_TRUE);
            OpenGL.Hint(OpenGL.GL_POINT_SMOOTH_HINT, OpenGL.GL_NICEST);
            //GL.GetDelegateFor<GL.glBlendEquation>()(GL.GL_FUNC_ADD_EXT);
            //GL.GetDelegateFor<GL.glBlendFuncSeparate>()(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA, GL.GL_ONE, GL.GL_ONE);

            //float[] quadratic = { 1.0f, 0, 0, 1.0f };
            //GL.PointParameter(GL.GL_POINT_DISTANCE_ATTENUATION, quadratic);
            //GL.PointParameter(GL.GL_POINT_FADE_THRESHOLD_SIZE, 10.0f);
            //GL.TexEnvf(GL.GL_POINT_SPRITE, GL.GL_COORD_REPLACE, GL.GL_TRUE);

            //GL.PointParameter(GL.GL_POINT_SIZE_MIN, m_ParticleSize);
            ////GL.TexEnvi(GL.GL_POINT_SPRITE, GL.GL_COORD_REPLACE, GL.GL_TRUE);
            //GL.PointParameter(GL.GL_POINT_SPRITE_COORD_ORIGIN, GL.GL_LOWER_LEFT);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void SwitchOff()
        {
            OpenGL.Disable(OpenGL.GL_POINT_SPRITE);
            OpenGL.Disable(OpenGL.GL_VERTEX_PROGRAM_POINT_SIZE);

            int count = this.SwitchList.Count;
            for (int i = count - 1; i >= 0; i--) { this.SwitchList[i].Off(); }
        }

        /// <summary>
        ///
        /// </summary>
        public GLSwitchList SwitchList { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}", this.GetType().Name);
        }
    }
}