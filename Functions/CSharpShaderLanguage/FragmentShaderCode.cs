﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpShaderLanguage
{
    /*
     
#version 150 core

in vec2 pass_UV;
out vec4 out_Color;
uniform sampler2D texture1;
uniform sampler2D texture2;
uniform float percent;

void main(void) 
{
	vec4 color = texture(texture1, pass_UV) * percent + texture(texture2, pass_UV) * (1.0 - percent);
	out_Color = color;
}

     */

    /// <summary>
    /// 这是一个用CSSL写的fragment shader的例子。
    /// </summary>
    class DemoFrag : FragmentShaderCode
    {
        [In]
        vec2 pass_UV;
        [Out]
        vec4 out_Color;

        [Uniform]
        sampler2D texture1;
        [Uniform]
        sampler2D texture2;
        [Uniform]
        float percent;
        public override void main()
        {
            vec4 color = texture(texture1, pass_UV) * percent + texture(texture2, pass_UV) * (1.0f - percent);
            out_Color = color;
        }

    }

    /// <summary>
    /// fragment shader共有的内容。
    /// 想写一个fragment shader，就继承此类型吧。
    /// </summary>
    public abstract class FragmentShaderCode : ShaderCode
    {
        //public override sealed string ExtensionName
        //{
        //    get { return "frag"; }
        //}

        //public override SemanticShader Dump(string fullname)
        //{
        //    return new SemanticFragmentShader(this, fullname);
        //}

        //TODO:在CSharpShaderLanguage.Convertor项目中没有区分vertex shader和fragment shader的Dump动作。目前是认为没有下面这个discard();方法的。注意注意！以后要改啊！
        /// <summary>
        /// 代表GLSL里的discard;语句。
        /// </summary>
        protected void discard() { }

    }
}
