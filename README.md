# Unimation

Unimation is an animation toolbox for Unity 2D and 3D games. The aim is to provide simple access to common animation requirements such as scaling, moving and rotating to all `GameObjects`.

For an explanation of Unimation and why it was created, as well as some sample GIFs, check out [this blog post](https://kylewbanks.com/blog/easier-2d-and-3d-unity-animations-using-unimation).

## Features
- Several built-in animations such as scaling, moving, and rotating `GameObjects`.
- Custom animation durations.
- Looping animations for a set number of iterations, or infinite looping.
- Animation interpolators, providing simple access to linear, accelerated, and decelerated animations. (*Coming soon: Only `Linear` is supported at the moment.*)
- Fully functional on Free and Pro versions of Unity.
 
## Installation

Unimation can be installed by either [downloading Unimation as a ZIP](https://github.com/KyleBanks/unimation/archive/master.zip) and unzipping in your project, or by cloning the Unimation repository into your project, like so:

```sh
cd Assets/
git clone git@github.com:KyleBanks/unimation.git
```

## Usage

All Unimation animations can be run in one of two ways. The easiest way is to use the static `Unimation.Animate` methods:

```cs
Unimation.Animate.ScaleTo(gameObject, scale, duration);
```

However the preferred way to use Unimation, is to have your scripts extend `Unimation.Behaviour` (rather than `MonoBehaviour`), which adds access to the animation methods on the script itself:

```cs
public class MyScript : Unimation.Behaviour {

  void Start() {
    this.ScaleTo(scale, duration);
  }

}
```

### Looping

By default, animations do not loop - they animate to the desired state and are marked **complete**. However, they can be set to loop a desired number of times by providing a positive integer as the loop parameter to an animation, or by using `Unimation.Animation.LoopInfinite` to have the animation loop infinitely.

When looping, the initial state of the animating property is captured and the animation animates back to this state before animating again. 

For example, given a `GameObject` with an initial scale of `Vector3.one`, and animating using  `ScaleTo` with a scale of `Vector3.zero` and an initial scaleloop count of `3` and a duration of `1f` loops like so:

| Time  | Scale |
| ------------- | ------------- |
| `0s` (Before Animation) | `Vector3.one` |
| `1s` | `Vector3.zero` |
| `2s` | `Vector3.one` |
| `3s` (Animation Complete) | `Vector3.zero` |


### Interpolators

Interpolators define the style and easing of the animation.

- `Linear` (**Default**) animations animate evenly from start to finish.
- `Accelerate` animations start slowly, and speed up as the animation progresses.
- `Decelerate` animations start quickly, and slow down as the animation progresses.

### Animation State

All animation methods return a `Unimation.Animation` subclass of the appropriate type. For instance, `ScaleTo` returns a `ScaleTo` object.

You can use the returned animation object to check on the status of the animation using the following methods and properties:

#### GetCompletionPercentage 

Returns a `float` in the range of `0.0f` and `1.0f` indicating what percentage of the animation (in the current loop) has completed. For instance, calling `GetCompletionPercentage` on an animation with a duration of `4f` (four seconds) after two seconds would return `0.5f.

#### GetRemainingPercentage

Returns a `float` in the range of `0.0f` and `1.0f` indicating what percentage of the animation (in the current loop) is remaining. This is the inverse of `GetCompletionPercentage`.

#### Animation.complete

Each `Unimation.Animation` contains a `bool complete` property that is `true` when all loops (if any) of the animation have been completed.

## Animations

All Unimation animations provide common customization, such as the `Duration`, `Mode`, and `Loop Count`. The animations can all be run using the static methods on `Unimation.Animate`, or by extending `Unimation.Behaviour`.

### ScaleTo

`ScaleTo` animates the scale of the `GameObject` to the desired scale. 

- `scale` (`Vector3`) - The scale to animate to.
- `duration` (`float`) - The duration of the animation, in seconds.
- `animationMode` (`Unimation.Mode`) [*Default:* `Unimation.Mode.Linear`] - The interpolator type to use, defaults to `Linear`.
- `loopCount` (`int`) [*Default:* `0`] - The number of times to loop the animation, defaults to `0`.

**Example**
```cs
// Subclassing
public class MyScript : Unimation.Behaviour {
  
  void Start() {
    ScaleTo(Vector3.zero, 3.0f, Unimation.Mode.Linear, Unimation.Animation.LoopInfinite);
  }
  
}

// Static
Unimation.Animate.ScaleTo(this.gameObject, Vector3.zero, 3.0f, Unimation.Mode.Linear, 3);
```

### ScaleIn

`ScaleIn` animates the scale of the `GameObject` to `(1, 1, 1)`.

- `duration` (`float`) - The duration of the animation, in seconds.
- `animationMode` (`Unimation.Mode`) [*Default:* `Unimation.Mode.Linear`] - The interpolator type to use, defaults to `Linear`.
 
**Example**
```cs
// Subclassing
public class MyScript : Unimation.Behaviour {
  
  void Start() {
    ScaleIn(3.0f, Unimation.Mode.Linear);
  }
  
}

// Static
Unimation.Animate.ScaleIn(3.0f, Unimation.Mode.Linear);
```

### ScaleOut

`ScaleOut` animates the scale of the `GameObject` to `(0, 0, 0)`.

- `duration` (`float`) - The duration of the animation, in seconds.
- `animationMode` (`Unimation.Mode`) [*Default:* `Unimation.Mode.Linear`] - The interpolator type to use, defaults to `Linear`.

**Example**
```cs
// Subclassing
public class MyScript : Unimation.Behaviour {
  
  void Start() {
    ScaleOut(3.0f, Unimation.Mode.Linear);
  }
  
}

// Static
Unimation.Animate.ScaleOut(3.0f, Unimation.Mode.Linear);
```

### MoveTo

`MoveTo` animates the position of the `GameObject` to the desired location.

- `position` (`Vector3`) - The position to animate to.
- `duration` (`float`) - The duration of the animation, in seconds.
- `animationMode` (`Unimation.Mode`) [*Default:* `Unimation.Mode.Linear`] - The interpolator type to use, defaults to `Linear`.
- `loopCount` (`int`) [*Default:* `0`] - The number of times to loop the animation, defaults to `0`.

**Example**

```cs
// Subclassing
public class MyScript : Unimation.Behaviour {
  
  void Start() {
    MoveTo(new Vector3(new Vector3(10f, 8f, 6f), 3.0f, Unimation.Mode.Linear, Unimation.Animation.LoopInfinite);
  }
  
}

// Static
Unimation.Animate.MoveTo(this.gameObject, new Vector3(10f, 8f, 6f), 3.0f, Unimation.Mode.Linear, Unimation.Animation.LoopInfinite);
```

### RotateTo

`RotateTo` animates the rotation of the `GameObject` to the desired rotation in degrees.

- `degrees` (`Vector3`) - The degrees to animate to.
- `duration` (`float`) - The duration of the animation, in seconds.
- `animationMode` (`Unimation.Mode`) [*Default:* `Unimation.Mode.Linear`] - The interpolator type to use, defaults to `Linear`.
- `loopCount` (`int`) [*Default:* `0`] - The number of times to loop the animation, defaults to `0`.

**Example**

```cs
// Subclassing
public class MyScript : Unimation.Behaviour {
  
  void Start() {
    RotateTo(new Vector3(new Vector3(45f, 45f, 0f), 3.0f, Unimation.Mode.Linear, Unimation.Animation.LoopInfinite);
  }
  
}

// Static
Unimation.Animate.RotateTo(this.gameObject, new Vector3(45f, 45f, 0f), 3.0f, Unimation.Mode.Linear, Unimation.Animation.LoopInfinite);
```
## License

```
MIT License

Copyright (c) 2016 Kyle Banks

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```
