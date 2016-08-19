﻿using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    /// <summary>
    /// renders well pipeline(several cylinders)
    /// </summary>
    public class WellRenderer : Renderer, IModelSize, ILabelPosition
    {

        private UpdatingRecord wellPipelineColorRecord = new UpdatingRecord();
        private Color wellColor = Color.White;// maps to white color in shader.
        public Color WellColor
        {
            get { return wellColor; }
            set
            {
                wellColor = value;
                wellPipelineColorRecord.Mark();
            }
        }

        public static WellRenderer Create(WellModel model)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\Well.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\Well.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", WellModel.strPosition);
            var renderer = new WellRenderer(model, shaderCodes, map);
            return renderer;
        }

        /// <summary>
        /// renders well pipeline(several cylinders)
        /// </summary>
        /// <param name="model"></param>
        /// <param name="shaderCodes"></param>
        /// <param name="propertyNameMap"></param>
        /// <param name="switches"></param>
        private WellRenderer(WellModel model, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(model, shaderCodes, propertyNameMap, switches)
        {
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            var model = this.bufferable as WellModel;
            this.ModelMatrix = model.ModelMatrix;
            this.lengths = model.lengths;
            this.firstNode = model.FirstNode;
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            if (wellPipelineColorRecord.IsMarked())
            {
                this.SetUniform("wellColor", this.wellColor.ToVec4());
                wellPipelineColorRecord.CancelMark();
            }

            mat4 mvp = arg.Camera.GetProjectionMat4() * arg.Camera.GetViewMat4() * this.ModelMatrix;
            this.SetUniform("mvp", mvp);

            base.DoRender(arg);
        }

        private vec3 firstNode;
        private vec3 lengths;
        public float XLength { get { return lengths.x; } }

        public float YLength { get { return lengths.y; } }

        public float ZLength { get { return lengths.z; } }

        vec3 ILabelPosition.Position { get { return firstNode; } }
    }
}
