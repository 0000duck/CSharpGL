namespace CSharpGL.LightEffects
{
    // 不可将此文件中的代码复制到其他文件内（如果包含了其他的using ...;，那么CSSL2GLSL.exe就无法正常编译这些代码了。）
    using CSharpShadingLanguage;

#if DEBUG

    /// <summary>
    /// 一个<see cref="DiffuseReflectionVert"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// 这就是C#Shader形式的vertex shader。
    /// </summary>
    [Dump2File(true)]
    class DiffuseReflectionVert : VertexCSShaderCode
    {
        [In]
        vec3 in_Position;
        [In]
        vec3 in_Color;

        [Out]
        vec4 pass_Color;

        [Uniform]
        mat4 modelMatrix;
        [Uniform]
        mat4 viewMatrix;
        [Uniform]
        mat4 projectionMatrix;

        public override void main()
        {
            gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0f);

            pass_Color = vec4(in_Color, 1.0f);
        }
    }

    /// <summary>
    /// 一个<see cref="DiffuseReflectionFrag"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// 这就是C#Shader形式的fragment shader。
    /// </summary>
    class DiffuseReflectionFrag : FragmentCSShaderCode
    {
        [In]
        vec4 pass_Color;

        [Out]
        vec4 out_Color;

        public override void main()
        {
            out_Color = pass_Color;
        }
    }

#endif
}
