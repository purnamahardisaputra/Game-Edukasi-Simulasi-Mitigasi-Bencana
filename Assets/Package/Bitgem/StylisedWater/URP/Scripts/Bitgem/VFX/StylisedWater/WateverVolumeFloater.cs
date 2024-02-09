#region Using statements

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#endregion

namespace Bitgem.VFX.StylisedWater
{
    public class WateverVolumeFloater : MonoBehaviour
    {
        #region Public fields

        public WaterVolumeHelper WaterVolumeHelper;

        #endregion

        #region MonoBehaviour events

        void Update()
        {
            var instance = WaterVolumeHelper ? WaterVolumeHelper : WaterVolumeHelper.Instance;
            if (!instance)
            {
                return;
            }

            try
            {
                transform.position = new Vector3(transform.position.x, instance.GetHeight(transform.position) + 0.5f ?? transform.position.y, transform.position.z);
            }
            catch(NullReferenceException e)
            {

            }

        }

        #endregion
    }
}