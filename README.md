# Nat1Wizard Event System

Unity Package for a Scriptable Object Based Event System.

## Description

This repository contains a Unity package for a simple scriptable object based event system designed to facilitate script communication across scenes without spaghetti references or anti-patterns (like singletons).

The system works by creating _Game Events_, which are scriptable objects that can be invoked to pass data. 
When invoking the created game event, you pass a (possibly null) instance of the _Game Event Context_ class, which can hold any object as data.
To listen for game event invokation, add the _Game Event Listener_ monobehavior to a game objects, and set the callback method which recieves the Game Event Context.

## Getting Started

### Installation

The event system can be [installed through the Unity Package Manager](https://docs.unity3d.com/Manual/upm-ui-giturl.html) using this repository's git URL:

```https://github.com/kbvatral/SO-Event-System```

### Basic Usage
* Create a _Game Event_ scriptable object for your event
* Pass a reference of this scriptable object to the invoking class
* Add the _Game Event Listener_ monobehavior to the receiving game object
    * Set the `Game Event` parameter of this monobehavior to the desired game event scriptable object
    * Set the `Callback` Unity event to invoke the desired behaviors when the game event is invoked. These callback methods can optionally take a `GameEventContext` parameter.
* In the invoking class, invoke the game event scriptable object, which optional context parameters
    * `gameEvent.Invoke()` will invoke the event with a null context. Use this appoach to pass a message without any data.
    * `gameEvent.Invoke(GameEventContext ctx)` will invoke the event with the specified context object
    * `gameEvent.Invoke(Object data)` will create a new `GameEventContext` with its data set to the specified object and then invoke the event with this created context
* In the recieving class, create a callback method to handle the game event invokation and read any relevant data
    * `gameEventContext.GetData<T>` will return the data associated with the `GameEventContext` cast to type `T`. Use this to retrieve the passed data from the invoking class.
    * _Note_: The `GetData<T>` will attempt to cast the passed data to the specified type regardless of what was passed. If the cast is unsuccessful, it will return `default(T)`.
    * _Note_: The `GameEventContext` will not handle objects which no longer exist (e.g., garbage collected or destroyed by Unity), so take extra care to check the resulting data if using in a case where this may happen.

## Version History

* 1.0.0
    * Initial Public Release

## License

This project is licensed under the GPL 3.0 License - see the LICENSE file for details

## Acknowledgments

Portions of this codebase were adapted and expanded from the [Game Events Unity Tutorial by Jason Weimann](https://www.youtube.com/watch?v=lgA8KirhLEU).