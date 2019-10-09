using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public struct Matrix3
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9;
        public Matrix3(float val_1, float val_2, float val_3, float val_4, float val_5, float val_6, float val_7, float val_8, float val_9)
        {
            m1 = 1; m2 = 0; m3 = 0;
            m4 = 0; m5 = 1; m6 = 0;
            m7 = 0; m8 = 0; m9 = 1;
        }
        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(
            lhs.m1 * rhs.m1 + lhs.m2 * rhs.m4 + lhs.m3 * rhs.m7,
            lhs.m1 * rhs.m2 + lhs.m2 * rhs.m5 + lhs.m3 * rhs.m8,
            lhs.m1 * rhs.m3 + lhs.m2 * rhs.m6 + lhs.m3 * rhs.m9,

            lhs.m4 * rhs.m1 + lhs.m5 * rhs.m4 + lhs.m6 * rhs.m7,
            lhs.m4 * rhs.m2 + lhs.m5 * rhs.m5 + lhs.m6 * rhs.m8,
            lhs.m4 * rhs.m3 + lhs.m5 * rhs.m6 + lhs.m6 * rhs.m9,

            lhs.m7 * rhs.m1 + lhs.m8 * rhs.m4 + lhs.m9 * rhs.m7,
            lhs.m7 * rhs.m2 + lhs.m8 * rhs.m5 + lhs.m9 * rhs.m8,
            lhs.m7 * rhs.m3 + lhs.m8 * rhs.m6 + lhs.m9 * rhs.m9);
        }
        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            return new Vector3
               ((lhs.m1 * rhs.x) + (lhs.m2 * rhs.y) + (lhs.m3 * rhs.z),
                (lhs.m4 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m6 * rhs.z),
                (lhs.m7 * rhs.x) + (lhs.m8 * rhs.y) + (lhs.m9 * rhs.z));
        }
        Matrix3 GetTansposed()
        {
            // flip row and column
            return new Matrix3(
           m1, m4, m7,
           m2, m5, m8,
           m3, m6, m9);
        }
        public void Set(float val_1, float val_2, float val_3, float val_4, float val_5, float val_6, float val_7, float val_8, float val_9)
        {
            m1 = val_1; m2 = val_2; m3 = val_3;
            m4 = val_4; m5 = val_5; m6 = val_6;
            m7 = val_7; m8 = val_8; m9 = val_9;
        }
        public void Set(Matrix3 m)
        {
            m1 = m.m1; m2 = m.m2; m3 = m.m3;
            m4 = m.m4; m5 = m.m5; m6 = m.m6;
            m7 = m.m7; m8 = m.m8; m9 = m.m9;
        }

        public void SetRotateX(double radians)
        {
            Set(1, 0, 0,
            0, (float)Math.Cos(radians), (float)Math.Sin(radians),
            0, (float)-Math.Sin(radians), (float)Math.Cos(radians));
        }
        public void RotateX(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateX(radians);
            Set(this * m);
        }

    }
}