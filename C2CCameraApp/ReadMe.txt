The application has been built as publish/subscriber architecture approach.
The client sends some kinds of commands to communication channel then the camera application handle the commands.
The client here is a part of internal micro apps system.
To initialize communication between the client and camera the client has to get specific camera identifier which provides camera app. 
Therefore the camera app publish the command to retrieve camera guid, so the client has to subscribe on that.
Finally, the client is able to publish command to control camera state.

The application includes 3 parts:
1) The camera application. Includes domain logic layer, infrastructure layer, application layer.
 a) The domain layer defines behavior and state of the camera objects. 
 There are 2 camera objects: fixed camera, quadcopter camera.
 The fixed camera object describes standart fixed camera object connected to PC and provides trivial operations: 
 turn on/off, zoom, speed up/slow down mode.
 The quadcopter camera object provides based operations of the previous one as well, but the same time it has movement support. 
 So, for that we can specify a point as x, y, z coordinates to move flying camera.
 b) The infrastructure layer defines wrapper of the physical device to persist and apply some settings to the physical device.
 Here we have a device storage object that provides operation to interact with physical device. 
  Just imagine, 'Create' method possibly register some devices into operation system of PC with 
specified settings and identifier from domain object.
'Update' method apply some settings from domain object to physical device.
'GetById' method retrieve device with specified guid from operation system level.
c) The camera  app layer defines some commands and command handlers to interact with external services. 
The type of the camera defines here. So i supposed that client should not define the camera type.

2) The communication channel is publish/subscriber pattern implementation to interact between different kind of apps.
The benefit of the approach is the publishers are not be aware about subscribers. 
Here is not dorectly dependencies between apps. Therefore communication between apps take place only through the channel

3) The client app is a console app as entry point of apps. Here is possibly to define some client command handlers.


