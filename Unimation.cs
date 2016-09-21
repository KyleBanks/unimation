/**
 * The MIT License (MIT)
 * Copyright (c) 2016 Kyle Banks
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */
using UnityEngine;
using System.Collections;

namespace Unimation {

	public enum Mode {
		Linear = 0
	}
		
	public static class Util {

		// --- ScaleTo --- //

		public static ScaleTo ScaleTo(GameObject gameObject, Vector3 scale, float duration, Unimation.Mode animationMode = Unimation.Mode.Linear, int loopCount = 0) {
			ScaleTo scaleTo = gameObject.AddComponent<ScaleTo>();
			scaleTo.SetAnimationMode(animationMode);
			scaleTo.duration = duration;
			scaleTo.loopCount = loopCount;
			scaleTo.SetScale(scale);

			return scaleTo;
		}

		public static ScaleTo ScaleOut(GameObject gameObject, float duration, Unimation.Mode animationMode = Unimation.Mode.Linear) {
			return ScaleTo(gameObject, Vector3.zero, duration, animationMode, 0);
		}

		public static ScaleTo ScaleIn(GameObject gameObject, float duration, Unimation.Mode animationMode = Unimation.Mode.Linear) {
			return ScaleTo(gameObject, Vector3.one, duration, animationMode, 0);
		}


		// --- MoveTo --- //

		public static MoveTo MoveTo(GameObject gameObject, Vector3 position, float duration, Unimation.Mode animationMode = Unimation.Mode.Linear, int loopCount = 0) {
			MoveTo moveTo = gameObject.AddComponent<MoveTo>();
			moveTo.SetAnimationMode(animationMode);
			moveTo.duration = duration;
			moveTo.loopCount = loopCount;
			moveTo.SetPosition(position);

			return moveTo;
		}

		// --- RotateTo --- //

		public static RotateTo RotateTo(GameObject gameObject, Vector3 degrees, float duration, Unimation.Mode animationMode = Unimation.Mode.Linear, int loopCount = 0) {
			RotateTo rotateTo = gameObject.AddComponent<RotateTo>();
			rotateTo.SetAnimationMode(animationMode);
			rotateTo.duration = duration;
			rotateTo.loopCount = loopCount;
			rotateTo.SetDegrees(degrees);

			return rotateTo;
		}
	}

	public class Behaviour : MonoBehaviour {

		// --- ScaleTo --- //

		public ScaleTo ScaleTo(Vector3 scale, float duration, Unimation.Mode animationMode = Unimation.Mode.Linear, int loopCount = 0) {
			return Unimation.Util.ScaleTo(this.gameObject, scale, duration, animationMode, loopCount);
		}

		public ScaleTo ScaleOut(float duration, Unimation.Mode animationMode = Unimation.Mode.Linear) {
			return ScaleTo(Vector3.zero, duration, animationMode, 0);
		}

		public ScaleTo ScaleIn(float duration, Unimation.Mode animationMode = Unimation.Mode.Linear) {
			return ScaleTo(Vector3.one, duration, animationMode, 0);
		}

		// --- MoveTo --- //

		public MoveTo MoveTo(Vector3 position, float duration, Unimation.Mode animationMode = Unimation.Mode.Linear, int loopCount = 0) {
			return Unimation.Util.MoveTo(this.gameObject, position, duration, animationMode, loopCount);
		}

		// --- RotateTo --- //

		public RotateTo RotateTo(Vector3 degrees, float duration, Unimation.Mode animationMode = Unimation.Mode.Linear, int loopCount = 0) {
			return Unimation.Util.RotateTo(this.gameObject, degrees, duration, animationMode, loopCount);
		}

	}

}
