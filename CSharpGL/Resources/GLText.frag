#version 150 core

in vec2 passUV;

uniform sampler2D fontTexture;
uniform vec3 textColor = vec3(1, 1, 1);

out vec4 color;

void main(void)
{
	vec4 textureColor = texture(fontTexture, passUV);
	color = vec4(textColor, textureColor.r);
}
