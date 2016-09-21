# Unimation

Unimation is an animation toolbox for Unity 2D and 3D games. The aim is to provide simple access to common animation requirements such as scaling, moving and rotating to all `GameObjects`.

## Features
- Several built-in animations such as scaling, moving, and rotating `GameObjects`.
- Defining animation durations.
- Animation interpolators, providing simple access to linear, accelerated, and decelerated animations.
- Full support for Free and Pro versions of Unity.
 
## Installation

Unimation can be installed by either cloning the Unimation repository into your project, like so:

```
cd Assets/
git clone git@github.com:KyleBanks/unimation.git
```

Or by simply [downloading Unimation as a ZIP](https://github.com/KyleBanks/unimation/archive/master.zip) and unzipping in your project.

## Usage

All Unimation animations can be run in one of two ways. The easiest way is to use the static `Unimation.Animate` methods:

```
Unimation.Animate.ScaleTo(gameObject, scale, duration);
```

The preferred way to use Unimation however, is to have your scripts extend `Unimation.Behaviour` (rather than `MonoBehaviour`), which adds access to the animation methods on the script itself:

```
public class MyScript : Unimation.Behaviour {

  void Start() {
    this.ScaleTo(scale, duration);
  }

}
```

## Animations

All Unimation animations provide common customization, such as the `Duration`, `Mode`, and `Loop Count`. The animations can all be run using the static methods on `Unimation.Animate`, or by extending `Unimation.Behaviour`.

### ScaleTo

`ScaleTo` animates the scale of the `GameObject` to the desired scale. 

- `scale` (`Vector3`) - The scale to animate to.
- `duration` (`float`) - The duration of the animation, in seconds.
- `animationMode` (`Unimation.Mode`) [*Default:* `Unimation.Mode.Linear`] - The interpolator type to use, defaults to `Linear`.
- `loopCount` (`int`) [*Default:* `0`] - The number of times to loop the animation, defaults to `0`.

**Example**
```
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
```
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
```
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
```
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
