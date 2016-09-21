﻿using System;

namespace CSharpGL.Demos
{
    [DemoRenderer]
    partial class ShaderToyRenderer
    {
        private float timeElapsingSpeed = 1.0f;

        /// <summary>
        /// 时间流逝速度
        /// </summary>
        public float TimeElapsingSpeed
        {
            get { return timeElapsingSpeed; }
            set { timeElapsingSpeed = value; }
        }

        private float rainDrop = 1.0f;

        /// <summary>
        /// 雨滴效果强度
        /// </summary>
        public float RainDrop
        {
            get { return rainDrop; }
            set { rainDrop = value; }
        }

        private float granularity = 4.0f;

        /// <summary>
        /// 颗粒粒度
        /// </summary>
        public float Granularity
        {
            get { return granularity; }
            set { granularity = value; }
        }

        private DateTime lastTime;

        protected override void DoRender(RenderEventArgs arg)
        {
            // setup uniforms
            var now = DateTime.Now;
            float time = (float)now.Subtract(this.lastTime).TotalMilliseconds * 0.001f;
            this.SetUniform("iGlobalTime", time * timeElapsingSpeed);
            //this.SetUniform("granularity", this.granularity);
            int[] viewport = OpenGL.GetViewport();
            this.SetUniform("iResolution", new vec2(viewport[2], viewport[3]));

            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 model = mat4.identity();
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            this.SetUniform("modelMatrix", model);
            mat4 projectionMatrix = arg.Camera.GetProjectionMatrix();
            mat4 viewMatrix = arg.Camera.GetViewMatrix();
            mat4 modelMatrix = mat4.identity();

            base.DoRender(arg);
        }
    }
}