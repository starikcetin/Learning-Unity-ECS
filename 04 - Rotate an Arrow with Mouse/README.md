# 04 - Rotate an Arrow with Mouse #
Rotating a single 3D arrow around itself using mouse controls. 

Hold down *Mouse 0* and move your mouse.


Learning Objectives
---
- Transfer information from Unity classes to ECS.
- Multiple injection groups in systems.
- Entity creation and destruction in systems.


Notes
---
 - The `math.euler` method of `Unity.Mathematics` is throwing `NotImplementedException`. So in `RotateWithMouseInputSystem`, I constructed two different `quaternion`s using `math.angleAxis` and multiplied them using `math.mul`, essentially getting the same result.

  - You can inject `EntityManager`s into systems. That is amazing. The more I play with ECS, the more I come to love it.
 
 - It would be cool if they added the standard math operators to `quaternion` of `Unity.Mathematics`. I suppose this will come with time, since even some of the methods are yet to be implemented in the library.
 
 - Mouse input should be written to a single component on a single entity, and not to everyone who needs it. Or maybe a shared component if you are feeling fancy. This should be a simple conversion, maybe I will do it sometime.
