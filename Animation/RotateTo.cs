using System;
using UnityEngine;

namespace Unimation {
	public class RotateTo : Unimation.Animation {

		void Start() {
			interpolator.initialVector3 = transform.rotation.eulerAngles;
		}

		protected override void Tick() {
			Quaternion rotation = transform.rotation;
			rotation.eulerAngles = interpolator.NextVector3();
			transform.rotation = rotation;
		}

		public void SetDegrees(Vector3 degrees) {
			interpolator.targetVec3 = degrees;
		}

		public Vector3 GetDegrees() {
			return interpolator.targetVec3;
		}

	}
}

