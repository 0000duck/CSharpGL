#version 150 core

in vec3 in_Positions;
in vec2 in_UV;

out vec2 passUV;

uniform vec3 billboardCenter_worldspace; // Position of the center of the billboard
uniform vec2 viewportSize;
uniform mat4 projection;
uniform mat4 view;

void main()
{
    // billboardSize is in pixels.
    gl_Position = projection * view * vec4(billboardCenter_worldspace, 1.0f); // Get the screen-space position of the particle's center
    gl_Position /= gl_Position.w; // Here we have to do the perspective division ourselves.
    gl_Position.xy += in_Positions.xy / viewportSize * 2; // Move the vertex in directly screen space. No need for CameraUp/Right_worlspace here.

    // UV of the vertex. No special space for this one.
    passUV = in_UV;
}
