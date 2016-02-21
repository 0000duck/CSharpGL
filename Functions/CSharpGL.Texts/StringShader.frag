#version 150 core

in vec3 passColor;
out vec4 outputColor;
in vec2 passTexCoord;
uniform sampler2D glyphTexture;

void main(void)
{
    vec4 glyphColor = texture(glyphTexture, passTexCoord);
    outputColor = vec4(passColor, 1.0f) * glyphColor;
}

