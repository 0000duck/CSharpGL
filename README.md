# :art:Welcome to CSharpGL
[CSharpGL @ nuget](https://www.nuget.org/packages/CSharpGL) 

[CSharpGL](https://github.com/bitzhuwei/CSharpGL) is a pure C# project that allows for modern OpenGL rendering in an Object-Oriented way. It meets common requirements in OpenGL rendering such as:
## :rocket:Modern Rendering
High-efficiency rendering of massive vertexes is supported by Object-Oriented modern rendering using GLSL shaders and vertex buffer objects.  
![modern-rendering](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/modern-rendering.png?raw=true)
## :stars:GLCanvas
A winform control that supports drag-drop and wraps initialization of creating OpenGL context.
![raycast-volume-rendering](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/GLCanvas.gif?raw=true)
## :car:Uniform Variables
structs support setting values for uniform variables in GLSL shader.
![edit-uniform-value](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/edit-uniform-value.jpg?raw=true)
## :cancer:GLSwitch
Wraps OpenGL commands like 
```
glEnable(GL_BLEND);
glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_DST_ALPHA);
...
glDisable(GL_BLEND);
```
or
``glLineWidth(2.0f);``
![GLSwitch](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/GLSwitch.jpg?raw=true)
## :pushpin:Color-Coded Picking
PickableRenderer supports picking primitives in multiple vertex buffer objects using Mouse.  
![pick and move primitive](http://images2015.cnblogs.com/blog/383191/201605/383191-20160503191610388-117673971.gif)
## :radio_button::ballot_box_with_check::white_square_button:GLControl & Text
Rendering 'Control' at fixed position with fixed size. For example, GLAxis renders an axis at left bottom corner.
'Control' binding to specified border just like winform-control.
Rendering text using ``glRasterPos()`` and ``CallList()``.
Rendering text using GLText(a special GLControl).
![GLText and GLAxis](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/GLText-GLAxis.png?raw=true)

![export-glyph-texture-from-TTF](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/glyph-texture.png?raw=true)
# :gem:Some Cool Demos
## Image Processing Using Compute Shader.
![compute-shader-image-processing](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/compute-shader-edge-detection.gif?raw=true)
## Raycast Volume Rendering.
![raycast-volume-rendering](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/raycast-volume-render.gif?raw=true)
## Particle Simulator Using Compute Shader.
![compute-shader-particles](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/compute-shader-particles.gif?raw=true)  
![compute-shader-particles](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/compute-shader-particles.jpg?raw=true)
## Order-Dependent Transparency VS Order-Independent Transparency.
![order-independent-transparency](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/order-independent-transparency.jpg?raw=true)
## Point Sprite.
10000 particles with a sphere inside a cube.
![point-sprite](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/point-sprite.png?raw=true)  
![point-sprite](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/point-sprite2.png?raw=true)
## Earth.
An earth model that singly rotate same as real earth. It's composed of 65341 positions, normals and uvs and 130140 indexes and a 10800x5400 texture.
![earth](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/earth.gif?raw=true)
## :id::100:Billboard
Billboard can be used to display health-bar, damage numbers in game application.
![billboard-health-bar-text](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/billboard-health-bar-text.png?raw=true)
## :movie_camera:Scene Editor
Useful tool to build a scene and feels how opengl's transform system works.
![CSharpGL-Scene-Editor](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/CSharpGL-Scene-Editor.jpg?raw=true)
# :question:Support or Contact
Check my blog [here](http://www.cnblogs.com/bitzhuwei/) or join my QQ Group<a target="_blank" href="http://shang.qq.com/wpa/qunwpa?idkey=98131e619f6da03b96ad2213a1278da4fdd05b42a58d053125ce6ba76cf991f9"><img border="0" src="http://pub.idqqimg.com/wpa/images/group.png" alt="开源CSharpGL群 (C#+OpenGL)" title="CSharpGL (C#+OpenGL)"></a>.
