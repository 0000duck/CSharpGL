﻿using CSharpGL.Maths;
using CSharpGL.Objects.SceneElements;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpGL.Objects.UIs;

namespace CSharpGL.Objects.Demos.UIs
{
    public class NewSimpleUIColorIndicator : SceneElementBase//, IMVP,IUILayout
    {
        private SimpleUIColorIndicator bar;
        private SimpleUIPointSpriteStringElement[] numbers;

        public NewSimpleUIColorIndicator(IUILayoutParam param, ColorPalette colorPalette, GLColor textColor, float min, float max, float step)
        {
            this.bar = new SimpleUIColorIndicator(param, colorPalette, min, max, step);

            float[] coords = colorPalette.Coords;
            float coordLength = coords[coords.Length - 1] - coords[0];
            this.numbers = new SimpleUIPointSpriteStringElement[coords.Length];
            const float posY = -1.0f;
            this.numbers[0] = new SimpleUIPointSpriteStringElement(
                param, (-100.0f).ToShortString(), new vec3(-0.5f, posY, 0), textColor, 20);
            for (int i = 1; i < coords.Length; i++)
            {
                float x = (coords[i] - coords[0]) / coordLength - 0.5f;
                if (i + 1 == coords.Length)
                {
                    var number = new SimpleUIPointSpriteStringElement(param,
                        (100.0f).ToShortString(), new vec3(x, posY, 0), textColor, 20);
                    this.numbers[i] = number;
                }
                else
                {
                    var number = new SimpleUIPointSpriteStringElement(param,
                        (-100.0f + i * (100 - (-100)) / 5).ToShortString(), new vec3(x, posY, 0), textColor, 20);
                    this.numbers[i] = number;
                }
            }
        }

        protected override void DoInitialize()
        {
            this.bar.Initialize();
            this.bar.BeforeRendering += bar_BeforeRendering;
            this.bar.AfterRendering += bar_AfterRendering;

            foreach (var item in this.numbers)
            {
                item.Initialize();
                item.BeforeRendering += number_BeforeRendering;
                item.AfterRendering += number_AfterRendering;
            }
        }

        void number_AfterRendering(object sender, RenderEventArgs e)
        {
            IMVP element = sender as IMVP;

            element.UnbindShaderProgram();
        }

        void number_BeforeRendering(object sender, RenderEventArgs e)
        {
            mat4 projectionMatrix, viewMatrix, modelMatrix;

            {
                IUILayout element = sender as IUILayout;
                element.GetMatrix(out projectionMatrix, out viewMatrix, out modelMatrix);
            }

            {
                mat4 mvp = projectionMatrix * viewMatrix * modelMatrix;

                IMVP element = sender as IMVP;

                element.UpdateMVP(mvp);
            }
        }

        void bar_AfterRendering(object sender, RenderEventArgs e)
        {
            SimpleUIColorIndicator element = sender as SimpleUIColorIndicator;

            element.shaderProgram.Unbind();
        }

        void bar_BeforeRendering(object sender, RenderEventArgs e)
        {
            mat4 projectionMatrix, viewMatrix, modelMatrix;
            {
                IUILayout element = sender as IUILayout;

                element.GetMatrix(out projectionMatrix, out viewMatrix, out modelMatrix);
            }

            {
                SimpleUIColorIndicator element = sender as SimpleUIColorIndicator;

                ShaderProgram shaderProgram = element.shaderProgram;

                shaderProgram.Bind();

                shaderProgram.SetUniformMatrix4(SimpleUIColorIndicator.strprojectionMatrix, projectionMatrix.to_array());
                shaderProgram.SetUniformMatrix4(SimpleUIColorIndicator.strviewMatrix, viewMatrix.to_array());
                shaderProgram.SetUniformMatrix4(SimpleUIColorIndicator.strmodelMatrix, modelMatrix.to_array());
            }
        }

        protected override void DoRender(RenderEventArgs e)
        {
            this.bar.Render(e);

            foreach (var item in this.numbers)
            {
                item.Render(e);
            }
        }

        public IUILayoutParam Param { get; set; }
    }
}
