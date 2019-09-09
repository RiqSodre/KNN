using System;
using System.Collections.Generic;
using System.Text;

namespace kNN_Leo
{
    public class Flor
    {
        public string type;
        public Vector2 sepala;
        public Vector2 petala;

        public Flor(string p_type, Vector2 p_sepala, Vector2 p_petala)
        {
            type = p_type;
            sepala = p_sepala;
            petala = p_petala;
        }

        public float Distance(Flor target)
        {
            float x = MathF.Pow(this.sepala.x - target.sepala.x, 2);
            float y = MathF.Pow(this.sepala.y - target.sepala.y, 2);
            float x1 = MathF.Pow(this.petala.x - target.petala.x, 2);
            float y1 = MathF.Pow(this.petala.y - target.petala.y, 2);

            float distance = MathF.Sqrt(x + y + x1 + y1);

            return distance;
        }
    }
}

public class Vector2
{
    public float x;
    public float y;

    public Vector2() { }

    public Vector2(float argx, float argy)
    {
        x = argx;
        y = argy;
    }
}
