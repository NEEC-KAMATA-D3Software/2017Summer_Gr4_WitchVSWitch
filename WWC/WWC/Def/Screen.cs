using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WWC.Def
{
    /// <summary>
    /// スクリーンクラス
    /// </summary>
    static class Screen
    {
        //スクリーンサイズ
        public static readonly int Width = 540;　//横
        public static readonly int Height = 720;　//縦
        // 9:16 540 X 720 
        // 16:9 1280 X 720、960 X 540
        // 4:3 1024 X 768
    }
}
