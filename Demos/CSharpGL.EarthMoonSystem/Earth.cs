﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.EarthMoonSystem
{
    class Earth : ITimeElapse
    {
        /// <summary>
        /// 自转角速度（单位： X°每毫秒）
        /// </summary>
        public const double singleRotationSpeed = 360.0 / 24 / 60 / 60 / 1000;//
        // 每秒自转1周。用于测试应该用角度还是弧度（结果是应该用弧度）。
        //public const double singleRotationSpeed = 360.0 / 3000.0;//°每毫秒

        /// <summary>
        /// 自转轴（地轴）倾斜角度66.34°
        /// </summary>
        public const double singleRotationAxisAngle = 66.0 + 34.0 / 60.0;//66.34°
        /// <summary>
        /// 自转轴（地轴）倾斜弧度
        /// </summary>
        public const double singleRotationAxisRadian = singleRotationAxisAngle * Math.PI / 180.0;
        /// <summary>
        /// 自转轴（地轴）
        /// </summary>
        public static readonly vec3 singleRotationAxis = new vec3(
            (float)Math.Cos(singleRotationAxisRadian),
            (float)Math.Sin(singleRotationAxisRadian),
            0f
            );
        /// <summary>
        /// 地球半径：(赤道半径 + 极半径) / 2，单位：千米
        /// </summary>
        public const double radius = (6378137 + 6356752) / 2;

        /// <summary>
        /// 当前的自转角度
        /// </summary>
        public double SingleRotationAngle { get; private set; }

        /// <summary>
        /// 当前的自转弧度
        /// </summary>
        public double SingleRotationRadian
        {
            get
            {
                return this.SingleRotationAngle * Math.PI / 180.0;
            }
        }

        public void Elapse(double interval)
        {
            double angle = this.SingleRotationAngle + singleRotationSpeed * interval;
            if (360 < angle)
            {
                angle = angle % 360;
            }

            this.SingleRotationAngle = angle;
        }

        public mat4 GetModelRotationMatrix()
        {
            mat4 model = glm.rotate((float)this.SingleRotationRadian, new vec3(0, 1, 0));
            model = glm.rotate((float)(Math.PI / 2 - Earth.singleRotationAxisRadian), new vec3(0, 0, -1)) * model;
            return model;
        }
        public override string ToString()
        {
            return string.Format("Single Rotation: {0}°", this.SingleRotationAngle);
        }
    }
}
