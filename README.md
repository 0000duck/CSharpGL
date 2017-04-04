<img align="right" src="https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/earth/earth-64-60.gif?raw=true" alt="CSharpGL" style="float:right">  
# Object Oriented OpenGL in C\#  
:crystal_ball:[Wiki](https://github.com/bitzhuwei/CSharpGL/wiki) | :egg:[nuget](https://www.nuget.org/packages/CSharpGL) | :bread:[CSharpGL.dll](https://raw.githubusercontent.com/bitzhuwei/CSharpGL/master/CSharpGL/CSharpGL.dll)  
[CSharpGL](https://github.com/bitzhuwei/CSharpGL) is a 3D graphics library based on OpenGL in pure C#. It wraps OpenGL API(buffer, shader, state, texture, matrix etc) and demonstrates how to express high-level functions(scene, text, picking, UI etc) with CSharpGL library.  
![modern-rendering](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/modern-rendering.gif?raw=true)
## :pushpin:Color-Coded Picking
`IColorCodedPicking` supports picking primitives in multiple vertex buffer objects using Mouse.  
![pick and move primitive](http://images2015.cnblogs.com/blog/383191/201605/383191-20160503191610388-117673971.gif)
## :radio_button::ballot_box_with_check:`UIRenderer` & Text
Rendering 'Control' at fixed position with fixed size.  
For example, ``UIAxis`` renders an axis at left bottom corner.  
All kinds of controls binds to specified border just like winform-control.  
Rendering text using ``glRasterPos()`` and ``CallList()``.(Obsolete)  
Rendering text using ``UIText``.  
![UIText and UIAxis](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/GLText-GLAxis.png?raw=true)

![export-glyph-texture-from-TTF](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/glyph-texture.png?raw=true)
# :gem:Some Cool Demos
## Image Processing using Compute Shader.
Simple edge-detection implemented by compute shader.  
![compute-shader-image-processing](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/compute-shader-edge-detection.gif?raw=true)
## Raycast Volume Rendering using 3D texture.
![raycast-volume-rendering](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/raycast-volume-render.gif?raw=true)
## Particle Simulator using Compute Shader.
Particle's speed and position is updated by compute shader.  
![compute-shader-particles](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/compute-shader-particles.gif?raw=true)  
![compute-shader-particles](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/compute-shader-particles2.gif?raw=true)
## Order-Dependent Transparency VS Order-Independent Transparency.
![order-independent-transparency](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/order-independent-transparency.jpg?raw=true)
## Point Sprite.
10000 particles with a sphere inside a cube.
![point-sprite](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/point-sprite.png?raw=true)
## Generated Klein Bottle.
![Klein Bottle](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/KleinBottle.png?raw=true)
## Earth.
An earth model that singly rotates same as real earth. It's composed of 65341 positions, normals and uvs and 130140 indexes and a 10800x5400 texture.
![earth](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/earth.gif?raw=true)
## :id::100:Billboard and `LabelRenderer`
Billboard can be used to display health-bar, damage numbers in game application.
``LabelRenderer`` renders a string at specified position which always faces camera.  
![billboard-health-bar-text](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/billboard-health-bar-text.png?raw=true)
## :high_brightness:Light
ambient, diffuse and specular light effect from directional light.  
![Direcional-light](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/directional-light.gif?raw=true)
## :movie_camera:Scene Editor
Useful tool to build a scene and feels how opengl's transform system works.
![CSharpGL-Scene-Editor](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/CSharpGL-Scene-Editor.jpg?raw=true)
## :fries:Renderer Generator
RendererGenerator is a tiny console that reads an xml config file and dumps a Renderer.cs, a Model.cs, a vertex shader file(.vert) and a fragment shader file(.frag).
A demo is shown as below:
```
<?xml version="1.0" encoding="utf-8"?>
<RendererGenerator TargetName="Demo" ZeroIndexBuffer="false" DrawMode="Points">
  <VertexAttribute NameInShader="in_Position" NameInModel="position" AttributeType="vec3" />
  <VertexAttribute NameInShader="in_TexCoord" NameInModel="texCoord" AttributeType="vec2" />
</RendererGenerator>
```

# :question:Support or Contact
Check my blog [here](http://www.cnblogs.com/bitzhuwei/) or join my QQ Group<a target="_blank" href="http://shang.qq.com/wpa/qunwpa?idkey=98131e619f6da03b96ad2213a1278da4fdd05b42a58d053125ce6ba76cf991f9"><img border="0" src="http://pub.idqqimg.com/wpa/images/group.png" alt="CSharpGL(C#+OpenGL)" title="CSharpGL(C#+OpenGL)"></a>.