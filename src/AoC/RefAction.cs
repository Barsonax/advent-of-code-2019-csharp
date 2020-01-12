namespace AoC
{
    delegate void RefAction<T1>(ref T1 p1);
    delegate void RefAction<T1, T2>(ref T1 p1, ref T2 p2);
    delegate void RefAction<T1, T2, T3>(ref T1 p1, ref T2 p2, ref T3 p3);
}