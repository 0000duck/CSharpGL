namespace CSharpGL.Demos
{
    using System.Drawing;
    using System.IO;

    /// <summary>
    /// Renderer of PointCloud
    /// </summary>
    [DemoRenderer]
    public partial class PointCloudRenderer : CSharpGL.Renderer
    {
        // you can replace PointCloudModel with IBufferable in the method's parameter.
        public static PointCloudRenderer Create(PointCloudModel model)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\PointCloud.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\PointCloud.frag"), ShaderType.FragmentShader);
            var map = new CSharpGL.AttributeMap();
            map.Add("in_Position", PointCloudModel.position);
            var renderer = new PointCloudRenderer(model, shaderCodes, map);
            renderer.ModelSize = model.Lengths;
            renderer.WorldPosition = model.WorldPosition;
            //renderer.switchList.Add(new PointSizeSwitch(10));
            return renderer;
        }

        private PointCloudRenderer(CSharpGL.IBufferable model, CSharpGL.ShaderCode[] shaderCodes, CSharpGL.AttributeMap attributeMap, params GLSwitch[] switches) :
            base(model, shaderCodes, attributeMap, switches)
        {
        }

        private long modelTicks;

        protected override void DoRender(CSharpGL.RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            MarkableStruct<mat4> model = this.GetModelMatrix();
            if (this.modelTicks != model.UpdateTicks)
            {
                this.SetUniform("modelMatrix", model.Value);
                this.modelTicks = model.UpdateTicks;
            }
            if (this.pointColorRecord.IsMarked())
            {
                this.SetUniform("PointColor", this.pointColor);
                this.pointColorRecord.CancelMark();
            }

            base.DoRender(arg);
        }

        private UpdatingRecord pointColorRecord = new UpdatingRecord();
        private vec3 pointColor = new vec3(1, 0, 1);

        /// <summary>
        ///
        /// </summary>
        public Color PointColor
        {
            get { return pointColor.ToColor(); }
            set
            {
                vec3 color = value.ToVec3();
                if (color != pointColor)
                {
                    this.pointColor = color;
                    pointColorRecord.Mark();
                }
            }
        }
    }
}