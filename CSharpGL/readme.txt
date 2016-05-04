﻿CSharpGL允许你以面向对象的方式使用OpenGL的功能。
封装了OpenGL的函数，用枚举代替部分uint参数。
提取出OpenGL中隐含的对象，用class描述他们。
提供矩阵、向量相关的数学类。
提供实用的公用class、扩展方法。

CSharpGL allows you to use OpenGL functions in the Object-Oriented way.
It wraps OpenGL’s functions and use enum type as parameters instead of ‘uint’for some functions.
It abstracts objects inside OpenGL and describes them as classes.
It provides maths class for matrix and vectors.
It provide useful utilities.

release notes:
v1.0.0.9:
1. supports picking of point, line and basic geometry(triangle, quad, polygon) from any kind of OneIndexRenderer or ZeroIndexRenderer.
2. rename *ModernRenderer*.cs to *Renderer*.cs
3. fix bug in QuadStripRecoginzer: reorder its vertexs to form a quad.(0 1 2 3 -> 0 1 3 2)
v1.0.0.2:
1. add model: BigDipper, Tetrahedron, Cube, Sphere, Teapot.
v1.0.0.1:
1. Modern rendering(Shader+VBO).
2. Color-coded-picking of primitives in a VBO.
3. Highlight picked primitives.
4. Draw text using glRasterPos() and CallList.
5. PolygonOffsetSwitch.
6. UILayout.

