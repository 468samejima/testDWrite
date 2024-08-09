using System.Numerics;
using System.Collections.Generic;
using Windows.UI;

namespace DirectN.WinUI3.testDWrite
{
    public class DWStrings : List<DWString>
    {
        public DWStrings() { }
    }

    public class DWString
    {
        // members
        public string Str;              // 文字列
        public Vector2 Pos;             // 配置点
        public int Height;              // 文字高さ
        public int Anchor;              // 配置位置
        public string FontFace;         // フォント名
        public DWRITE_FONT_WEIGHT FontWeight;       // フォントウェイト
        public float Ang;              // 傾き
        public double Scale;            // 配置スケール
        //public double Aspect;           // アスペクト比
        //public double Pitch;            // 文字ピッチ
        //public double LinePitch;        // 行間隔
        //public int Orientation;         // 文字向き
        //public double Slant;            // スラント角
        //public T2_Grp Vect;             // ベクター展開用

        public bool IsItalic;
        public bool HasUnderline;
        public bool IsStruckout;

        public Color FontColor;


        public DWString()
        {

            Str = "";
            Pos = new();
            Height = 0;
            Anchor = 0;
            FontFace = "ARIAL";
            FontWeight = DWRITE_FONT_WEIGHT.DWRITE_FONT_WEIGHT_NORMAL;
            Ang = 0;
            Scale = 1;
            //Aspect = 0;
            //Pitch = 0;
            //LinePitch = 0;
            //Orientation = 0;
            //Slant = 0;
            //Vect = new();
            //FStrLineCount = 0;
            IsItalic = false;
            HasUnderline = false;
            IsStruckout = false;

            FontColor = new();
        }
    }
}
