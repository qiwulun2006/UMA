﻿using UnityEngine;
using System.Collections;

namespace UMA
{
	public class ForearmTwistSlotScript : MonoBehaviour 
	{
		static int leftHandHash;
		static int rightHandHash;
		static int leftTwistHash;
		static int rightTwistHash;
		static bool hashesFound = false;

		public void OnDnaApplied(UMAData umaData)
		{
			if (!hashesFound)
			{
				leftHandHash = UMASkeleton.StringToHash("LeftHand");
				rightHandHash = UMASkeleton.StringToHash("RightHand");
				leftTwistHash = UMASkeleton.StringToHash("LeftForeArmTwist");
				rightTwistHash = UMASkeleton.StringToHash("RightForeArmTwist");
				hashesFound = true;
			}

			GameObject leftHand = umaData.GetBoneGameObject(leftHandHash);
			GameObject rightHand = umaData.GetBoneGameObject(rightHandHash);
			GameObject leftTwist = umaData.GetBoneGameObject(leftTwistHash);
			GameObject rightTwist = umaData.GetBoneGameObject(rightTwistHash);

			if ((leftHand == null) || (rightHand == null) || (leftTwist == null) || (rightTwist == null))
			{
				Debug.LogError("Failed to add Forearm Twist to: " + umaData.name);
				return;
			}

			var twist = umaData.umaRoot.AddComponent<TwistBones>();
			twist.twistValue = 0.5f;
			twist.twistBone = new Transform[] {leftTwist.transform, rightTwist.transform};
			twist.refBone = new Transform[] {leftHand.transform, rightHand.transform};
			twist.InitializeBoneRotations();
		}
	}
}