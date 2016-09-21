using UnityEngine;
using System.Collections;

namespace Unimation {
	public abstract class Interpolator {

		public float completionPercentage;

		public float initialFloat;
		public float targetFloat;

		public Vector3 initialVector3;
		public Vector3 targetVec3;

		public abstract float NextFloat();

		public abstract Vector3 NextVector3();

		public virtual void Reverse() {
			float initialFloatCopy = initialFloat;
			initialFloat = targetFloat;
			targetFloat = initialFloatCopy;

			Vector3 initialVector3Copy = initialVector3;
			initialVector3 = targetVec3;
			targetVec3 = initialVector3Copy;
		}

	}
}
