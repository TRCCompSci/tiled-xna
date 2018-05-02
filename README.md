tiled-xna
=========

C# and XNA implementation of Tiled map reader. http://www.mapeditor.org/

Drawing the map is specific to XNA, but reading the Tiled file format should be useful for any framework using C#.

On the XBox360, GZip compression requires a class not present in the 360's version of the .NET runtime. See Releases for more information.

TRCCompSci
==========

In order to make this more student friendly i have added a method to the Layer class to return the texture of a given tile ID. Students using per pixel collision found it impossible to obtain the texture of a collided tile, this was because tiled-xna seems to store the tileset image for each tile and a rectangle for the tiles position in the tileset.

I have added the code to support zlib compressed tmx maps (this is the default in tiled after all).

I have changed the Draw method of the map to draw the layers and objectgroups combined in alphabetical order. This means you can have layers drawn over the top of objects.

I have added the code to read in polyline and polygon objects from the map. PointList will be available to access all of the coordinates.

The current code can draw isometric maps with a RightDown tile render order, i could probably also support other options but this will be low priority. The layers and the object will be drawn in the correct locations, there is a slight movement of the objects has the map moves. This is due to how it draws based on the tile row and tile column. I will look into improving this.
