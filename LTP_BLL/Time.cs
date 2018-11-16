using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace LTP_BLL
{
    public static class Time
    {
        public static float DeltaTime { get; private set; }
        public static float GameTimeSinceLaunch { get; private set; }
        private static Clock TimeClock;
        private static float timeAtLastFrame;
        public static float TimeScale = 1;
        public static float FixedDeltaTime;
        public static float FixedTimeStep;

        public static void InitTime()
        {
            TimeClock = new Clock();

            FixedTimeStep = 1f / 60f;
            FixedDeltaTime = 1f/60f;
            timeAtLastFrame = 0;
            GameTimeSinceLaunch = 0;
        }
        public static void UpdateTime()
        {
            GameTimeSinceLaunch = TimeClock.ElapsedTime.AsSeconds();
            DeltaTime = (GameTimeSinceLaunch - timeAtLastFrame) * TimeScale;
            timeAtLastFrame = GameTimeSinceLaunch;

        }

    }
}
