tiled-xna
=========

C# and XNA implementation of Tiled map reader. http://www.mapeditor.org/

Drawing the map is specific to XNA, but reading the Tiled file format should be useful for any framework using C#.

On the XBox360, GZip compression requires a class not present in the 360's version of the .NET runtime. See Releases for more information.

TRCCompSci
==========

In order to make this more student friendly i have added a method to the Layer class to return the texture of a given tile ID. Students using per pixel collision found it impossible to obtain the texture of a collided tile, this was because tiled-xna seems to store the tileset image for each tile and a rectangle for the tiles position in the tileset.
