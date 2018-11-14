using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTP_BLL
{
    public class LevelManager
    {
        public int Currentevel { get; private set; } = 0;
        public Level CurrentLevelRef;
        public GameManager GameManager { get; private set; }

        public LevelManager(GameManager gameManager)
        {
            this.GameManager = gameManager;
        }

        public void LoadLevel(Level _level)
        {
            CurrentLevelRef = _level;
            CurrentLevelRef.Initialize(GameManager);
        }


    }
}
