namespace CSharpGL
{
    using System.Drawing;
    using System.IO;

    /// <summary>
    /// Renderer of PointCloud
    /// </summary>
    public partial class RandomPointsRenderer : CSharpGL.Renderer
    {
        // you can replace PointCloudModel with IBufferable in the method's parameter.
        public static RandomPointsRenderer Create(RandomPointsModel model)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\RandomPoints.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\RandomPoints.frag"), ShaderType.FragmentShader);
            var map = new CSharpGL.PropertyNameMap();
            map.Add("in_Position", RandomPointsModel.position);
            var renderer = new RandomPointsRenderer(model, shaderCodes, map);
            renderer.Lengths = model.Lengths;
            //renderer.switchList.Add(new PointSizeSwitch(10));
            return renderer;
        }

        private RandomPointsRenderer(CSharpGL.IBufferable bufferable, CSharpGL.ShaderCode[] shaderCodes, CSharpGL.PropertyNameMap propertyNameMap, params GLSwitch[] switches) :
            base(bufferable, shaderCodes, propertyNameMap, switches)
        {
        }

        protected override void DoRender(CSharpGL.RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            if (this.modelMatrixRecord.IsMarked())
            {
                mat4 model = this.GetModelMatrix();
                this.SetUniform("modelMatrix", model);
                this.modelMatrixRecord.CancelMark();
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