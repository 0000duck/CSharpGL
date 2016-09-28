namespace CSharpGL.OBJFileViewer
{
    using CSharpGL;
    using CSharpGL.OBJFile;
    using System.Drawing;
    using System.IO;

    /// <summary>
    /// Renders one of the models in a *.obj file.
    /// </summary>
    public class OBJModelRenderer : Renderer
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="singleModel"></param>
        /// <returns></returns>
        public static OBJModelRenderer Create(OBJModel singleModel)
        //, Bitmap bitmap)
        {
            var model = new OBJModelAdpater(singleModel);
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\OBJModel.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\OBJModel.frag"), ShaderType.FragmentShader);
            var map = new AttributeNameMap();
            map.Add("in_Position", OBJModelAdpater.strin_Position);
            map.Add("in_uv", OBJModelAdpater.strin_uv);
            //map.Add("in_Normal", OBJModelAdpater.strin_Normal);
            var renderer = new OBJModelRenderer(model, shaderCodes, map);

            return renderer;
        }

        private OBJModelRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeNameMap attributeNameMap, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeNameMap, switches)
        {
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();
        }

        public void SetTexture(Bitmap bitmap)
        {
            if (bitmap != null)
            {
                var texture = new Texture(TextureTarget.Texture2D, bitmap,
                    new SamplerParameters(
                        TextureWrapping.Repeat, TextureWrapping.Repeat, TextureWrapping.Repeat,
                        TextureFilter.Linear, TextureFilter.Linear));
                texture.Initialize();
                this.SetUniform("tex", texture);
            }
        }
        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            this.SetUniform("modelMatrix", model);

            base.DoRender(arg);
        }
    }
}