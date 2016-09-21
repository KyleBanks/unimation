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
using System;
using UnityEngine;

namespace Unimation {
	
	public abstract class Animation : MonoBehaviour {

		public static int LoopInfinite = -1;

		public float duration;
		public int loopCount;
		public bool complete;

		protected Unimation.Interpolator interpolator;

		private float deltaTime;
		private float elapsedTime;
		private int completedLoops;

		void Update() {
			if (complete) {
				return;
			}

			deltaTime = Time.deltaTime;
			elapsedTime += deltaTime;

			float completion = GetCompletionPercentage();
			interpolator.completionPercentage = completion;
			Tick();

			if (elapsedTime >= duration) {
				elapsedTime = duration;
				completedLoops ++;

				if (loopCount < 0 || loopCount > completedLoops) {
					Reverse();
				} else {
					complete = true;
				}
			}
		}

		protected abstract void Tick();

		public void SetAnimationMode(Unimation.Mode animationMode) {
			switch (animationMode) {
			case Unimation.Mode.Linear:
			default:
				interpolator = new LinearInterpolator();
				break;
			}
		}

		public float GetCompletionPercentage() {
			return duration > 0.0f ? 
				Mathf.Min(1.0f, Mathf.Max(0f, elapsedTime / duration)) : 
				0f;
		}

		public float GetRemainingPercentage() {
			return 1.0f - GetCompletionPercentage();
		}

		protected float GetDeltaTime() {
			return deltaTime;
		}

		protected void Reverse() {
			elapsedTime = 0f;
			interpolator.Reverse();
		}

	}

}

