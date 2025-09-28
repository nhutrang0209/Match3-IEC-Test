* Advantage: 
   - Clear high-level Folder: Resources, Scenes, Scripts, Textures
   - Prefabs grouped under Resources/prefabs so your current code that uses Resources.Load works.
   - Scripts subfolders (Board, UI, etc.) show feature-based thinking
* Disadvantage: 
   - Heavy reliance on Resources
   - Use DOTween -> GC Alloc and Overhead Runtime (if there are alot tween in a frame)
   - Do not use mono inheritance on Item and Board --> difficult to debug
   - No reference but always use string path
   - No pooling, just Instantiate and Destroy
* Suggestion: 
   - Use Addressable load instead of Resource load prefab
   - Keep Resources minimal
   - modularize code using assembly
   - Prefer direct references