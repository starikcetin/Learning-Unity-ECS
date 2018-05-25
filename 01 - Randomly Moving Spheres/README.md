# 01 - Randomly Moving Spheres #
Creating an arbitrary amount of spheres that moves in random direction.


Learning Objectives
---
- Initializing an ECS project
- Bootstrapping


Resources
---
- [Unity ECS Basics - Getting Started - With 100,000 Tacos](https://www.youtube.com/watch?v=lDTyCYAtQyQ)


Notes
---
On my laptop (Nvidia GTX 850M & Intel Core i7), the GPU runs at 95% while the CPU sits at around 30% for 20k spheres.

This is a very simple setup that does not include much CPU work. But still, seeing the bottleneck is at GPU and not CPU is pretty impressive.
