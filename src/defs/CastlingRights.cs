namespace chessmag.defs
{
    // 0000 - each bit for one right
    public enum CastlingRights : int
    {
        NONE = 0,
        K = 1,
        Q = 2,
        k = 4,
        q = 8,
        ALL = 15
    }
}