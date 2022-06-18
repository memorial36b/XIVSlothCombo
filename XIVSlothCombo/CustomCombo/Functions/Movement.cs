﻿using System.Numerics;

namespace XIVSlothCombo.CustomComboNS.Functions
{
    internal abstract partial class CustomComboFunctions
    {
        protected Vector2 Position { get; set; }
        protected float PlayerSpeed { get; set; }
        protected uint MovingCounter { get; set; }
        public static bool IsMoving { get; set; }

        /// <summary> Checks player movement </summary>
        public void CheckMovement()
        {
            if (MovingCounter == 0)
            {
                Vector2 newPosition = LocalPlayer is null ? Vector2.Zero : new Vector2(LocalPlayer.Position.X, LocalPlayer.Position.Z);
                PlayerSpeed = Vector2.Distance(newPosition, Position);
                IsMoving = PlayerSpeed > 0;
                Position = LocalPlayer is null ? Vector2.Zero : newPosition;
                MovingCounter = 50; // refreshes every 50 dalamud ticks for a more accurate representation of speed, otherwise it'll report 0.
            }

            if (MovingCounter > 0)
                MovingCounter--;
        }
    }
}
