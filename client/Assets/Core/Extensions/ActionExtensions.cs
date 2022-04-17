using System;

namespace VortexGames.Core.Extensions
{
    public static class ActionExtensions
    {
        public static void SafeInvoke(this Action action)
        {
            if(action != null)
                action.Invoke();
        }

        public static void SafeInvoke<T0>(this Action<T0> action, T0 arg0)
        {
            if (action != null)
                action.Invoke(arg0);
        }

        public static void SafeInvoke<T0, T1>(this Action<T0,T1> action, T0 arg0, T1 arg1)
        {
            if (action != null)
                action.Invoke(arg0 , arg1);
        }

        public static void SafeInvoke<T0, T1, T2>(this Action<T0, T1, T2> action, T0 arg0, T1 arg1, T2 arg2)
        {
            if (action != null)
                action.Invoke(arg0, arg1, arg2);
        }
    }
}
