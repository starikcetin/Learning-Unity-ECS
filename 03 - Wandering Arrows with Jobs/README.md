# 03 - Wandering Arrows with Jobs #
Same as [project #02](/02%20-%20Wandering%20Arrows), but using jobified systems.


Learning Objectives
---
- Jobifying systems


Resources
---
- [ECS features in detail](https://github.com/Unity-Technologies/EntityComponentSystemSamples/blob/master/Documentation/content/ecs_in_detail.md)


Notes
---
Since I can't access UnityEngine.Random from inside a job, and I can't create a reference type to use System.Random, I used noise class from Unity.Mathematics.

I must admit, result looks prettier to look at.
